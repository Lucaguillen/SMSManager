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
    /// <summary>
    /// Formulario principal para visualizar, editar, buscar y administrar la lista de contactos del sistema.
    /// </summary>
    public partial class frmContactos : FormPrincipal
    {
        /// <summary>
        /// Constructor. Inicializa el formulario y oculta los encabezados de las filas en la grilla.
        /// </summary>
        public frmContactos()
        {
            InitializeComponent();
            dgvContactos.RowHeadersVisible = false;

        }

        /// <summary>
        /// Sobrescribe el método base para cargar el contenido específico del formulario.
        /// En este caso, recarga la lista de contactos desde la base de datos.
        /// </summary>
        public override void CargarContenido()
        {
            CargarContactos(); 
        }

        /// <summary>
        /// Carga y muestra todos los contactos desde la base de datos en la grilla principal.
        /// </summary>
        public void CargarContactos()
        {
            try
            {
                var servicio = new ContactoService();
                var listaContactos = servicio.ObtenerTodos();

                dgvContactos.DataSource = null;
                dgvContactos.DataSource = listaContactos;
                dgvContactos.Columns["Id"].Visible = false;
                dgvContactos.Columns["Seleccionado"].Visible = false;



                dgvContactos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                Logger.LogInfo("Contactos cargados correctamente.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al cargar los contactos: {ex.Message} - {ex.StackTrace}");
                MessageBox.Show($"Error al cargar los contactos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento que se dispara al cargar el formulario. Llama a CargarContactos si no está en modo diseño.
        /// </summary>
        private void frmContactos_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                CargarContactos();
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Editar".
        /// Abre un formulario para modificar el contacto actualmente seleccionado en la grilla.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Actualizar".
        /// Recarga la lista completa de contactos desde la base de datos.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarContactos();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Agregar".
        /// Abre el formulario para agregar un nuevo contacto.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Buscar".
        /// Filtra la lista de contactos según el texto ingresado.
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarContactos();
        }

        /// <summary>
        /// Compara dos textos y determina si son similares ignorando mayúsculas y espacios.
        /// </summary>
        private bool EsSimilar(string entrada, string campo)
        {
            if (string.IsNullOrEmpty(campo)) return false;

            string normalCampo = ValidadorDeDatos.NormalizarTexto(campo);
            if (normalCampo.Contains(entrada)) return true;

            int score = Fuzz.PartialRatio(entrada, normalCampo);
            return score >= 75;
        }

        /// <summary>
        /// Filtra y muestra contactos cuya cédula, nombre o seudónimo coincidan parcialmente con el texto ingresado.
        /// </summary>
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
                EsSimilar(textoFiltro, c.Matricula) ||
                EsSimilar(textoFiltro, c.Seudonimo) ||
                EsSimilar(textoFiltro, c.Fecha) ||
                EsSimilar(textoFiltro, c.Hora)
            ).ToList();

            dgvContactos.DataSource = null;
            dgvContactos.DataSource = listaFiltrada;
            dgvContactos.Columns["Id"].Visible = false;
            dgvContactos.Columns["Seleccionado"].Visible = false;
            dgvContactos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Eliminar".
        /// Elimina el contacto actualmente seleccionado, tras confirmación del usuario.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta al cambiar el texto del campo de búsqueda.
        /// Aplica el filtro automáticamente si hay texto ingresado.
        /// </summary>
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Importar".
        /// Abre el formulario de importación masiva de contactos desde archivo CSV.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Volver".
        /// Cierra este formulario y regresa a la ventana anterior.
        /// </summary>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;
            BuscarContactos();
        }
    }
}
