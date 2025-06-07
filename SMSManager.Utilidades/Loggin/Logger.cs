using System;
using System.IO;

namespace SMSManager.Utilidades.Logging
{
    /// <summary>
    /// Clase utilitaria estática para registrar mensajes de log en archivos de texto.
    /// Los mensajes se guardan en archivos diarios dentro de la carpeta "Logs".
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Ruta a la carpeta donde se almacenan los archivos de log.
        /// </summary>
        private static readonly string _logFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        /// <summary>
        /// Registra un mensaje informativo en el archivo de log.
        /// </summary>
        public static void LogInfo(string mensaje)
        {
            Log(mensaje, "INFO");
        }

        /// <summary>
        /// Registra un mensaje de error en el archivo de log.
        /// </summary>
        public static void LogError(string mensaje)
        {
            Log(mensaje, "ERROR");
        }

        /// <summary>
        /// Registra un mensaje de depuración en el archivo de log.
        /// </summary>
        public static void LogDebug(string mensaje)
        {
            Log(mensaje, "DEBUG");
        }

        /// <summary>
        /// Método privado que gestiona el formateo y escritura del mensaje en el archivo correspondiente.
        /// Crea la carpeta si no existe, y no lanza excepción si falla el log para evitar romper la aplicación.
        /// </summary>
        private static void Log(string mensaje, string tipo)
        {
            try
            {
                if (!Directory.Exists(_logFolderPath))
                {
                    Directory.CreateDirectory(_logFolderPath);
                }

                string fechaActual = DateTime.Now.ToString("dd-MM-yyyy"); // 👈 día-mes-año
                string logFilePath = Path.Combine(_logFolderPath, $"Log_{fechaActual}.txt");

                string mensajeFinal = $"{DateTime.Now:dd-MM-yyyy HH:mm:ss} [{tipo}] {mensaje}"; // 👈 día-mes-año hora:minuto:segundo

                File.AppendAllText(logFilePath, mensajeFinal + Environment.NewLine);
            }
            catch
            {
                // No romper la aplicación si el log falla
            }
        }
    }
}
