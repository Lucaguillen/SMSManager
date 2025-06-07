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
using SMSManager.Utilidades.Logging;
using SMSManager.Logica.Utilidades;

namespace SMSManager.UI.Forms
{
    /// <summary>
    /// Formulario que permite revisar y confirmar el envío de mensajes SMS a una lista de contactos.
    /// </summary>
    public partial class frmConfirmarEnvio : Form
    {

        /// <summary>
        /// Lista de contactos a quienes se enviarán los mensajes.
        /// </summary>
        private List<Contacto> _contactos;

        /// <summary>
        /// Constructor. Inicializa el formulario con la lista de contactos recibida como parámetro.
        /// </summary>
        public frmConfirmarEnvio(List<Contacto> contactos)
        {
            InitializeComponent();
            _contactos = contactos;
            this.FormClosed += FrmConfirmarEnvio_FormClosed;
            this.Load += frmConfirmarEnvio_Load;
            dgvDestinatarios.SelectionChanged += dgvDestinatarios_SelectionChanged;
            dgvDestinatarios.CellContentClick += dgvDestinatarios_CellContentClick;


        }

        /// <summary>
        /// Envía un mensaje SMS de forma asincrónica al número especificado.
        /// Valida la configuración de la API antes de enviar.
        /// </summary>
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
                    SMSManager.Utilidades.Logging.Logger.LogError("Configuración de API incompleta.");
                    return false;
                }

                if (!numero.StartsWith("+"))
                {
                    numero = "+598" + numero.TrimStart('0');
                }

