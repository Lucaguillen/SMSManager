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
using SMSManager.Logica.Utilidades;
using SMSManager.Objetos.Modelos;
using SMSManager.Utilidades.Logging;
using SMSManager.Utilidades.Validaciones;


namespace SMSManager.UI.Forms
{
    /// <summary>
    /// Formulario para agregar manualmente un nuevo contacto al sistema.
    /// </summary>
    public partial class frmAgregarContacto : Form
    {
        /// <summary>
        /// Constructor. Inicializa los componentes del formulario.
        /// </summary>
        public frmAgregarContacto()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento del botón Guardar. Valida los campos y guarda el nuevo contacto si es válido.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var servicio = new ContactoService();

                var nuevoContacto = new Contacto
                {
                    Nombre = txtNombre.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Cedula = txtCedula.Text.Trim(),
                    Matricula = txtMatricula.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Seudonimo = txtSeudonimo.Text.Trim(),
                    Fecha = txtFecha.Text.Trim(),
                    Hora = txtHora.Text.Trim()
                };


                if (string.IsNullOrWhiteSpace(nuevoContacto.Seudonimo) || string.IsNullOrWhiteSpace(nuevoContacto.Telefono))
                {
                    MessageBox.Show("los campos Telefono y Seudonimo son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Todos los campos son obligatorios.");    
                    return;
                }

                // Validar formato del Nombre Solo si esta vacio
                if (!string.IsNullOrWhiteSpace(nuevoContacto.Cedula) && !ValidadorDeDatos.NombreEsValido(nuevoContacto.Nombre))
                {
                    MessageBox.Show("El Nombre solo puede contener letras y espacios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Intento de agregar un nombre con formato inválido.");
                    return;
                }

                // Validar formato del Teléfono
                if (!ValidadorDeDatos.TelefonoEsValido(nuevoContacto.Telefono))
                {
                    MessageBox.Show("El Teléfono debe contener exactamente 9 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Intento de agregar un teléfono con formato inválido.");
                    return;
                }

                // Validar formato de la Cédula (solo si no está vacía)
                if (!string.IsNullOrWhiteSpace(nuevoContacto.Cedula) && !ValidadorDeDatos.CedulaEsValida(nuevoContacto.Cedula))
                {
                    MessageBox.Show("La Cédula debe contener exactamente 8 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Intento de agregar una cédula con formato inválido.");
                    return;
                }


                 //Validar duplicados
                if (UtilidadesLogica.ExisteTelefono(nuevoContacto.Telefono))
                {
                    MessageBox.Show("Ya existe un contacto con ese número de teléfono.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Intento de agregar un contacto con un teléfono duplicado.");
                    return;
                }


                if (!string.IsNullOrWhiteSpace(nuevoContacto.Cedula) && UtilidadesLogica.ExisteCedula(nuevoContacto.Cedula))
                {
                    MessageBox.Show("Ya existe un contacto con esa cédula.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Intento de agregar un contacto con una cedula duplicada.");
                    return;
                }
                if (UtilidadesLogica.ExisteMatricula(nuevoContacto.Matricula))
                {
                    MessageBox.Show("Ya existe un contacto con esa Matricula.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Intento de agregar un contacto con una matricula duplicada.");

                    return;
                }

                if (UtilidadesLogica.ExisteSeudonimo(nuevoContacto.Seudonimo))
                {
                    MessageBox.Show("Ya existe un contacto con ese Seudonimo.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Intento de agregar un contacto con un Seudonimo duplicado.");

                    return;
                }

                servicio.Agregar(nuevoContacto);
                Logger.LogInfo($"Contacto {nuevoContacto.Nombre} agregado exitosamente.");
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Error al guardar el contacto: {ex.Message} - {ex.StackTrace}");
                MessageBox.Show($"Error al guardar el contacto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento del botón Cancelar. Cierra el formulario sin guardar cambios.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
