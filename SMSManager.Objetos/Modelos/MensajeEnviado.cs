using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSManager.Objetos.Modelos
{
    /// <summary>
    /// Representa un registro histórico de un mensaje que fue enviado (o se intentó enviar).
    /// Almacena información sobre el destinatario, contenido del mensaje, estado y fecha.
    /// </summary>
    public class MensajeEnviado
    {
        /// <summary>
        /// Identificador único del mensaje registrado.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Número de teléfono del destinatario.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Seudónimo o alias del destinatario, si está disponible.
        /// </summary>
        public string Seudonimo { get; set; }

        /// <summary>
        /// Contenido completo del mensaje enviado.
        /// </summary>
        public string Contenido { get; set; }

        /// <summary>
        /// Estado del envío: "Enviado", "Error", etc.
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Fecha y hora en que se realizó (o intentó) el envío del mensaje.
        /// </summary>
        public DateTime FechaHora { get; set; }
    }
}
