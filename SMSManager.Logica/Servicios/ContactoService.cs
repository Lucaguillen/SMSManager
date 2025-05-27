using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SMSManager.Datos.Database;
using SMSManager.Datos.Repositorios;
using SMSManager.Logica.Utilidades;
using SMSManager.Objetos.Modelos;
using SMSManager.Objetos.Resultados;
using SMSManager.Utilidades.Logging;

namespace SMSManager.Logica.Servicios
{
    public class ContactoService
    {
        private readonly ContactoRepository contactoRepository;

        public ContactoService()
        {
            contactoRepository = new ContactoRepository();
        }

        public ResultadoImportacion ImportarDesdeCsv(string rutaArchivo)
        {
            var resultado = new ResultadoImportacion();
            List<Contacto> contactos = CsvUtils.LeerContactosDesdeCsv(rutaArchivo);

            foreach (var contacto in contactos)
            {
                if (!EsContactoValido(contacto))
                {
                    resultado.ContactosFallidos++;
                    resultado.Errores.Add($"Contacto inválido: {contacto.Nombre} {contacto.Apellido} (faltan campos obligatorios)");
                    continue;
                }
                if (!EsTelefonoValido(contacto)) {
                    resultado.ContactosFallidos++;
                    resultado.Errores.Add($"Contacto inválido: {contacto.Nombre} {contacto.Apellido} (El numero de telefono debe tener exactamente 9 digitos)");
                    continue;
                }

                if (YaExisteMat(contacto))
                {
                    resultado.ContactosFallidos++;
                    resultado.Errores.Add($"Duplicado: {contacto.Nombre} {contacto.Apellido} (Matricula ya existe)");
                    continue;
                }
                if (YaExisteCedula(contacto))
                {
                    resultado.ContactosFallidos++;
                    resultado.Errores.Add($"Duplicado: {contacto.Nombre} {contacto.Apellido} (cédula ya existe)");
                    continue;
                }
                if (YaExisteTel(contacto))
                {
                    resultado.ContactosFallidos++;
                    resultado.Errores.Add($"Duplicado: {contacto.Nombre} {contacto.Apellido} (teléfono ya existe)");
                    continue;
                }
                if (YaExisteSeu(contacto))
                {
                    resultado.ContactosFallidos++;
                    resultado.Errores.Add($"Duplicado: {contacto.Nombre} {contacto.Apellido} (Seudonimo ya existe)");
                    continue;
                }

                contactoRepository.Insertar(contacto);
                resultado.ContactosImportados++;
            }

            return resultado;
        }

        private bool EsContactoValido(Contacto contacto)
        {
            return !string.IsNullOrWhiteSpace(contacto.Seudonimo) &&
                   !string.IsNullOrWhiteSpace(contacto.Telefono);
        }
        private bool EsTelefonoValido(Contacto contacto)
        {
            return contacto.Telefono.All(char.IsDigit) &&
                   contacto.Telefono.Length == 9;
        }
         
                   

        private bool YaExisteCedula(Contacto contacto)
        {
            return contactoRepository.ExisteCedula(contacto.Cedula);
        }
        private bool YaExisteTel(Contacto contacto)
        {
            return contactoRepository.ExisteTelefono(contacto.Telefono);

        }
        private bool YaExisteMat(Contacto contacto)
        {
            return contactoRepository.ExisteMatricula(contacto.Matricula);
        }
        private bool YaExisteSeu(Contacto contacto)
        {
            return contactoRepository.ExisteSeudonimo(contacto.Seudonimo);
        }

