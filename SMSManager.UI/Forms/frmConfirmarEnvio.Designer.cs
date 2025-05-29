namespace SMSManager.UI.Forms
{
    partial class frmConfirmarEnvio
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
            cmbFormato = new ComboBox();
            label1 = new Label();
            dgvDestinatarios = new DataGridView();
            txtVistaPrevia = new TextBox();
            btnEnviarTodos = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            progressBarEnvio = new ProgressBar();
            lblProgreso = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDestinatarios).BeginInit();
            SuspendLayout();
            // 
            // cmbFormato
            // 
            cmbFormato.FormattingEnabled = true;
            cmbFormato.Location = new Point(149, 6);
            cmbFormato.Name = "cmbFormato";
            cmbFormato.Size = new Size(121, 23);
            cmbFormato.TabIndex = 0;
            cmbFormato.SelectedIndexChanged += cmbFormato_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(131, 15);
            label1.TabIndex = 1;
            label1.Text = "Seleccione un Formato:";
            // 
            // dgvDestinatarios
            // 
            dgvDestinatarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDestinatarios.Location = new Point(12, 35);
            dgvDestinatarios.Name = "dgvDestinatarios";
            dgvDestinatarios.Size = new Size(767, 363);
            dgvDestinatarios.TabIndex = 2;
            // 
            // txtVistaPrevia
            // 
            txtVistaPrevia.Location = new Point(12, 444);
            txtVistaPrevia.Multiline = true;
            txtVistaPrevia.Name = "txtVistaPrevia";
            txtVistaPrevia.ReadOnly = true;
            txtVistaPrevia.Size = new Size(612, 110);
            txtVistaPrevia.TabIndex = 3;
            // 
            // btnEnviarTodos
            // 
            btnEnviarTodos.Location = new Point(630, 444);
            btnEnviarTodos.Name = "btnEnviarTodos";
            btnEnviarTodos.Size = new Size(149, 23);
            btnEnviarTodos.TabIndex = 4;
            btnEnviarTodos.Text = "Enviar a Todos";
            btnEnviarTodos.UseVisualStyleBackColor = true;
            btnEnviarTodos.Click += btnEnviarTodos_Click;
            // 
            // button2
            // 
            button2.Location = new Point(630, 473);
            button2.Name = "button2";
            button2.Size = new Size(149, 23);
            button2.TabIndex = 5;
            button2.Text = "Enviar a Seleccionados";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(630, 531);
            button3.Name = "button3";
            button3.Size = new Size(149, 23);
            button3.TabIndex = 6;
            button3.Text = "Cancelar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(630, 502);
            button4.Name = "button4";
            button4.Size = new Size(149, 23);
            button4.TabIndex = 7;
            button4.Text = "Deseleccionar Todos";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // progressBarEnvio
            // 
            progressBarEnvio.Location = new Point(12, 402);
            progressBarEnvio.Name = "progressBarEnvio";
            progressBarEnvio.Size = new Size(767, 23);
            progressBarEnvio.Style = ProgressBarStyle.Continuous;
            progressBarEnvio.TabIndex = 8;
            progressBarEnvio.Tag = "";
            // 
            // lblProgreso
            // 
            lblProgreso.AutoSize = true;
            lblProgreso.Location = new Point(257, 428);
            lblProgreso.Name = "lblProgreso";
            lblProgreso.Size = new Size(247, 15);
            lblProgreso.TabIndex = 9;
            lblProgreso.Text = "Lote 0/0 - Mensaje 0/0 - Tiempo: 00:00 / 00:00";
            // 
            // frmConfirmarEnvio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 558);
            Controls.Add(lblProgreso);
            Controls.Add(progressBarEnvio);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(btnEnviarTodos);
            Controls.Add(txtVistaPrevia);
            Controls.Add(dgvDestinatarios);
            Controls.Add(label1);
            Controls.Add(cmbFormato);
            Name = "frmConfirmarEnvio";
            Text = "frmConfirmarEnvio";
            ((System.ComponentModel.ISupportInitialize)dgvDestinatarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbFormato;
        private Label label1;
        private DataGridView dgvDestinatarios;
        private TextBox txtVistaPrevia;
        private Button btnEnviarTodos;
        private Button button2;
        private Button button3;
        private Button button4;
        private ProgressBar progressBarEnvio;
        private Label lblProgreso;
    }
}