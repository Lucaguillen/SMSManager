using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSManager.Objetos.Resultados
{
    /// <summary>
    /// Representa el resultado de un proceso de importación de contactos desde un archivo.
    /// Incluye la cantidad de contactos importados correctamente, los fallidos y una lista de errores descriptivos.
    /// </summary>
    public class ResultadoImportacion
    {
        /// <summary>
        /// Cantidad de contactos que fueron importados exitosamente.
        /// </summary>
        public int ContactosImportados { get; set; }

        /// <summary>
        /// Cantidad de contactos que no pudieron importarse por errores de validación.
        /// </summary>
        public int ContactosFallidos { get; set; }

        /// <summary>
        /// Lista de descripciones de errores detectados durante la importación.
        /// </summary>
        public List<string> Errores { get; set; } = new();
    }

}
