using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSManager.Objetos.Modelos
{
    public class MensajeEnviado
    {
        public int Id { get; set; }
        public string Telefono { get; set; }
        public string Seudonimo { get; set; }
        public string Contenido { get; set; }
        public string Estado { get; set; }
        public DateTime FechaHora { get; set; }
    }

}