        public List<Contacto> ObtenerTodos()
        {
            var listaContactos = new List<Contacto>();

            try
            {
                using (var connection = DatabaseManager.ObtenerConexion())
                {
                    var command = new SQLiteCommand("SELECT Id, Nombre, Apellido, Telefono, Cedula, Matricula, Seudonimo, Fecha, Hora FROM Contactos", connection);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaContactos.Add(new Contacto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nombre = reader["Nombre"].ToString() ?? string.Empty,
                                Apellido = reader["Apellido"].ToString() ?? string.Empty,
                                Telefono = reader["Telefono"].ToString() ?? string.Empty,
                                Cedula = reader["Cedula"].ToString() ?? string.Empty,
                                Matricula = reader["Matricula"].ToString() ?? string.Empty,
                                Seudonimo = reader["Seudonimo"].ToString() ?? string.Empty,
                                Fecha = reader["Fecha"].ToString() ?? string.Empty,
                                Hora = reader["Hora"].ToString() ?? string.Empty

                            });
                        }
                    }
                }
                Logger.LogInfo("Contactos obtenidos correctamente.");   
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al obtener los contactos: {ex.Message} - {ex.StackTrace}"); 
                throw new Exception("Error al obtener los contactos.", ex);
            }

            return listaContactos;
        }

        public void Agregar(Contacto contacto)
        {
            try
            {
                using (var connection = DatabaseManager.ObtenerConexion())
                {
                    var command = new SQLiteCommand("INSERT INTO Contactos (Nombre, Apellido, Telefono, Cedula, Matricula, Seudonimo, Fecha, Hora) VALUES (@Nombre, @Apellido, @Telefono, @Cedula, @Matricula, @Seudonimo, @Fecha, @Hora)", connection);
                    command.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                    command.Parameters.AddWithValue("@Apellido", contacto.Apellido);
                    command.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    command.Parameters.AddWithValue("@Cedula", string.IsNullOrWhiteSpace(contacto.Cedula) ? DBNull.Value : contacto.Cedula);
                    command.Parameters.AddWithValue("@Matricula", string.IsNullOrWhiteSpace(contacto.Matricula) ? DBNull.Value : contacto.Matricula);
                    command.Parameters.AddWithValue("@Seudonimo", contacto.Seudonimo);
                    command.Parameters.AddWithValue("@Fecha", contacto.Fecha);
                    command.Parameters.AddWithValue("@Hora", contacto.Hora);



                    command.ExecuteNonQuery();
                    
                }
                Logger.LogInfo($"Contacto {contacto.Nombre} agregado correctamente.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al agregar el contacto: {ex.Message} - {ex.StackTrace}");
                throw new Exception("Error al agregar un nuevo contacto.", ex);
            }
        }

        public void Actualizar(Contacto contacto)
        {
            try
            {
                using (var connection = DatabaseManager.ObtenerConexion())
                {
                    var command = new SQLiteCommand("UPDATE Contactos SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, Cedula = @Cedula, Matricula = @Matricula, Seudonimo = @Seudonimo, Fecha = @Fecha, Hora = @Hora WHERE Id = @Id", connection);

                    command.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                    command.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    command.Parameters.AddWithValue("@Cedula", contacto.Cedula ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Apellido", contacto.Apellido);
                    command.Parameters.AddWithValue("@Matricula", string.IsNullOrWhiteSpace(contacto.Matricula) ? DBNull.Value : contacto.Matricula);
                    command.Parameters.AddWithValue("@Seudonimo", contacto.Seudonimo);
                    command.Parameters.AddWithValue("@Fecha", contacto.Fecha);
                    command.Parameters.AddWithValue("@Hora", contacto.Hora);

                    command.Parameters.AddWithValue("@Id", contacto.Id);

                    command.ExecuteNonQuery();
                }
                Logger.LogInfo($"Contacto {contacto.Nombre} actualizado correctamente.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al actualizar el contacto en el servicio: {ex.Message} - {ex.StackTrace}");    
                throw new Exception("Error al actualizar el contacto.", ex);
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                using (var connection = DatabaseManager.ObtenerConexion())
                {
                    var command = new SQLiteCommand("DELETE FROM Contactos WHERE Id = @Id", connection);
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
                Logger.LogInfo($"Contacto con ID {id} eliminado correctamente.");
            }
            catch (Exception ex)
            {

                Logger.LogError($"Error al eliminar el contacto con ID {id}: {ex.Message} - {ex.StackTrace}");
                throw new Exception("Error al eliminar el contacto.", ex);
            }
        }

        public void EliminarTodosLosContactos() {
            try
            {
                using (var connection = DatabaseManager.ObtenerConexion())
                {
                    var command = new SQLiteCommand("DELETE FROM Contactos" , connection);

                    command.ExecuteNonQuery();
                }
                Logger.LogInfo($"Todos los Contactos eliminados correctamente.");
            }
            catch (Exception ex)
            {

                Logger.LogError($"Error al eliminar todos los contactos: {ex.Message} - {ex.StackTrace}");
                throw new Exception("Error al eliminar todos los contactos .", ex);
            }
        }


    }
}
