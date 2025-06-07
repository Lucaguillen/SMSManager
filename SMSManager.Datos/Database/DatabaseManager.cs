using System;
using System.Data.SQLite;
using System.IO;
using SMSManager.Utilidades.Logging;

namespace SMSManager.Datos.Database
{
    /// <summary>
    /// Clase estática responsable de la inicialización y gestión básica de la base de datos SQLite.
    /// Maneja la creación del archivo y las tablas necesarias para el funcionamiento del sistema.
    /// </summary>
    public static class DatabaseManager
    {
        /// <summary>
        /// Ruta completa al archivo físico de la base de datos SQLite.
        /// </summary>
        private static readonly string _dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SMSManager.db");

        /// <summary>
        /// Cadena de conexión utilizada para acceder a la base de datos.
        /// </summary>
        private static readonly string _connectionString = $"Data Source={_dbFilePath};Version=3;";

        /// <summary>
        /// Inicializa la base de datos:
        /// - Crea el archivo .db si no existe.
        /// - Establece conexión.
        /// - Crea las tablas necesarias si no existen.
        /// </summary>
        public static void InicializarBaseDeDatos()
        {
            try
            {
                if (!File.Exists(_dbFilePath))
                {
                    SQLiteConnection.CreateFile(_dbFilePath);
                }

                using (var connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    CrearTablasSiNoExisten(connection);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al inicializar la base de datos: {ex.Message} - {ex.StackTrace}");  
                throw new Exception("Error al inicializar la base de datos.", ex);
            }
        }
        /// <summary>
        /// Crea las tablas necesarias en la base de datos si aún no existen.
        /// Ejecuta múltiples sentencias CREATE TABLE IF NOT EXISTS.
        /// </summary>
        private static void CrearTablasSiNoExisten(SQLiteConnection connection)
        {
            var command = connection.CreateCommand();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Contactos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT,
                    Apellido TEXT,
                    Telefono TEXT NOT NULL,
                    Cedula TEXT,
                    Matricula TEXT,
                    Seudonimo TEXT NOT NULL,
                    Fecha TEXT,
                    Hora TEXT
                );

                CREATE TABLE IF NOT EXISTS MensajesEnviados (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Telefono TEXT,
                    Seudonimo TEXT,
                    Contenido TEXT,
                    Estado TEXT,
                    FechaHora TEXT
                );

                CREATE TABLE IF NOT EXISTS Formatos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL UNIQUE,
                    Cuerpo TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Plantillas (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    CuerpoMensaje TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Envios (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ContactoId INTEGER NOT NULL,
                    PlantillaId INTEGER NOT NULL,
                    FechaHoraEnvio DATETIME,
                    MensajeFinal TEXT,
                    EstadoEnvio TEXT,
                    ErrorMensaje TEXT,
                    FOREIGN KEY (ContactoId) REFERENCES Contactos(Id),
                    FOREIGN KEY (PlantillaId) REFERENCES Plantillas(Id)
                );
            ";

            command.ExecuteNonQuery();
        }
        /// <summary>
        /// Obtiene una nueva conexión abierta a la base de datos SQLite.
        /// El llamador es responsable de cerrarla cuando termine de usarla.
        /// </summary>
        public static SQLiteConnection ObtenerConexion()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
