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
    public  class ContactoRepository
    {
        public  void Insertar(Contacto contacto)
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

        public  bool ExisteCedula(string cedula)
        {
            return ExisteCampo("Cedula", cedula);
        }

        public  bool ExisteTelefono(string telefono)
        {
            return ExisteCampo("Telefono", telefono);
        }

        public  bool ExisteMatricula(string matricula)
        {
            return ExisteCampo("Matricula", matricula);
        }
        public bool ExisteSeudonimo(string seudonimo)
        {
            return ExisteCampo("Seudonimo", seudonimo);
        }

        private  bool ExisteCampo(string campo, string valor)
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
