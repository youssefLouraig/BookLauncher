namespace BookLauncher.Forms
{
    partial class Frm_Active
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Active));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bclose = new DevExpress.XtraEditors.SimpleButton();
            this.Bsend = new DevExpress.XtraEditors.SimpleButton();
            this.pictwait = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictKeyValidation = new System.Windows.Forms.PictureBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictsavekey = new System.Windows.Forms.PictureBox();
            this.pictconnexion = new System.Windows.Forms.PictureBox();
            this.TCodeClient = new DevExpress.XtraEditors.TextEdit();
            this.tSerial = new DevExpress.XtraEditors.TextEdit();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.Reactivation = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictwait)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictKeyValidation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictsavekey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictconnexion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TCodeClient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSerial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Reactivation);
            this.panel1.Controls.Add(this.labelControl5);
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.bclose);
            this.panel1.Controls.Add(this.Bsend);
            this.panel1.Controls.Add(this.pictwait);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.TCodeClient);
            this.panel1.Controls.Add(this.tSerial);
            this.panel1.Location = new System.Drawing.Point(21, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 254);
            this.panel1.TabIndex = 0;
            // 
            // bclose
            // 
            this.bclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bclose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bclose.ImageOptions.Image")));
            this.bclose.Location = new System.Drawing.Point(329, 90);
            this.bclose.Name = "bclose";
            this.bclose.Size = new System.Drawing.Size(95, 35);
            this.bclose.TabIndex = 196;
            this.bclose.Text = "Close";
            this.bclose.Click += new System.EventHandler(this.bclose_Click);
            // 
            // Bsend
            // 
            this.Bsend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bsend.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Bsend.ImageOptions.Image")));
            this.Bsend.Location = new System.Drawing.Point(113, 90);
            this.Bsend.Name = "Bsend";
            this.Bsend.Size = new System.Drawing.Size(95, 35);
            this.Bsend.TabIndex = 196;
            this.Bsend.Text = "Send";
            this.Bsend.Click += new System.EventHandler(this.Bsend_Click);
            // 
            // pictwait
            // 
            this.pictwait.BackgroundImage = global::BookLauncher.Properties.Resources.demo_wait;
            this.pictwait.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictwait.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictwait.Location = new System.Drawing.Point(293, 131);
            this.pictwait.Name = "pictwait";
            this.pictwait.Size = new System.Drawing.Size(131, 83);
            this.pictwait.TabIndex = 195;
            this.pictwait.TabStop = false;
            this.pictwait.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictKeyValidation);
            this.panel3.Controls.Add(this.labelControl3);
            this.panel3.Controls.Add(this.labelControl2);
            this.panel3.Controls.Add(this.labelControl1);
            this.panel3.Controls.Add(this.pictsavekey);
            this.panel3.Controls.Add(this.pictconnexion);
            this.panel3.Location = new System.Drawing.Point(47, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 83);
            this.panel3.TabIndex = 194;
            this.panel3.Visible = false;
            // 
            // pictKeyValidation
            // 
            this.pictKeyValidation.BackgroundImage = global::BookLauncher.Properties.Resources.Novalide;
            this.pictKeyValidation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictKeyValidation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictKeyValidation.Location = new System.Drawing.Point(162, 38);
            this.pictKeyValidation.Name = "pictKeyValidation";
            this.pictKeyValidation.Size = new System.Drawing.Size(24, 20);
            this.pictKeyValidation.TabIndex = 193;
            this.pictKeyValidation.TabStop = false;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(13, 60);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(158, 20);
            this.labelControl3.TabIndex = 194;
            this.labelControl3.Text = "Saving your Activation key...";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(13, 38);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(158, 20);
            this.labelControl2.TabIndex = 194;
            this.labelControl2.Text = "Checking key validation...";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(13, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(132, 20);
            this.labelControl1.TabIndex = 194;
            this.labelControl1.Text = "Connecting to server...";
            // 
            // pictsavekey
            // 
            this.pictsavekey.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictsavekey.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictsavekey.Location = new System.Drawing.Point(177, 60);
            this.pictsavekey.Name = "pictsavekey";
            this.pictsavekey.Size = new System.Drawing.Size(24, 20);
            this.pictsavekey.TabIndex = 193;
            this.pictsavekey.TabStop = false;
            // 
            // pictconnexion
            // 
            this.pictconnexion.BackgroundImage = global::BookLauncher.Properties.Resources.valide;
            this.pictconnexion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictconnexion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictconnexion.Location = new System.Drawing.Point(147, 12);
            this.pictconnexion.Name = "pictconnexion";
            this.pictconnexion.Size = new System.Drawing.Size(24, 20);
            this.pictconnexion.TabIndex = 193;
            this.pictconnexion.TabStop = false;
            // 
            // TCodeClient
            // 
            this.TCodeClient.EditValue = "";
            this.TCodeClient.Location = new System.Drawing.Point(60, 28);
            this.TCodeClient.Name = "TCodeClient";
            this.TCodeClient.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCodeClient.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.TCodeClient.Properties.Appearance.Options.UseFont = true;
            this.TCodeClient.Properties.Appearance.Options.UseForeColor = true;
            this.TCodeClient.Size = new System.Drawing.Size(291, 22);
            this.TCodeClient.TabIndex = 0;
            // 
            // tSerial
            // 
            this.tSerial.EditValue = "";
            this.tSerial.Location = new System.Drawing.Point(60, 62);
            this.tSerial.Name = "tSerial";
            this.tSerial.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 10F);
            this.tSerial.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.tSerial.Properties.Appearance.Options.UseFont = true;
            this.tSerial.Properties.Appearance.Options.UseForeColor = true;
            this.tSerial.Size = new System.Drawing.Size(291, 22);
            this.tSerial.TabIndex = 0;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Verdana", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl4.Location = new System.Drawing.Point(15, 31);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(33, 16);
            this.labelControl4.TabIndex = 197;
            this.labelControl4.Text = "Email";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Verdana", 10F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl5.Location = new System.Drawing.Point(15, 65);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 16);
            this.labelControl5.TabIndex = 197;
            this.labelControl5.Text = "Key";
            // 
            // Reactivation
            // 
            this.Reactivation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Reactivation.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.Reactivation.Location = new System.Drawing.Point(214, 90);
            this.Reactivation.Name = "Reactivation";
            this.Reactivation.Size = new System.Drawing.Size(109, 35);
            this.Reactivation.TabIndex = 198;
            this.Reactivation.Text = "Reactivation";
            this.Reactivation.Click += new System.EventHandler(this.Reactivation_Click);
            // 
            // Frm_Active
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Frm_Active";
            this.Size = new System.Drawing.Size(508, 328);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictwait)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictKeyValidation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictsavekey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictconnexion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TCodeClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSerial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit tSerial;
        private System.Windows.Forms.PictureBox pictwait;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictsavekey;
        private System.Windows.Forms.PictureBox pictKeyValidation;
        private System.Windows.Forms.PictureBox pictconnexion;
        private DevExpress.XtraEditors.TextEdit TCodeClient;
        private DevExpress.XtraEditors.SimpleButton bclose;
        private DevExpress.XtraEditors.SimpleButton Bsend;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton Reactivation;
    }
}
