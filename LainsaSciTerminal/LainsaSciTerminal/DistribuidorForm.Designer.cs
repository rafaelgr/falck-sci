namespace LainsaSciTerminal
{
    partial class DistribuidorForm
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
            this.lblMensajeEspera = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblMensajeEspera
            // 
            this.lblMensajeEspera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMensajeEspera.Location = new System.Drawing.Point(0, 0);
            this.lblMensajeEspera.Name = "lblMensajeEspera";
            this.lblMensajeEspera.Size = new System.Drawing.Size(240, 294);
            this.lblMensajeEspera.Text = "Cargando datos, espere por favor...";
            this.lblMensajeEspera.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DistribuidorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.lblMensajeEspera);
            this.Name = "DistribuidorForm";
            this.Text = "Espere...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMensajeEspera;
    }
}