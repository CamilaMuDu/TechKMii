namespace TechKMii.Layers.UI.Reportes
{
    partial class frmReporteCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteCliente));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdentificacionCliente = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnMostrarReporte = new System.Windows.Forms.Button();
            this.rdbOrdenadoCedula = new System.Windows.Forms.RadioButton();
            this.rdbOrdenadoNombre = new System.Windows.Forms.RadioButton();
            this.grbOrdenamiento = new System.Windows.Forms.GroupBox();
            this.grbOrdenamiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion del Cliente";
            // 
            // txtIdentificacionCliente
            // 
            this.txtIdentificacionCliente.Location = new System.Drawing.Point(388, 144);
            this.txtIdentificacionCliente.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtIdentificacionCliente.Name = "txtIdentificacionCliente";
            this.txtIdentificacionCliente.Size = new System.Drawing.Size(720, 31);
            this.txtIdentificacionCliente.TabIndex = 14;
            this.txtIdentificacionCliente.TextChanged += new System.EventHandler(this.txtIentificacionCliente_TextChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSalir.Location = new System.Drawing.Point(1083, 407);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(142, 58);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnMostrarReporte
            // 
            this.btnMostrarReporte.BackColor = System.Drawing.Color.SkyBlue;
            this.btnMostrarReporte.Location = new System.Drawing.Point(714, 267);
            this.btnMostrarReporte.Margin = new System.Windows.Forms.Padding(6);
            this.btnMostrarReporte.Name = "btnMostrarReporte";
            this.btnMostrarReporte.Size = new System.Drawing.Size(260, 96);
            this.btnMostrarReporte.TabIndex = 11;
            this.btnMostrarReporte.Text = "Mostrar Reporte";
            this.btnMostrarReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMostrarReporte.UseVisualStyleBackColor = false;
            this.btnMostrarReporte.Click += new System.EventHandler(this.btnMostrarReporte_Click);
            // 
            // rdbOrdenadoCedula
            // 
            this.rdbOrdenadoCedula.AutoSize = true;
            this.rdbOrdenadoCedula.Location = new System.Drawing.Point(28, 54);
            this.rdbOrdenadoCedula.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rdbOrdenadoCedula.Name = "rdbOrdenadoCedula";
            this.rdbOrdenadoCedula.Size = new System.Drawing.Size(249, 29);
            this.rdbOrdenadoCedula.TabIndex = 7;
            this.rdbOrdenadoCedula.Text = "Ordenado por Cédula";
            this.rdbOrdenadoCedula.UseVisualStyleBackColor = true;
            // 
            // rdbOrdenadoNombre
            // 
            this.rdbOrdenadoNombre.AutoSize = true;
            this.rdbOrdenadoNombre.Location = new System.Drawing.Point(28, 94);
            this.rdbOrdenadoNombre.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rdbOrdenadoNombre.Name = "rdbOrdenadoNombre";
            this.rdbOrdenadoNombre.Size = new System.Drawing.Size(256, 29);
            this.rdbOrdenadoNombre.TabIndex = 8;
            this.rdbOrdenadoNombre.Text = "Ordenado por Nombre";
            this.rdbOrdenadoNombre.UseVisualStyleBackColor = true;
            // 
            // grbOrdenamiento
            // 
            this.grbOrdenamiento.Controls.Add(this.rdbOrdenadoCedula);
            this.grbOrdenamiento.Controls.Add(this.rdbOrdenadoNombre);
            this.grbOrdenamiento.Location = new System.Drawing.Point(93, 247);
            this.grbOrdenamiento.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.grbOrdenamiento.Name = "grbOrdenamiento";
            this.grbOrdenamiento.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.grbOrdenamiento.Size = new System.Drawing.Size(300, 148);
            this.grbOrdenamiento.TabIndex = 15;
            this.grbOrdenamiento.TabStop = false;
            this.grbOrdenamiento.Text = "Ordenamiento";
            // 
            // frmReporteCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(1240, 480);
            this.Controls.Add(this.txtIdentificacionCliente);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnMostrarReporte);
            this.Controls.Add(this.grbOrdenamiento);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmReporteCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Clientes";
            this.Load += new System.EventHandler(this.frmReporteCliente_Load);
            this.grbOrdenamiento.ResumeLayout(false);
            this.grbOrdenamiento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdentificacionCliente;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnMostrarReporte;
        private System.Windows.Forms.RadioButton rdbOrdenadoCedula;
        private System.Windows.Forms.RadioButton rdbOrdenadoNombre;
        private System.Windows.Forms.GroupBox grbOrdenamiento;
    }
}