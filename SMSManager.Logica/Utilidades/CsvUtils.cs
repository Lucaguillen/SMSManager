using CsvHelper;
using CsvHelper.Configuration;
using SMSManager.Objetos.Modelos;
using SMSManager.Utilidades.Logging;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;

namespace SMSManager.Logica.Utilidades
{
    /// <summary>
    /// Clase utilitaria para operaciones relacionadas con archivos CSV.
    /// Permite leer contactos desde CSV y limpiar datos antes de procesarlos.
    /// </summary>
    public static class CsvUtils
    {
        /// <summary>
        /// Lee un archivo CSV desde la ruta proporcionada y lo convierte en una lista de objetos Contacto.
        /// </summary>
        public static List<Contacto> LeerContactosDesdeCsv(string rutaArchivo)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                HeaderValidated = null,
                Delimiter = ",", 
                IgnoreBlankLines = true
            };

            using var reader = new StreamReader(rutaArchivo);
            using var csv = new CsvReader(reader, config);

            var contactos = new List<Contacto>();
            try
            {
                contactos = new List<Contacto>(csv.GetRecords<Contacto>());
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al leer los contactos desde el csv: {ex.Message} - {ex.StackTrace}");
                throw new Exception("Error al obtener los contactos desde el csv.", ex);
            }

            return contactos;
        }
    }
}
