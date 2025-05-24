using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SMSManager.Datos.Database;
using SMSManager.Objetos.Modelos;
using SMSManager.Utilidades.Logging;

namespace SMSManager.Logica.Servicios
{
    public class ContactoService
    {
        public List<Contacto> ObtenerTodos()
        {
            var listaContactos = new List<Contacto>();

            try
            {
                using (var connection = DatabaseManager.ObtenerConexion())
                {
                    var command = new SQLiteCommand("SELECT Id, Nombre, Apellido, Telefono, Cedula, Matricula FROM Contactos", connection);
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
                                Matricula = reader["Matricula"].ToString() ?? string.Empty

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
                    var command = new SQLiteCommand("INSERT INTO Contactos (Nombre, Apellido, Telefono, Cedula, Matricula) VALUES (@Nombre, @Apellido, @Telefono, @Cedula, @Matricula)", connection);
                    command.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                    command.Parameters.AddWithValue("@Apellido", contacto.Apellido);
                    command.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    command.Parameters.AddWithValue("@Cedula", string.IsNullOrWhiteSpace(contacto.Cedula) ? DBNull.Value : contacto.Cedula);
                    command.Parameters.AddWithValue("@Matricula", string.IsNullOrWhiteSpace(contacto.Matricula) ? DBNull.Value : contacto.Matricula);



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
                    var command = new SQLiteCommand("UPDATE Contactos SET Nombre = @Nombre, Apellido = @Apellido, Telefono = @Telefono, Cedula = @Cedula, Matricula = @Matricula WHERE Id = @Id", connection);

                    command.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                    command.Parameters.AddWithValue("@Telefono", contacto.Telefono);
                    command.Parameters.AddWithValue("@Cedula", contacto.Cedula ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Apellido", contacto.Apellido);
                    command.Parameters.AddWithValue("@Matricula", string.IsNullOrWhiteSpace(contacto.Matricula) ? DBNull.Value : contacto.Matricula);

                    command.Parameters.AddWithValue("@Id", contacto.Id);

                    command.ExecuteNonQuery();
                }
                Logger.LogInfo($"Contacto {contacto.Nombre} actualizado correctamente.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al actualizar el contacto: {ex.Message} - {ex.StackTrace}");    
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


    }
}
