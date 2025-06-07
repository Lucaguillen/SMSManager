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
    /// Formulario para crear un nuevo formato de mensaje o editar uno existente.
    /// Permite definir variables que se reemplazarán al enviar mensajes.
    /// </summary>
    public partial class frmNuevoFormato : Form
    {
        private Formato formatoEditar;

        /// <summary>
        /// Constructor que permite abrir el formulario en modo edición si se pasa un formato existente.
        /// </summary>
        /// <param name="formato">El formato a editar, o null para crear uno nuevo.</param>
        public frmNuevoFormato(Formato formato = null)
        {
            InitializeComponent();
         

            if (formato != null)
            {
                formatoEditar = formato;
                txtNombreFormato.Text = formato.Nombre;
                txtCuerpoFormato.Text = formato.Cuerpo;
                txtNombreFormato.Enabled = false; 
            }
        }


        /// <summary>
        /// Muestra una ventana de ayuda explicando cómo utilizar variables en el cuerpo del mensaje.
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            string ayudaFormato =
            "¿Cómo crear un formato de mensaje?\n\n" +
            "Usá llaves { } para insertar datos de cada contacto en el mensaje. Estas variables se completan automáticamente al enviar.\n\n" +
            "Ejemplo:\n" +
            "Hola {Nombre}, tu turno es el {Fecha} a las {Hora}.\n\n" +
            "Variables automáticas disponibles:\n" +
            "- {Seudonimo}\n" +
            "- {Nombre}\n" +
            "- {Apellido}\n" +
            "- {Telefono}\n" +
            "- {Cedula}\n" +
            "- {Matricula}\n" +
            "- {Fecha}\n" +
            "- {Hora}\n\n" +
            "También podés usar cualquier otra palabra entre llaves, como {Codigo} o {Observacion}, y completarlas manualmente luego.";

            MessageBox.Show(ayudaFormato, "Ayuda sobre formatos", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        /// <summary>
        /// Cierra el formulario actual sin realizar cambios.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Guarda el nuevo formato o actualiza uno existente.
        /// Valida el nombre y cuerpo antes de persistir los cambios.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreFormato.Text.Trim();
            string cuerpo = txtCuerpoFormato.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(cuerpo))
            {
                MessageBox.Show("El nombre y el cuerpo del formato no pueden estar vacíos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var servicio = new FormatoService();

                if (formatoEditar == null)
                {
                    var nuevo = new Formato { Nombre = nombre, Cuerpo = cuerpo };
                    servicio.GuardarFormato(nuevo);
                }
                else
                {
                    formatoEditar.Cuerpo = cuerpo;
                    servicio.ActualizarFormato(formatoEditar);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el formato: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
