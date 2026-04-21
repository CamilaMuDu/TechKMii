namespace TechKMii
{
    partial class frmMenúPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenúPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeDispositivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDePorductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteDeFacturasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administraciónToolStripMenuItem,
            this.mantenimientosToolStripMenuItem,
            this.procesosToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(738, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.administraciónToolStripMenuItem.Text = "Administración";
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // mantenimientosToolStripMenuItem
            // 
            this.mantenimientosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.marcaToolStripMenuItem,
            this.productoToolStripMenuItem,
            this.proveedorToolStripMenuItem,
            this.tipoDeDispositivoToolStripMenuItem,
            this.inventarioToolStripMenuItem});
            this.mantenimientosToolStripMenuItem.Name = "mantenimientosToolStripMenuItem";
            this.mantenimientosToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.mantenimientosToolStripMenuItem.Text = "Mantenimientos";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            this.marcaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.marcaToolStripMenuItem.Text = "Marca";
            this.marcaToolStripMenuItem.Click += new System.EventHandler(this.marcaToolStripMenuItem_Click);
            // 
            // productoToolStripMenuItem
            // 
            this.productoToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.productoToolStripMenuItem.Name = "productoToolStripMenuItem";
            this.productoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.productoToolStripMenuItem.Text = "Producto";
            this.productoToolStripMenuItem.Click += new System.EventHandler(this.productoToolStripMenuItem_Click);
            // 
            // proveedorToolStripMenuItem
            // 
            this.proveedorToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.proveedorToolStripMenuItem.Name = "proveedorToolStripMenuItem";
            this.proveedorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.proveedorToolStripMenuItem.Text = "Proveedor";
            this.proveedorToolStripMenuItem.Click += new System.EventHandler(this.proveedorToolStripMenuItem_Click);
            // 
            // tipoDeDispositivoToolStripMenuItem
            // 
            this.tipoDeDispositivoToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tipoDeDispositivoToolStripMenuItem.Name = "tipoDeDispositivoToolStripMenuItem";
            this.tipoDeDispositivoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tipoDeDispositivoToolStripMenuItem.Text = "Tipo de dispositivo";
            this.tipoDeDispositivoToolStripMenuItem.Click += new System.EventHandler(this.tipoDeDispositivoToolStripMenuItem_Click);
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            this.inventarioToolStripMenuItem.Click += new System.EventHandler(this.inventarioToolStripMenuItem_Click);
            // 
            // procesosToolStripMenuItem
            // 
            this.procesosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturacionToolStripMenuItem});
            this.procesosToolStripMenuItem.Name = "procesosToolStripMenuItem";
            this.procesosToolStripMenuItem.Size = new System.Drawing.Size(66, 22);
            this.procesosToolStripMenuItem.Text = "Procesos";
            // 
            // facturacionToolStripMenuItem
            // 
            this.facturacionToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.facturacionToolStripMenuItem.Name = "facturacionToolStripMenuItem";
            this.facturacionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.facturacionToolStripMenuItem.Text = "Facturación";
            this.facturacionToolStripMenuItem.Click += new System.EventHandler(this.facturacionToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reporteDeClienteToolStripMenuItem,
            this.reporteDePorductosToolStripMenuItem,
            this.reporteDeVentasToolStripMenuItem,
            this.reporteDeFacturasToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 22);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reporteDeClienteToolStripMenuItem
            // 
            this.reporteDeClienteToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.reporteDeClienteToolStripMenuItem.Name = "reporteDeClienteToolStripMenuItem";
            this.reporteDeClienteToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.reporteDeClienteToolStripMenuItem.Text = "Reporte de Clientes";
            // 
            // reporteDePorductosToolStripMenuItem
            // 
            this.reporteDePorductosToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.reporteDePorductosToolStripMenuItem.Name = "reporteDePorductosToolStripMenuItem";
            this.reporteDePorductosToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.reporteDePorductosToolStripMenuItem.Text = "Reporte de Productos";
            this.reporteDePorductosToolStripMenuItem.Click += new System.EventHandler(this.reporteDePorductosToolStripMenuItem_Click);
            // 
            // reporteDeVentasToolStripMenuItem
            // 
            this.reporteDeVentasToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.reporteDeVentasToolStripMenuItem.Name = "reporteDeVentasToolStripMenuItem";
            this.reporteDeVentasToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.reporteDeVentasToolStripMenuItem.Text = "Reporte de Ventas";
            // 
            // reporteDeFacturasToolStripMenuItem
            // 
            this.reporteDeFacturasToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.reporteDeFacturasToolStripMenuItem.Name = "reporteDeFacturasToolStripMenuItem";
            this.reporteDeFacturasToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.reporteDeFacturasToolStripMenuItem.Text = "Reporte de Facturas";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 384);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.statusStrip1.Size = new System.Drawing.Size(738, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            // 
            // frmMenúPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(738, 406);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMenúPrincipal";
            this.Text = "Menú Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMenúPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mantenimientosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procesosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proveedorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeDispositivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDePorductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteDeFacturasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
    }
}

