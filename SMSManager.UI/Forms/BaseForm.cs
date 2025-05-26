using System;
using System.Linq;
using System.Windows.Forms;
using SMSManager.Logica.Servicios;
using SMSManager.Objetos.Modelos;

namespace SMSManager.UI
{
    public class BaseForm : Form
    {
        protected MenuStrip menuStrip;

        public BaseForm()
        {
            InicializarMenuComun();
        }
        protected void NavegarAVerFormatos()
        {
            if (!(this is Forms.frmVerFormatos))
            {
                var existente = Application.OpenForms.OfType<Forms.frmVerFormatos>().FirstOrDefault();
                if (existente != null)
                {
                    existente.CargarFormatos(); // Refresca
                    existente.Show();
                    existente.Activate();
                }
                else
                {
                    new Forms.frmVerFormatos().Show();
                }

                this.Hide();
            }
        }

        protected void NavegarAContactos()
        {
            if (!(this is Forms.frmContactos))
            {
                var existente = Application.OpenForms.OfType<Forms.frmContactos>().FirstOrDefault();
                if (existente != null)
                {
                    existente.CargarContactos();
                    existente.Show();
                    existente.Activate();
                }
                else
                {
                    new Forms.frmContactos().Show();
                }

                this.Hide();
            }
        }

        protected void NavegarANuevoMensaje()
        {
            if (!(this is Forms.frmNuevoMensaje))
            {
                var existente = Application.OpenForms.OfType<Forms.frmNuevoMensaje>().FirstOrDefault();
                if (existente != null)
                {
                    existente.CargarContactos();
                    existente.Show();
                    existente.Activate();
                }
                else
                {
                    new Forms.frmNuevoMensaje().Show();
                }

                this.Hide();
            }
        }

        protected void NavegarANuevoFormato()
        {
            using var frm = new Forms.frmNuevoFormato();
            frm.ShowDialog();
        }

        protected void AbrirFormularioFormatoEdicion(Formato formato)
        {
            using var frm = new Forms.frmNuevoFormato(formato);
            frm.ShowDialog();
        }

        private void InicializarMenuComun()
        {
            menuStrip = new MenuStrip();

            // Menú Contactos
            var contactosMenu = new ToolStripMenuItem("Contactos");

            var irAContactos = new ToolStripMenuItem("Ir a Contactos");
            irAContactos.Click += (s, e) => NavegarAContactos();

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
                        if (abierto != null)
                        {
                            abierto.CargarContactos();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            contactosMenu.DropDownItems.Add(irAContactos);
            contactosMenu.DropDownItems.Add(eliminarTodos);

            // Menú Mensajes
            var mensajesMenu = new ToolStripMenuItem("Mensajes");

            var nuevoMensaje = new ToolStripMenuItem("Nuevo Mensaje");
            nuevoMensaje.Click += (s, e) => NavegarANuevoMensaje();

            var nuevoFormato = new ToolStripMenuItem("Nuevo Formato");
            nuevoFormato.Click += (s, e) => NavegarANuevoFormato();

            var verFormatos = new ToolStripMenuItem("Ver Formatos");
            verFormatos.Click += (s, e) => NavegarAVerFormatos();


            mensajesMenu.DropDownItems.Add(nuevoMensaje);
            mensajesMenu.DropDownItems.Add(nuevoFormato);
            mensajesMenu.DropDownItems.Add(verFormatos);

            // Menú Configuración
            var configuracionMenu = new ToolStripMenuItem("Configuración");
            var configurarApi = new ToolStripMenuItem("Configurar API");
            configurarApi.Click += (s, e) =>
            {
                MessageBox.Show("Configuración de API próximamente.", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            configuracionMenu.DropDownItems.Add(configurarApi);

            // Agregar menús al MenuStrip
            menuStrip.Items.Add(contactosMenu);
            menuStrip.Items.Add(mensajesMenu);
            menuStrip.Items.Add(configuracionMenu);

            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
        }
    }
}
