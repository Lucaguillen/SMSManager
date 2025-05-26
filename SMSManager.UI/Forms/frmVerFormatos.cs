using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMSManager.Logica.Servicios;
using SMSManager.Objetos.Modelos;

namespace SMSManager.UI.Forms
{
    public partial class frmVerFormatos : BaseForm
    {
        public frmVerFormatos()
        {
            InitializeComponent();
            this.FormClosed += frmVerFormatos_FormClosed;
            this.VisibleChanged += frmVerFormatos_VisibleChanged;
            this.Load += frmVerFormatos_Load;
        }

        private void frmVerFormatos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Cast<Form>().All(f => !f.Visible))
            {
                Application.Exit();
            }
        }
        private void frmVerFormatos_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                CargarFormatos();
            }
        }
        private void frmVerFormatos_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) 
            {
                CargarFormatos();
            }
        }
        public void CargarFormatos()
        {
            try
            {
                dgvFormatos.RowHeadersVisible = false;

                var servicio = new FormatoService();
                var lista = servicio.ObtenerTodos();

                dgvFormatos.DataSource = null;
                dgvFormatos.DataSource = lista;

                dgvFormatos.Columns["Id"].Visible = false;
                dgvFormatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los formatos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnActualizarFormatos_Click(object sender, EventArgs e)
        {
            CargarFormatos();
        }

        private void btnNuevoFormato_Click(object sender, EventArgs e)
        {
            using (var frm = new frmNuevoFormato())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CargarFormatos();
                }
            }
        }

        private void btnEliminarFormato_Click(object sender, EventArgs e)
        {
            if (dgvFormatos.CurrentRow != null && dgvFormatos.CurrentRow.DataBoundItem is Formato formatoSeleccionado)
            {
                var confirmacion = MessageBox.Show(
                    $"¿Estás seguro de que querés eliminar el formato \"{formatoSeleccionado.Nombre}\"?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    try
                    {
                        var servicio = new FormatoService();
                        servicio.EliminarFormato(formatoSeleccionado.Id);

                       
                        CargarFormatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el formato: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccioná un formato para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditarFormato_Click(object sender, EventArgs e)
        {
            if (dgvFormatos.CurrentRow != null && dgvFormatos.CurrentRow.DataBoundItem is Formato formatoSeleccionado)
            {
                using (var frm = new frmNuevoFormato(formatoSeleccionado))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarFormatos();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccioná un formato para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
