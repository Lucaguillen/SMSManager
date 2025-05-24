using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using SMSManager.Logica.Servicios;
using SMSManager.Objetos.Modelos;

namespace SMSManager.Utilidades.Validaciones
{
    public static class ValidadorDeDatos
    {
        public static bool NombreEsValido(string nombre)
        {
            // Permite solo letras y espacios
            return Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$");
        }

        public static bool TelefonoEsValido(string telefono)
        {
            // Exactamente 9 dígitos
            return Regex.IsMatch(telefono, @"^\d{9}$");
        }

        public static bool CedulaEsValida(string cedula)
        {
            // Exactamente 8 dígitos
            return Regex.IsMatch(cedula, @"^\d{8}$");
        }

        public static bool ExisteMatricula(string matricula)
        {
            if (string.IsNullOrWhiteSpace(matricula)) return false;

            ContactoService service = new ContactoService();
            return service.ObtenerTodos().Any(c => c.Matricula == matricula);
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
