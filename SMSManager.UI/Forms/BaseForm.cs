using System;
using System.Linq;
using System.Windows.Forms;
using SMSManager.Logica.Servicios;
using SMSManager.Objetos.Modelos;
using SMSManager.UI.Forms;

namespace SMSManager.UI
{
    /// <summary>
    /// Formulario base que proporciona navegación común entre formularios
    /// y elementos de menú compartidos para reutilización en la interfaz.
    /// </summary>
    public class BaseForm : Form
    {
        /// <summary>
        /// Menú principal del sistema.
        /// </summary>
        protected MenuStrip menuStrip;

        /// <summary>
        /// Constructor. Llama a la inicialización del menú común.
        /// </summary>
        public BaseForm()
        {
            InicializarMenuComun();
        }

        /// <summary>
        /// Abre un formulario principal. Si ya está abierto, lo activa y actualiza su contenido.
        /// </summary>
        /// <param name="destino">Instancia del formulario principal a mostrar.</param>
        protected void IrAFormularioPrincipal(FormPrincipal destino)
        {
            if (this.GetType() != destino.GetType())
            {
                var existente = Application.OpenForms
                    .OfType<Form>()
                    .FirstOrDefault(f => f.GetType() == destino.GetType());

                if (existente is FormPrincipal yaAbierto)
                {
                    yaAbierto.CargarContenido();
                    yaAbierto.Show();
                    yaAbierto.Activate();
                }
                else
                {
                    destino.Show();
                }

                this.Hide();
            }
        }


        /// <summary>
        /// Abre el formulario de creación de nuevo formato como ventana modal.
        /// </summary>
        protected void NavegarANuevoFormato()
        {
            using var frm = new Forms.frmNuevoFormato();
            frm.ShowDialog();
        }


        /// <summary>
        /// Inicializa el menú común compartido por todos los formularios.
        /// Agrega entradas de navegación, configuración y acciones globales.
        /// </summary>
        private void InicializarMenuComun()
        {
            menuStrip = new MenuStrip();

            // --- Menú Contactos ---
            var contactosMenu = new ToolStripMenuItem("Contactos");
            var irAContactos = new ToolStripMenuItem("Ir a Contactos");
            irAContactos.Click += (s, e) => IrAFormularioPrincipal(new Forms.frmContactos());

            var eliminarTodos = new ToolStripMenuItem("Eliminar todos los contactos");
            eliminarTodos.Click += (s, e) =>
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
                        var servicio = new ContactoService();
                        servicio.EliminarTodosLosContactos();
                        MessageBox.Show("Contactos eliminados correctamente.", "Éxito");

                        var abierto = Application.OpenForms.OfType<Forms.frmContactos>().FirstOrDefault();
                        abierto?.CargarContactos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            contactosMenu.DropDownItems.Add(irAContactos);
            contactosMenu.DropDownItems.Add(eliminarTodos);

            // --- Menú Mensajes ---
            var mensajesMenu = new ToolStripMenuItem("Mensajes");

            var nuevoMensaje = new ToolStripMenuItem("Nuevo Mensaje");
            nuevoMensaje.Click += (s, e) => IrAFormularioPrincipal(new Forms.frmNuevoMensaje());

            var nuevoFormato = new ToolStripMenuItem("Nuevo Formato");
            nuevoFormato.Click += (s, e) => NavegarANuevoFormato();

            var verFormatos = new ToolStripMenuItem("Ver Formatos");
            verFormatos.Click += (s, e) => IrAFormularioPrincipal(new frmVerFormatos());

            var verHistorial = new ToolStripMenuItem("Historial");
            verHistorial.Click += (s, e) =>
            {
                using var frm = new Forms.frmHistorial();
                frm.ShowDialog();
            };

            mensajesMenu.DropDownItems.Add(nuevoMensaje);
            mensajesMenu.DropDownItems.Add(verHistorial);
            mensajesMenu.DropDownItems.Add(nuevoFormato);
            mensajesMenu.DropDownItems.Add(verFormatos);

            // --- Menú Configuración ---
            var configuracionMenu = new ToolStripMenuItem("Configuración");
            var configurarApi = new ToolStripMenuItem("Configurar API");
            configurarApi.Click += (s, e) =>
            {
                using var frm = new Forms.frmConfiguracionApi();
                frm.ShowDialog();
            };
            configuracionMenu.DropDownItems.Add(configurarApi);

            // Agrega todos los menús al MenuStrip
            menuStrip.Items.Add(contactosMenu);
            menuStrip.Items.Add(mensajesMenu);
            menuStrip.Items.Add(configuracionMenu);

            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
        }
    }
}
