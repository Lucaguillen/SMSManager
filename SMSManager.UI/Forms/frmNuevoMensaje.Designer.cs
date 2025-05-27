namespace SMSManager.UI.Forms
{
    partial class frmNuevoMensaje
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
            btnContinuar = new Button();
            btnSeleccionarTodos = new Button();
            btnBuscar = new Button();
            txtBuscar = new TextBox();
            btnVolver = new Button();
            btnContactos = new Button();
            btnDeseleccionar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvContactos).BeginInit();
            SuspendLayout();
            // 
            // dgvContactos
            // 
            dgvContactos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContactos.Location = new Point(1, 27);
            dgvContactos.Name = "dgvContactos";
            dgvContactos.Size = new Size(788, 303);
            dgvContactos.TabIndex = 1;
            // 
            // btnContinuar
            // 
            btnContinuar.Font = new Font("Segoe UI", 11F);
            btnContinuar.Location = new Point(634, 336);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(144, 38);
            btnContinuar.TabIndex = 2;
            btnContinuar.Text = "Continuar";
            btnContinuar.UseVisualStyleBackColor = true;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // btnSeleccionarTodos
            // 
            btnSeleccionarTodos.Font = new Font("Segoe UI", 11F);
            btnSeleccionarTodos.Location = new Point(13, 336);
            btnSeleccionarTodos.Name = "btnSeleccionarTodos";
            btnSeleccionarTodos.Size = new Size(164, 38);
            btnSeleccionarTodos.TabIndex = 3;
            btnSeleccionarTodos.Text = "Seleccionar Todos";
            btnSeleccionarTodos.UseVisualStyleBackColor = true;
            btnSeleccionarTodos.Click += btnSeleccionarTodos_Click_1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(326, 363);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(140, 24);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(326, 336);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(140, 23);
            txtBuscar.TabIndex = 5;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(326, 391);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(140, 24);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "VOLVER";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnContactos
            // 
            btnContactos.Font = new Font("Segoe UI", 11F);
            btnContactos.Location = new Point(634, 377);
            btnContactos.Name = "btnContactos";
            btnContactos.Size = new Size(144, 38);
            btnContactos.TabIndex = 8;
            btnContactos.Text = "Volver a Contactos";
            btnContactos.UseVisualStyleBackColor = true;
            btnContactos.Click += button1_Click;
            // 
            // btnDeseleccionar
            // 
            btnDeseleccionar.Font = new Font("Segoe UI", 11F);
            btnDeseleccionar.Location = new Point(13, 378);
            btnDeseleccionar.Name = "btnDeseleccionar";
            btnDeseleccionar.Size = new Size(164, 38);
            btnDeseleccionar.TabIndex = 9;
            btnDeseleccionar.Text = "Deseleccionar Todos";
            btnDeseleccionar.UseVisualStyleBackColor = true;
            btnDeseleccionar.Click += btnDeseleccionar_Click;
            // 
            // frmNuevoMensaje
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(789, 421);
            Controls.Add(btnDeseleccionar);
            Controls.Add(btnContactos);
            Controls.Add(btnVolver);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(btnSeleccionarTodos);
            Controls.Add(btnContinuar);
            Controls.Add(dgvContactos);
            Name = "frmNuevoMensaje";
            Text = "frmNuevoMensaje";
            Load += frmNuevoMensaje_Load;
            Controls.SetChildIndex(dgvContactos, 0);
            Controls.SetChildIndex(btnContinuar, 0);
            Controls.SetChildIndex(btnSeleccionarTodos, 0);
            Controls.SetChildIndex(btnBuscar, 0);
            Controls.SetChildIndex(txtBuscar, 0);
            Controls.SetChildIndex(btnVolver, 0);
            Controls.SetChildIndex(btnContactos, 0);
            Controls.SetChildIndex(btnDeseleccionar, 0);
            ((System.ComponentModel.ISupportInitialize)dgvContactos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnVolver;
        private Button button2;
        private Button btnContinuar;
        private Button btnSeleccionarTodos;
        private DataGridView dgvContactos;
        private Button btnBuscar;
        private TextBox txtBuscar;
        private Button btnContactos;
        private Button btnDeseleccionar;
    }
}