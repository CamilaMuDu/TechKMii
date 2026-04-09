namespace TechKMii.Layers.UI.Mantenimientos.Filtros
{
    partial class frmProductoFiltro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductoFiltro));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tspNuevo = new System.Windows.Forms.ToolStripButton();
            this.tspBuscarProducto = new System.Windows.Forms.ToolStripButton();
            this.tspSalir = new System.Windows.Forms.ToolStripButton();
            this.dgvBuscar = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscar)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspNuevo,
            this.tspBuscarProducto,
            this.tspSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1185, 42);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tspNuevo
            // 
            this.tspNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tspNuevo.Image")));
            this.tspNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspNuevo.Name = "tspNuevo";
            this.tspNuevo.Size = new System.Drawing.Size(121, 36);
            this.tspNuevo.Text = "Nuevo";
            this.tspNuevo.Click += new System.EventHandler(this.tspNuevo_Click);
            // 
            // tspBuscarProducto
            // 
            this.tspBuscarProducto.Image = ((System.Drawing.Image)(resources.GetObject("tspBuscarProducto.Image")));
            this.tspBuscarProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBuscarProducto.Name = "tspBuscarProducto";
            this.tspBuscarProducto.Size = new System.Drawing.Size(222, 36);
            this.tspBuscarProducto.Text = "Buscar Producto";
            // 
            // tspSalir
            // 
            this.tspSalir.Image = ((System.Drawing.Image)(resources.GetObject("tspSalir.Image")));
            this.tspSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspSalir.Name = "tspSalir";
            this.tspSalir.Size = new System.Drawing.Size(95, 36);
            this.tspSalir.Text = "Salir";
            this.tspSalir.Click += new System.EventHandler(this.tspSalir_Click);
            // 
            // dgvBuscar
            // 
            this.dgvBuscar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscar.Location = new System.Drawing.Point(40, 175);
            this.dgvBuscar.Name = "dgvBuscar";
            this.dgvBuscar.RowHeadersWidth = 82;
            this.dgvBuscar.RowTemplate.Height = 33;
            this.dgvBuscar.Size = new System.Drawing.Size(1086, 347);
            this.dgvBuscar.TabIndex = 6;
            this.dgvBuscar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuscar_CellClick);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(40, 110);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(1086, 31);
            this.txtBuscar.TabIndex = 5;
            // 
            // frmProductoFiltro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 544);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvBuscar);
            this.Controls.Add(this.txtBuscar);
            this.Name = "frmProductoFiltro";
            this.Text = "Filtro de Producto";
            this.Load += new System.EventHandler(this.frmProductoFiltro_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tspNuevo;
        private System.Windows.Forms.ToolStripButton tspBuscarProducto;
        private System.Windows.Forms.ToolStripButton tspSalir;
        private System.Windows.Forms.DataGridView dgvBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}