namespace SMSManager.UI.Forms
{
    partial class frmConfiguracionApi
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtIP = new TextBox();
            txtPuerto = new TextBox();
            txtToken = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 0;
            label1.Text = "IP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(12, 52);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 1;
            label2.Text = "Puerto:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(12, 92);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 2;
            label3.Text = "Token:";
            // 
            // txtIP
            // 
            txtIP.Location = new Point(83, 14);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(206, 23);
            txtIP.TabIndex = 3;
            // 
            // txtPuerto
            // 
            txtPuerto.Location = new Point(83, 52);
            txtPuerto.Name = "txtPuerto";
            txtPuerto.Size = new Size(100, 23);
            txtPuerto.TabIndex = 4;
            // 
            // txtToken
            // 
            txtToken.Location = new Point(83, 93);
            txtToken.Multiline = true;
            txtToken.Name = "txtToken";
            txtToken.Size = new Size(206, 92);
            txtToken.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(83, 211);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 6;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnGuardar_Click;
            // 
            // button2
            // 
            button2.Location = new Point(164, 211);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 7;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += btnCancelar_Click;
            // 
            // frmConfiguracionApi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 250);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtToken);
            Controls.Add(txtPuerto);
            Controls.Add(txtIP);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmConfiguracionApi";
            Text = "frmConfiguracionApi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtIP;
        private TextBox txtPuerto;
        private TextBox txtToken;
        private Button button1;
        private Button button2;
    }
}