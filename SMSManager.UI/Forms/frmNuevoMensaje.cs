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
    /// <summary>
    /// Formulario principal para redactar y enviar nuevos mensajes a contactos seleccionados.
    /// </summary>
    public partial class frmNuevoMensaje : FormPrincipal
    {
        /// <summary>
        /// Constructor. Inicializa el formulario, configura la grilla y carga los contactos disponibles.
        /// </summary>
        public frmNuevoMensaje()
        {
            InitializeComponent();
            this.FormClosed += FrmNuevoMensaje_FormClosed;
            dgvContactos.RowHeadersVisible = false;
            CargarContactos();
            dgvContactos.Refresh();


        }

        /// <summary>
        /// Evento que se dispara al cargar el formulario.
        /// Refresca la grilla con los contactos actuales.
        /// </summary>
        private void frmNuevoMensaje_Load(object sender, EventArgs e)
        {
            CargarContactos();
            dgvContactos.Refresh();
        }

        /// <summary>
        /// Lista completa de contactos cargados desde la base de datos.
        /// Se utiliza como fuente original para aplicar filtros de búsqueda sin perder los datos.
        /// </summary>
        private List<Contacto> listaOriginal;

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Buscar".
        /// Aplica un filtro difuso a la lista de contactos según el texto ingresado.
        /// </summary>
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            BuscarContactos();
        }

        /// <summary>
        /// Determina si un campo es similar a un texto ingresado, usando comparación difusa.
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
        /// Filtra y muestra contactos cuya información coincida con el texto de búsqueda.
        /// </summary>
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

        /// <summary>
        /// Sobrescribe el método base para cargar el contenido específico del formulario.
        /// En este caso, recarga los contactos disponibles desde la base de datos.
        /// </summary>
        public override void CargarContenido()
        {
            CargarContactos();
        }

        /// <summary>
        /// Carga todos los contactos desde la base de datos y los asigna al DataGridView.
        /// </summary>
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
            dgvContactos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Fecha", HeaderText = "Fecha" });
            dgvContactos.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Hora", HeaderText = "Hora" });


            dgvContactos.DataSource = listaOriginal;


            dgvContactos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// Evento que se ejecuta cuando se cierra el formulario.
        /// Vuelve a mostrar el formulario principal anterior.
        /// </summary>
        private void FrmNuevoMensaje_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (Application.OpenForms.Cast<Form>().All(f => !f.Visible))
            {
                Application.Exit();
            }
        }


        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón con ícono (generalmente ayuda o instrucciones).
        /// Muestra un mensaje explicando cómo funcionan las variables en el cuerpo del mensaje.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            IrAFormularioPrincipal(new frmContactos()); 
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Seleccionar todos".
        /// Marca todos los contactos visibles como seleccionados para el envío.
        /// </summary>
        private void btnSeleccionarTodos_Click_1(object sender, EventArgs e)
        {
            foreach (var contacto in listaOriginal)
            {
                contacto.Seleccionado = true;

            }
            dgvContactos.Refresh();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Deseleccionar".
        /// Desmarca todos los contactos seleccionados en la lista.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Volver".
        /// Cierra el formulario y retorna a la pantalla anterior.
        /// </summary>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;
            BuscarContactos();
        }
        /// <summary>
        /// Obtiene la lista de contactos seleccionados por el usuario en la grilla.
        /// Solo se incluyen aquellos que tengan la casilla de selección activada.
        /// </summary>
        private List<Contacto> ObtenerContactosSeleccionados()
        {
            return listaOriginal
                .Where(c => c.Seleccionado)
                .ToList();
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Continuar".
        /// Abre el formulario para confirmar el envío de mensajes a los contactos seleccionados.
        /// </summary>
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            var contactosSeleccionados = ObtenerContactosSeleccionados();

            if (contactosSeleccionados == null || contactosSeleccionados.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un contacto para continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existente = Application.OpenForms.OfType<frmConfirmarEnvio>().FirstOrDefault();

            if (existente != null)
            {
                existente.Focus();
                existente.Activate();
            }
            else
            {
                var frm = new frmConfirmarEnvio(contactosSeleccionados);
                frm.FormClosed += (s, args) =>
                {
                    if (Application.OpenForms.Count == 0)
                        Application.Exit();
                };
                frm.Show();
            }

            this.Hide();
        }

    }
}
