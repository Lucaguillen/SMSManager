

namespace SMSManager.Objetos.Modelos
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty; 
        public string Telefono { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string? Matricula { get; set; }
        public string Seudonimo { get; set; } = string.Empty;
        public bool Seleccionado { get; set; } = false;
        public string Fecha { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;



    }
}
