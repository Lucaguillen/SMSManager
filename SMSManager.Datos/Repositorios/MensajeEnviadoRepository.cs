using System;
using System.Collections.Generic;
using System.Data.SQLite;
using SMSManager.Objetos.Modelos;

namespace SMSManager.Datos.Repositorios
{
    /// <summary>
    /// Repositorio responsable de registrar y consultar mensajes enviados en la base de datos.
    /// </summary>
    public class MensajeEnviadoRepository
    {
        /// <summary>
        /// Cadena de conexión SQLite utilizada para acceder a la base de datos local del sistema.
        /// </summary>
        private readonly string _cadenaConexion = "Data Source=smsmanager.db;Version=3;";

        /// <summary>
        /// Inserta un mensaje enviado en la base de datos como registro histórico.
        /// </summary>
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

        /// <summary>
        /// Devuelve la lista de todos los mensajes enviados registrados en la base de datos.
        /// </summary>
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
