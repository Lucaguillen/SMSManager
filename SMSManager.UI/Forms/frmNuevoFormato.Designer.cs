namespace SMSManager.UI.Forms
{
    partial class frmNuevoFormato
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
            txtNombreFormato = new TextBox();
            label1 = new Label();
            txtCuerpoFormato = new TextBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // txtNombreFormato
            // 
            txtNombreFormato.Location = new Point(34, 28);
            txtNombreFormato.Name = "txtNombreFormato";
            txtNombreFormato.Size = new Size(161, 23);
            txtNombreFormato.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(34, 5);
            label1.Name = "label1";
            label1.Size = new Size(149, 20);
            label1.TabIndex = 1;
            label1.Text = "Nombre del Formato";
            // 
            // txtCuerpoFormato
            // 
            txtCuerpoFormato.Location = new Point(34, 87);
            txtCuerpoFormato.Multiline = true;
            txtCuerpoFormato.Name = "txtCuerpoFormato";
            txtCuerpoFormato.Size = new Size(294, 202);
            txtCuerpoFormato.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(34, 64);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 3;
            label2.Text = "Formato";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 11F);
            button1.Location = new Point(34, 308);
            button1.Name = "button1";
            button1.Size = new Size(75, 31);
            button1.TabIndex = 4;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 11F);
            button2.Location = new Point(252, 308);
            button2.Name = "button2";
            button2.Size = new Size(76, 31);
            button2.TabIndex = 5;
            button2.Text = "Cancelar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 11F);
            button3.Location = new Point(142, 308);
            button3.Name = "button3";
            button3.Size = new Size(75, 31);
            button3.TabIndex = 6;
            button3.Text = "Ayuda";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // frmNuevoFormato
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(371, 348);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(txtCuerpoFormato);
            Controls.Add(label1);
            Controls.Add(txtNombreFormato);
            Name = "frmNuevoFormato";
            Text = "frmNuevoFormato";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreFormato;
        private Label label1;
        private TextBox txtCuerpoFormato;
        private Label label2;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}