using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSManager.Logica.Servicios;

namespace SMSManager.Logica.Utilidades
{
    public static class UtilidadesLogica
    {
        public static bool ExisteMatricula(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula)) return false;

            ContactoService service = new ContactoService();
            return service.ObtenerTodos().Any(c => c.Matricula == matricula);
        }
        public static bool ExisteSeudonimo(string seudo)
        {
            if (string.IsNullOrWhiteSpace(seudo)) return false;

            ContactoService service = new ContactoService();
            return service.ObtenerTodos().Any(c => c.Seudonimo == seudo);
        }

        public static bool ExisteCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula)) return false;

            ContactoService service = new ContactoService();
            return service.ObtenerTodos().Any(c => c.Cedula == cedula);
        }

        public static bool ExisteTelefono(string tel)
        {
            if (string.IsNullOrWhiteSpace(tel)) return false;

            ContactoService service = new ContactoService();
            return service.ObtenerTodos().Any(c => c.Telefono == tel);
        }
    }
}
