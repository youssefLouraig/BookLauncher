namespace BookLauncher.Forms
{
    partial class Frm_LoginKDP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LoginKDP));
            this.Blogin = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tEmail = new DevExpress.XtraEditors.TextEdit();
            this.tPassword = new DevExpress.XtraEditors.TextEdit();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lValide = new DevExpress.XtraEditors.LabelControl();
            this.pictvalide = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictvalide)).BeginInit();
            this.SuspendLayout();
            // 
            // Blogin
            // 
            this.Blogin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Blogin.ImageOptions.Image")));
            this.Blogin.Location = new System.Drawing.Point(142, 126);
            this.Blogin.Name = "Blogin";
            this.Blogin.Size = new System.Drawing.Size(75, 37);
            this.Blogin.TabIndex = 0;
            this.Blogin.Text = "Valide";
            this.Blogin.Click += new System.EventHandler(this.Blogin_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(223, 126);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 37);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Cancel";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(25, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(161, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Email (phone for mobile accounts)";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Password";
            // 
            // tEmail
            // 
            this.tEmail.Location = new System.Drawing.Point(25, 38);
            this.tEmail.Name = "tEmail";
            this.tEmail.Size = new System.Drawing.Size(257, 20);
            this.tEmail.TabIndex = 2;
            // 
            // tPassword
            // 
            this.tPassword.Location = new System.Drawing.Point(25, 92);
            this.tPassword.Name = "tPassword";
            this.tPassword.Properties.PasswordChar = '*';
            this.tPassword.Size = new System.Drawing.Size(257, 20);
            this.tPassword.TabIndex = 2;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lValide);
            this.panel1.Controls.Add(this.pictvalide);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.tPassword);
            this.panel1.Controls.Add(this.Blogin);
            this.panel1.Controls.Add(this.tEmail);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.labelControl2);
            this.panel1.Location = new System.Drawing.Point(8, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 207);
            this.panel1.TabIndex = 3;
            // 
            // lValide
            // 
            this.lValide.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lValide.Appearance.Options.UseFont = true;
            this.lValide.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lValide.Location = new System.Drawing.Point(51, 169);
            this.lValide.Name = "lValide";
            this.lValide.Size = new System.Drawing.Size(187, 20);
            this.lValide.TabIndex = 196;
            this.lValide.Text = "Validation has been performed";
            this.lValide.Visible = false;
            // 
            // pictvalide
            // 
            this.pictvalide.BackgroundImage = global::BookLauncher.Properties.Resources.valide;
            this.pictvalide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictvalide.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictvalide.Location = new System.Drawing.Point(21, 169);
            this.pictvalide.Name = "pictvalide";
            this.pictvalide.Size = new System.Drawing.Size(24, 20);
            this.pictvalide.TabIndex = 195;
            this.pictvalide.TabStop = false;
            this.pictvalide.Visible = false;
            // 
            // Frm_LoginKDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Frm_LoginKDP";
            this.Size = new System.Drawing.Size(369, 232);
            this.Load += new System.EventHandler(this.Frm_LoginKDP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictvalide)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Blogin;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit tEmail;
        private DevExpress.XtraEditors.TextEdit tPassword;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl lValide;
        private System.Windows.Forms.PictureBox pictvalide;
    }
}