namespace TechKMii.Layers.UI.Mantenimientos
{
    partial class frmProveedorMantenimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedorMantenimiento));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tspNuevo = new System.Windows.Forms.ToolStripButton();
            this.tspEditar = new System.Windows.Forms.ToolStripButton();
            this.tspBorrar = new System.Windows.Forms.ToolStripButton();
            this.tspSalir = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnAgregarProveedor = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspNuevo,
            this.tspEditar,
            this.tspBorrar,
            this.tspSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1680, 42);
            this.toolStrip1.TabIndex = 0;
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
            // tspEditar
            // 
            this.tspEditar.Image = ((System.Drawing.Image)(resources.GetObject("tspEditar.Image")));
            this.tspEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspEditar.Name = "tspEditar";
            this.tspEditar.Size = new System.Drawing.Size(110, 36);
            this.tspEditar.Text = "Editar";
            this.tspEditar.Click += new System.EventHandler(this.tspEditar_Click);
            // 
            // tspBorrar
            // 
            this.tspBorrar.Image = ((System.Drawing.Image)(resources.GetObject("tspBorrar.Image")));
            this.tspBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBorrar.Name = "tspBorrar";
            this.tspBorrar.Size = new System.Drawing.Size(114, 36);
            this.tspBorrar.Text = "Borrar";
            this.tspBorrar.Click += new System.EventHandler(this.tspBorrar_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Estado";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(182, 156);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(367, 31);
            this.txtNombre.TabIndex = 3;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(182, 246);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(367, 33);
            this.cmbEstado.TabIndex = 4;
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(670, 99);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 82;
            this.dgvDatos.RowTemplate.Height = 33;
            this.dgvDatos.Size = new System.Drawing.Size(960, 482);
            this.dgvDatos.TabIndex = 5;
            this.dgvDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellClick);
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // btnAgregarProveedor
            // 
            this.btnAgregarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProveedor.Location = new System.Drawing.Point(182, 495);
            this.btnAgregarProveedor.Name = "btnAgregarProveedor";
            this.btnAgregarProveedor.Size = new System.Drawing.Size(320, 86);
            this.btnAgregarProveedor.TabIndex = 6;
            this.btnAgregarProveedor.Text = "Agregar Proveedor";
            this.btnAgregarProveedor.UseVisualStyleBackColor = true;
            this.btnAgregarProveedor.Click += new System.EventHandler(this.btnAgregarProveedor_Click);
            // 
            // frmProveedorMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1680, 636);
            this.Controls.Add(this.btnAgregarProveedor);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmProveedorMantenimiento";
            this.Text = "Mantenimiento de Proveedor";
            this.Load += new System.EventHandler(this.frmProveedorMantenimiento_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tspNuevo;
        private System.Windows.Forms.ToolStripButton tspEditar;
        private System.Windows.Forms.ToolStripButton tspBorrar;
        private System.Windows.Forms.ToolStripButton tspSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnAgregarProveedor;
    }
}