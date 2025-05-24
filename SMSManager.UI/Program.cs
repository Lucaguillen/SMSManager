using System;
using System.Windows.Forms;
using SMSManager.Datos.Database;
using SMSManager.UI.Forms;
using SMSManager.Utilidades.Logging;

namespace SMSManager.UI
{
    internal static class Program
    {
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
