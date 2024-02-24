namespace BookLauncher.Forms
{
    partial class Frm_UpdateLoginApp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_UpdateLoginApp));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.tNewUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lValide = new DevExpress.XtraEditors.LabelControl();
            this.pictvalide = new System.Windows.Forms.PictureBox();
            this.tNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.Blogin = new DevExpress.XtraEditors.SimpleButton();
            this.tCurrentPass = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tNewPassword2 = new DevExpress.XtraEditors.TextEdit();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNewUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictvalide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCurrentPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNewPassword2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.tNewUser);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.lValide);
            this.panelControl1.Controls.Add(this.pictvalide);
            this.panelControl1.Controls.Add(this.tNewPassword2);
            this.panelControl1.Controls.Add(this.tNewPassword);
            this.panelControl1.Controls.Add(this.Blogin);
            this.panelControl1.Controls.Add(this.tCurrentPass);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Location = new System.Drawing.Point(15, 13);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(281, 268);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 15);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(86, 13);
            this.labelControl3.TabIndex = 206;
            this.labelControl3.Text = "Current Password";
            // 
            // tNewUser
            // 
            this.tNewUser.Location = new System.Drawing.Point(14, 76);
            this.tNewUser.Name = "tNewUser";
            this.tNewUser.Size = new System.Drawing.Size(257, 20);
            this.tNewUser.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 13);
            this.labelControl1.TabIndex = 204;
            this.labelControl1.Text = "New User";
            // 
            // lValide
            // 
            this.lValide.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lValide.Appearance.Options.UseFont = true;
            this.lValide.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lValide.Location = new System.Drawing.Point(42, 231);
            this.lValide.Name = "lValide";
            this.lValide.Size = new System.Drawing.Size(187, 20);
            this.lValide.TabIndex = 203;
            this.lValide.Text = "Validation has been performed";
            this.lValide.Visible = false;
            // 
            // pictvalide
            // 
            this.pictvalide.BackgroundImage = global::BookLauncher.Properties.Resources.valide;
            this.pictvalide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictvalide.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictvalide.Location = new System.Drawing.Point(12, 231);
            this.pictvalide.Name = "pictvalide";
            this.pictvalide.Size = new System.Drawing.Size(24, 20);
            this.pictvalide.TabIndex = 202;
            this.pictvalide.TabStop = false;
            this.pictvalide.Visible = false;
            // 
            // tNewPassword
            // 
            this.tNewPassword.Location = new System.Drawing.Point(14, 119);
            this.tNewPassword.Name = "tNewPassword";
            this.tNewPassword.Properties.PasswordChar = '*';
            this.tNewPassword.Size = new System.Drawing.Size(257, 20);
            this.tNewPassword.TabIndex = 2;
            // 
            // Blogin
            // 
            this.Blogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Blogin.ImageOptions.Image")));
            this.Blogin.Location = new System.Drawing.Point(114, 188);
            this.Blogin.Name = "Blogin";
            this.Blogin.Size = new System.Drawing.Size(75, 37);
            this.Blogin.TabIndex = 4;
            this.Blogin.Text = "Valide";
            this.Blogin.Click += new System.EventHandler(this.Blogin_Click);
            // 
            // tCurrentPass
            // 
            this.tCurrentPass.Location = new System.Drawing.Point(14, 33);
            this.tCurrentPass.Name = "tCurrentPass";
            this.tCurrentPass.Properties.PasswordChar = '*';
            this.tCurrentPass.Size = new System.Drawing.Size(257, 20);
            this.tCurrentPass.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(195, 188);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 37);
            this.simpleButton1.TabIndex = 5;
            this.simpleButton1.Text = "Cancel";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 101);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 13);
            this.labelControl2.TabIndex = 199;
            this.labelControl2.Text = "New Password";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 144);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(84, 13);
            this.labelControl4.TabIndex = 199;
            this.labelControl4.Text = "Retype Password";
            // 
            // tNewPassword2
            // 
            this.tNewPassword2.Location = new System.Drawing.Point(14, 162);
            this.tNewPassword2.Name = "tNewPassword2";
            this.tNewPassword2.Properties.PasswordChar = '*';
            this.tNewPassword2.Size = new System.Drawing.Size(257, 20);
            this.tNewPassword2.TabIndex = 3;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Frm_UpdateLoginApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "Frm_UpdateLoginApp";
            this.Size = new System.Drawing.Size(304, 301);
            this.Load += new System.EventHandler(this.Frm_UpdateLoginApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNewUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictvalide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCurrentPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNewPassword2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit tNewUser;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lValide;
        private System.Windows.Forms.PictureBox pictvalide;
        private DevExpress.XtraEditors.TextEdit tNewPassword;
        private DevExpress.XtraEditors.SimpleButton Blogin;
        private DevExpress.XtraEditors.TextEdit tCurrentPass;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit tNewPassword2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
