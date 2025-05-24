namespace SMSManager.UI.Forms
{
    partial class frmContactos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            dgvContactos = new DataGridView();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnImportar = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            menuStrip1 = new MenuStrip();
            contactosToolStripMenuItem = new ToolStripMenuItem();
            mensajesToolStripMenuItem = new ToolStripMenuItem();
            nuevoMensajeToolStripMenuItem = new ToolStripMenuItem();
            nuevoCuerpoDeMensajeToolStripMenuItem = new ToolStripMenuItem();
            verFormatosToolStripMenuItem = new ToolStripMenuItem();
            configuracionToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dgvContactos).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvContactos
            // 
            dgvContactos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContactos.Location = new Point(12, 58);
            dgvContactos.Name = "dgvContactos";
            dgvContactos.Size = new Size(897, 454);
            dgvContactos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 10F);
            btnAgregar.Location = new Point(12, 26);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 26);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar ➕";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Segoe UI", 10F);
            btnEditar.Location = new Point(118, 26);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 26);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "Editar 📝";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 10F);
            btnEliminar.Location = new Point(224, 26);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(100, 26);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar 🗑️";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Font = new Font("Segoe UI", 10F);
            btnActualizar.Location = new Point(330, 26);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 26);
            btnActualizar.TabIndex = 4;
            btnActualizar.Text = "Actualizar 🔄";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(663, 26);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(140, 25);
            txtBuscar.TabIndex = 6;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 10F);
            btnBuscar.Location = new Point(809, 26);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 26);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar 🔍";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnImportar
            // 
            btnImportar.Font = new Font("Segoe UI", 10F);
            btnImportar.Location = new Point(436, 26);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(120, 26);
            btnImportar.TabIndex = 8;
            btnImportar.Text = "Importar .csv 📄";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { contactosToolStripMenuItem, mensajesToolStripMenuItem, configuracionToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(924, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // contactosToolStripMenuItem
            // 
            contactosToolStripMenuItem.Name = "contactosToolStripMenuItem";
            contactosToolStripMenuItem.Size = new Size(73, 20);
            contactosToolStripMenuItem.Text = "Contactos";
            // 
            // mensajesToolStripMenuItem
            // 
            mensajesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevoMensajeToolStripMenuItem, nuevoCuerpoDeMensajeToolStripMenuItem, verFormatosToolStripMenuItem });
            mensajesToolStripMenuItem.Name = "mensajesToolStripMenuItem";
            mensajesToolStripMenuItem.Size = new Size(68, 20);
            mensajesToolStripMenuItem.Text = "Mensajes";
            // 
            // nuevoMensajeToolStripMenuItem
            // 
            nuevoMensajeToolStripMenuItem.Name = "nuevoMensajeToolStripMenuItem";
            nuevoMensajeToolStripMenuItem.Size = new Size(214, 22);
            nuevoMensajeToolStripMenuItem.Text = "Nuevo Mensaje";
            // 
            // nuevoCuerpoDeMensajeToolStripMenuItem
            // 
            nuevoCuerpoDeMensajeToolStripMenuItem.Name = "nuevoCuerpoDeMensajeToolStripMenuItem";
            nuevoCuerpoDeMensajeToolStripMenuItem.Size = new Size(157, 22);
            nuevoCuerpoDeMensajeToolStripMenuItem.Text = "Nuevo Formato";
            nuevoCuerpoDeMensajeToolStripMenuItem.Click += nuevoCuerpoDeMensajeToolStripMenuItem_Click;
            // 
            // verFormatosToolStripMenuItem
            // 
            verFormatosToolStripMenuItem.Name = "verFormatosToolStripMenuItem";
            verFormatosToolStripMenuItem.Size = new Size(214, 22);
            verFormatosToolStripMenuItem.Text = "Ver Formatos";
            // 
            // configuracionToolStripMenuItem
            // 
            configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            configuracionToolStripMenuItem.Size = new Size(95, 20);
            configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // frmContactos
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 521);
            Controls.Add(menuStrip1);
            Controls.Add(btnImportar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvContactos);
            Font = new Font("Segoe UI", 10F);
            MainMenuStrip = menuStrip1;
            Name = "frmContactos";
            Text = "frmContactos";
            Load += frmContactos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvContactos).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvContactos;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnActualizar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnImportar;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem contactosToolStripMenuItem;
        private ToolStripMenuItem mensajesToolStripMenuItem;
        private ToolStripMenuItem nuevoMensajeToolStripMenuItem;
        private ToolStripMenuItem nuevoCuerpoDeMensajeToolStripMenuItem;
        private ToolStripMenuItem verFormatosToolStripMenuItem;
        private ToolStripMenuItem configuracionToolStripMenuItem;
    }
}