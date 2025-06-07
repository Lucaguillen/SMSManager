using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSManager.Logica.Servicios;

namespace SMSManager.Logica.Utilidades
{
    /// <summary>
    /// Funciones utilitarias generales utilizadas por la lógica de negocio para validación de datos.
    /// </summary>
    public static class UtilidadesLogica
    {
        /// <summary>
        /// Verifica si ya existe un contacto con la matrícula especificada.
        /// </summary>
        public static bool ExisteMatricula(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula)) return false;

            ContactoService service = new ContactoService();
            return service.ObtenerTodos().Any(c => c.Matricula == matricula);
        }
        /// <summary>
        /// Verifica si ya existe un contacto con el seudónimo especificado.
        /// </summary>
        public static bool ExisteSeudonimo(string seudo)
        {
            if (string.IsNullOrWhiteSpace(seudo)) return false;

            ContactoService service = new ContactoService();
            return service.ObtenerTodos().Any(c => c.Seudonimo == seudo);
        }
        /// <summary>
        /// Verifica si ya existe un contacto con la cédula especificada.
        /// </summary>
        public static bool ExisteCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula)) return false;

            ContactoService service = new ContactoService();
            return service.ObtenerTodos().Any(c => c.Cedula == cedula);
        }
        /// <summary>
        /// Verifica si ya existe un contacto con el número de teléfono especificado.
        /// </summary>
        public static bool ExisteTelefono(string tel)
        {
            if (string.IsNullOrWhiteSpace(tel)) return false;

            ContactoService service = new ContactoService();
            return service.ObtenerTodos().Any(c => c.Telefono == tel);
        }
    }
}
