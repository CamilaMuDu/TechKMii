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
            this.label1.Location = new System.Drawing.Point(87, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descripcion del Cliente";
            // 
            // txtIentificacionCliente
            // 
            this.txtIentificacionCliente.Location = new System.Drawing.Point(388, 145);
            this.txtIentificacionCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtIentificacionCliente.Name = "txtIentificacionCliente";
            this.txtIentificacionCliente.Size = new System.Drawing.Size(720, 31);
            this.txtIentificacionCliente.TabIndex = 14;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(1126, 493);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(142, 57);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnMostrarReporte
            // 
            this.btnMostrarReporte.Location = new System.Drawing.Point(827, 340);
            this.btnMostrarReporte.Margin = new System.Windows.Forms.Padding(6);
            this.btnMostrarReporte.Name = "btnMostrarReporte";
            this.btnMostrarReporte.Size = new System.Drawing.Size(260, 97);
            this.btnMostrarReporte.TabIndex = 11;
            this.btnMostrarReporte.Text = "Mostrar Reporte";
            this.btnMostrarReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMostrarReporte.UseVisualStyleBackColor = true;
            // 
            // rdbOrdenadoCedula
            // 
            this.rdbOrdenadoCedula.AutoSize = true;
            this.rdbOrdenadoCedula.Checked = true;
            this.rdbOrdenadoCedula.Location = new System.Drawing.Point(28, 53);
            this.rdbOrdenadoCedula.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdbOrdenadoCedula.Name = "rdbOrdenadoCedula";
            this.rdbOrdenadoCedula.Size = new System.Drawing.Size(249, 29);
            this.rdbOrdenadoCedula.TabIndex = 7;
            this.rdbOrdenadoCedula.TabStop = true;
            this.rdbOrdenadoCedula.Text = "Ordenado por Cédula";
            this.rdbOrdenadoCedula.UseVisualStyleBackColor = true;
            // 
            // rdbOrdenadoNombre
            // 
            this.rdbOrdenadoNombre.AutoSize = true;
            this.rdbOrdenadoNombre.Location = new System.Drawing.Point(28, 94);
            this.rdbOrdenadoNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdbOrdenadoNombre.Name = "rdbOrdenadoNombre";
            this.rdbOrdenadoNombre.Size = new System.Drawing.Size(256, 29);
            this.rdbOrdenadoNombre.TabIndex = 8;
            this.rdbOrdenadoNombre.TabStop = true;
            this.rdbOrdenadoNombre.Text = "Ordenado por Nombre";
            this.rdbOrdenadoNombre.UseVisualStyleBackColor = true;
            // 
            // grbMostrar
            // 
            this.grbMostrar.Controls.Add(this.rdbCorreo);
            this.grbMostrar.Controls.Add(this.rdbPantalla);
            this.grbMostrar.Location = new System.Drawing.Point(441, 314);
            this.grbMostrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbMostrar.Name = "grbMostrar";
            this.grbMostrar.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbMostrar.Size = new System.Drawing.Size(274, 156);
            this.grbMostrar.TabIndex = 16;
            this.grbMostrar.TabStop = false;
            this.grbMostrar.Text = "Mostrar";
            // 
            // rdbCorreo
            // 
            this.rdbCorreo.AutoSize = true;
            this.rdbCorreo.Location = new System.Drawing.Point(30, 92);
            this.rdbCorreo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdbCorreo.Name = "rdbCorreo";
            this.rdbCorreo.Size = new System.Drawing.Size(108, 29);
            this.rdbCorreo.TabIndex = 1;
            this.rdbCorreo.TabStop = true;
            this.rdbCorreo.Text = "Correo";
            this.rdbCorreo.UseVisualStyleBackColor = true;
            // 
            // rdbPantalla
            // 
            this.rdbPantalla.AutoSize = true;
            this.rdbPantalla.Checked = true;
            this.rdbPantalla.Location = new System.Drawing.Point(30, 50);
            this.rdbPantalla.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rdbPantalla.Name = "rdbPantalla";
            this.rdbPantalla.Size = new System.Drawing.Size(85, 29);
            this.rdbPantalla.TabIndex = 0;
            this.rdbPantalla.TabStop = true;
            this.rdbPantalla.Text = "PDF";
            this.rdbPantalla.UseVisualStyleBackColor = true;
            // 
            // grbOrdenamiento
            // 
            this.grbOrdenamiento.Controls.Add(this.rdbOrdenadoCedula);
            this.grbOrdenamiento.Controls.Add(this.rdbOrdenadoNombre);
            this.grbOrdenamiento.Location = new System.Drawing.Point(92, 314);
            this.grbOrdenamiento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbOrdenamiento.Name = "grbOrdenamiento";
            this.grbOrdenamiento.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbOrdenamiento.Size = new System.Drawing.Size(300, 156);
            this.grbOrdenamiento.TabIndex = 15;
            this.grbOrdenamiento.TabStop = false;
            this.grbOrdenamiento.Text = "Ordenamiento";
            // 
            // frmReporteCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 565);
            this.Controls.Add(this.txtIentificacionCliente);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnMostrarReporte);
            this.Controls.Add(this.grbMostrar);
            this.Controls.Add(this.grbOrdenamiento);
            this.Controls.Add(this.label1);
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