using System;
using System.Globalization;
using FuzzySharp;
using SMSManager.Logica.Servicios;
using SMSManager.Objetos.Modelos;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMSManager.Utilidades.Logging;
using SMSManager.Utilidades.Validaciones;

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

        private void btnBuscar_Click(object sender, EventArgs e)
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
            var servicio = new ContactoService();
            var listaOriginal = servicio.ObtenerTodos();

            var listaFiltrada = listaOriginal.Where(c =>
                EsSimilar(textoFiltro, c.Nombre) ||
                EsSimilar(textoFiltro, c.Apellido) ||
                EsSimilar(textoFiltro, c.Telefono) ||
                EsSimilar(textoFiltro, c.Cedula) ||
                EsSimilar(textoFiltro, c.Matricula)
            ).ToList();

            dgvContactos.DataSource = null;
            dgvContactos.DataSource = listaFiltrada;
            dgvContactos.Columns["Id"].Visible = false;
            dgvContactos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";
            openFileDialog.Title = "Seleccionar archivo CSV";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = openFileDialog.FileName;
                var servicio = new ContactoService();

                var resultado = servicio.ImportarDesdeCsv(rutaArchivo);

                StringBuilder mensaje = new StringBuilder();
                mensaje.AppendLine($"✔ Contactos importados: {resultado.ContactosImportados}");
                mensaje.AppendLine($"❌ Contactos fallidos: {resultado.ContactosFallidos}");

                if (resultado.Errores.Any())
                {
                    mensaje.AppendLine("\nDetalles de errores:");
                    foreach (var error in resultado.Errores)
                    {
                        mensaje.AppendLine($"- {error}");
                    }
                }

                MessageBox.Show(mensaje.ToString(), "Resultado de la Importación", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarContactos();
            }
        }

        private void nuevoCuerpoDeMensajeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void irAContactosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this is frmContactos)
            {
                return;
            }

            var contactosForm = new frmContactos();
            contactosForm.Show();
            this.Close();
        }

        private void eLIMINARTODOSLOSCONTACTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
            "¿Está seguro de que desea eliminar todos los contactos?",
            "Confirmación",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    ContactoService service = new ContactoService();
                    service.EliminarTodosLosContactos();
                    CargarContactos();

                    MessageBox.Show("Todos los contactos han sido eliminados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
