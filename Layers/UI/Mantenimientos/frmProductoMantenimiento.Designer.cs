namespace TechKMii.Layers.UI.Mantenimientos
{
    partial class frmProductoMantenimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductoMantenimiento));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tspNuevo = new System.Windows.Forms.ToolStripButton();
            this.tspEditar = new System.Windows.Forms.ToolStripButton();
            this.tspBorrar = new System.Windows.Forms.ToolStripButton();
            this.tspBuscarProduto = new System.Windows.Forms.ToolStripButton();
            this.tspSalir = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.pcbFoto = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvDatosProducto = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbTipoDispositivo = new System.Windows.Forms.ComboBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtCaracteristicas = new System.Windows.Forms.TextBox();
            this.txtExtras = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnAdjuntarDocumento = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.btnCargarFoto = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.txtCodigoIndustria = new System.Windows.Forms.TextBox();
            this.nudCantStock = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.lblVistaPrevia = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantStock)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Plum;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspNuevo,
            this.tspEditar,
            this.tspBorrar,
            this.tspBuscarProduto,
            this.tspSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(2068, 50);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tspNuevo
            // 
            this.tspNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tspNuevo.Image")));
            this.tspNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspNuevo.Name = "tspNuevo";
            this.tspNuevo.Size = new System.Drawing.Size(121, 44);
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
            // tspBuscarProduto
            // 
            this.tspBuscarProduto.Image = ((System.Drawing.Image)(resources.GetObject("tspBuscarProduto.Image")));
            this.tspBuscarProduto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBuscarProduto.Name = "tspBuscarProduto";
            this.tspBuscarProduto.Size = new System.Drawing.Size(222, 36);
            this.tspBuscarProduto.Text = "Buscar Producto";
            this.tspBuscarProduto.Click += new System.EventHandler(this.tspBuscarProduto_Click);
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
            this.label1.Location = new System.Drawing.Point(31, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Imagen";
            // 
            // pcbFoto
            // 
            this.pcbFoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbFoto.Location = new System.Drawing.Point(36, 129);
            this.pcbFoto.Margin = new System.Windows.Forms.Padding(4);
            this.pcbFoto.Name = "pcbFoto";
            this.pcbFoto.Size = new System.Drawing.Size(302, 279);
            this.pcbFoto.TabIndex = 3;
            this.pcbFoto.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 958);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Extras";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 869);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Características";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 781);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 725);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Precio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 669);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Modelo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 613);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 25);
            this.label7.TabIndex = 9;
            this.label7.Text = "Marca";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 558);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 25);
            this.label8.TabIndex = 10;
            this.label8.Text = "Proveedor";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 502);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(192, 25);
            this.label9.TabIndex = 11;
            this.label9.Text = "Tipo de dispositivo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 444);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 25);
            this.label10.TabIndex = 12;
            this.label10.Text = "Nombre";
            // 
            // dgvDatosProducto
            // 
            this.dgvDatosProducto.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatosProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosProducto.Location = new System.Drawing.Point(1060, 75);
            this.dgvDatosProducto.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDatosProducto.Name = "dgvDatosProducto";
            this.dgvDatosProducto.RowHeadersWidth = 82;
            this.dgvDatosProducto.RowTemplate.Height = 33;
            this.dgvDatosProducto.Size = new System.Drawing.Size(968, 963);
            this.dgvDatosProducto.TabIndex = 13;
            this.dgvDatosProducto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosProducto_CellClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(32, 1013);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 25);
            this.label12.TabIndex = 15;
            this.label12.Text = "Estado";
            // 
            // txtNombre
            // 
            this.txtNombre.AcceptsReturn = true;
            this.txtNombre.Location = new System.Drawing.Point(248, 438);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(448, 31);
            this.txtNombre.TabIndex = 17;
            // 
            // cmbTipoDispositivo
            // 
            this.cmbTipoDispositivo.FormattingEnabled = true;
            this.cmbTipoDispositivo.Location = new System.Drawing.Point(248, 492);
            this.cmbTipoDispositivo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoDispositivo.Name = "cmbTipoDispositivo";
            this.cmbTipoDispositivo.Size = new System.Drawing.Size(448, 33);
            this.cmbTipoDispositivo.TabIndex = 18;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(248, 548);
            this.cmbProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(448, 33);
            this.cmbProveedor.TabIndex = 19;
            // 
            // cmbMarca
            // 
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(248, 606);
            this.cmbMarca.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(448, 33);
            this.cmbMarca.TabIndex = 20;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(248, 663);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(4);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(448, 31);
            this.txtModelo.TabIndex = 21;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(248, 719);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(240, 31);
            this.txtPrecio.TabIndex = 22;
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(248, 775);
            this.txtColor.Margin = new System.Windows.Forms.Padding(4);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(240, 31);
            this.txtColor.TabIndex = 23;
            // 
            // txtCaracteristicas
            // 
            this.txtCaracteristicas.Location = new System.Drawing.Point(248, 831);
            this.txtCaracteristicas.Margin = new System.Windows.Forms.Padding(4);
            this.txtCaracteristicas.Multiline = true;
            this.txtCaracteristicas.Name = "txtCaracteristicas";
            this.txtCaracteristicas.Size = new System.Drawing.Size(448, 64);
            this.txtCaracteristicas.TabIndex = 24;
            // 
            // txtExtras
            // 
            this.txtExtras.Location = new System.Drawing.Point(248, 919);
            this.txtExtras.Margin = new System.Windows.Forms.Padding(4);
            this.txtExtras.Multiline = true;
            this.txtExtras.Name = "txtExtras";
            this.txtExtras.Size = new System.Drawing.Size(448, 64);
            this.txtExtras.TabIndex = 25;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(248, 1006);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(448, 33);
            this.cmbEstado.TabIndex = 26;
            // 
            // btnAdjuntarDocumento
            // 
            this.btnAdjuntarDocumento.BackColor = System.Drawing.Color.Plum;
            this.btnAdjuntarDocumento.Location = new System.Drawing.Point(736, 438);
            this.btnAdjuntarDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdjuntarDocumento.Name = "btnAdjuntarDocumento";
            this.btnAdjuntarDocumento.Size = new System.Drawing.Size(256, 58);
            this.btnAdjuntarDocumento.TabIndex = 29;
            this.btnAdjuntarDocumento.Text = "Adjuntar Documento";
            this.btnAdjuntarDocumento.UseVisualStyleBackColor = false;
            this.btnAdjuntarDocumento.Click += new System.EventHandler(this.btnAdjuntarDocumento_Click_1);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.Color.Plum;
            this.btnAgregarProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarProducto.Location = new System.Drawing.Point(736, 944);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(286, 94);
            this.btnAgregarProducto.TabIndex = 30;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // btnCargarFoto
            // 
            this.btnCargarFoto.BackColor = System.Drawing.Color.Plum;
            this.btnCargarFoto.Location = new System.Drawing.Point(364, 356);
            this.btnCargarFoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnCargarFoto.Name = "btnCargarFoto";
            this.btnCargarFoto.Size = new System.Drawing.Size(196, 52);
            this.btnCargarFoto.TabIndex = 31;
            this.btnCargarFoto.Text = "Cargar Imagen";
            this.btnCargarFoto.UseVisualStyleBackColor = false;
            this.btnCargarFoto.Click += new System.EventHandler(this.btnCargarFoto_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(703, 90);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(198, 25);
            this.label13.TabIndex = 33;
            this.label13.Text = "Codigo de Industria";
            // 
            // txtCodigoIndustria
            // 
            this.txtCodigoIndustria.Location = new System.Drawing.Point(707, 144);
            this.txtCodigoIndustria.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoIndustria.Name = "txtCodigoIndustria";
            this.txtCodigoIndustria.Size = new System.Drawing.Size(308, 31);
            this.txtCodigoIndustria.TabIndex = 34;
            // 
            // nudCantStock
            // 
            this.nudCantStock.Enabled = false;
            this.nudCantStock.Location = new System.Drawing.Point(413, 144);
            this.nudCantStock.Margin = new System.Windows.Forms.Padding(4);
            this.nudCantStock.Name = "nudCantStock";
            this.nudCantStock.Size = new System.Drawing.Size(231, 31);
            this.nudCantStock.TabIndex = 27;
            this.nudCantStock.ValueChanged += new System.EventHandler(this.nudCantStock_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(407, 90);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(188, 25);
            this.label11.TabIndex = 14;
            this.label11.Text = "Cantidad en Stock";
            // 
            // lblVistaPrevia
            // 
            this.lblVistaPrevia.AutoSize = true;
            this.lblVistaPrevia.Location = new System.Drawing.Point(800, 500);
            this.lblVistaPrevia.Name = "lblVistaPrevia";
            this.lblVistaPrevia.Size = new System.Drawing.Size(127, 25);
            this.lblVistaPrevia.TabIndex = 35;
            this.lblVistaPrevia.Text = "Vista Previa";
            this.lblVistaPrevia.Click += new System.EventHandler(this.lblVistaPrevia_Click);
            // 
            // frmProductoMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(2068, 1062);
            this.Controls.Add(this.lblVistaPrevia);
            this.Controls.Add(this.txtCodigoIndustria);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnCargarFoto);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.btnAdjuntarDocumento);
            this.Controls.Add(this.nudCantStock);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.txtExtras);
            this.Controls.Add(this.txtCaracteristicas);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.cmbProveedor);
            this.Controls.Add(this.cmbTipoDispositivo);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dgvDatosProducto);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pcbFoto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProductoMantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Producto";
            this.Load += new System.EventHandler(this.frmProductoMantenimiento_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantStock)).EndInit();
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
        private System.Windows.Forms.PictureBox pcbFoto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvDatosProducto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbTipoDispositivo;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.TextBox txtCaracteristicas;
        private System.Windows.Forms.TextBox txtExtras;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnAdjuntarDocumento;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.Button btnCargarFoto;
        private System.Windows.Forms.ToolStripButton tspBuscarProduto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtCodigoIndustria;
        private System.Windows.Forms.NumericUpDown nudCantStock;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblVistaPrevia;
    }
}