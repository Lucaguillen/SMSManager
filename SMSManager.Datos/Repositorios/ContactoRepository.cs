using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using SMSManager.Objetos.Modelos;
using SMSManager.Datos.Database;


namespace SMSManager.Datos.Repositorios
{
    /// <summary>
    /// Repositorio encargado de realizar operaciones CRUD sobre la tabla Contactos.
    /// </summary>
    public class ContactoRepository
    {
        /// <summary>
        /// Inserta un nuevo contacto en la base de datos.
        /// </summary>
        public void Insertar(Contacto contacto)
        {
            using var connection = DatabaseManager.ObtenerConexion();


            using var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Contactos (Nombre, Apellido, Telefono, Cedula, Matricula, Seudonimo, Fecha, Hora)
                VALUES (@Nombre, @Apellido, @Telefono, @Cedula, @Matricula, @Seudonimo, @Fecha, @Hora);";


            command.Parameters.AddWithValue("@Nombre", contacto.Nombre);
            command.Parameters.AddWithValue("@Apellido", contacto.Apellido);
            command.Parameters.AddWithValue("@Telefono", contacto.Telefono);
            command.Parameters.AddWithValue("@Cedula", contacto.Cedula);
            command.Parameters.AddWithValue("@Matricula", contacto.Matricula);
            command.Parameters.AddWithValue("@Seudonimo", contacto.Seudonimo);
            command.Parameters.AddWithValue("@Fecha", contacto.Fecha);
            command.Parameters.AddWithValue("@Hora", contacto.Hora);


            command.ExecuteNonQuery();
        }
        /// <summary>
        /// Verifica si ya existe un contacto con la cédula proporcionada.
        /// </summary>
        public bool ExisteCedula(string cedula)
        {
            return ExisteCampo("Cedula", cedula);
        }
        /// <summary>
        /// Verifica si ya existe un contacto con el número de teléfono proporcionado.
        /// </summary>
        public bool ExisteTelefono(string telefono)
        {
            return ExisteCampo("Telefono", telefono);
        }
        /// <summary>
        /// Verifica si ya existe un contacto con la matrícula proporcionada.
        /// </summary>
        public bool ExisteMatricula(string matricula)
        {
            return ExisteCampo("Matricula", matricula);
        }

        /// <summary>
        /// Verifica si ya existe un contacto con el seudónimo proporcionado.
        /// </summary>
        public bool ExisteSeudonimo(string seudonimo)
        {
            return ExisteCampo("Seudonimo", seudonimo);
        }

        /// <summary>
        /// Verifica si ya existe un valor determinado en un campo específico de la tabla Contactos.
        /// </summary>
        private bool ExisteCampo(string campo, string valor)
        {
            using var connection = DatabaseManager.ObtenerConexion();
            using var command = connection.CreateCommand();
            command.CommandText = $"SELECT COUNT(1) FROM Contactos WHERE {campo} = @Valor";
            command.Parameters.AddWithValue("@Valor", valor ?? "");

            var count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }

    }
}
