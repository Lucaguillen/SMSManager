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
using SMSManager.Utilidades.Logging;

namespace SMSManager.UI.Forms
{
    public partial class frmContactos : Form
    {
        public frmContactos()
        {
            InitializeComponent();
        }
        private void CargarContactos()
        {
            try
            {
                var servicio = new ContactoService();
                var listaContactos = servicio.ObtenerTodos();

                dgvContactos.DataSource = null;
                dgvContactos.DataSource = listaContactos;
                dgvContactos.Columns["Id"].Visible = false;



                dgvContactos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Logger.LogInfo("Contactos cargados correctamente.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al cargar los contactos: {ex.Message} - {ex.StackTrace}");
                MessageBox.Show($"Error al cargar los contactos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmContactos_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                CargarContactos();
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContactos.CurrentRow != null && dgvContactos.CurrentRow.DataBoundItem is Contacto contactoSeleccionado)
                {
                    using (var frm = new frmEditarContacto(contactoSeleccionado))
                    {
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            CargarContactos(); 
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un contacto para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar editar el contacto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarContactos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new frmAgregarContacto())
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        CargarContactos();
                        Logger.LogInfo("Contacto agregado correctamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al intentar agregar un contacto: {ex.Message} - {ex.StackTrace}");
                MessageBox.Show($"Error al intentar agregar un contacto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContactos.CurrentRow != null && dgvContactos.CurrentRow.DataBoundItem is Contacto contactoSeleccionado)
                {
                    var confirmacion = MessageBox.Show($"¿Estás seguro de que quieres eliminar el contacto '{contactoSeleccionado.Nombre}'?",
                        "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (confirmacion == DialogResult.Yes)
                    {
                        var servicio = new ContactoService();
                        servicio.Eliminar(contactoSeleccionado.Id);

                        Logger.LogInfo($"Contacto eliminado: ID {contactoSeleccionado.Id} - {contactoSeleccionado.Nombre}");


                        CargarContactos(); 
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un contacto para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al eliminar contacto: {ex.Message} - {ex.StackTrace}");
                MessageBox.Show("Ocurrió un error al intentar eliminar el contacto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
