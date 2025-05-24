using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
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
    }
}
