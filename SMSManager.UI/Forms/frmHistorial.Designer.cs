namespace SMSManager.UI.Forms
{
    partial class frmHistorial
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
            dgvHistorial = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // dgvHistorial
            // 
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(1, 1);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.Size = new Size(799, 449);
            dgvHistorial.TabIndex = 0;
            // 
            // frmHistorial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvHistorial);
            Name = "frmHistorial";
            Text = "frmHistorial";
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvHistorial;
    }
}