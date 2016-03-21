namespace LainsaSciTerminal
{
    partial class CambioForm
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
            this.mnuMain = new System.Windows.Forms.MainMenu();
            this.mnuSalir = new System.Windows.Forms.MenuItem();
            this.mnuGeneral = new System.Windows.Forms.MenuItem();
            this.lblCaptura = new System.Windows.Forms.Label();
            this.txtCaptura = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSustituto = new System.Windows.Forms.TextBox();
            this.lblSustituto = new System.Windows.Forms.Label();
            this.lblInfOriginal = new System.Windows.Forms.Label();
            this.lblInfSustituto = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblComentario = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.MenuItems.Add(this.mnuSalir);
            this.mnuMain.MenuItems.Add(this.mnuGeneral);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Text = "Atrás";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuGeneral
            // 
            this.mnuGeneral.Text = "Aceptar";
            this.mnuGeneral.Click += new System.EventHandler(this.mnuGeneral_Click);
            // 
            // lblCaptura
            // 
            this.lblCaptura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCaptura.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblCaptura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCaptura.Location = new System.Drawing.Point(21, 13);
            this.lblCaptura.Name = "lblCaptura";
            this.lblCaptura.Size = new System.Drawing.Size(202, 25);
            this.lblCaptura.Text = "Dispositivo a sustituir";
            this.lblCaptura.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtCaptura
            // 
            this.txtCaptura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCaptura.Location = new System.Drawing.Point(21, 41);
            this.txtCaptura.Name = "txtCaptura";
            this.txtCaptura.Size = new System.Drawing.Size(114, 21);
            this.txtCaptura.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(141, 43);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(76, 19);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(141, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "ACEPTAR";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSustituto
            // 
            this.txtSustituto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSustituto.Location = new System.Drawing.Point(21, 145);
            this.txtSustituto.Name = "txtSustituto";
            this.txtSustituto.Size = new System.Drawing.Size(114, 21);
            this.txtSustituto.TabIndex = 3;
            // 
            // lblSustituto
            // 
            this.lblSustituto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSustituto.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblSustituto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSustituto.Location = new System.Drawing.Point(21, 117);
            this.lblSustituto.Name = "lblSustituto";
            this.lblSustituto.Size = new System.Drawing.Size(202, 25);
            this.lblSustituto.Text = "Dispositivo sustiuto";
            this.lblSustituto.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblInfOriginal
            // 
            this.lblInfOriginal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfOriginal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lblInfOriginal.ForeColor = System.Drawing.Color.DimGray;
            this.lblInfOriginal.Location = new System.Drawing.Point(21, 65);
            this.lblInfOriginal.Name = "lblInfOriginal";
            this.lblInfOriginal.Size = new System.Drawing.Size(202, 43);
            this.lblInfOriginal.Text = "Dispositivo a sustituir";
            // 
            // lblInfSustituto
            // 
            this.lblInfSustituto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfSustituto.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lblInfSustituto.ForeColor = System.Drawing.Color.DimGray;
            this.lblInfSustituto.Location = new System.Drawing.Point(21, 169);
            this.lblInfSustituto.Name = "lblInfSustituto";
            this.lblInfSustituto.Size = new System.Drawing.Size(202, 37);
            this.lblInfSustituto.Text = "Dispositivo sustituto";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.txtComentario);
            this.panel4.Controls.Add(this.lblComentario);
            this.panel4.Location = new System.Drawing.Point(0, 218);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(240, 50);
            // 
            // txtComentario
            // 
            this.txtComentario.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtComentario.Location = new System.Drawing.Point(0, 17);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(240, 26);
            this.txtComentario.TabIndex = 5;
            // 
            // lblComentario
            // 
            this.lblComentario.BackColor = System.Drawing.Color.White;
            this.lblComentario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblComentario.Location = new System.Drawing.Point(0, 0);
            this.lblComentario.Name = "lblComentario";
            this.lblComentario.Size = new System.Drawing.Size(240, 17);
            this.lblComentario.Text = "Comentarios:";
            // 
            // CambioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblInfSustituto);
            this.Controls.Add(this.lblInfOriginal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSustituto);
            this.Controls.Add(this.lblSustituto);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtCaptura);
            this.Controls.Add(this.lblCaptura);
            this.Menu = this.mnuMain;
            this.Name = "CambioForm";
            this.Text = "FALCK-SUSTITUCIÓN";
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mnuMain;
        private System.Windows.Forms.MenuItem mnuSalir;
        private System.Windows.Forms.MenuItem mnuGeneral;
        private System.Windows.Forms.Label lblCaptura;
        private System.Windows.Forms.TextBox txtCaptura;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSustituto;
        private System.Windows.Forms.Label lblSustituto;
        private System.Windows.Forms.Label lblInfOriginal;
        private System.Windows.Forms.Label lblInfSustituto;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label lblComentario;
    }
}