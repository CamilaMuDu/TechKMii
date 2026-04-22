namespace TechKMii.Layers.UI.Procesos
{
    partial class frmFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturacion));
            this.erpError = new System.Windows.Forms.ErrorProvider(this.components);
            this.grbFacturacion = new System.Windows.Forms.GroupBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.btnEliminarCliente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtNoFactura = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLblDolar = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.StpVentaDolar = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspBarraSuperior = new System.Windows.Forms.ToolStrip();
            this.tspNuevo = new System.Windows.Forms.ToolStripButton();
            this.tspGenerarFactura = new System.Windows.Forms.ToolStripButton();
            this.tspEnviarPorCorreo = new System.Windows.Forms.ToolStripButton();
            this.tspSalir = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbBancoTransferencia = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNumeroTransfer = new System.Windows.Forms.TextBox();
            this.cmbBancoSINPE = new System.Windows.Forms.ComboBox();
            this.txtNumeroSinpe = new System.Windows.Forms.TextBox();
            this.cmbTipoTarjeta = new System.Windows.Forms.ComboBox();
            this.cmbBancoTarjeta = new System.Windows.Forms.ComboBox();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdbSINPE = new System.Windows.Forms.RadioButton();
            this.rdbTransferencia = new System.Windows.Forms.RadioButton();
            this.rdbTarjeta = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ptbFirma = new System.Windows.Forms.PictureBox();
            this.btnLimpiarFirma = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEliminarProducto = new System.Windows.Forms.Button();
            this.txtCantidadStock = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            this.txtTotalUSD = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtTotalCRC = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtIVACRC = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtSubtotalCRC = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).BeginInit();
            this.grbFacturacion.SuspendLayout();
            this.sttBarraInferior.SuspendLayout();
            this.tspBarraSuperior.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirma)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // erpError
            // 
            this.erpError.ContainerControl = this;
            // 
            // grbFacturacion
            // 
            this.grbFacturacion.Controls.Add(this.txtUsuario);
            this.grbFacturacion.Controls.Add(this.btnEliminarCliente);
            this.grbFacturacion.Controls.Add(this.label2);
            this.grbFacturacion.Controls.Add(this.btnBuscarCliente);
            this.grbFacturacion.Controls.Add(this.dtpFecha);
            this.grbFacturacion.Controls.Add(this.cmbEstado);
            this.grbFacturacion.Controls.Add(this.txtCorreo);
            this.grbFacturacion.Controls.Add(this.txtCliente);
            this.grbFacturacion.Controls.Add(this.txtNoFactura);
            this.grbFacturacion.Controls.Add(this.label12);
            this.grbFacturacion.Controls.Add(this.label11);
            this.grbFacturacion.Controls.Add(this.label6);
            this.grbFacturacion.Controls.Add(this.label4);
            this.grbFacturacion.Controls.Add(this.label1);
            this.grbFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grbFacturacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbFacturacion.Location = new System.Drawing.Point(16, 96);
            this.grbFacturacion.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grbFacturacion.Name = "grbFacturacion";
            this.grbFacturacion.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.grbFacturacion.Size = new System.Drawing.Size(1840, 236);
            this.grbFacturacion.TabIndex = 12;
            this.grbFacturacion.TabStop = false;
            this.grbFacturacion.Text = "Datos de Facturación";
            this.grbFacturacion.Enter += new System.EventHandler(this.grbFacturacion_Enter);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(1356, 116);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(286, 31);
            this.txtUsuario.TabIndex = 26;
            // 
            // btnEliminarCliente
            // 
            this.btnEliminarCliente.BackColor = System.Drawing.Color.Plum;
            this.btnEliminarCliente.Location = new System.Drawing.Point(894, 98);
            this.btnEliminarCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.Size = new System.Drawing.Size(162, 54);
            this.btnEliminarCliente.TabIndex = 19;
            this.btnEliminarCliente.Text = "Eliminar";
            this.btnEliminarCliente.UseVisualStyleBackColor = false;
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1128, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Usuario";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.Plum;
            this.btnBuscarCliente.Location = new System.Drawing.Point(724, 98);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(162, 54);
            this.btnBuscarCliente.TabIndex = 16;
            this.btnBuscarCliente.Text = "Buscar Cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(1356, 42);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(460, 31);
            this.dtpFecha.TabIndex = 15;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(1356, 168);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(286, 33);
            this.cmbEstado.TabIndex = 14;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(258, 172);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(460, 31);
            this.txtCorreo.TabIndex = 11;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(258, 112);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(460, 31);
            this.txtCliente.TabIndex = 10;
            // 
            // txtNoFactura
            // 
            this.txtNoFactura.Location = new System.Drawing.Point(258, 50);
            this.txtNoFactura.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNoFactura.Name = "txtNoFactura";
            this.txtNoFactura.Size = new System.Drawing.Size(628, 31);
            this.txtNoFactura.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 120);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 25);
            this.label12.TabIndex = 8;
            this.label12.Text = "Cliente";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 56);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 25);
            this.label11.TabIndex = 7;
            this.label11.Text = "No.Factura";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1128, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1128, 184);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Estado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 184);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Correo ";
            // 
            // sttBarraInferior
            // 
            this.sttBarraInferior.BackColor = System.Drawing.Color.Plum;
            this.sttBarraInferior.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sttBarraInferior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLblDolar,
            this.toolStripStatusLabel1,
            this.StpVentaDolar});
            this.sttBarraInferior.Location = new System.Drawing.Point(0, 1725);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.sttBarraInferior.Size = new System.Drawing.Size(1904, 55);
            this.sttBarraInferior.TabIndex = 10;
            this.sttBarraInferior.Text = "statusStrip1";
            // 
            // toolStripStatusLblDolar
            // 
            this.toolStripStatusLblDolar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLblDolar.Name = "toolStripStatusLblDolar";
            this.toolStripStatusLblDolar.Size = new System.Drawing.Size(33, 45);
            this.toolStripStatusLblDolar.Text = "-";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 45);
            // 
            // StpVentaDolar
            // 
            this.StpVentaDolar.Name = "StpVentaDolar";
            this.StpVentaDolar.Size = new System.Drawing.Size(138, 45);
            this.StpVentaDolar.Text = "Venta Dolar";
            // 
            // tspBarraSuperior
            // 
            this.tspBarraSuperior.BackColor = System.Drawing.Color.Plum;
            this.tspBarraSuperior.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tspBarraSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspNuevo,
            this.tspGenerarFactura,
            this.tspEnviarPorCorreo,
            this.tspSalir});
            this.tspBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.tspBarraSuperior.Name = "tspBarraSuperior";
            this.tspBarraSuperior.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.tspBarraSuperior.Size = new System.Drawing.Size(1904, 42);
            this.tspBarraSuperior.TabIndex = 11;
            this.tspBarraSuperior.Text = "toolStrip1";
            // 
            // tspNuevo
            // 
            this.tspNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tspNuevo.Image")));
            this.tspNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspNuevo.Name = "tspNuevo";
            this.tspNuevo.Size = new System.Drawing.Size(121, 36);
            this.tspNuevo.Text = "Nuevo";
            this.tspNuevo.Click += new System.EventHandler(this.tspNuevo_Click);
            // 
            // tspGenerarFactura
            // 
            this.tspGenerarFactura.Image = ((System.Drawing.Image)(resources.GetObject("tspGenerarFactura.Image")));
            this.tspGenerarFactura.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspGenerarFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspGenerarFactura.Name = "tspGenerarFactura";
            this.tspGenerarFactura.Size = new System.Drawing.Size(217, 36);
            this.tspGenerarFactura.Text = "Generar Factura";
            this.tspGenerarFactura.Click += new System.EventHandler(this.tspGenerarFactura_Click);
            // 
            // tspEnviarPorCorreo
            // 
            this.tspEnviarPorCorreo.Image = ((System.Drawing.Image)(resources.GetObject("tspEnviarPorCorreo.Image")));
            this.tspEnviarPorCorreo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspEnviarPorCorreo.Name = "tspEnviarPorCorreo";
            this.tspEnviarPorCorreo.Size = new System.Drawing.Size(220, 36);
            this.tspEnviarPorCorreo.Text = "Enviar por correo";
            this.tspEnviarPorCorreo.Click += new System.EventHandler(this.tspEnviarPorCorreo_Click);
            // 
            // tspSalir
            // 
            this.tspSalir.Image = ((System.Drawing.Image)(resources.GetObject("tspSalir.Image")));
            this.tspSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tspSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspSalir.Name = "tspSalir";
            this.tspSalir.Size = new System.Drawing.Size(95, 36);
            this.tspSalir.Text = "Salir";
            this.tspSalir.Click += new System.EventHandler(this.tspSalir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbBancoTransferencia);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.txtNumeroTransfer);
            this.groupBox1.Controls.Add(this.cmbBancoSINPE);
            this.groupBox1.Controls.Add(this.txtNumeroSinpe);
            this.groupBox1.Controls.Add(this.cmbTipoTarjeta);
            this.groupBox1.Controls.Add(this.cmbBancoTarjeta);
            this.groupBox1.Controls.Add(this.txtNumeroTarjeta);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rdbSINPE);
            this.groupBox1.Controls.Add(this.rdbTransferencia);
            this.groupBox1.Controls.Add(this.rdbTarjeta);
            this.groupBox1.Location = new System.Drawing.Point(16, 356);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1840, 416);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sistema de Pago";
            // 
            // cmbBancoTransferencia
            // 
            this.cmbBancoTransferencia.FormattingEnabled = true;
            this.cmbBancoTransferencia.Location = new System.Drawing.Point(1330, 172);
            this.cmbBancoTransferencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbBancoTransferencia.Name = "cmbBancoTransferencia";
            this.cmbBancoTransferencia.Size = new System.Drawing.Size(486, 33);
            this.cmbBancoTransferencia.TabIndex = 25;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1048, 176);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 25);
            this.label18.TabIndex = 24;
            this.label18.Text = "Banco";
            // 
            // txtNumeroTransfer
            // 
            this.txtNumeroTransfer.Location = new System.Drawing.Point(1330, 120);
            this.txtNumeroTransfer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumeroTransfer.Name = "txtNumeroTransfer";
            this.txtNumeroTransfer.Size = new System.Drawing.Size(486, 31);
            this.txtNumeroTransfer.TabIndex = 23;
            // 
            // cmbBancoSINPE
            // 
            this.cmbBancoSINPE.FormattingEnabled = true;
            this.cmbBancoSINPE.Location = new System.Drawing.Point(258, 360);
            this.cmbBancoSINPE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbBancoSINPE.Name = "cmbBancoSINPE";
            this.cmbBancoSINPE.Size = new System.Drawing.Size(460, 33);
            this.cmbBancoSINPE.TabIndex = 22;
            // 
            // txtNumeroSinpe
            // 
            this.txtNumeroSinpe.Location = new System.Drawing.Point(258, 306);
            this.txtNumeroSinpe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumeroSinpe.Name = "txtNumeroSinpe";
            this.txtNumeroSinpe.Size = new System.Drawing.Size(628, 31);
            this.txtNumeroSinpe.TabIndex = 21;
            // 
            // cmbTipoTarjeta
            // 
            this.cmbTipoTarjeta.FormattingEnabled = true;
            this.cmbTipoTarjeta.Location = new System.Drawing.Point(258, 228);
            this.cmbTipoTarjeta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTipoTarjeta.Name = "cmbTipoTarjeta";
            this.cmbTipoTarjeta.Size = new System.Drawing.Size(460, 33);
            this.cmbTipoTarjeta.TabIndex = 20;
            // 
            // cmbBancoTarjeta
            // 
            this.cmbBancoTarjeta.FormattingEnabled = true;
            this.cmbBancoTarjeta.Location = new System.Drawing.Point(258, 172);
            this.cmbBancoTarjeta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbBancoTarjeta.Name = "cmbBancoTarjeta";
            this.cmbBancoTarjeta.Size = new System.Drawing.Size(460, 33);
            this.cmbBancoTarjeta.TabIndex = 19;
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(258, 116);
            this.txtNumeroTarjeta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(628, 31);
            this.txtNumeroTarjeta.TabIndex = 19;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 54);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(170, 25);
            this.label17.TabIndex = 8;
            this.label17.Text = "Metodo de Pago";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 124);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(190, 25);
            this.label16.TabIndex = 7;
            this.label16.Text = "Numero de Tarjeta";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 180);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 25);
            this.label15.TabIndex = 6;
            this.label15.Text = "Banco";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 236);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(157, 25);
            this.label14.TabIndex = 5;
            this.label14.Text = "Tipo de Tarjeta";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1048, 124);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(248, 25);
            this.label13.TabIndex = 4;
            this.label13.Text = "Numero de transferencia";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(32, 312);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(185, 25);
            this.label10.TabIndex = 3;
            this.label10.Text = "Numero de SINPE";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 368);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 25);
            this.label9.TabIndex = 2;
            this.label9.Text = "Banco";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 460);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 25);
            this.label8.TabIndex = 1;
            this.label8.Text = "label8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 516);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // rdbSINPE
            // 
            this.rdbSINPE.AutoSize = true;
            this.rdbSINPE.Location = new System.Drawing.Point(816, 52);
            this.rdbSINPE.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbSINPE.Name = "rdbSINPE";
            this.rdbSINPE.Size = new System.Drawing.Size(162, 29);
            this.rdbSINPE.TabIndex = 11;
            this.rdbSINPE.TabStop = true;
            this.rdbSINPE.Text = "SINPE Movil";
            this.rdbSINPE.UseVisualStyleBackColor = true;
            this.rdbSINPE.CheckedChanged += new System.EventHandler(this.rdbSINPE_CheckedChanged);
            // 
            // rdbTransferencia
            // 
            this.rdbTransferencia.AutoSize = true;
            this.rdbTransferencia.Location = new System.Drawing.Point(492, 52);
            this.rdbTransferencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbTransferencia.Name = "rdbTransferencia";
            this.rdbTransferencia.Size = new System.Drawing.Size(175, 29);
            this.rdbTransferencia.TabIndex = 10;
            this.rdbTransferencia.TabStop = true;
            this.rdbTransferencia.Text = "Transferencia";
            this.rdbTransferencia.UseVisualStyleBackColor = true;
            this.rdbTransferencia.CheckedChanged += new System.EventHandler(this.rdbTransferencia_CheckedChanged);
            // 
            // rdbTarjeta
            // 
            this.rdbTarjeta.AutoSize = true;
            this.rdbTarjeta.Location = new System.Drawing.Point(258, 52);
            this.rdbTarjeta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdbTarjeta.Name = "rdbTarjeta";
            this.rdbTarjeta.Size = new System.Drawing.Size(110, 29);
            this.rdbTarjeta.TabIndex = 9;
            this.rdbTarjeta.TabStop = true;
            this.rdbTarjeta.Text = "Tarjeta";
            this.rdbTarjeta.UseVisualStyleBackColor = true;
            this.rdbTarjeta.CheckedChanged += new System.EventHandler(this.rdbTarjeta_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ptbFirma);
            this.groupBox2.Controls.Add(this.btnLimpiarFirma);
            this.groupBox2.Location = new System.Drawing.Point(16, 1500);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1840, 200);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Firma del Cliente";
            // 
            // ptbFirma
            // 
            this.ptbFirma.BackColor = System.Drawing.SystemColors.Control;
            this.ptbFirma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ptbFirma.Location = new System.Drawing.Point(312, 32);
            this.ptbFirma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ptbFirma.Name = "ptbFirma";
            this.ptbFirma.Size = new System.Drawing.Size(952, 146);
            this.ptbFirma.TabIndex = 1;
            this.ptbFirma.TabStop = false;
            this.ptbFirma.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picFirma_MouseDown);
            this.ptbFirma.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picFirma_MouseMove);
            this.ptbFirma.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picFirma_MouseUp);
            // 
            // btnLimpiarFirma
            // 
            this.btnLimpiarFirma.BackColor = System.Drawing.Color.Plum;
            this.btnLimpiarFirma.Location = new System.Drawing.Point(1542, 112);
            this.btnLimpiarFirma.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiarFirma.Name = "btnLimpiarFirma";
            this.btnLimpiarFirma.Size = new System.Drawing.Size(224, 64);
            this.btnLimpiarFirma.TabIndex = 0;
            this.btnLimpiarFirma.Text = "Limpiar Firma";
            this.btnLimpiarFirma.UseVisualStyleBackColor = false;
            this.btnLimpiarFirma.Click += new System.EventHandler(this.btnLimpiarFirma_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEliminarProducto);
            this.groupBox3.Controls.Add(this.txtCantidadStock);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.btnAgregarProducto);
            this.groupBox3.Controls.Add(this.txtTotalUSD);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.txtTotalCRC);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.txtIVACRC);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtSubtotalCRC);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.dgvProductos);
            this.groupBox3.Controls.Add(this.txtPrecio);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.txtCantidad);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.txtProducto);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.btnEliminar);
            this.groupBox3.Controls.Add(this.btnBuscarProducto);
            this.groupBox3.Location = new System.Drawing.Point(24, 780);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(1832, 712);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Detalle de Facturación";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btnEliminarProducto
            // 
            this.btnEliminarProducto.BackColor = System.Drawing.Color.Plum;
            this.btnEliminarProducto.Location = new System.Drawing.Point(1546, 32);
            this.btnEliminarProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminarProducto.Name = "btnEliminarProducto";
            this.btnEliminarProducto.Size = new System.Drawing.Size(246, 72);
            this.btnEliminarProducto.TabIndex = 20;
            this.btnEliminarProducto.Text = "Eliminar Producto";
            this.btnEliminarProducto.UseVisualStyleBackColor = false;
            this.btnEliminarProducto.Click += new System.EventHandler(this.btnEliminarProducto_Click_1);
            // 
            // txtCantidadStock
            // 
            this.txtCantidadStock.Location = new System.Drawing.Point(1052, 136);
            this.txtCantidadStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCantidadStock.Name = "txtCantidadStock";
            this.txtCantidadStock.Size = new System.Drawing.Size(164, 31);
            this.txtCantidadStock.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(506, 142);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "Cantidad";
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.BackColor = System.Drawing.Color.Plum;
            this.btnAgregarProducto.Location = new System.Drawing.Point(1280, 32);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(246, 72);
            this.btnAgregarProducto.TabIndex = 17;
            this.btnAgregarProducto.Text = "Agregar Producto";
            this.btnAgregarProducto.UseVisualStyleBackColor = false;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // txtTotalUSD
            // 
            this.txtTotalUSD.Location = new System.Drawing.Point(1476, 660);
            this.txtTotalUSD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalUSD.Name = "txtTotalUSD";
            this.txtTotalUSD.Size = new System.Drawing.Size(312, 31);
            this.txtTotalUSD.TabIndex = 16;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(1308, 664);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(110, 25);
            this.label25.TabIndex = 15;
            this.label25.Text = "Total USD";
            // 
            // txtTotalCRC
            // 
            this.txtTotalCRC.Location = new System.Drawing.Point(1476, 618);
            this.txtTotalCRC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTotalCRC.Name = "txtTotalCRC";
            this.txtTotalCRC.Size = new System.Drawing.Size(312, 31);
            this.txtTotalCRC.TabIndex = 14;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(1308, 624);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(111, 25);
            this.label24.TabIndex = 13;
            this.label24.Text = "Total CRC";
            // 
            // txtIVACRC
            // 
            this.txtIVACRC.Location = new System.Drawing.Point(1476, 572);
            this.txtIVACRC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIVACRC.Name = "txtIVACRC";
            this.txtIVACRC.Size = new System.Drawing.Size(312, 31);
            this.txtIVACRC.TabIndex = 12;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(1308, 576);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(96, 25);
            this.label23.TabIndex = 11;
            this.label23.Text = "IVA CRC";
            // 
            // txtSubtotalCRC
            // 
            this.txtSubtotalCRC.Location = new System.Drawing.Point(1476, 528);
            this.txtSubtotalCRC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSubtotalCRC.Name = "txtSubtotalCRC";
            this.txtSubtotalCRC.Size = new System.Drawing.Size(312, 31);
            this.txtSubtotalCRC.TabIndex = 10;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1300, 532);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(142, 25);
            this.label22.TabIndex = 9;
            this.label22.Text = "Subtotal CRC";
            // 
            // dgvProductos
            // 
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(30, 192);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 82;
            this.dgvProductos.RowTemplate.Height = 33;
            this.dgvProductos.Size = new System.Drawing.Size(1762, 320);
            this.dgvProductos.TabIndex = 8;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(1408, 140);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(312, 31);
            this.txtPrecio.TabIndex = 7;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1300, 144);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(73, 25);
            this.label21.TabIndex = 6;
            this.label21.Text = "Precio";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(612, 138);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(164, 31);
            this.txtCantidad.TabIndex = 5;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(858, 142);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(185, 25);
            this.label20.TabIndex = 4;
            this.label20.Text = "Cantidad en stock";
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(134, 136);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(306, 31);
            this.txtProducto.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 142);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 25);
            this.label19.TabIndex = 2;
            this.label19.Text = "Producto";
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Plum;
            this.btnEliminar.Location = new System.Drawing.Point(232, 60);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(184, 52);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.Color.Plum;
            this.btnBuscarProducto.Location = new System.Drawing.Point(30, 60);
            this.btnBuscarProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(184, 52);
            this.btnBuscarProducto.TabIndex = 0;
            this.btnBuscarProducto.Text = "Buscar Producto";
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1904, 1780);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbFacturacion);
            this.Controls.Add(this.sttBarraInferior);
            this.Controls.Add(this.tspBarraSuperior);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1908, 999);
            this.Name = "frmFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Proceso de facturación";
            this.Load += new System.EventHandler(this.frmFacturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).EndInit();
            this.grbFacturacion.ResumeLayout(false);
            this.grbFacturacion.PerformLayout();
            this.sttBarraInferior.ResumeLayout(false);
            this.sttBarraInferior.PerformLayout();
            this.tspBarraSuperior.ResumeLayout(false);
            this.tspBarraSuperior.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbFirma)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider erpError;
        private System.Windows.Forms.GroupBox grbFacturacion;
        private System.Windows.Forms.StatusStrip sttBarraInferior;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblDolar;
        private System.Windows.Forms.ToolStrip tspBarraSuperior;
        private System.Windows.Forms.ToolStripButton tspNuevo;
        private System.Windows.Forms.ToolStripButton tspGenerarFactura;
        private System.Windows.Forms.ToolStripButton tspSalir;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel StpVentaDolar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtNoFactura;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.ToolStripButton tspEnviarPorCorreo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbSINPE;
        private System.Windows.Forms.RadioButton rdbTransferencia;
        private System.Windows.Forms.RadioButton rdbTarjeta;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoTarjeta;
        private System.Windows.Forms.ComboBox cmbBancoTarjeta;
        private System.Windows.Forms.TextBox txtNumeroTarjeta;
        private System.Windows.Forms.ComboBox cmbBancoSINPE;
        private System.Windows.Forms.TextBox txtNumeroSinpe;
        private System.Windows.Forms.ComboBox cmbBancoTransferencia;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNumeroTransfer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLimpiarFirma;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Button btnEliminarCliente;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtTotalUSD;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtTotalCRC;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtIVACRC;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtSubtotalCRC;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.TextBox txtCantidadStock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEliminarProducto;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.PictureBox ptbFirma;
    }
}