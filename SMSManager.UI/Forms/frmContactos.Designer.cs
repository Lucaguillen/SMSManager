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
            dgvContactos = new DataGridView();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnActualizar = new Button();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnImportar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvContactos).BeginInit();
            SuspendLayout();
            // 
            // dgvContactos
            // 
            dgvContactos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContactos.Location = new Point(12, 44);
            dgvContactos.Name = "dgvContactos";
            dgvContactos.Size = new Size(897, 454);
            dgvContactos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 10F);
            btnAgregar.Location = new Point(12, 12);
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
            btnEditar.Location = new Point(118, 12);
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
            btnEliminar.Location = new Point(224, 12);
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
            btnActualizar.Location = new Point(330, 12);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(100, 26);
            btnActualizar.TabIndex = 4;
            btnActualizar.Text = "Actualizar 🔄";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(663, 12);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(140, 25);
            txtBuscar.TabIndex = 6;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 10F);
            btnBuscar.Location = new Point(809, 12);
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
            btnImportar.Location = new Point(436, 12);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(120, 26);
            btnImportar.TabIndex = 8;
            btnImportar.Text = "Importar .csv 📄";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Click += btnImportar_Click;
            // 
            // frmContactos
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 510);
            Controls.Add(btnImportar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnActualizar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvContactos);
            Font = new Font("Segoe UI", 10F);
            Name = "frmContactos";
            Text = "frmContactos";
            Load += frmContactos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvContactos).EndInit();
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
    }
}