using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using SMSManager.Objetos.Modelos;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SMSManager.Utilidades.Validaciones
{
    public static class ValidadorDeDatos
    {
        public static bool NombreEsValido(string nombre)
        {
            return string.IsNullOrEmpty(nombre) || Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$");


        }

        public static bool TelefonoEsValido(string telefono)
        {
            // Exactamente 9 dígitos
            return string.IsNullOrEmpty(telefono) || Regex.IsMatch(telefono, @"^\d{9}$");
        }

        public static bool CedulaEsValida(string cedula)
        {
            // Exactamente 8 dígitos
            return string.IsNullOrEmpty(cedula) || Regex.IsMatch(cedula, @"^\d{8}$");
        }
        public static string NormalizarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return string.Empty;

            var normalizado = texto.Normalize(NormalizationForm.FormD);
            var chars = normalizado.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
            return new string(chars.ToArray()).ToLower().Replace("ñ", "n");
        }
    }
}
