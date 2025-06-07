using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMSManager.Objetos.Modelos;
using SMSManager.Logica.Utilidades;

namespace SMSManager.UI.Forms
{
    /// <summary>
    /// Formulario que permite configurar los parámetros de conexión con la API Traccar.
    /// </summary>
    public partial class frmConfiguracionApi : Form
    {
        /// <summary>
        /// Constructor. Inicializa el formulario y carga la configuración actual desde el archivo local.
        /// </summary>
        public frmConfiguracionApi()
        {
            InitializeComponent();
            CargarConfiguracion();

        }
        /// <summary>
        /// Carga los valores de configuración desde el archivo local y los muestra en los campos correspondientes.
        /// </summary>
        private void CargarConfiguracion()
        {
            var config = ConfiguracionService.Cargar();

            txtIP.Text = config.IP;
            txtPuerto.Text = config.Puerto;
            txtToken.Text = config.Token;
        }
        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Guardar".
        /// Valida los campos y guarda la nueva configuración en un archivo local.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIP.Text) ||
                string.IsNullOrWhiteSpace(txtPuerto.Text) ||
                string.IsNullOrWhiteSpace(txtToken.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var config = new ApiConfig
            {
                IP = txtIP.Text.Trim(),
                Puerto = txtPuerto.Text.Trim(),
                Token = txtToken.Text.Trim()
            };

            ConfiguracionService.Guardar(config);

            MessageBox.Show("Configuración guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Cancelar".
        /// Cierra el formulario sin guardar cambios.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
