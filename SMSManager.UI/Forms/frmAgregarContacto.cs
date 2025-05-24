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


namespace SMSManager.UI.Forms
{
    public partial class frmAgregarContacto : Form
    {
        public frmAgregarContacto()
        {
            InitializeComponent();
        }

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
                    Apellido = txtApellido.Text.Trim()
                };


                if (string.IsNullOrWhiteSpace(nuevoContacto.Nombre) || string.IsNullOrWhiteSpace(nuevoContacto.Telefono) || string.IsNullOrEmpty(nuevoContacto.Matricula) || string.IsNullOrEmpty(nuevoContacto.Apellido))
                {
                    MessageBox.Show("Todos los campos son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Todos los campos son obligatorios.");    
                    return;
                }

                // Validar formato del Nombre
                if (!ValidadorDeDatos.NombreEsValido(nuevoContacto.Nombre))
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


                // Validar duplicados
                if (ValidadorDeDatos.ExisteTelefono(nuevoContacto.Telefono))
                {
                    MessageBox.Show("Ya existe un contacto con ese número de teléfono.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Intento de agregar un contacto con un teléfono duplicado.");
                    return;
                }


                if (!string.IsNullOrWhiteSpace(nuevoContacto.Cedula) && ValidadorDeDatos.ExisteCedula(nuevoContacto.Cedula))
                {
                    MessageBox.Show("Ya existe un contacto con esa cédula.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Intento de agregar un contacto con una cedula duplicada.");
                    return;
                }
                if (ValidadorDeDatos.ExisteMatricula(nuevoContacto.Matricula))
                {
                    MessageBox.Show("Ya existe un contacto con esa Matricula.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Logger.LogError("Intento de agregar un contacto con una matricula duplicada.");

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
