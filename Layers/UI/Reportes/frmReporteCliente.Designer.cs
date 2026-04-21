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
            this.txtIentificacionCliente = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnMostrarReporte = new System.Windows.Forms.Button();
            this.rdbOrdenadoCedula = new System.Windows.Forms.RadioButton();
            this.rdbOrdenadoNombre = new System.Windows.Forms.RadioButton();
            this.grbMostrar = new System.Windows.Forms.GroupBox();
            this.rdbCorreo = new System.Windows.Forms.RadioButton();
            this.rdbPantalla = new System.Windows.Forms.RadioButton();
            this.grbOrdenamiento = new System.Windows.Forms.GroupBox();
            this.grbMostrar.SuspendLayout();
            this.grbOrdenamiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 79);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion del Cliente";
            // 
            // txtIentificacionCliente
            // 
            this.txtIentificacionCliente.Location = new System.Drawing.Point(194, 75);
            this.txtIentificacionCliente.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtIentificacionCliente.Name = "txtIentificacionCliente";
            this.txtIentificacionCliente.Size = new System.Drawing.Size(362, 20);
            this.txtIentificacionCliente.TabIndex = 14;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.LightGreen;
            this.btnSalir.Location = new System.Drawing.Point(563, 256);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(71, 30);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnMostrarReporte
            // 
            this.btnMostrarReporte.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnMostrarReporte.Location = new System.Drawing.Point(414, 177);
            this.btnMostrarReporte.Name = "btnMostrarReporte";
            this.btnMostrarReporte.Size = new System.Drawing.Size(130, 50);
            this.btnMostrarReporte.TabIndex = 11;
            this.btnMostrarReporte.Text = "Mostrar Reporte";
            this.btnMostrarReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMostrarReporte.UseVisualStyleBackColor = false;
            // 
            // rdbOrdenadoCedula
            // 
            this.rdbOrdenadoCedula.AutoSize = true;
            this.rdbOrdenadoCedula.Location = new System.Drawing.Point(14, 28);
            this.rdbOrdenadoCedula.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdbOrdenadoCedula.Name = "rdbOrdenadoCedula";
            this.rdbOrdenadoCedula.Size = new System.Drawing.Size(126, 17);
            this.rdbOrdenadoCedula.TabIndex = 7;
            this.rdbOrdenadoCedula.Text = "Ordenado por Cédula";
            this.rdbOrdenadoCedula.UseVisualStyleBackColor = true;
            // 
            // rdbOrdenadoNombre
            // 
            this.rdbOrdenadoNombre.AutoSize = true;
            this.rdbOrdenadoNombre.Location = new System.Drawing.Point(14, 49);
            this.rdbOrdenadoNombre.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdbOrdenadoNombre.Name = "rdbOrdenadoNombre";
            this.rdbOrdenadoNombre.Size = new System.Drawing.Size(130, 17);
            this.rdbOrdenadoNombre.TabIndex = 8;
            this.rdbOrdenadoNombre.Text = "Ordenado por Nombre";
            this.rdbOrdenadoNombre.UseVisualStyleBackColor = true;
            // 
            // grbMostrar
            // 
            this.grbMostrar.Controls.Add(this.rdbCorreo);
            this.grbMostrar.Controls.Add(this.rdbPantalla);
            this.grbMostrar.Location = new System.Drawing.Point(220, 163);
            this.grbMostrar.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grbMostrar.Name = "grbMostrar";
            this.grbMostrar.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grbMostrar.Size = new System.Drawing.Size(137, 81);
            this.grbMostrar.TabIndex = 16;
            this.grbMostrar.TabStop = false;
            this.grbMostrar.Text = "Mostrar";
            // 
            // rdbCorreo
            // 
            this.rdbCorreo.AutoSize = true;
            this.rdbCorreo.Location = new System.Drawing.Point(15, 48);
            this.rdbCorreo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdbCorreo.Name = "rdbCorreo";
            this.rdbCorreo.Size = new System.Drawing.Size(56, 17);
            this.rdbCorreo.TabIndex = 1;
            this.rdbCorreo.Text = "Correo";
            this.rdbCorreo.UseVisualStyleBackColor = true;
            // 
            // rdbPantalla
            // 
            this.rdbPantalla.AutoSize = true;
            this.rdbPantalla.Location = new System.Drawing.Point(15, 26);
            this.rdbPantalla.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.rdbPantalla.Name = "rdbPantalla";
            this.rdbPantalla.Size = new System.Drawing.Size(46, 17);
            this.rdbPantalla.TabIndex = 0;
            this.rdbPantalla.Text = "PDF";
            this.rdbPantalla.UseVisualStyleBackColor = true;
            // 
            // grbOrdenamiento
            // 
            this.grbOrdenamiento.Controls.Add(this.rdbOrdenadoCedula);
            this.grbOrdenamiento.Controls.Add(this.rdbOrdenadoNombre);
            this.grbOrdenamiento.Location = new System.Drawing.Point(46, 163);
            this.grbOrdenamiento.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grbOrdenamiento.Name = "grbOrdenamiento";
            this.grbOrdenamiento.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grbOrdenamiento.Size = new System.Drawing.Size(150, 81);
            this.grbOrdenamiento.TabIndex = 15;
            this.grbOrdenamiento.TabStop = false;
            this.grbOrdenamiento.Text = "Ordenamiento";
            // 
            // frmReporteCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(652, 294);
            this.Controls.Add(this.txtIentificacionCliente);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnMostrarReporte);
            this.Controls.Add(this.grbMostrar);
            this.Controls.Add(this.grbOrdenamiento);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmReporteCliente";
            this.Text = "Reporte de Clientes";
            this.grbMostrar.ResumeLayout(false);
            this.grbMostrar.PerformLayout();
            this.grbOrdenamiento.ResumeLayout(false);
            this.grbOrdenamiento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIentificacionCliente;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnMostrarReporte;
        private System.Windows.Forms.RadioButton rdbOrdenadoCedula;
        private System.Windows.Forms.RadioButton rdbOrdenadoNombre;
        private System.Windows.Forms.GroupBox grbMostrar;
        private System.Windows.Forms.RadioButton rdbCorreo;
        private System.Windows.Forms.RadioButton rdbPantalla;
        private System.Windows.Forms.GroupBox grbOrdenamiento;
    }
}