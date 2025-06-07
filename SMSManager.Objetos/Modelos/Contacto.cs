

namespace SMSManager.Objetos.Modelos
{
    /// <summary>
    /// Representa un contacto individual con información personal y de envío.
    /// Usado para construir los destinatarios de los mensajes SMS.
    /// </summary>
    public class Contacto
    {
        /// <summary>
        /// Identificador único del contacto (clave primaria en base de datos).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del contacto.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Apellido del contacto.
        /// </summary>
        public string Apellido { get; set; } = string.Empty;

        /// <summary>
        /// Número de teléfono asociado al contacto 9 digitos obligatoiros (099999999).
        /// </summary>
        public string Telefono { get; set; } = string.Empty;

        /// <summary>
        /// Cédula de identidad del contacto (formato nacional).
        /// </summary>
        public string Cedula { get; set; } = string.Empty;

        /// <summary>
        /// Matrícula asociada (si aplica).
        /// </summary>
        public string? Matricula { get; set; }

        /// <summary>
        /// Seudónimo o apodo para el contacto.
        /// </summary>
        public string Seudonimo { get; set; } = string.Empty;

        /// <summary>
        /// Indica si el contacto fue marcado como seleccionado para envío.
        /// </summary>
        public bool Seleccionado { get; set; } = false;

        /// <summary>
        /// Fecha de alta o carga del contacto (en formato string).
        /// </summary>
        public string Fecha { get; set; } = string.Empty;

        /// <summary>
        /// Hora de carga o registro del contacto (en formato string).
        /// </summary>
        public string Hora { get; set; } = string.Empty;
    }
}