                string url = $"http://{config.IP}:{config.Puerto}/";
                var json = $"{{\"to\": \"{numero}\", \"message\": \"{mensaje}\"}}";

                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(config.Token);

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);

                string responseText = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    Logger.LogInfo($"SMS enviado correctamente a {numero}. Respuesta: {responseText}");
                    return true;
                }
                else
                {
                    Logger.LogError($"Fallo al enviar SMS a {numero}. Respuesta: {responseText}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError($"Excepción al enviar SMS a {numero}: {ex.Message}");
                MessageBox.Show($"❌ Error al enviar SMS: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Registra en el historial el mensaje enviado, incluyendo destinatario, contenido y fecha/hora.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta al cargar el formulario. Configura y muestra los datos de contacto en la grilla.
        /// </summary>
        private void frmConfirmarEnvio_Load(object sender, EventArgs e)
        {
            CargarFormatos();
        }

        /// <summary>
        /// Carga los formatos de mensaje disponibles en el combo desplegable al iniciar el formulario.
        /// </summary>
        private void CargarFormatos()
        {
            var servicio = new FormatoService();
            var formatos = servicio.ObtenerTodos();

            cmbFormato.DisplayMember = "Nombre";
            cmbFormato.ValueMember = "Id";
            cmbFormato.DataSource = formatos;
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en una celda de la grilla, útil para acciones contextuales como eliminar.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta al cerrar el formulario. Muestra nuevamente el formulario anterior si es necesario.
        /// </summary>
        private void FrmConfirmarEnvio_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Cast<Form>().All(f => !f.Visible))
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se cambia la selección en la grilla de destinatarios.
        /// </summary>
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

        /// <summary>
        /// Evento que se dispara cuando se cambia la opción seleccionada en el combo de formatos.
        /// Actualiza el contenido del mensaje en pantalla.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de limpiar destinatarios seleccionados.
        /// </summary>
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

        /// <summary>
        /// Reconstruye el contenido de la grilla de destinatarios tras cambios en la lista.
        /// </summary>
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


        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de cancelar y cerrar el formulario.
        /// </summary>
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

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para quitar un contacto seleccionado de la lista de envío.
        /// </summary>
        private async void button2_Click(object sender, EventArgs e)
        {
            if (cmbFormato.SelectedItem is not Formato formatoSeleccionado)
            {
                MessageBox.Show("Debe seleccionar un formato antes de enviar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string textoBase = formatoSeleccionado.Cuerpo;

            // Filtrar filas que tengan "Enviar" = true
            var filasParaEnviar = dgvDestinatarios.Rows
                .Cast<DataGridViewRow>()
                .Where(f => f.Cells["Enviar"]?.Value as bool? == true)
                .ToList();

            int loteActual = 1;
            int totalLotes = (int)Math.Ceiling(filasParaEnviar.Count / 20.0);

            progressBarEnvio.Maximum = filasParaEnviar.Count;
            progressBarEnvio.Value = 0;

            DateTime inicio = DateTime.Now;

            for (int i = 0; i < filasParaEnviar.Count; i++)
            {
                if (i > 0 && i % 20 == 0)
                {
                    loteActual++;
                    await Task.Delay(10000); // 10 segundos entre lotes
                }

                var fila = filasParaEnviar[i];

                try
                {
                    string telefono = fila.Cells["Telefono"].Value?.ToString() ?? "";
                    string mensaje = textoBase;

                    var reemplazos = new Dictionary<string, string>();
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        string nombreCol = celda.OwningColumn.Name;
                        if (!string.IsNullOrWhiteSpace(nombreCol) && celda.Value != null)
                        {
                            reemplazos[nombreCol] = celda.Value.ToString();
                        }
                    }

                    foreach (var kv in reemplazos)
                    {
                        mensaje = mensaje.Replace($"{{{kv.Key}}}", kv.Value);
                    }

                    bool exito = await EnviarMensajeAsync(telefono, mensaje);
                    string estado = exito ? "Enviado" : "Error";
                    fila.Cells["Estado"].Value = estado;

                    progressBarEnvio.Value = i + 1;

                    TimeSpan transcurrido = DateTime.Now - inicio;
                    int restantes = filasParaEnviar.Count - (i + 1);
                    TimeSpan estimadoTotal = TimeSpan.FromSeconds(filasParaEnviar.Count * 3 + (totalLotes - 1) * 10);
                    TimeSpan restante = estimadoTotal - transcurrido;

                    lblProgreso.Text = $"Lote {loteActual}/{totalLotes} - " +
                                       $"Mensaje {i + 1}/{filasParaEnviar.Count} - " +
                                       $"Tiempo: {transcurrido:mm\\:ss} / {estimadoTotal:mm\\:ss}";


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

                await Task.Delay(3000); // 3 segundos entre mensajes
            }

            MessageBox.Show("Proceso de envío finalizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Enviar todos".
        /// Envía el mensaje a todos los contactos en la lista de forma asincrónica.
        /// </summary>
        private async void btnEnviarTodos_Click(object sender, EventArgs e)
        {
            if (cmbFormato.SelectedItem is not Formato formatoSeleccionado)
            {
                MessageBox.Show("Debe seleccionar un formato antes de enviar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string textoBase = formatoSeleccionado.Cuerpo;

            // Filtrar filas válidas para enviar
            var filasParaEnviar = dgvDestinatarios.Rows
                .Cast<DataGridViewRow>()
                .Where(f => f.Cells["Telefono"].Value != null && !string.IsNullOrWhiteSpace(f.Cells["Telefono"].Value.ToString()))
                .ToList();

            int loteActual = 1;
            int totalLotes = (int)Math.Ceiling(filasParaEnviar.Count / 20.0);

            progressBarEnvio.Maximum = filasParaEnviar.Count;
            progressBarEnvio.Value = 0;

            DateTime inicio = DateTime.Now;

            for (int i = 0; i < filasParaEnviar.Count; i++)
            {
                if (i > 0 && i % 20 == 0)
                {
                    loteActual++;
                    await Task.Delay(10000); // 10 segundos entre lotes
                }

                var fila = filasParaEnviar[i];

                try
                {
                    string telefono = fila.Cells["Telefono"].Value?.ToString() ?? "";
                    string mensaje = textoBase;

                    var reemplazos = new Dictionary<string, string>();
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        string nombreCol = celda.OwningColumn.Name;
                        if (!string.IsNullOrWhiteSpace(nombreCol) && celda.Value != null)
                        {
                            reemplazos[nombreCol] = celda.Value.ToString();
                        }
                    }

                    foreach (var kv in reemplazos)
                    {
                        mensaje = mensaje.Replace($"{{{kv.Key}}}", kv.Value);
                    }

                    bool exito = await EnviarMensajeAsync(telefono, mensaje);
                    string estado = exito ? "Enviado" : "Error";
                    fila.Cells["Estado"].Value = estado;

                    progressBarEnvio.Value = i + 1;

                    TimeSpan transcurrido = DateTime.Now - inicio;
                    int restantes = filasParaEnviar.Count - (i + 1);
                    TimeSpan estimadoTotal = TimeSpan.FromSeconds(filasParaEnviar.Count * 3 + (totalLotes - 1) * 10);
                    TimeSpan restante = estimadoTotal - transcurrido;

                    lblProgreso.Text = $"Lote {loteActual}/{totalLotes} - " +
                                       $"Mensaje {i + 1}/{filasParaEnviar.Count} - " +
                                       $"Tiempo: {transcurrido:mm\\:ss} / {estimadoTotal:mm\\:ss}";


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

                await Task.Delay(3000); // 3 segundos entre mensajes
            }

            MessageBox.Show("Proceso de envío finalizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }

}