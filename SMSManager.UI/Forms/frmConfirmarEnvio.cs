using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SMSManager.Datos.Repositorios;
using SMSManager.Logica.Servicios;
using SMSManager.Objetos.Modelos;

namespace SMSManager.UI.Forms
{
    public partial class frmConfirmarEnvio : Form
    {


        private List<Contacto> _contactos;
        public frmConfirmarEnvio(List<Contacto> contactos)
        {
            InitializeComponent();
            _contactos = contactos;
            this.FormClosed += FrmConfirmarEnvio_FormClosed;
            this.Load += frmConfirmarEnvio_Load;
            dgvDestinatarios.SelectionChanged += dgvDestinatarios_SelectionChanged;
            dgvDestinatarios.CellContentClick += dgvDestinatarios_CellContentClick;


        }

        private async Task<bool> EnviarMensajeAsync(string numero, string mensaje)
        {
            try
            {
                var config = ConfiguracionService.Cargar();

                if (string.IsNullOrWhiteSpace(config.IP) ||
                    string.IsNullOrWhiteSpace(config.Puerto) ||
                    string.IsNullOrWhiteSpace(config.Token))
                {
                    MessageBox.Show("La configuración de API está incompleta. Por favor, revise los datos en 'Configurar API'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Asegurarse de que el número esté en formato internacional
                if (!numero.StartsWith("+"))
                {
                    numero = "+598" + numero.TrimStart('0'); // Remueve el 0 inicial si es necesario
                }

                string url = $"http://{config.IP}:{config.Puerto}/";
                var json = $"{{\"to\": \"{numero}\", \"message\": \"{mensaje}\"}}";

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(config.Token);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error al enviar SMS: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void RegistrarEnHistorial(string telefono, string seudonimo, string mensaje, string estado)
        {
            var historialRepo = new MensajeEnviadoRepository();

            var registro = new MensajeEnviado
            {
                Telefono = telefono,
                Seudonimo = seudonimo,
                Contenido = mensaje,
                Estado = estado,
                FechaHora = DateTime.Now
            };

            historialRepo.Insertar(registro);
        }

        private void frmConfirmarEnvio_Load(object sender, EventArgs e)
        {
            CargarFormatos();
        }

        private void CargarFormatos()
        {
            var servicio = new FormatoService();
            var formatos = servicio.ObtenerTodos();

            cmbFormato.DisplayMember = "Nombre";
            cmbFormato.ValueMember = "Id";
            cmbFormato.DataSource = formatos;
        }
        private void dgvDestinatarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var columna = dgvDestinatarios.Columns[e.ColumnIndex];

            if (columna.Name == "Eliminar")
            {
                var confirmacion = MessageBox.Show("¿Deseás eliminar este destinatario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    dgvDestinatarios.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void FrmConfirmarEnvio_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Cast<Form>().All(f => !f.Visible))
            {
                Application.Exit();
            }
        }
        private void dgvDestinatarios_SelectionChanged(object sender, EventArgs e)
        {
            if (cmbFormato.SelectedItem is not Formato formatoSeleccionado || dgvDestinatarios.CurrentRow == null)
                return;

            string textoBase = formatoSeleccionado.Cuerpo;
            DataGridViewRow fila = dgvDestinatarios.CurrentRow;

            var reemplazos = new Dictionary<string, string>
            {
                { "Nombre", dgvDestinatarios.Columns.Contains("Nombre") ? fila.Cells["Nombre"].Value?.ToString() ?? "" : "" },
                { "Apellido", dgvDestinatarios.Columns.Contains("Apellido") ? fila.Cells["Apellido"].Value?.ToString() ?? "" : "" },
                { "Cedula", dgvDestinatarios.Columns.Contains("Cedula") ? fila.Cells["Cedula"].Value?.ToString() ?? "" : "" },
                { "Matricula", dgvDestinatarios.Columns.Contains("Matricula") ? fila.Cells["Matricula"].Value?.ToString() ?? "" : "" },
                { "Fecha", dgvDestinatarios.Columns.Contains("Fecha") ? fila.Cells["Fecha"].Value?.ToString() ?? "" : "" },
                { "Hora", dgvDestinatarios.Columns.Contains("Hora") ? fila.Cells["Hora"].Value?.ToString() ?? "" : "" }

            };

            // Agregar los placeholders manuales dinámicamente
            foreach (DataGridViewCell cell in fila.Cells)
            {
                string nombre = cell.OwningColumn.Name;
                if (!reemplazos.ContainsKey(nombre) && cell.Value != null)
                {
                    reemplazos[nombre] = cell.Value.ToString();
                }
            }

            // Reemplazar en el texto
            foreach (var kv in reemplazos)
            {
                textoBase = textoBase.Replace($"{{{kv.Key}}}", kv.Value);
            }

            txtVistaPrevia.Text = textoBase;
        }

        private void cmbFormato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFormato.SelectedItem is Formato formatoSeleccionado)
            {
                string textoFormato = formatoSeleccionado.Cuerpo;

                var placeholders = ExtraerPlaceholders(textoFormato);
                ReconstruirGrilla(placeholders);
            }
        }
        private List<string> ExtraerPlaceholders(string textoFormato)
        {
            var matches = System.Text.RegularExpressions.Regex.Matches(textoFormato, @"\{(.*?)\}");

            return matches
                .Select(m => m.Groups[1].Value)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }
        private void button3_Click(object sender, EventArgs e)
        {

            var frmNuevoMensaje = Application.OpenForms
                .OfType<frmNuevoMensaje>()
                .FirstOrDefault();

            if (frmNuevoMensaje != null)
            {
                frmNuevoMensaje.Show();
                frmNuevoMensaje.Activate();
            }
            else
            {

                new frmNuevoMensaje().Show();
            }

            this.Close();
        }
        private void ReconstruirGrilla(List<string> placeholders)
        {
            dgvDestinatarios.Columns.Clear();
            dgvDestinatarios.Rows.Clear();
            dgvDestinatarios.AutoGenerateColumns = false;
            dgvDestinatarios.RowHeadersVisible = false;

            // Siempre visibles
            dgvDestinatarios.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Enviar", HeaderText = "Enviar", Width = 60 });
            dgvDestinatarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Seudonimo", HeaderText = "Seudónimo", ReadOnly = true });
            dgvDestinatarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Telefono", HeaderText = "Teléfono", ReadOnly = true });

            // Automáticos si están presentes en placeholders
            var camposContacto = new[] { "Nombre", "Apellido", "Cedula", "Matricula", "Fecha", "Hora" };

            foreach (var campo in camposContacto)
            {
                if (placeholders.Any(p => p.Equals(campo, StringComparison.OrdinalIgnoreCase)))
                {
                    dgvDestinatarios.Columns.Add(new DataGridViewTextBoxColumn { Name = campo, HeaderText = campo, ReadOnly = true });
                }
            }

            // Manuales: los que no están en el modelo de Contacto
            var manuales = placeholders
                .Where(p => !camposContacto.Contains(p, StringComparer.OrdinalIgnoreCase) && p != "Seudonimo" && p != "Telefono")
                .Distinct(StringComparer.OrdinalIgnoreCase);

            foreach (var campo in manuales)
            {
                dgvDestinatarios.Columns.Add(new DataGridViewTextBoxColumn { Name = campo, HeaderText = campo, ReadOnly = false });
            }

            // Estado de envío
            dgvDestinatarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Estado", HeaderText = "Estado", ReadOnly = true });

            // Botón eliminar
            dgvDestinatarios.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Eliminar",
                HeaderText = "Eliminar",
                Text = "🗑️",
                UseColumnTextForButtonValue = true,
                Width = 60
            });

            // Cargar filas
            foreach (var contacto in _contactos)
            {
                // Generar una lista de valores en el orden de las columnas agregadas
                var fila = new List<object>
        {
            true,
            contacto.Seudonimo,
            contacto.Telefono
        };

                // Automáticos
                foreach (var campo in camposContacto)
                {
                    if (placeholders.Contains(campo, StringComparer.OrdinalIgnoreCase))
                    {
                        fila.Add(contacto.GetType().GetProperty(campo)?.GetValue(contacto)?.ToString() ?? "");
                    }
                }

                // Manuales (vacíos)
                foreach (var _ in manuales)
                {
                    fila.Add("");
                }

                // Estado
                fila.Add("No enviado");

                dgvDestinatarios.Rows.Add(fila.ToArray());
            }

            dgvDestinatarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Estás seguro de que quieres quitar todas las selecciones?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                foreach (DataGridViewRow fila in dgvDestinatarios.Rows)
                {
                    if (fila.Cells["Enviar"] is DataGridViewCheckBoxCell chk)
                    {
                        chk.Value = false;
                    }
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (cmbFormato.SelectedItem is not Formato formatoSeleccionado)
            {
                MessageBox.Show("Debe seleccionar un formato antes de enviar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string textoBase = formatoSeleccionado.Cuerpo;

            foreach (DataGridViewRow fila in dgvDestinatarios.Rows)
            {
                bool enviar = fila.Cells["Enviar"]?.Value as bool? ?? false;
                if (!enviar) continue;

                try
                {
                    string telefono = fila.Cells["Telefono"].Value?.ToString() ?? "";
                    string mensaje = textoBase;

                    // Recolectar valores para reemplazo
                    var reemplazos = new Dictionary<string, string>();
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        string nombreCol = celda.OwningColumn.Name;
                        if (!string.IsNullOrWhiteSpace(nombreCol) && celda.Value != null)
                        {
                            reemplazos[nombreCol] = celda.Value.ToString();
                        }
                    }

                    // Reemplazar placeholders en el texto
                    foreach (var kv in reemplazos)
                    {
                        mensaje = mensaje.Replace($"{{{kv.Key}}}", kv.Value);
                    }

                    bool exito = await EnviarMensajeAsync(telefono, mensaje);
                    string estado = exito ? "Enviado" : "Error";
                    fila.Cells["Estado"].Value = estado;

                    // Registrar en historial
                    RegistrarEnHistorial(
                        telefono,
                        reemplazos.GetValueOrDefault("Seudonimo", ""),
                        mensaje,
                        estado
                    );
                }
                catch
                {
                    fila.Cells["Estado"].Value = "Error";
                }
            }

            MessageBox.Show("Proceso de envío finalizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private async void btnEnviarTodos_Click(object sender, EventArgs e)
        {
            if (cmbFormato.SelectedItem is not Formato formatoSeleccionado)
            {
                MessageBox.Show("Debe seleccionar un formato antes de enviar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string textoBase = formatoSeleccionado.Cuerpo;

            foreach (DataGridViewRow fila in dgvDestinatarios.Rows)
            {
                try
                {
                    string telefono = fila.Cells["Telefono"].Value?.ToString() ?? "";
                    string mensaje = textoBase;

                    // Recolectar valores para reemplazo
                    var reemplazos = new Dictionary<string, string>();
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        string nombreCol = celda.OwningColumn.Name;
                        if (!string.IsNullOrWhiteSpace(nombreCol) && celda.Value != null)
                        {
                            reemplazos[nombreCol] = celda.Value.ToString();
                        }
                    }

                    // Reemplazar placeholders en el texto
                    foreach (var kv in reemplazos)
                    {
                        mensaje = mensaje.Replace($"{{{kv.Key}}}", kv.Value);
                    }

                    bool exito = await EnviarMensajeAsync(telefono, mensaje);
                    string estado = exito ? "Enviado" : "Error";
                    fila.Cells["Estado"].Value = estado;

                    RegistrarEnHistorial(
                        telefono,
                        reemplazos.GetValueOrDefault("Seudonimo", ""),
                        mensaje,
                        estado
                    );
                }
                catch
                {
                    fila.Cells["Estado"].Value = "Error";
                }
            }

            MessageBox.Show("Proceso de envío finalizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }


}
