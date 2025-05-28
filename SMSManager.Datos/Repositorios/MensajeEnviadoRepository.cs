using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SMSManager.Objetos.Modelos;

namespace SMSManager.Datos.Repositorios
{
    public class MensajeEnviadoRepository
    {
        private readonly string _cadenaConexion = "Data Source=smsmanager.db;Version=3;";

        public void Insertar(MensajeEnviado mensaje)
        {
            using var conexion = new SQLiteConnection(_cadenaConexion);
            conexion.Open();

            var comando = new SQLiteCommand("INSERT INTO MensajesEnviados (Telefono, Seudonimo, Contenido, Estado, FechaHora) VALUES (@telefono, @seudonimo, @contenido, @estado, @fechaHora)", conexion);
            comando.Parameters.AddWithValue("@telefono", mensaje.Telefono);
            comando.Parameters.AddWithValue("@seudonimo", mensaje.Seudonimo);
            comando.Parameters.AddWithValue("@contenido", mensaje.Contenido);
            comando.Parameters.AddWithValue("@estado", mensaje.Estado);
            comando.Parameters.AddWithValue("@fechaHora", mensaje.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"));

            comando.ExecuteNonQuery();
        }

        public List<MensajeEnviado> ObtenerTodos()
        {
            var lista = new List<MensajeEnviado>();

            using var conexion = new SQLiteConnection(_cadenaConexion);
            conexion.Open();

            var comando = new SQLiteCommand("SELECT * FROM MensajesEnviados ORDER BY FechaHora DESC", conexion);
            using var lector = comando.ExecuteReader();

            while (lector.Read())
            {
                lista.Add(new MensajeEnviado
                {
                    Id = Convert.ToInt32(lector["Id"]),
                    Telefono = lector["Telefono"].ToString(),
                    Seudonimo = lector["Seudonimo"].ToString(),
                    Contenido = lector["Contenido"].ToString(),
                    Estado = lector["Estado"].ToString(),
                    FechaHora = DateTime.Parse(lector["FechaHora"].ToString())
                });
            }

            return lista;
        }
    }
}
