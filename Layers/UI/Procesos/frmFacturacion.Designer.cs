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
            this.erpError = new System.Windows.Forms.ErrorProvider(this.components);
            this.tlbPanelTotalPagar = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.grbFacturacion = new System.Windows.Forms.GroupBox();
            this.grbDetalle = new System.Windows.Forms.GroupBox();
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLblDolar = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspBarraSuperior = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnFacturar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdbTarjetaCredito = new System.Windows.Forms.RadioButton();
            this.rdbTransferencia = new System.Windows.Forms.RadioButton();
            this.cmbTipoMoneda = new System.Windows.Forms.ComboBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnFacturaXML = new System.Windows.Forms.Button();
            this.chkEstado = new System.Windows.Forms.CheckBox();
            this.rdbSinpeMovil = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).BeginInit();
            this.tlbPanelTotalPagar.SuspendLayout();
            this.grbFacturacion.SuspendLayout();
            this.grbDetalle.SuspendLayout();
            this.sttBarraInferior.SuspendLayout();
            this.tspBarraSuperior.SuspendLayout();
            this.tlpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // erpError
            // 
            this.erpError.ContainerControl = this;
            // 
            // tlbPanelTotalPagar
            // 
            this.tlbPanelTotalPagar.ColumnCount = 2;
            this.tlbPanelTotalPagar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.68208F));
            this.tlbPanelTotalPagar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.31792F));
            this.tlbPanelTotalPagar.Controls.Add(this.label8, 0, 0);
            this.tlbPanelTotalPagar.Controls.Add(this.label9, 0, 1);
            this.tlbPanelTotalPagar.Controls.Add(this.label10, 0, 2);
            this.tlbPanelTotalPagar.Controls.Add(this.txtSubtotal, 1, 0);
            this.tlbPanelTotalPagar.Controls.Add(this.txtImpuesto, 1, 1);
            this.tlbPanelTotalPagar.Controls.Add(this.txtTotal, 1, 2);
            this.tlbPanelTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlbPanelTotalPagar.Location = new System.Drawing.Point(37, 599);
            this.tlbPanelTotalPagar.Margin = new System.Windows.Forms.Padding(6);
            this.tlbPanelTotalPagar.Name = "tlbPanelTotalPagar";
            this.tlbPanelTotalPagar.RowCount = 3;
            this.tlbPanelTotalPagar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlbPanelTotalPagar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlbPanelTotalPagar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlbPanelTotalPagar.Size = new System.Drawing.Size(410, 179);
            this.tlbPanelTotalPagar.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 26);
            this.label8.TabIndex = 0;
            this.label8.Text = "Subtotal";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 71);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 26);
            this.label9.TabIndex = 1;
            this.label9.Text = "Impuesto";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 132);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(130, 26);
            this.label10.TabIndex = 2;
            this.label10.Text = "Total";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(148, 6);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(6);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(252, 44);
            this.txtSubtotal.TabIndex = 0;
            this.txtSubtotal.TabStop = false;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Location = new System.Drawing.Point(148, 62);
            this.txtImpuesto.Margin = new System.Windows.Forms.Padding(6);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.ReadOnly = true;
            this.txtImpuesto.Size = new System.Drawing.Size(246, 44);
            this.txtImpuesto.TabIndex = 0;
            this.txtImpuesto.TabStop = false;
            this.txtImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(148, 118);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(6);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(246, 44);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.TabStop = false;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grbFacturacion
            // 
            this.grbFacturacion.Controls.Add(this.chkEstado);
            this.grbFacturacion.Controls.Add(this.btnFacturaXML);
            this.grbFacturacion.Controls.Add(this.tlpPanel);
            this.grbFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grbFacturacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbFacturacion.Location = new System.Drawing.Point(15, 76);
            this.grbFacturacion.Margin = new System.Windows.Forms.Padding(6);
            this.grbFacturacion.Name = "grbFacturacion";
            this.grbFacturacion.Padding = new System.Windows.Forms.Padding(6);
            this.grbFacturacion.Size = new System.Drawing.Size(875, 823);
            this.grbFacturacion.TabIndex = 12;
            this.grbFacturacion.TabStop = false;
            this.grbFacturacion.Text = "Facturación";
            // 
            // grbDetalle
            // 
            this.grbDetalle.Controls.Add(this.dgvDatos);
            this.grbDetalle.Controls.Add(this.tlbPanelTotalPagar);
            this.grbDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDetalle.Location = new System.Drawing.Point(902, 76);
            this.grbDetalle.Margin = new System.Windows.Forms.Padding(6);
            this.grbDetalle.Name = "grbDetalle";
            this.grbDetalle.Padding = new System.Windows.Forms.Padding(6);
            this.grbDetalle.Size = new System.Drawing.Size(1240, 823);
            this.grbDetalle.TabIndex = 14;
            this.grbDetalle.TabStop = false;
            this.grbDetalle.Text = "Detalle";
            // 
            // sttBarraInferior
            // 
            this.sttBarraInferior.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sttBarraInferior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLblDolar});
            this.sttBarraInferior.Location = new System.Drawing.Point(0, 917);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.sttBarraInferior.Size = new System.Drawing.Size(1973, 55);
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
            // tspBarraSuperior
            // 
            this.tspBarraSuperior.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tspBarraSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNuevo,
            this.toolStripBtnFacturar,
            this.toolStripBtnSalir});
            this.tspBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.tspBarraSuperior.Name = "tspBarraSuperior";
            this.tspBarraSuperior.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tspBarraSuperior.Size = new System.Drawing.Size(1973, 42);
            this.tspBarraSuperior.TabIndex = 11;
            this.tspBarraSuperior.Text = "toolStrip1";
            // 
            // toolStripBtnNuevo
            // 
            this.toolStripBtnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNuevo.Name = "toolStripBtnNuevo";
            this.toolStripBtnNuevo.Size = new System.Drawing.Size(89, 36);
            this.toolStripBtnNuevo.Text = "Nuevo";
            // 
            // toolStripBtnFacturar
            // 
            this.toolStripBtnFacturar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnFacturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnFacturar.Name = "toolStripBtnFacturar";
            this.toolStripBtnFacturar.Size = new System.Drawing.Size(102, 36);
            this.toolStripBtnFacturar.Text = "Facturar";
            // 
            // toolStripBtnSalir
            // 
            this.toolStripBtnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSalir.Name = "toolStripBtnSalir";
            this.toolStripBtnSalir.Size = new System.Drawing.Size(63, 36);
            this.toolStripBtnSalir.Text = "Salir";
            // 
            // tlpPanel
            // 
            this.tlpPanel.ColumnCount = 3;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.tlpPanel.Controls.Add(this.txtNumeroFactura, 1, 0);
            this.tlpPanel.Controls.Add(this.label1, 0, 0);
            this.tlpPanel.Controls.Add(this.label2, 0, 1);
            this.tlpPanel.Controls.Add(this.txtCliente, 1, 1);
            this.tlpPanel.Controls.Add(this.btnBuscarCliente, 2, 1);
            this.tlpPanel.Controls.Add(this.rdbSinpeMovil, 1, 9);
            this.tlpPanel.Controls.Add(this.rdbTransferencia, 1, 8);
            this.tlpPanel.Controls.Add(this.rdbTarjetaCredito, 1, 7);
            this.tlpPanel.Controls.Add(this.label6, 0, 7);
            this.tlpPanel.Controls.Add(this.cmbTipoMoneda, 1, 5);
            this.tlpPanel.Controls.Add(this.dtpFecha, 1, 3);
            this.tlpPanel.Controls.Add(this.label4, 0, 5);
            this.tlpPanel.Controls.Add(this.label3, 0, 3);
            this.tlpPanel.Controls.Add(this.label5, 0, 2);
            this.tlpPanel.Controls.Add(this.txtUsuario, 1, 2);
            this.tlpPanel.Location = new System.Drawing.Point(12, 56);
            this.tlpPanel.Margin = new System.Windows.Forms.Padding(6);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 10;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlpPanel.Size = new System.Drawing.Size(821, 380);
            this.tlpPanel.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "No.Factura";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 192);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo de moneda";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Usuario";
            // 
            // rdbTarjetaCredito
            // 
            this.rdbTarjetaCredito.AutoSize = true;
            this.rdbTarjetaCredito.Checked = true;
            this.rdbTarjetaCredito.Location = new System.Drawing.Point(186, 233);
            this.rdbTarjetaCredito.Margin = new System.Windows.Forms.Padding(6);
            this.rdbTarjetaCredito.Name = "rdbTarjetaCredito";
            this.rdbTarjetaCredito.Size = new System.Drawing.Size(215, 29);
            this.rdbTarjetaCredito.TabIndex = 6;
            this.rdbTarjetaCredito.TabStop = true;
            this.rdbTarjetaCredito.Text = "Tarjeta de Credito";
            this.rdbTarjetaCredito.UseVisualStyleBackColor = true;
            // 
            // rdbTransferencia
            // 
            this.rdbTransferencia.AutoSize = true;
            this.rdbTransferencia.Location = new System.Drawing.Point(186, 279);
            this.rdbTransferencia.Margin = new System.Windows.Forms.Padding(6);
            this.rdbTransferencia.Name = "rdbTransferencia";
            this.rdbTransferencia.Size = new System.Drawing.Size(175, 29);
            this.rdbTransferencia.TabIndex = 6;
            this.rdbTransferencia.Text = "Transferencia";
            this.rdbTransferencia.UseVisualStyleBackColor = true;
            // 
            // cmbTipoMoneda
            // 
            this.cmbTipoMoneda.FormattingEnabled = true;
            this.cmbTipoMoneda.Location = new System.Drawing.Point(186, 188);
            this.cmbTipoMoneda.Margin = new System.Windows.Forms.Padding(6);
            this.cmbTipoMoneda.Name = "cmbTipoMoneda";
            this.cmbTipoMoneda.Size = new System.Drawing.Size(396, 33);
            this.cmbTipoMoneda.TabIndex = 8;
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Location = new System.Drawing.Point(594, 49);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(6);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(198, 47);
            this.btnBuscarCliente.TabIndex = 14;
            this.btnBuscarCliente.Text = "Buscar Cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(186, 49);
            this.txtCliente.Margin = new System.Windows.Forms.Padding(6);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(396, 31);
            this.txtCliente.TabIndex = 2;
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(186, 6);
            this.txtNumeroFactura.Margin = new System.Windows.Forms.Padding(6);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.ReadOnly = true;
            this.txtNumeroFactura.Size = new System.Drawing.Size(396, 31);
            this.txtNumeroFactura.TabIndex = 19;
            this.txtNumeroFactura.TabStop = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(183, 148);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(399, 31);
            this.dtpFecha.TabIndex = 20;
            // 
            // btnFacturaXML
            // 
            this.btnFacturaXML.Location = new System.Drawing.Point(23, 533);
            this.btnFacturaXML.Name = "btnFacturaXML";
            this.btnFacturaXML.Size = new System.Drawing.Size(201, 69);
            this.btnFacturaXML.TabIndex = 12;
            this.btnFacturaXML.Text = "Generar Factura";
            this.btnFacturaXML.UseVisualStyleBackColor = true;
            // 
            // chkEstado
            // 
            this.chkEstado.AutoSize = true;
            this.chkEstado.Location = new System.Drawing.Point(23, 470);
            this.chkEstado.Name = "chkEstado";
            this.chkEstado.Size = new System.Drawing.Size(111, 29);
            this.chkEstado.TabIndex = 14;
            this.chkEstado.Text = "Estado";
            this.chkEstado.UseVisualStyleBackColor = true;
            // 
            // rdbSinpeMovil
            // 
            this.rdbSinpeMovil.AutoSize = true;
            this.rdbSinpeMovil.Location = new System.Drawing.Point(186, 332);
            this.rdbSinpeMovil.Margin = new System.Windows.Forms.Padding(6);
            this.rdbSinpeMovil.Name = "rdbSinpeMovil";
            this.rdbSinpeMovil.Size = new System.Drawing.Size(155, 29);
            this.rdbSinpeMovil.TabIndex = 21;
            this.rdbSinpeMovil.Text = "Sinpe Movil";
            this.rdbSinpeMovil.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 237);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 25);
            this.label6.TabIndex = 22;
            this.label6.Text = "Metodo de pago";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(186, 108);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(6);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(396, 31);
            this.txtUsuario.TabIndex = 23;
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(25, 56);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 82;
            this.dgvDatos.RowTemplate.Height = 33;
            this.dgvDatos.Size = new System.Drawing.Size(1034, 534);
            this.dgvDatos.TabIndex = 6;
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1973, 972);
            this.Controls.Add(this.grbFacturacion);
            this.Controls.Add(this.grbDetalle);
            this.Controls.Add(this.sttBarraInferior);
            this.Controls.Add(this.tspBarraSuperior);
            this.Name = "frmFacturacion";
            this.Text = "frmFacturacion";
            this.Load += new System.EventHandler(this.frmFacturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).EndInit();
            this.tlbPanelTotalPagar.ResumeLayout(false);
            this.tlbPanelTotalPagar.PerformLayout();
            this.grbFacturacion.ResumeLayout(false);
            this.grbFacturacion.PerformLayout();
            this.grbDetalle.ResumeLayout(false);
            this.sttBarraInferior.ResumeLayout(false);
            this.sttBarraInferior.PerformLayout();
            this.tspBarraSuperior.ResumeLayout(false);
            this.tspBarraSuperior.PerformLayout();
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider erpError;
        private System.Windows.Forms.GroupBox grbFacturacion;
        private System.Windows.Forms.GroupBox grbDetalle;
        private System.Windows.Forms.TableLayoutPanel tlbPanelTotalPagar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.TextBox txtImpuesto;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.StatusStrip sttBarraInferior;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblDolar;
        private System.Windows.Forms.ToolStrip tspBarraSuperior;
        private System.Windows.Forms.ToolStripButton toolStripBtnNuevo;
        private System.Windows.Forms.ToolStripButton toolStripBtnFacturar;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalir;
        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdbTarjetaCredito;
        private System.Windows.Forms.RadioButton rdbTransferencia;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cmbTipoMoneda;
        private System.Windows.Forms.Button btnFacturaXML;
        private System.Windows.Forms.CheckBox chkEstado;
        private System.Windows.Forms.RadioButton rdbSinpeMovil;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.DataGridView dgvDatos;
    }
}