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
using SMSManager.Utilidades.Validaciones;
using SMSManager.Logica.Utilidades;


namespace SMSManager.UI.Forms
{
    public partial class frmEditarContacto : Form
    {
        private readonly Contacto contactoEditar;
        public frmEditarContacto(Contacto contacto)
        {
            InitializeComponent();
            contactoEditar = contacto;
        }
        public frmEditarContacto()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var servicio = new ContactoService();

                string nuevoTelefono = txtTelefono.Text.Trim();
                string nuevaCedula = txtCedula.Text.Trim();
                string nuevaMatricula = txtMatricula.Text.Trim();
                string nuevoApellido = txtApellido.Text.Trim();
                string nuevoNombre = txtNombre.Text.Trim();
                string nuevoSeudonimo = txtSeudonimo.Text.Trim();
                string nuevaFecha = txtFecha.Text.Trim();
                string nuevaHora = txtHora.Text.Trim();

                // Validar duplicados solo si el usuario cambió el teléfono
                if (nuevoTelefono != contactoEditar.Telefono && UtilidadesLogica.ExisteTelefono(nuevoTelefono))
                {
                    MessageBox.Show("Ya existe un contacto con ese número de teléfono.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (nuevoSeudonimo != contactoEditar.Seudonimo && UtilidadesLogica.ExisteSeudonimo(nuevoSeudonimo))
                {
                    MessageBox.Show("Ya existe un contacto con ese Seudonimo.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar duplicados solo si el usuario cambió la cédula
                if (!string.IsNullOrWhiteSpace(nuevaCedula) &&
                    nuevaCedula != contactoEditar.Cedula &&
                    UtilidadesLogica.ExisteCedula(nuevaCedula)) 
                {
                    MessageBox.Show("Ya existe un contacto con esa cédula.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar duplicados solo si el usuario cambió la matrícula
                if (!string.IsNullOrWhiteSpace(nuevaMatricula) &&
                    nuevaMatricula != contactoEditar.Matricula &&
                    UtilidadesLogica.ExisteMatricula(nuevaMatricula))
                {
                    MessageBox.Show("Ya existe un contacto con esa matrícula.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Asignar valores actualizados
                contactoEditar.Nombre = nuevoNombre;
                contactoEditar.Apellido = nuevoApellido;
                contactoEditar.Telefono = nuevoTelefono;
                contactoEditar.Cedula = nuevaCedula;
                contactoEditar.Matricula = nuevaMatricula;
                contactoEditar.Seudonimo = nuevoSeudonimo;
                contactoEditar.Fecha = nuevaFecha;
                contactoEditar.Hora = nuevaHora;

                // Validaciones obligatorias
                if (string.IsNullOrWhiteSpace(contactoEditar.Seudonimo) ||
                    string.IsNullOrWhiteSpace(contactoEditar.Telefono))
                {
                    MessageBox.Show("Seudonimo y Teléfono son campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validaciones de formato
                if (!ValidadorDeDatos.NombreEsValido(contactoEditar.Nombre))
                {
                    MessageBox.Show("El Nombre solo puede contener letras y espacios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Intento de actualizar un contacto con nombre inválido.");
                    return;
                }

                if (!ValidadorDeDatos.TelefonoEsValido(contactoEditar.Telefono))
                {
                    MessageBox.Show("El Teléfono debe contener exactamente 9 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Intento de actualizar un contacto con teléfono inválido.");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(contactoEditar.Cedula) && !ValidadorDeDatos.CedulaEsValida(contactoEditar.Cedula))
                {
                    MessageBox.Show("La Cédula debe contener exactamente 8 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Intento de actualizar un contacto con cédula inválida.");
                    return;
                }

                // Guardar contacto
                servicio.Actualizar(contactoEditar);
                Logger.LogInfo($"Contacto actualizado: ID {contactoEditar.Id} - {contactoEditar.Nombre}");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al actualizar contacto en frmContacto: {ex.Message} - {ex.StackTrace}");
                MessageBox.Show("Ocurrió un error al intentar guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmEditarContacto_Load(object sender, EventArgs e)
        {
            try
            {
                if (contactoEditar != null)
                {
                    txtNombre.Text = contactoEditar.Nombre;
                    txtTelefono.Text = contactoEditar.Telefono;
                    txtCedula.Text = contactoEditar.Cedula;
                    txtMatricula.Text = contactoEditar.Matricula;
                    txtApellido.Text = contactoEditar.Apellido;
                    txtSeudonimo.Text = contactoEditar.Seudonimo;
                    txtHora.Text = contactoEditar.Hora;
                    txtFecha.Text = contactoEditar.Fecha;
                }
                else
                {
                    Logger.LogError("frmEditarContacto_Load: contactoEditar es null.");
                    MessageBox.Show("No se pudo cargar el contacto para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error en frmEditarContacto_Load: {ex.Message} - {ex.StackTrace}");
                MessageBox.Show("Error inesperado al cargar el formulario de edición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
