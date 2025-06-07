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
    /// <summary>
    /// Formulario que muestra todos los formatos disponibles para consulta o edición.
    /// </summary>
    public partial class frmVerFormatos : FormPrincipal
    {
        /// <summary>
        /// Constructor. Inicializa el formulario y configura los eventos de carga y visibilidad.
        /// </summary>
        public frmVerFormatos()
        {
            InitializeComponent();
            this.FormClosed += frmVerFormatos_FormClosed;
            this.VisibleChanged += frmVerFormatos_VisibleChanged;
            this.Load += frmVerFormatos_Load;
        }

        /// <summary>
        /// Evento que se ejecuta cuando el formulario se cierra.
        /// Cierra completamente la aplicación si no quedan ventanas visibles.
        /// </summary>
        private void frmVerFormatos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Cast<Form>().All(f => !f.Visible))
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se carga el formulario.
        /// Llama a la función para cargar los formatos si no está en modo diseño.
        /// </summary>
        private void frmVerFormatos_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                CargarFormatos();
            }
        }

        /// <summary>
        /// Evento que se dispara al cambiar la visibilidad del formulario.
        /// Recarga la lista de formatos cuando se vuelve visible.
        /// </summary>
        private void frmVerFormatos_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) 
            {
                CargarFormatos();
            }
        }

        /// <summary>
        /// Método sobrescrito que se utiliza cuando se navega a este formulario desde el menú principal.
        /// Permite recargar la información (en este caso, los formatos) automáticamente
        /// si el formulario ya estaba abierto.
        /// </summary>
        public override void CargarContenido()
        {
            CargarFormatos();
        }

        /// <summary>
        /// Carga todos los formatos almacenados desde el servicio y los muestra en la grilla.
        /// Se utiliza tanto al cargar como al actualizar la vista.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Actualizar".
        /// Refresca manualmente la lista de formatos desde el servicio.
        /// </summary>
        private void btnActualizarFormatos_Click(object sender, EventArgs e)
        {
            CargarFormatos();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Nuevo Formato".
        /// Abre el formulario de creación de un nuevo formato como ventana modal.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Eliminar".
        /// Elimina el formato seleccionado de la base de datos tras confirmar la acción.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Editar".
        /// Abre el formulario de edición con los datos del formato actualmente seleccionado.
        /// </summary>
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
