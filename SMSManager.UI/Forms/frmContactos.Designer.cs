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
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvContactos).BeginInit();
            SuspendLayout();
            // 
            // dgvContactos
            // 
            dgvContactos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContactos.Location = new Point(12, 58);
            dgvContactos.Name = "dgvContactos";
            dgvContactos.Size = new Size(902, 454);
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
            txtBuscar.Location = new Point(562, 27);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(140, 25);
            txtBuscar.TabIndex = 6;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Segoe UI", 10F);
            btnBuscar.Location = new Point(708, 26);
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
            // btnVolver
            // 
            btnVolver.Font = new Font("Segoe UI", 10F);
            btnVolver.Location = new Point(814, 26);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(100, 26);
            btnVolver.TabIndex = 9;
            btnVolver.Text = "Volver ⬅️";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // frmContactos
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(923, 521);
            Controls.Add(btnVolver);
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
            Controls.SetChildIndex(dgvContactos, 0);
            Controls.SetChildIndex(btnAgregar, 0);
            Controls.SetChildIndex(btnEditar, 0);
            Controls.SetChildIndex(btnEliminar, 0);
            Controls.SetChildIndex(btnActualizar, 0);
            Controls.SetChildIndex(txtBuscar, 0);
            Controls.SetChildIndex(btnBuscar, 0);
            Controls.SetChildIndex(btnImportar, 0);
            Controls.SetChildIndex(btnVolver, 0);
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
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private Button btnVolver;
    }
}