using System;

namespace SMSManager.Objetos.Modelos
{
    public class Envio
    {
        public int Id { get; set; }
        public int ContactoId { get; set; }
        public int PlantillaId { get; set; }
        public DateTime? FechaHoraEnvio { get; set; } // Puede ser null si aún no fue enviado
        public string MensajeFinal { get; set; } = string.Empty;
        public string EstadoEnvio { get; set; } = "Pendiente"; // Por defecto
        public string ErrorMensaje { get; set; } = string.Empty;
    }
}
