using System.IO;
using System.Text.Json;
using SMSManager.Objetos.Modelos;

namespace SMSManager.Logica.Utilidades
{
    /// <summary>
    /// Servicio de utilidad para persistir y recuperar la configuración de conexión con la API Traccar.
    /// </summary>
    public static class ConfiguracionService
    {
        /// <summary>
        /// Ruta local del archivo de configuración.
        /// </summary>
        private static string ruta = "config.json";

        /// <summary>
        /// Guarda la configuración actual (IP, puerto, token) en un archivo local.
        /// </summary>
        public static void Guardar(ApiConfig config)
        {
            string json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ruta, json);
        }

        /// <summary>
        /// Carga la configuración de conexión desde un archivo JSON local (config.json).
        /// Si el archivo no existe o hay error, devuelve una configuración vacía.
        /// </summary>
        public static ApiConfig Cargar()
        {
            if (!File.Exists(ruta))
            {
                return new ApiConfig();
            }

            string json = File.ReadAllText(ruta);
            return JsonSerializer.Deserialize<ApiConfig>(json);
        }
    }
}

