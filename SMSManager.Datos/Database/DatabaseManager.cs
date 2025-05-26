using System;
using System.Data.SQLite;
using System.IO;
using SMSManager.Utilidades.Logging;

namespace SMSManager.Datos.Database
{
    public static class DatabaseManager
    {
        private static readonly string _dbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SMSManager.db");
        private static readonly string _connectionString = $"Data Source={_dbFilePath};Version=3;";

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
                    Seudonimo TEXT NOT NULL
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

        public static SQLiteConnection ObtenerConexion()
        {
            var connection = new SQLiteConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
