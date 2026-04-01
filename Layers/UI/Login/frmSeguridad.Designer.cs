namespace TechKMii.Layers.UI.Login
{
    partial class frmSeguridad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSeguridad));
            this.ntfMensaje = new System.Windows.Forms.NotifyIcon(this.components);
            this.imgListaTreeView = new System.Windows.Forms.ImageList(this.components);
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmdMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trvUsuarios = new System.Windows.Forms.TreeView();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasenna = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.spcContenedor = new System.Windows.Forms.SplitContainer();
            this.tplPanel = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnGuardarUsuario = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.tspBarraPrincipal = new System.Windows.Forms.ToolStrip();
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.cmdMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcContenedor)).BeginInit();
            this.spcContenedor.Panel1.SuspendLayout();
            this.spcContenedor.Panel2.SuspendLayout();
            this.spcContenedor.SuspendLayout();
            this.tplPanel.SuspendLayout();
            this.tspBarraPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgListaTreeView
            // 
            this.imgListaTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListaTreeView.ImageStream")));
            this.imgListaTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListaTreeView.Images.SetKeyName(0, "database.jpg");
            this.imgListaTreeView.Images.SetKeyName(1, "userdatabase.png");
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 38);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(152, 38);
            this.borrarToolStripMenuItem.Text = "Borrar";
            // 
            // cmdMenu
            // 
            this.cmdMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmdMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrarToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.cmdMenu.Name = "cmdMenu";
            this.cmdMenu.Size = new System.Drawing.Size(153, 80);
            // 
            // trvUsuarios
            // 
            this.trvUsuarios.ContextMenuStrip = this.cmdMenu;
            this.trvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvUsuarios.ImageIndex = 0;
            this.trvUsuarios.ImageList = this.imgListaTreeView;
            this.trvUsuarios.Location = new System.Drawing.Point(0, 0);
            this.trvUsuarios.Margin = new System.Windows.Forms.Padding(6);
            this.trvUsuarios.Name = "trvUsuarios";
            this.trvUsuarios.SelectedImageIndex = 0;
            this.trvUsuarios.Size = new System.Drawing.Size(901, 606);
            this.trvUsuarios.TabIndex = 5;
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(6, 9);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(123, 25);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogin.Location = new System.Drawing.Point(141, 6);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(6);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(440, 31);
            this.txtLogin.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(141, 49);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(6);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(440, 31);
            this.txtNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 52);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(123, 25);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre";
            // 
            // lblContrasena
            // 
            this.lblContrasena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(6, 95);
            this.lblContrasena.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(123, 25);
            this.lblContrasena.TabIndex = 1;
            this.lblContrasena.Text = "Contrasena";
            // 
            // txtContrasenna
            // 
            this.txtContrasenna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContrasenna.Location = new System.Drawing.Point(141, 92);
            this.txtContrasenna.Margin = new System.Windows.Forms.Padding(6);
            this.txtContrasenna.Name = "txtContrasenna";
            this.txtContrasenna.PasswordChar = '*';
            this.txtContrasenna.Size = new System.Drawing.Size(440, 31);
            this.txtContrasenna.TabIndex = 3;
            // 
            // lblRol
            // 
            this.lblRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(6, 175);
            this.lblRol.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(123, 25);
            this.lblRol.TabIndex = 6;
            this.lblRol.Text = "Rol";
            // 
            // cmbRol
            // 
            this.cmbRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(141, 171);
            this.cmbRol.Margin = new System.Windows.Forms.Padding(6);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(440, 33);
            this.cmbRol.TabIndex = 4;
            // 
            // spcContenedor
            // 
            this.spcContenedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spcContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcContenedor.Location = new System.Drawing.Point(0, 50);
            this.spcContenedor.Margin = new System.Windows.Forms.Padding(6);
            this.spcContenedor.Name = "spcContenedor";
            // 
            // spcContenedor.Panel1
            // 
            this.spcContenedor.Panel1.Controls.Add(this.tplPanel);
            // 
            // spcContenedor.Panel2
            // 
            this.spcContenedor.Panel2.Controls.Add(this.trvUsuarios);
            this.spcContenedor.Size = new System.Drawing.Size(1567, 610);
            this.spcContenedor.SplitterDistance = 654;
            this.spcContenedor.SplitterWidth = 8;
            this.spcContenedor.TabIndex = 5;
            // 
            // tplPanel
            // 
            this.tplPanel.ColumnCount = 2;
            this.tplPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tplPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tplPanel.Controls.Add(this.lblLogin, 0, 0);
            this.tplPanel.Controls.Add(this.txtLogin, 1, 0);
            this.tplPanel.Controls.Add(this.txtNombre, 1, 1);
            this.tplPanel.Controls.Add(this.lblNombre, 0, 1);
            this.tplPanel.Controls.Add(this.lblContrasena, 0, 2);
            this.tplPanel.Controls.Add(this.txtContrasenna, 1, 2);
            this.tplPanel.Controls.Add(this.lblRol, 0, 3);
            this.tplPanel.Controls.Add(this.cmbRol, 1, 3);
            this.tplPanel.Location = new System.Drawing.Point(20, 47);
            this.tplPanel.Margin = new System.Windows.Forms.Padding(6);
            this.tplPanel.Name = "tplPanel";
            this.tplPanel.RowCount = 4;
            this.tplPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tplPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tplPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tplPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tplPanel.Size = new System.Drawing.Size(587, 247);
            this.tplPanel.TabIndex = 1;
            // 
            // toolStripBtnSalir
            // 
            this.toolStripBtnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSalir.Name = "toolStripBtnSalir";
            this.toolStripBtnSalir.Size = new System.Drawing.Size(63, 44);
            this.toolStripBtnSalir.Text = "Sa&lir";
            this.toolStripBtnSalir.Click += new System.EventHandler(this.toolStripBtnSalir_Click);
            // 
            // toolStripBtnGuardarUsuario
            // 
            this.toolStripBtnGuardarUsuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnGuardarUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnGuardarUsuario.Name = "toolStripBtnGuardarUsuario";
            this.toolStripBtnGuardarUsuario.Size = new System.Drawing.Size(102, 44);
            this.toolStripBtnGuardarUsuario.Text = "Guardar";
            this.toolStripBtnGuardarUsuario.Click += new System.EventHandler(this.toolStripBtnGuardarUsuario_Click);
            // 
            // toolStripBtnNuevo
            // 
            this.toolStripBtnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNuevo.Name = "toolStripBtnNuevo";
            this.toolStripBtnNuevo.Size = new System.Drawing.Size(89, 44);
            this.toolStripBtnNuevo.Text = "&Nuevo";
            this.toolStripBtnNuevo.Click += new System.EventHandler(this.toolStripBtnNuevo_Click);
            // 
            // tspBarraPrincipal
            // 
            this.tspBarraPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tspBarraPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNuevo,
            this.toolStripBtnGuardarUsuario,
            this.toolStripBtnSalir});
            this.tspBarraPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tspBarraPrincipal.Name = "tspBarraPrincipal";
            this.tspBarraPrincipal.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tspBarraPrincipal.Size = new System.Drawing.Size(1567, 50);
            this.tspBarraPrincipal.TabIndex = 4;
            this.tspBarraPrincipal.Text = "toolStrip1";
            // 
            // sttBarraInferior
            // 
            this.sttBarraInferior.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sttBarraInferior.Location = new System.Drawing.Point(0, 660);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.sttBarraInferior.Size = new System.Drawing.Size(1567, 22);
            this.sttBarraInferior.TabIndex = 3;
            this.sttBarraInferior.Text = "statusStrip1";
            this.sttBarraInferior.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sttBarraInferior_ItemClicked);
            // 
            // frmSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1567, 682);
            this.Controls.Add(this.spcContenedor);
            this.Controls.Add(this.tspBarraPrincipal);
            this.Controls.Add(this.sttBarraInferior);
            this.Name = "frmSeguridad";
            this.Text = "frmSeguridad";
            this.Load += new System.EventHandler(this.frmSeguridad_Load);
            this.cmdMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.spcContenedor.Panel1.ResumeLayout(false);
            this.spcContenedor.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcContenedor)).EndInit();
            this.spcContenedor.ResumeLayout(false);
            this.tplPanel.ResumeLayout(false);
            this.tplPanel.PerformLayout();
            this.tspBarraPrincipal.ResumeLayout(false);
            this.tspBarraPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon ntfMensaje;
        private System.Windows.Forms.ImageList imgListaTreeView;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmdMenu;
        private System.Windows.Forms.TreeView trvUsuarios;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.SplitContainer spcContenedor;
        private System.Windows.Forms.TableLayoutPanel tplPanel;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtContrasenna;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.ToolStrip tspBarraPrincipal;
        private System.Windows.Forms.ToolStripButton toolStripBtnNuevo;
        private System.Windows.Forms.ToolStripButton toolStripBtnGuardarUsuario;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalir;
        private System.Windows.Forms.StatusStrip sttBarraInferior;
    }
}