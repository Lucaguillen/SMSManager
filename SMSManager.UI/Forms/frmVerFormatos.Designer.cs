namespace SMSManager.UI.Forms
{
    partial class frmVerFormatos
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
            dgvFormatos = new DataGridView();
            btnNuevoFormato = new Button();
            btnEliminarFormato = new Button();
            btnActualizarFormatos = new Button();
            btnEditarFormato = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFormatos).BeginInit();
            SuspendLayout();
            // 
            // dgvFormatos
            // 
            dgvFormatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFormatos.Location = new Point(0, 47);
            dgvFormatos.Name = "dgvFormatos";
            dgvFormatos.Size = new Size(702, 312);
            dgvFormatos.TabIndex = 0;
            // 
            // btnNuevoFormato
            // 
            btnNuevoFormato.Font = new Font("Segoe UI", 11F);
            btnNuevoFormato.Location = new Point(158, 365);
            btnNuevoFormato.Name = "btnNuevoFormato";
            btnNuevoFormato.Size = new Size(96, 29);
            btnNuevoFormato.TabIndex = 1;
            btnNuevoFormato.Text = "Agregar ➕";
            btnNuevoFormato.UseVisualStyleBackColor = true;
            btnNuevoFormato.Click += btnNuevoFormato_Click;
            // 
            // btnEliminarFormato
            // 
            btnEliminarFormato.Font = new Font("Segoe UI", 11F);
            btnEliminarFormato.Location = new Point(260, 365);
            btnEliminarFormato.Name = "btnEliminarFormato";
            btnEliminarFormato.Size = new Size(96, 29);
            btnEliminarFormato.TabIndex = 2;
            btnEliminarFormato.Text = "Eliminar 🗑️";
            btnEliminarFormato.UseVisualStyleBackColor = true;
            btnEliminarFormato.Click += btnEliminarFormato_Click;
            // 
            // btnActualizarFormatos
            // 
            btnActualizarFormatos.Font = new Font("Segoe UI", 11F);
            btnActualizarFormatos.Location = new Point(362, 366);
            btnActualizarFormatos.Name = "btnActualizarFormatos";
            btnActualizarFormatos.Size = new Size(113, 29);
            btnActualizarFormatos.TabIndex = 3;
            btnActualizarFormatos.Text = "Actualizar 🔄";
            btnActualizarFormatos.UseVisualStyleBackColor = true;
            btnActualizarFormatos.Click += btnActualizarFormatos_Click;
            // 
            // btnEditarFormato
            // 
            btnEditarFormato.Font = new Font("Segoe UI", 11F);
            btnEditarFormato.Location = new Point(481, 365);
            btnEditarFormato.Name = "btnEditarFormato";
            btnEditarFormato.Size = new Size(96, 29);
            btnEditarFormato.TabIndex = 4;
            btnEditarFormato.Text = "Editar 📝";
            btnEditarFormato.UseVisualStyleBackColor = true;
            btnEditarFormato.Click += btnEditarFormato_Click;
            // 
            // frmVerFormatos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 400);
            Controls.Add(btnEditarFormato);
            Controls.Add(btnActualizarFormatos);
            Controls.Add(btnEliminarFormato);
            Controls.Add(btnNuevoFormato);
            Controls.Add(dgvFormatos);
            Name = "frmVerFormatos";
            Text = "frmVerFormatos";
            Controls.SetChildIndex(dgvFormatos, 0);
            Controls.SetChildIndex(btnNuevoFormato, 0);
            Controls.SetChildIndex(btnEliminarFormato, 0);
            Controls.SetChildIndex(btnActualizarFormatos, 0);
            Controls.SetChildIndex(btnEditarFormato, 0);
            ((System.ComponentModel.ISupportInitialize)dgvFormatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFormatos;
        private Button btnNuevoFormato;
        private Button btnEliminarFormato;
        private Button btnActualizarFormatos;
        private Button btnEditarFormato;
    }
}