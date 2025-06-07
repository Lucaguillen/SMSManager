using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSManager.Objetos.Modelos
{
    /// <summary>
    /// Representa la configuración necesaria para conectarse con la API Traccar SMS Gateway.
    /// Contiene los parámetros de conexión: IP, Puerto y Token de autenticación.
    /// </summary>
    public class ApiConfig
    {
        /// <summary>
        /// Dirección IP del dispositivo Android donde está ejecutándose Traccar SMS Gateway.
        /// Ejemplo: "192.168.1.100"
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// Puerto configurado en la aplicación Traccar para recibir solicitudes HTTP.
        /// Por defecto suele ser "8082".
        /// </summary>
        public string Puerto { get; set; }

        /// <summary>
        /// Token de autenticación generado por la aplicación Traccar.
        /// Se utiliza para autorizar el envío de SMS desde la API.
        /// </summary>
        public string Token { get; set; }
    }
}
