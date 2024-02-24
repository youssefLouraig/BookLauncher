namespace BookLauncher.Forms
{
    partial class Frm_ImportExcel
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ImportExcel));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupAccuntKDP = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.tpassword = new DevExpress.XtraEditors.TextEdit();
            this.temail = new DevExpress.XtraEditors.TextEdit();
            this.BsendMult = new DevExpress.XtraEditors.SimpleButton();
            this.cshutdown = new DevExpress.XtraEditors.CheckEdit();
            this.bclose = new DevExpress.XtraEditors.SimpleButton();
            this.progbar = new DevExpress.XtraEditors.ProgressBarControl();
            this.Bsend = new DevExpress.XtraEditors.SimpleButton();
            this.gridBooks = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.BInterior = new System.Windows.Forms.Button();
            this.tManuscript = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupAccuntKDP)).BeginInit();
            this.groupAccuntKDP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tpassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.temail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cshutdown.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tManuscript.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.groupAccuntKDP);
            this.panelControl1.Controls.Add(this.BsendMult);
            this.panelControl1.Controls.Add(this.cshutdown);
            this.panelControl1.Controls.Add(this.bclose);
            this.panelControl1.Controls.Add(this.progbar);
            this.panelControl1.Controls.Add(this.Bsend);
            this.panelControl1.Controls.Add(this.gridBooks);
            this.panelControl1.Controls.Add(this.groupControl6);
            this.panelControl1.Location = new System.Drawing.Point(14, 16);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1036, 503);
            this.panelControl1.TabIndex = 0;
            this.panelControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelControl1_Paint);
            // 
            // groupAccuntKDP
            // 
            this.groupAccuntKDP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupAccuntKDP.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupAccuntKDP.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.groupAccuntKDP.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("groupAccuntKDP.AppearanceCaption.Image")));
            this.groupAccuntKDP.AppearanceCaption.Options.UseFont = true;
            this.groupAccuntKDP.AppearanceCaption.Options.UseImage = true;
            this.groupAccuntKDP.AppearanceCaption.Options.UseTextOptions = true;
            this.groupAccuntKDP.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupAccuntKDP.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.groupAccuntKDP.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupAccuntKDP.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupAccuntKDP.Controls.Add(this.labelControl2);
            this.groupAccuntKDP.Controls.Add(this.labelControl1);
            this.groupAccuntKDP.Controls.Add(this.tpassword);
            this.groupAccuntKDP.Controls.Add(this.temail);
            this.groupAccuntKDP.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.groupAccuntKDP.Location = new System.Drawing.Point(34, 19);
            this.groupAccuntKDP.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupAccuntKDP.Name = "groupAccuntKDP";
            this.groupAccuntKDP.Size = new System.Drawing.Size(665, 64);
            this.groupAccuntKDP.TabIndex = 200;
            this.groupAccuntKDP.Text = "Account KDP Amazon";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.Location = new System.Drawing.Point(310, 33);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Password";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl1.Location = new System.Drawing.Point(5, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Email";
            // 
            // tpassword
            // 
            this.tpassword.EditValue = "SalamYoussef.85";
            this.tpassword.Location = new System.Drawing.Point(362, 30);
            this.tpassword.Name = "tpassword";
            this.tpassword.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.tpassword.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.tpassword.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.tpassword.Properties.Appearance.Options.UseBackColor = true;
            this.tpassword.Properties.Appearance.Options.UseFont = true;
            this.tpassword.Properties.Appearance.Options.UseForeColor = true;
            this.tpassword.Properties.PasswordChar = '*';
            this.tpassword.Size = new System.Drawing.Size(188, 20);
            this.tpassword.TabIndex = 0;
            // 
            // temail
            // 
            this.temail.EditValue = "dev4guelmim@gmail.com";
            this.temail.Location = new System.Drawing.Point(35, 30);
            this.temail.Name = "temail";
            this.temail.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.temail.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.temail.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.temail.Properties.Appearance.Options.UseBackColor = true;
            this.temail.Properties.Appearance.Options.UseFont = true;
            this.temail.Properties.Appearance.Options.UseForeColor = true;
            this.temail.Size = new System.Drawing.Size(269, 20);
            this.temail.TabIndex = 0;
            // 
            // BsendMult
            // 
            this.BsendMult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BsendMult.Location = new System.Drawing.Point(735, 442);
            this.BsendMult.Name = "BsendMult";
            this.BsendMult.Size = new System.Drawing.Size(90, 34);
            this.BsendMult.TabIndex = 199;
            this.BsendMult.Text = "Send Multip";
            this.BsendMult.Visible = false;
            this.BsendMult.Click += new System.EventHandler(this.BsendMult_Click);
            // 
            // cshutdown
            // 
            this.cshutdown.Location = new System.Drawing.Point(34, 438);
            this.cshutdown.Name = "cshutdown";
            this.cshutdown.Properties.Caption = "Computer shutdown after publishing";
            this.cshutdown.Size = new System.Drawing.Size(203, 20);
            this.cshutdown.TabIndex = 198;
            // 
            // bclose
            // 
            this.bclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bclose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bclose.ImageOptions.Image")));
            this.bclose.Location = new System.Drawing.Point(937, 441);
            this.bclose.Name = "bclose";
            this.bclose.Size = new System.Drawing.Size(90, 35);
            this.bclose.TabIndex = 197;
            this.bclose.Text = "Close";
            this.bclose.Click += new System.EventHandler(this.bclose_Click);
            // 
            // progbar
            // 
            this.progbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progbar.Location = new System.Drawing.Point(34, 417);
            this.progbar.Name = "progbar";
            this.progbar.Properties.ShowTitle = true;
            this.progbar.Size = new System.Drawing.Size(997, 18);
            this.progbar.TabIndex = 18;
            this.progbar.Visible = false;
            // 
            // Bsend
            // 
            this.Bsend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Bsend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bsend.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Bsend.ImageOptions.Image")));
            this.Bsend.Location = new System.Drawing.Point(842, 441);
            this.Bsend.Name = "Bsend";
            this.Bsend.Size = new System.Drawing.Size(90, 34);
            this.Bsend.TabIndex = 17;
            this.Bsend.Text = "Send";
            this.Bsend.Click += new System.EventHandler(this.Bsend_Click);
            // 
            // gridBooks
            // 
            this.gridBooks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBooks.Location = new System.Drawing.Point(34, 159);
            this.gridBooks.MainView = this.gridView1;
            this.gridBooks.Name = "gridBooks";
            this.gridBooks.Size = new System.Drawing.Size(997, 252);
            this.gridBooks.TabIndex = 16;
            this.gridBooks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridBooks;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowMergedGrouping = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // groupControl6
            // 
            this.groupControl6.AppearanceCaption.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl6.AppearanceCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.groupControl6.AppearanceCaption.Image = ((System.Drawing.Image)(resources.GetObject("groupControl6.AppearanceCaption.Image")));
            this.groupControl6.AppearanceCaption.Options.UseFont = true;
            this.groupControl6.AppearanceCaption.Options.UseImage = true;
            this.groupControl6.AppearanceCaption.Options.UseTextOptions = true;
            this.groupControl6.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.groupControl6.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.groupControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupControl6.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl6.Controls.Add(this.BInterior);
            this.groupControl6.Controls.Add(this.tManuscript);
            this.groupControl6.GroupStyle = DevExpress.Utils.GroupStyle.Card;
            this.groupControl6.Location = new System.Drawing.Point(34, 89);
            this.groupControl6.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(665, 64);
            this.groupControl6.TabIndex = 9;
            this.groupControl6.Text = "File Excel";
            // 
            // BInterior
            // 
            this.BInterior.Location = new System.Drawing.Point(571, 28);
            this.BInterior.Name = "BInterior";
            this.BInterior.Size = new System.Drawing.Size(89, 23);
            this.BInterior.TabIndex = 2;
            this.BInterior.Text = "Select File";
            this.BInterior.UseVisualStyleBackColor = true;
            this.BInterior.Click += new System.EventHandler(this.BInterior_Click);
            // 
            // tManuscript
            // 
            this.tManuscript.EditValue = "File Excel";
            this.tManuscript.Location = new System.Drawing.Point(24, 29);
            this.tManuscript.Name = "tManuscript";
            this.tManuscript.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9F);
            this.tManuscript.Properties.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.tManuscript.Properties.Appearance.Options.UseFont = true;
            this.tManuscript.Properties.Appearance.Options.UseForeColor = true;
            this.tManuscript.Properties.ReadOnly = true;
            this.tManuscript.Size = new System.Drawing.Size(541, 20);
            this.tManuscript.TabIndex = 0;
            // 
            // Frm_ImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "Frm_ImportExcel";
            this.Size = new System.Drawing.Size(1072, 534);
            this.Load += new System.EventHandler(this.Frm_ImportExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupAccuntKDP)).EndInit();
            this.groupAccuntKDP.ResumeLayout(false);
            this.groupAccuntKDP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tpassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.temail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cshutdown.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tManuscript.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private System.Windows.Forms.Button BInterior;
        private DevExpress.XtraEditors.TextEdit tManuscript;
        private DevExpress.XtraGrid.GridControl gridBooks;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton Bsend;
        private DevExpress.XtraEditors.ProgressBarControl progbar;
        private DevExpress.XtraEditors.SimpleButton bclose;
        private DevExpress.XtraEditors.CheckEdit cshutdown;
        private DevExpress.XtraEditors.SimpleButton BsendMult;
        private DevExpress.XtraEditors.GroupControl groupAccuntKDP;
        private DevExpress.XtraEditors.TextEdit temail;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit tpassword;
    }
}
