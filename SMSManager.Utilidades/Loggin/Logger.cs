using System;
using System.IO;

namespace SMSManager.Utilidades.Logging
{
    public static class Logger
    {
        private static readonly string _logFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        public static void LogInfo(string mensaje)
        {
            Log(mensaje, "INFO");
        }

        public static void LogError(string mensaje)
        {
            Log(mensaje, "ERROR");
        }

        public static void LogDebug(string mensaje)
        {
            Log(mensaje, "DEBUG");
        }

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
