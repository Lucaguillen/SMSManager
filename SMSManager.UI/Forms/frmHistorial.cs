using System;
using System.Linq;
using System.Windows.Forms;
using SMSManager.Datos.Repositorios;

namespace SMSManager.UI.Forms
{
    public partial class frmHistorial : Form
    {
        public frmHistorial()
        {
            InitializeComponent();
            CargarHistorial();
        }

        private void CargarHistorial()
        {
            var repositorio = new MensajeEnviadoRepository();
            var mensajes = repositorio.ObtenerTodos();

            dgvHistorial.Columns.Clear();
            dgvHistorial.AutoGenerateColumns = false;
            dgvHistorial.RowHeadersVisible = false;

            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefono", HeaderText = "Teléfono" });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Seudonimo", HeaderText = "Seudónimo" });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Contenido", HeaderText = "Mensaje" });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Estado", HeaderText = "Estado" });
            dgvHistorial.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FechaHora", HeaderText = "Fecha y Hora" });

            dgvHistorial.DataSource = mensajes;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

    }
}
