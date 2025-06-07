using System;
using System.Linq;
using System.Windows.Forms;
using SMSManager.Datos.Repositorios;

namespace SMSManager.UI.Forms
{
    /// <summary>
    /// Formulario que muestra el historial de mensajes enviados, incluyendo destinatario, estado y fecha.
    /// </summary>
    public partial class frmHistorial : Form
    {
        /// <summary>
        /// Constructor. Inicializa los componentes del formulario y carga el historial de mensajes enviados.
        /// </summary>
        public frmHistorial()
        {
            InitializeComponent();
            CargarHistorial();
        }

        /// <summary>
        /// Carga los mensajes enviados desde el repositorio y los muestra en la grilla del historial.
        /// </summary>
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
