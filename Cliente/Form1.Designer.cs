namespace Cliente
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnHORA = new System.Windows.Forms.Button();
            this.btnFECHA = new System.Windows.Forms.Button();
            this.btnTODO = new System.Windows.Forms.Button();
            this.btnAPAGAR = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.lblComando = new System.Windows.Forms.Label();
            this.MenuItemParametros = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemParametros});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(525, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnHORA
            // 
            this.btnHORA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHORA.Location = new System.Drawing.Point(137, 158);
            this.btnHORA.Name = "btnHORA";
            this.btnHORA.Size = new System.Drawing.Size(79, 39);
            this.btnHORA.TabIndex = 1;
            this.btnHORA.Tag = "HORA";
            this.btnHORA.Text = "HORA";
            this.btnHORA.UseVisualStyleBackColor = true;
            this.btnHORA.Click += new System.EventHandler(this.pulsarBotonComando);
            // 
            // btnFECHA
            // 
            this.btnFECHA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFECHA.Location = new System.Drawing.Point(259, 158);
            this.btnFECHA.Name = "btnFECHA";
            this.btnFECHA.Size = new System.Drawing.Size(79, 39);
            this.btnFECHA.TabIndex = 2;
            this.btnFECHA.Tag = "FECHA";
            this.btnFECHA.Text = "FECHA";
            this.btnFECHA.UseVisualStyleBackColor = true;
            this.btnFECHA.Click += new System.EventHandler(this.pulsarBotonComando);
            // 
            // btnTODO
            // 
            this.btnTODO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTODO.Location = new System.Drawing.Point(195, 203);
            this.btnTODO.Name = "btnTODO";
            this.btnTODO.Size = new System.Drawing.Size(79, 39);
            this.btnTODO.TabIndex = 3;
            this.btnTODO.Tag = "TODO";
            this.btnTODO.Text = "TODO";
            this.btnTODO.UseVisualStyleBackColor = true;
            this.btnTODO.Click += new System.EventHandler(this.pulsarBotonComando);
            // 
            // btnAPAGAR
            // 
            this.btnAPAGAR.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAPAGAR.Location = new System.Drawing.Point(12, 286);
            this.btnAPAGAR.Name = "btnAPAGAR";
            this.btnAPAGAR.Size = new System.Drawing.Size(91, 39);
            this.btnAPAGAR.TabIndex = 4;
            this.btnAPAGAR.Tag = "APAGAR";
            this.btnAPAGAR.Text = "APAGAR";
            this.btnAPAGAR.UseVisualStyleBackColor = true;
            this.btnAPAGAR.Click += new System.EventHandler(this.pulsarBotonComando);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(13, 131);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(81, 15);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "Aviso de error";
            // 
            // lblComando
            // 
            this.lblComando.AutoSize = true;
            this.lblComando.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblComando.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblComando.Location = new System.Drawing.Point(12, 36);
            this.lblComando.Name = "lblComando";
            this.lblComando.Size = new System.Drawing.Size(82, 20);
            this.lblComando.TabIndex = 8;
            this.lblComando.Text = "Resultado";
            // 
            // MenuItemParametros
            // 
            this.MenuItemParametros.Name = "MenuItemParametros";
            this.MenuItemParametros.Size = new System.Drawing.Size(79, 23);
            this.MenuItemParametros.Text = "Parámetros";
            this.MenuItemParametros.Click += new System.EventHandler(this.MenuItemParametros_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 337);
            this.Controls.Add(this.lblComando);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnAPAGAR);
            this.Controls.Add(this.btnTODO);
            this.Controls.Add(this.btnFECHA);
            this.Controls.Add(this.btnHORA);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Cliente de Hora y Fecha";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnHORA;
        private System.Windows.Forms.Button btnFECHA;
        private System.Windows.Forms.Button btnTODO;
        private System.Windows.Forms.Button btnAPAGAR;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblComando;
        private System.Windows.Forms.ToolStripMenuItem MenuItemParametros;
    }
}

