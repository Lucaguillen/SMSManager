namespace SMSManager.UI.Forms
{
    partial class frmAgregarContacto
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            txtCedula = new TextBox();
            lblCedula = new Label();
            btnGuardar = new Button();
            btnCancelar = new Button();
            txtMatricula = new TextBox();
            label1 = new Label();
            txtApellido = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(61, 40);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(151, 37);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 1;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(61, 106);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(151, 103);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(100, 23);
            txtTelefono.TabIndex = 3;
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(151, 137);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(100, 23);
            txtCedula.TabIndex = 5;
            // 
            // lblCedula
            // 
            lblCedula.AutoSize = true;
            lblCedula.Location = new Point(61, 140);
            lblCedula.Name = "lblCedula";
            lblCedula.Size = new Size(44, 15);
            lblCedula.TabIndex = 4;
            lblCedula.Text = "Cédula";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(52, 217);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar 💾";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(162, 217);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(81, 23);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = " Cancelar ❌";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(151, 170);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(100, 23);
            txtMatricula.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 173);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 8;
            label1.Text = "Matricula";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(151, 69);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(100, 23);
            txtApellido.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 72);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 10;
            label2.Text = "Apellido";
            // 
            // frmAgregarContacto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 286);
            Controls.Add(txtApellido);
            Controls.Add(label2);
            Controls.Add(txtMatricula);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtCedula);
            Controls.Add(lblCedula);
            Controls.Add(txtTelefono);
            Controls.Add(lblTelefono);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Name = "frmAgregarContacto";
            Text = "frmAgregarContacto";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private TextBox txtCedula;
        private Label lblCedula;
        private Button btnGuardar;
        private Button btnCancelar;
        private TextBox txtMatricula;
        private Label label1;
        private TextBox txtApellido;
        private Label label2;
    }
}