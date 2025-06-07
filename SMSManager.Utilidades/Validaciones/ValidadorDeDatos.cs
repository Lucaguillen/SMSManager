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
    /// <summary>
    /// Clase utilitaria para validar y normalizar datos ingresados por el usuario,
    /// como nombres, teléfonos y cédulas.
    /// </summary>
    public static class ValidadorDeDatos
    {
        /// <summary>
        /// Verifica si un nombre es válido.
        /// Se considera válido si está vacío o contiene solo letras y espacios.
        /// </summary>
        public static bool NombreEsValido(string nombre)
        {
            return string.IsNullOrEmpty(nombre) || Regex.IsMatch(nombre, @"^[a-zA-Z\s]+$");


        }

        /// <summary>
        /// Verifica si un número de teléfono es válido.
        /// Se considera válido si está vacío o contiene exactamente 9 dígitos.
        /// </summary>
        public static bool TelefonoEsValido(string telefono)
        {
            // Exactamente 9 dígitos
            return string.IsNullOrEmpty(telefono) || Regex.IsMatch(telefono, @"^\d{9}$");
        }

        /// <summary>
        /// Verifica si una cédula de identidad es válida.
        /// Se considera válida si está vacía o contiene exactamente 8 dígitos.
        /// </summary>
        public static bool CedulaEsValida(string cedula)
        {
            // Exactamente 8 dígitos
            return string.IsNullOrEmpty(cedula) || Regex.IsMatch(cedula, @"^\d{8}$");
        }

        /// <summary>
        /// Normaliza un texto eliminando acentos y caracteres especiales,
        /// convierte todo a minúsculas y reemplaza la letra "ñ" por "n".
        /// </summary>
        public static string NormalizarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return string.Empty;

            var normalizado = texto.Normalize(NormalizationForm.FormD);
            var chars = normalizado.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark);
            return new string(chars.ToArray()).ToLower().Replace("ñ", "n");
        }
    }
}
