namespace TechKMii.Layers.UI.Mantenimientos
{
    partial class frmClienteMantenimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClienteMantenimiento));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbBorrar = new System.Windows.Forms.ToolStripButton();
            this.tspBuscarCliente = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnAnnadirFoto = new System.Windows.Forms.Button();
            this.pcbFotografia = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cmbTipoIdentificacion = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.rdbFemenino = new System.Windows.Forms.RadioButton();
            this.rdbMasculino = new System.Windows.Forms.RadioButton();
            this.mskTelefono = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblValidacionCorreo = new System.Windows.Forms.Label();
            this.dgvDatosCliente = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbFotografia)).BeginInit();
            this.tlpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCliente)).BeginInit();
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
            this.tspBuscarCliente,
            this.tsbSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(2106, 42);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
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
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbBorrar
            // 
            this.tsbBorrar.Image = ((System.Drawing.Image)(resources.GetObject("tsbBorrar.Image")));
            this.tsbBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBorrar.Name = "tsbBorrar";
            this.tsbBorrar.Size = new System.Drawing.Size(114, 36);
            this.tsbBorrar.Text = "Borrar";
            this.tsbBorrar.Click += new System.EventHandler(this.tsbBorrar_Click);
            // 
            // tspBuscarCliente
            // 
            this.tspBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("tspBuscarCliente.Image")));
            this.tspBuscarCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBuscarCliente.Name = "tspBuscarCliente";
            this.tspBuscarCliente.Size = new System.Drawing.Size(201, 36);
            this.tspBuscarCliente.Text = "Buscar Cliente";
            this.tspBuscarCliente.Click += new System.EventHandler(this.tspBuscarCliente_Click);
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
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 42);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.btnAnnadirFoto);
            this.splitContainer1.Panel1.Controls.Add(this.pcbFotografia);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.tlpPanel);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.splitContainer1.Panel2.Controls.Add(this.dgvDatosCliente);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(2106, 1071);
            this.splitContainer1.SplitterDistance = 944;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnAnnadirFoto
            // 
            this.btnAnnadirFoto.BackColor = System.Drawing.Color.Plum;
            this.btnAnnadirFoto.Location = new System.Drawing.Point(340, 73);
            this.btnAnnadirFoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnnadirFoto.Name = "btnAnnadirFoto";
            this.btnAnnadirFoto.Size = new System.Drawing.Size(154, 62);
            this.btnAnnadirFoto.TabIndex = 16;
            this.btnAnnadirFoto.Text = "Añadir";
            this.btnAnnadirFoto.UseVisualStyleBackColor = false;
            this.btnAnnadirFoto.Click += new System.EventHandler(this.btnAnnadirFoto_Click);
            // 
            // pcbFotografia
            // 
            this.pcbFotografia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbFotografia.Location = new System.Drawing.Point(32, 73);
            this.pcbFotografia.Margin = new System.Windows.Forms.Padding(4);
            this.pcbFotografia.Name = "pcbFotografia";
            this.pcbFotografia.Size = new System.Drawing.Size(290, 279);
            this.pcbFotografia.TabIndex = 12;
            this.pcbFotografia.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 35);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 25);
            this.label9.TabIndex = 11;
            this.label9.Text = "Fotografia";
            // 
            // tlpPanel
            // 
            this.tlpPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpPanel.ColumnCount = 3;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 244F));
            this.tlpPanel.Controls.Add(this.cmbTipoIdentificacion, 1, 0);
            this.tlpPanel.Controls.Add(this.btnAgregar, 1, 11);
            this.tlpPanel.Controls.Add(this.rdbFemenino, 1, 4);
            this.tlpPanel.Controls.Add(this.rdbMasculino, 1, 5);
            this.tlpPanel.Controls.Add(this.mskTelefono, 1, 6);
            this.tlpPanel.Controls.Add(this.label10, 0, 9);
            this.tlpPanel.Controls.Add(this.txtDireccion, 1, 9);
            this.tlpPanel.Controls.Add(this.label6, 0, 8);
            this.tlpPanel.Controls.Add(this.cmbProvincia, 1, 8);
            this.tlpPanel.Controls.Add(this.txtCorreo, 1, 7);
            this.tlpPanel.Controls.Add(this.label7, 0, 6);
            this.tlpPanel.Controls.Add(this.txtApellidos, 1, 3);
            this.tlpPanel.Controls.Add(this.label8, 0, 7);
            this.tlpPanel.Controls.Add(this.txtNombre, 1, 2);
            this.tlpPanel.Controls.Add(this.label2, 0, 2);
            this.tlpPanel.Controls.Add(this.btnBuscarCliente, 2, 1);
            this.tlpPanel.Controls.Add(this.label4, 0, 0);
            this.tlpPanel.Controls.Add(this.label1, 0, 1);
            this.tlpPanel.Controls.Add(this.txtIdentificacion, 1, 1);
            this.tlpPanel.Controls.Add(this.label3, 0, 3);
            this.tlpPanel.Controls.Add(this.label5, 0, 4);
            this.tlpPanel.Controls.Add(this.label11, 0, 10);
            this.tlpPanel.Controls.Add(this.cmbEstado, 1, 10);
            this.tlpPanel.Controls.Add(this.lblValidacionCorreo, 2, 7);
            this.tlpPanel.Location = new System.Drawing.Point(32, 362);
            this.tlpPanel.Margin = new System.Windows.Forms.Padding(6);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 12;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpPanel.Size = new System.Drawing.Size(774, 627);
            this.tlpPanel.TabIndex = 10;
            this.tlpPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpPanel_Paint);
            // 
            // cmbTipoIdentificacion
            // 
            this.cmbTipoIdentificacion.FormattingEnabled = true;
            this.cmbTipoIdentificacion.Location = new System.Drawing.Point(204, 6);
            this.cmbTipoIdentificacion.Margin = new System.Windows.Forms.Padding(6);
            this.cmbTipoIdentificacion.Name = "cmbTipoIdentificacion";
            this.cmbTipoIdentificacion.Size = new System.Drawing.Size(396, 33);
            this.cmbTipoIdentificacion.TabIndex = 20;
            this.cmbTipoIdentificacion.SelectedIndexChanged += new System.EventHandler(this.cmbTipoIdentificacion_SelectedIndexChanged);
            this.cmbTipoIdentificacion.TextChanged += new System.EventHandler(this.txtIdentificacion_TextChanged);
            this.cmbTipoIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificacion_KeyPress);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Plum;
            this.btnAgregar.Location = new System.Drawing.Point(202, 536);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(363, 72);
            this.btnAgregar.TabIndex = 15;
            this.btnAgregar.Text = "Agregar Cliente";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // rdbFemenino
            // 
            this.rdbFemenino.AutoSize = true;
            this.rdbFemenino.Checked = true;
            this.rdbFemenino.Location = new System.Drawing.Point(204, 195);
            this.rdbFemenino.Margin = new System.Windows.Forms.Padding(6);
            this.rdbFemenino.Name = "rdbFemenino";
            this.rdbFemenino.Size = new System.Drawing.Size(138, 29);
            this.rdbFemenino.TabIndex = 6;
            this.rdbFemenino.TabStop = true;
            this.rdbFemenino.Text = "Femenino";
            this.rdbFemenino.UseVisualStyleBackColor = true;
            // 
            // rdbMasculino
            // 
            this.rdbMasculino.AutoSize = true;
            this.rdbMasculino.Location = new System.Drawing.Point(204, 236);
            this.rdbMasculino.Margin = new System.Windows.Forms.Padding(6);
            this.rdbMasculino.Name = "rdbMasculino";
            this.rdbMasculino.Size = new System.Drawing.Size(141, 29);
            this.rdbMasculino.TabIndex = 6;
            this.rdbMasculino.Text = "Masculino";
            this.rdbMasculino.UseVisualStyleBackColor = true;
            // 
            // mskTelefono
            // 
            this.mskTelefono.Location = new System.Drawing.Point(202, 275);
            this.mskTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.mskTelefono.Mask = "(999)000-0000";
            this.mskTelefono.Name = "mskTelefono";
            this.mskTelefono.Size = new System.Drawing.Size(400, 31);
            this.mskTelefono.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 420);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(186, 25);
            this.label10.TabIndex = 17;
            this.label10.Text = "Direccion";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(204, 409);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(6);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(396, 44);
            this.txtDireccion.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 365);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Provincia";
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(204, 359);
            this.cmbProvincia.Margin = new System.Windows.Forms.Padding(6);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(396, 33);
            this.cmbProvincia.TabIndex = 8;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(204, 316);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(6);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(396, 31);
            this.txtCorreo.TabIndex = 5;
            this.txtCorreo.TextChanged += new System.EventHandler(this.txtCorreo_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 278);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Telefono";
            // 
            // txtApellidos
            // 
            this.txtApellidos.Location = new System.Drawing.Point(204, 152);
            this.txtApellidos.Margin = new System.Windows.Forms.Padding(6);
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.Size = new System.Drawing.Size(396, 31);
            this.txtApellidos.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 319);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(186, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Correo";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(204, 109);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(6);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(396, 31);
            this.txtNombre.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.BackColor = System.Drawing.Color.Plum;
            this.btnBuscarCliente.Location = new System.Drawing.Point(612, 51);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(6);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(130, 46);
            this.btnBuscarCliente.TabIndex = 14;
            this.btnBuscarCliente.Text = "Buscar";
            this.btnBuscarCliente.UseVisualStyleBackColor = false;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Tipo Identificacion";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identificacion";
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(204, 51);
            this.txtIdentificacion.Margin = new System.Windows.Forms.Padding(6);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(396, 31);
            this.txtIdentificacion.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellidos";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 197);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sexo";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 485);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(186, 25);
            this.label11.TabIndex = 23;
            this.label11.Text = "Estado";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(202, 467);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(400, 33);
            this.cmbEstado.TabIndex = 22;
            // 
            // lblValidacionCorreo
            // 
            this.lblValidacionCorreo.AutoSize = true;
            this.lblValidacionCorreo.Location = new System.Drawing.Point(609, 310);
            this.lblValidacionCorreo.Name = "lblValidacionCorreo";
            this.lblValidacionCorreo.Size = new System.Drawing.Size(79, 25);
            this.lblValidacionCorreo.TabIndex = 24;
            this.lblValidacionCorreo.Text = "Validar";
            // 
            // dgvDatosCliente
            // 
            this.dgvDatosCliente.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatosCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosCliente.Location = new System.Drawing.Point(40, 60);
            this.dgvDatosCliente.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDatosCliente.Name = "dgvDatosCliente";
            this.dgvDatosCliente.RowHeadersWidth = 82;
            this.dgvDatosCliente.RowTemplate.Height = 33;
            this.dgvDatosCliente.Size = new System.Drawing.Size(1052, 906);
            this.dgvDatosCliente.TabIndex = 0;
            this.dgvDatosCliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosCliente_CellClick);
            this.dgvDatosCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosCliente_CellContentClick);
            // 
            // frmClienteMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2106, 1113);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmClienteMantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Cliente";
            this.Load += new System.EventHandler(this.frmClienteMantenimiento_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcbFotografia)).EndInit();
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbBorrar;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.RadioButton rdbFemenino;
        private System.Windows.Forms.RadioButton rdbMasculino;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.PictureBox pcbFotografia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mskTelefono;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.DataGridView dgvDatosCliente;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipoIdentificacion;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnAnnadirFoto;
        protected System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton tspBuscarCliente;
        private System.Windows.Forms.Label lblValidacionCorreo;
    }
}