namespace TechKMii.Layers.UI.Login
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContrasenna = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtContrasenna = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.pcbLogin = new System.Windows.Forms.PictureBox();
            this.tlpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.sttBarraInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogin)).BeginInit();
            this.tlpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // sttBarraInferior
            // 
            this.sttBarraInferior.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sttBarraInferior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.sttBarraInferior.Location = new System.Drawing.Point(0, 409);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Size = new System.Drawing.Size(432, 23);
            this.sttBarraInferior.TabIndex = 5;
            this.sttBarraInferior.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(50, 17);
            // 
            // lblUsuario
            // 
            this.lblUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(3, 16);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(117, 20);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblContrasenna
            // 
            this.lblContrasenna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContrasenna.AutoSize = true;
            this.lblContrasenna.Location = new System.Drawing.Point(3, 70);
            this.lblContrasenna.Name = "lblContrasenna";
            this.lblContrasenna.Size = new System.Drawing.Size(117, 20);
            this.lblContrasenna.TabIndex = 1;
            this.lblContrasenna.Text = "Contraseña";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(126, 13);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(196, 26);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtContrasenna
            // 
            this.txtContrasenna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContrasenna.Location = new System.Drawing.Point(126, 67);
            this.txtContrasenna.Name = "txtContrasenna";
            this.txtContrasenna.PasswordChar = '*';
            this.txtContrasenna.Size = new System.Drawing.Size(196, 26);
            this.txtContrasenna.TabIndex = 3;
            this.txtContrasenna.Text = "********";
            this.txtContrasenna.TextChanged += new System.EventHandler(this.txtContrasenna_TextChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Plum;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(138, 338);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(138, 53);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // pcbLogin
            // 
            this.pcbLogin.BackColor = System.Drawing.Color.LightSkyBlue;
            this.pcbLogin.Image = ((System.Drawing.Image)(resources.GetObject("pcbLogin.Image")));
            this.pcbLogin.Location = new System.Drawing.Point(119, 24);
            this.pcbLogin.Name = "pcbLogin";
            this.pcbLogin.Size = new System.Drawing.Size(174, 177);
            this.pcbLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbLogin.TabIndex = 9;
            this.pcbLogin.TabStop = false;
            // 
            // tlpPanel
            // 
            this.tlpPanel.BackColor = System.Drawing.Color.Plum;
            this.tlpPanel.ColumnCount = 2;
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.10624F));
            this.tlpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.89376F));
            this.tlpPanel.Controls.Add(this.lblUsuario, 0, 0);
            this.tlpPanel.Controls.Add(this.lblContrasenna, 0, 1);
            this.tlpPanel.Controls.Add(this.txtNombre, 1, 0);
            this.tlpPanel.Controls.Add(this.txtContrasenna, 1, 1);
            this.tlpPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpPanel.Location = new System.Drawing.Point(54, 225);
            this.tlpPanel.Name = "tlpPanel";
            this.tlpPanel.RowCount = 2;
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpPanel.Size = new System.Drawing.Size(325, 107);
            this.tlpPanel.TabIndex = 6;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(432, 432);
            this.Controls.Add(this.sttBarraInferior);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.pcbLogin);
            this.Controls.Add(this.tlpPanel);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.sttBarraInferior.ResumeLayout(false);
            this.sttBarraInferior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbLogin)).EndInit();
            this.tlpPanel.ResumeLayout(false);
            this.tlpPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip sttBarraInferior;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContrasenna;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtContrasenna;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.PictureBox pcbLogin;
        private System.Windows.Forms.TableLayoutPanel tlpPanel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}