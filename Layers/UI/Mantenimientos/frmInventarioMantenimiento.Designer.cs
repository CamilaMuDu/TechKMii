namespace TechKMii.Layers.UI.Mantenimientos
{
    partial class frmInventarioMantenimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioMantenimiento));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbBorrar = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.dgvDatosInventario = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnGuardarMovimiento = new System.Windows.Forms.Button();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtStockActual = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosInventario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Plum;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbBorrar,
            this.tsbSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(1357, 42);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(121, 36);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(110, 36);
            this.tsbEditar.Text = "Editar";
            // 
            // tsbBorrar
            // 
            this.tsbBorrar.Image = ((System.Drawing.Image)(resources.GetObject("tsbBorrar.Image")));
            this.tsbBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBorrar.Name = "tsbBorrar";
            this.tsbBorrar.Size = new System.Drawing.Size(114, 36);
            this.tsbBorrar.Text = "Borrar";
            // 
            // tsbSalir
            // 
            this.tsbSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalir.Image")));
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(95, 36);
            this.tsbSalir.Text = "Salir";
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(816, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Movimiento";
            // 
            // cmbTipoMovimiento
            // 
            this.cmbTipoMovimiento.FormattingEnabled = true;
            this.cmbTipoMovimiento.Location = new System.Drawing.Point(986, 102);
            this.cmbTipoMovimiento.Name = "cmbTipoMovimiento";
            this.cmbTipoMovimiento.Size = new System.Drawing.Size(321, 33);
            this.cmbTipoMovimiento.TabIndex = 3;
            // 
            // dgvDatosInventario
            // 
            this.dgvDatosInventario.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatosInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosInventario.Location = new System.Drawing.Point(28, 465);
            this.dgvDatosInventario.Name = "dgvDatosInventario";
            this.dgvDatosInventario.RowHeadersWidth = 82;
            this.dgvDatosInventario.RowTemplate.Height = 33;
            this.dgvDatosInventario.Size = new System.Drawing.Size(1279, 768);
            this.dgvDatosInventario.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Producto";
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(193, 99);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(336, 31);
            this.txtProducto.TabIndex = 6;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Plum;
            this.btnBuscar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBuscar.Location = new System.Drawing.Point(550, 80);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(148, 50);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(816, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cantidad";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(986, 261);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(138, 31);
            this.nudCantidad.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(193, 261);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(408, 31);
            this.dtpFecha.TabIndex = 11;
            // 
            // btnGuardarMovimiento
            // 
            this.btnGuardarMovimiento.BackColor = System.Drawing.Color.Plum;
            this.btnGuardarMovimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarMovimiento.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnGuardarMovimiento.Location = new System.Drawing.Point(475, 365);
            this.btnGuardarMovimiento.Name = "btnGuardarMovimiento";
            this.btnGuardarMovimiento.Size = new System.Drawing.Size(333, 81);
            this.btnGuardarMovimiento.TabIndex = 12;
            this.btnGuardarMovimiento.Text = "Guardar Movimiento";
            this.btnGuardarMovimiento.UseVisualStyleBackColor = false;
            this.btnGuardarMovimiento.Click += new System.EventHandler(this.btnGuardarMovimiento_Click);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(986, 183);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(321, 31);
            this.txtMotivo.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(816, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Motivo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Stock Actural";
            // 
            // txtStockActual
            // 
            this.txtStockActual.Location = new System.Drawing.Point(193, 182);
            this.txtStockActual.Name = "txtStockActual";
            this.txtStockActual.ReadOnly = true;
            this.txtStockActual.Size = new System.Drawing.Size(336, 31);
            this.txtStockActual.TabIndex = 16;
            // 
            // frmInventarioMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1357, 1307);
            this.Controls.Add(this.txtStockActual);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGuardarMovimiento);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvDatosInventario);
            this.Controls.Add(this.cmbTipoMovimiento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmInventarioMantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Inventario de Productos";
            this.Load += new System.EventHandler(this.frmInventarioMantenimiento_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosInventario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbBorrar;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoMovimiento;
        private System.Windows.Forms.DataGridView dgvDatosInventario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnGuardarMovimiento;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtStockActual;
    }
}