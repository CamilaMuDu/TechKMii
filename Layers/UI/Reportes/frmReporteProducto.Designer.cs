namespace TechKMii.Layers.UI.Reportes
{
    partial class frmReporteProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteProducto));
            this.txtDescripcionProducto = new System.Windows.Forms.TextBox();
            this.lblDescripcionProducto = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnMostrarReporte = new System.Windows.Forms.Button();
            this.grbOrdenamiento = new System.Windows.Forms.GroupBox();
            this.rdbOrdenadoProveedor = new System.Windows.Forms.RadioButton();
            this.rdbOrdenadoMarca = new System.Windows.Forms.RadioButton();
            this.rdbOrdenadoTipoDispositivo = new System.Windows.Forms.RadioButton();
            this.grbOrdenamiento.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescripcionProducto
            // 
            this.txtDescripcionProducto.Location = new System.Drawing.Point(408, 119);
            this.txtDescripcionProducto.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtDescripcionProducto.Name = "txtDescripcionProducto";
            this.txtDescripcionProducto.Size = new System.Drawing.Size(506, 31);
            this.txtDescripcionProducto.TabIndex = 4;
            this.txtDescripcionProducto.TextChanged += new System.EventHandler(this.txtDescripcionProducto_TextChanged);
            // 
            // lblDescripcionProducto
            // 
            this.lblDescripcionProducto.AutoSize = true;
            this.lblDescripcionProducto.BackColor = System.Drawing.SystemColors.Control;
            this.lblDescripcionProducto.Location = new System.Drawing.Point(60, 119);
            this.lblDescripcionProducto.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblDescripcionProducto.Name = "lblDescripcionProducto";
            this.lblDescripcionProducto.Size = new System.Drawing.Size(252, 25);
            this.lblDescripcionProducto.TabIndex = 8;
            this.lblDescripcionProducto.Text = "Descripción del Producto";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.LightGreen;
            this.btnSalir.Location = new System.Drawing.Point(1016, 433);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 58);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnMostrarReporte
            // 
            this.btnMostrarReporte.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnMostrarReporte.Location = new System.Drawing.Point(642, 258);
            this.btnMostrarReporte.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnMostrarReporte.Name = "btnMostrarReporte";
            this.btnMostrarReporte.Size = new System.Drawing.Size(272, 113);
            this.btnMostrarReporte.TabIndex = 6;
            this.btnMostrarReporte.Text = "Mostrar Reporte";
            this.btnMostrarReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMostrarReporte.UseVisualStyleBackColor = false;
            this.btnMostrarReporte.Click += new System.EventHandler(this.btnMostrarReporte_Click);
            // 
            // grbOrdenamiento
            // 
            this.grbOrdenamiento.BackColor = System.Drawing.SystemColors.Control;
            this.grbOrdenamiento.Controls.Add(this.rdbOrdenadoProveedor);
            this.grbOrdenamiento.Controls.Add(this.rdbOrdenadoMarca);
            this.grbOrdenamiento.Controls.Add(this.rdbOrdenadoTipoDispositivo);
            this.grbOrdenamiento.Location = new System.Drawing.Point(64, 210);
            this.grbOrdenamiento.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.grbOrdenamiento.Name = "grbOrdenamiento";
            this.grbOrdenamiento.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.grbOrdenamiento.Size = new System.Drawing.Size(428, 190);
            this.grbOrdenamiento.TabIndex = 16;
            this.grbOrdenamiento.TabStop = false;
            this.grbOrdenamiento.Text = "Ordenamiento";
            // 
            // rdbOrdenadoProveedor
            // 
            this.rdbOrdenadoProveedor.AutoSize = true;
            this.rdbOrdenadoProveedor.Location = new System.Drawing.Point(28, 133);
            this.rdbOrdenadoProveedor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rdbOrdenadoProveedor.Name = "rdbOrdenadoProveedor";
            this.rdbOrdenadoProveedor.Size = new System.Drawing.Size(278, 29);
            this.rdbOrdenadoProveedor.TabIndex = 9;
            this.rdbOrdenadoProveedor.TabStop = true;
            this.rdbOrdenadoProveedor.Text = "Ordenado por proveedor";
            this.rdbOrdenadoProveedor.UseVisualStyleBackColor = true;
            // 
            // rdbOrdenadoMarca
            // 
            this.rdbOrdenadoMarca.AutoSize = true;
            this.rdbOrdenadoMarca.Location = new System.Drawing.Point(28, 54);
            this.rdbOrdenadoMarca.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rdbOrdenadoMarca.Name = "rdbOrdenadoMarca";
            this.rdbOrdenadoMarca.Size = new System.Drawing.Size(240, 29);
            this.rdbOrdenadoMarca.TabIndex = 7;
            this.rdbOrdenadoMarca.Text = "Ordenado por marca";
            this.rdbOrdenadoMarca.UseVisualStyleBackColor = true;
            this.rdbOrdenadoMarca.CheckedChanged += new System.EventHandler(this.rdbOrdenadoCedula_CheckedChanged);
            // 
            // rdbOrdenadoTipoDispositivo
            // 
            this.rdbOrdenadoTipoDispositivo.AutoSize = true;
            this.rdbOrdenadoTipoDispositivo.Location = new System.Drawing.Point(28, 94);
            this.rdbOrdenadoTipoDispositivo.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.rdbOrdenadoTipoDispositivo.Name = "rdbOrdenadoTipoDispositivo";
            this.rdbOrdenadoTipoDispositivo.Size = new System.Drawing.Size(357, 29);
            this.rdbOrdenadoTipoDispositivo.TabIndex = 8;
            this.rdbOrdenadoTipoDispositivo.TabStop = true;
            this.rdbOrdenadoTipoDispositivo.Text = "Ordenado por tipo de Dispositivo";
            this.rdbOrdenadoTipoDispositivo.UseVisualStyleBackColor = true;
            // 
            // frmReporteProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(1170, 506);
            this.Controls.Add(this.grbOrdenamiento);
            this.Controls.Add(this.txtDescripcionProducto);
            this.Controls.Add(this.lblDescripcionProducto);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnMostrarReporte);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmReporteProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de Productos";
            this.Load += new System.EventHandler(this.frmReporteProducto_Load);
            this.grbOrdenamiento.ResumeLayout(false);
            this.grbOrdenamiento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescripcionProducto;
        private System.Windows.Forms.Label lblDescripcionProducto;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnMostrarReporte;
        private System.Windows.Forms.GroupBox grbOrdenamiento;
        private System.Windows.Forms.RadioButton rdbOrdenadoMarca;
        private System.Windows.Forms.RadioButton rdbOrdenadoTipoDispositivo;
        private System.Windows.Forms.RadioButton rdbOrdenadoProveedor;
    }
}