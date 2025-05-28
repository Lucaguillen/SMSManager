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

namespace SMSManager.UI.Forms
{
    public partial class frmConfiguracionApi : Form
    {
        public frmConfiguracionApi()
        {
            InitializeComponent();
            CargarConfiguracion();

        }
        private void CargarConfiguracion()
        {
            var config = ConfiguracionService.Cargar();

            txtIP.Text = config.IP;
            txtPuerto.Text = config.Puerto;
            txtToken.Text = config.Token;
        }

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
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
