using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FuzzySharp;
using SMSManager.Logica.Servicios;
using SMSManager.Objetos.Modelos;
using SMSManager.Utilidades.Logging;
using SMSManager.Utilidades.Validaciones;

namespace SMSManager.UI.Forms
{
    public partial class frmNuevoMensaje : BaseForm
    {

        public frmNuevoMensaje()
        {
            InitializeComponent();
            this.FormClosed += FrmNuevoMensaje_FormClosed;
            dgvContactos.RowHeadersVisible = false;
            CargarContactos();
            dgvContactos.Refresh();


        }

        private void frmNuevoMensaje_Load(object sender, EventArgs e)
        {
            CargarContactos();
            dgvContactos.Refresh();
        }

        private List<Contacto> listaOriginal;

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            BuscarContactos();
        }
        private bool EsSimilar(string entrada, string campo)
        {
            if (string.IsNullOrEmpty(campo)) return false;

            string normalCampo = ValidadorDeDatos.NormalizarTexto(campo);
            if (normalCampo.Contains(entrada)) return true;

            int score = Fuzz.PartialRatio(entrada, normalCampo);
            return score >= 75;
        }
        private void BuscarContactos()
        {
            string textoFiltro = ValidadorDeDatos.NormalizarTexto(txtBuscar.Text.Trim());

            var listaFiltrada = listaOriginal.Where(c =>
                EsSimilar(textoFiltro, c.Seudonimo) ||
                EsSimilar(textoFiltro, c.Nombre) ||
                EsSimilar(textoFiltro, c.Apellido) ||
                EsSimilar(textoFiltro, c.Telefono) ||
                EsSimilar(textoFiltro, c.Cedula) ||
                EsSimilar(textoFiltro, c.Matricula)
            ).ToList();

            dgvContactos.DataSource = null;
            dgvContactos.DataSource = listaFiltrada;
        }

        public void CargarContactos()
        {
            var service = new ContactoService();
            listaOriginal = service.ObtenerTodos();


            foreach (var contacto in listaOriginal)
            {
                contacto.Seleccionado = false;
            }


            dgvContactos.Columns.Clear();
            dgvContactos.AutoGenerateColumns = false;
            dgvContactos.RowHeadersVisible = false;


            var colSeleccionar = new DataGridViewCheckBoxColumn
            {
                Name = "Seleccionado",
                HeaderText = "Seleccionar",
                DataPropertyName = "Seleccionado",
                Width = 80
            };
            dgvContactos.Columns.Add(colSeleccionar);


            dgvContactos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", Name = "Id", Visible = false });
            dgvContactos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Seudonimo", HeaderText = "Seudónimo" });
            dgvContactos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Telefono", HeaderText = "Teléfono" });
            dgvContactos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Nombre", HeaderText = "Nombre" });
            dgvContactos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Apellido", HeaderText = "Apellido" });
            dgvContactos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Matricula", HeaderText = "Matrícula" });
            dgvContactos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Cedula", HeaderText = "Cédula" });


            dgvContactos.DataSource = listaOriginal;


            dgvContactos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void btnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvContactos.Rows)
            {
                row.Cells["Seleccionado"].Value = true;
            }
        }
        private void FrmNuevoMensaje_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (Application.OpenForms.Cast<Form>().All(f => !f.Visible))
            {
                Application.Exit();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            NavegarAContactos();
        }

        private void btnSeleccionarTodos_Click_1(object sender, EventArgs e)
        {
            foreach (var contacto in listaOriginal)
            {
                contacto.Seleccionado = true;

            }
            dgvContactos.Refresh();
        }

        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show($"¿Estás seguro de que quieres Quitar todas les selecciones?",
                        "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                foreach (var contacto in listaOriginal)
                {
                    contacto.Seleccionado = false;
                }
                dgvContactos.Refresh();
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty; 
            BuscarContactos();
        }
    }
}
