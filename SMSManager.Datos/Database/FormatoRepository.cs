using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SMSManager.Objetos.Modelos;
using SMSManager.Datos.Database;

namespace SMSManager.Datos.Repositorios
{
    public class FormatoRepository
    {
        public void Actualizar(Formato formato)
        {
            using var connection = DatabaseManager.ObtenerConexion();
            using var command = connection.CreateCommand();

            command.CommandText = "UPDATE Formatos SET Cuerpo = @Cuerpo WHERE Nombre = @Nombre";
            command.Parameters.AddWithValue("@Cuerpo", formato.Cuerpo);
            command.Parameters.AddWithValue("@Nombre", formato.Nombre);

            command.ExecuteNonQuery();
        }

        public void Insertar(Formato formato)
        {
            using var connection = DatabaseManager.ObtenerConexion();
            using var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO Formatos (Nombre, Cuerpo)
                VALUES (@Nombre, @Cuerpo);";

            command.Parameters.AddWithValue("@Nombre", formato.Nombre);
            command.Parameters.AddWithValue("@Cuerpo", formato.Cuerpo);

            command.ExecuteNonQuery();
        }

        public bool ExisteNombre(string nombre)
        {
            using var connection = DatabaseManager.ObtenerConexion();
            using var command = connection.CreateCommand();

            command.CommandText = "SELECT COUNT(1) FROM Formatos WHERE Nombre = @Nombre";
            command.Parameters.AddWithValue("@Nombre", nombre);

            var count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }
        public List<Formato> ObtenerTodos()
        {
            var lista = new List<Formato>();

            using var connection = DatabaseManager.ObtenerConexion();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Nombre, Cuerpo FROM Formatos";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Formato
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Cuerpo = reader.GetString(2)
                });
            }

            return lista;
        }

        public void Eliminar(int id)
        {
            using var connection = DatabaseManager.ObtenerConexion();
            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Formatos WHERE Id = @Id";
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }
    }
}
