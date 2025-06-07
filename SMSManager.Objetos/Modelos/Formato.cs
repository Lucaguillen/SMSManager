using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

using System;

namespace SMSManager.Objetos.Modelos
{
    /// <summary>
    /// Representa un formato o plantilla de mensaje SMS.
    /// Contiene un nombre identificador y el cuerpo del mensaje,
    /// que puede incluir variables dinámicas como {nombre}, {fecha}, etc.
    /// </summary>
    public class Formato
    {
        /// <summary>
        /// Identificador único del formato.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre descriptivo del formato, utilizado para identificarlo en la interfaz.
        /// </summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Texto del mensaje que será enviado. Puede contener placeholders reemplazables.
        /// </summary>
        public string Cuerpo { get; set; } = string.Empty;
    }
}



