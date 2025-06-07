using System;
using System.Windows.Forms;
using SMSManager.Datos.Database;
using SMSManager.UI.Forms;
using SMSManager.Utilidades.Logging;

namespace SMSManager.UI
{
    /// <summary>
    /// Clase principal de arranque de la aplicación.
    /// Contiene el punto de entrada donde se inicializa la base de datos y se lanza el formulario inicial.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal de la aplicación.
        /// Inicializa la base de datos, configura la aplicación y muestra el formulario de contactos.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                
                DatabaseManager.InicializarBaseDeDatos();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al inicializar la base de datos: {ex.Message} - {ex.StackTrace}");
                MessageBox.Show($"Error al inicializar la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new frmContactos()); 
        }
    }
}
