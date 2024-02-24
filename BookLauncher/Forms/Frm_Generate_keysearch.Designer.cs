namespace BookLauncher.Forms
{
    partial class Frm_Generate_keysearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Generate_keysearch));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.label6 = new System.Windows.Forms.Label();
            this.tCheminDossier = new DevExpress.XtraEditors.TextEdit();
            this.tnombrePuzzle = new DevExpress.XtraEditors.SpinEdit();
            this.progbar = new DevExpress.XtraEditors.ProgressBarControl();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.tdescription = new System.Windows.Forms.TextBox();
            this.ttitre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lchemin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lfilecount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.BModifier = new DevExpress.XtraEditors.SimpleButton();
            this.bParcourir1 = new DevExpress.XtraEditors.SimpleButton();
            this.bCover1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tCheminDossier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tnombrePuzzle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progbar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.bCover1);
            this.panelControl1.Controls.Add(this.bParcourir1);
            this.panelControl1.Controls.Add(this.progbar);
            this.panelControl1.Controls.Add(this.listBox2);
            this.panelControl1.Controls.Add(this.pictureBox1);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.tCheminDossier);
            this.panelControl1.Controls.Add(this.tnombrePuzzle);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.BModifier);
            this.panelControl1.Controls.Add(this.tdescription);
            this.panelControl1.Controls.Add(this.ttitre);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.lchemin);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.lfilecount);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Location = new System.Drawing.Point(13, 13);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(751, 568);
            this.panelControl1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Path folder";
            // 
            // tCheminDossier
            // 
            this.tCheminDossier.EditValue = "";
            this.tCheminDossier.Location = new System.Drawing.Point(92, 82);
            this.tCheminDossier.Name = "tCheminDossier";
            this.tCheminDossier.Properties.ReadOnly = true;
            this.tCheminDossier.Size = new System.Drawing.Size(335, 20);
            this.tCheminDossier.TabIndex = 4;
            // 
            // tnombrePuzzle
            // 
            this.tnombrePuzzle.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tnombrePuzzle.Location = new System.Drawing.Point(92, 272);
            this.tnombrePuzzle.Name = "tnombrePuzzle";
            this.tnombrePuzzle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tnombrePuzzle.Size = new System.Drawing.Size(60, 20);
            this.tnombrePuzzle.TabIndex = 11;
            // 
            // progbar
            // 
            this.progbar.Location = new System.Drawing.Point(12, 308);
            this.progbar.Name = "progbar";
            this.progbar.Properties.ShowTitle = true;
            this.progbar.Size = new System.Drawing.Size(489, 18);
            this.progbar.TabIndex = 34;
            this.progbar.Visible = false;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(513, 55);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(222, 251);
            this.listBox2.TabIndex = 12;
            this.listBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox2_KeyDown);
            // 
            // tdescription
            // 
            this.tdescription.Location = new System.Drawing.Point(92, 135);
            this.tdescription.Multiline = true;
            this.tdescription.Name = "tdescription";
            this.tdescription.Size = new System.Drawing.Size(333, 132);
            this.tdescription.TabIndex = 9;
            this.tdescription.Text = "Description";
            // 
            // ttitre
            // 
            this.ttitre.Location = new System.Drawing.Point(92, 109);
            this.ttitre.Name = "ttitre";
            this.ttitre.Size = new System.Drawing.Size(333, 21);
            this.ttitre.TabIndex = 7;
            this.ttitre.Text = "Title";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Sub Title";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Number puzzle";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Book title";
            // 
            // lchemin
            // 
            this.lchemin.BackColor = System.Drawing.Color.Gray;
            this.lchemin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lchemin.ForeColor = System.Drawing.Color.White;
            this.lchemin.Location = new System.Drawing.Point(92, 57);
            this.lchemin.Name = "lchemin";
            this.lchemin.Size = new System.Drawing.Size(335, 18);
            this.lchemin.TabIndex = 1;
            this.lchemin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(515, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Count keywords";
            // 
            // lfilecount
            // 
            this.lfilecount.AutoSize = true;
            this.lfilecount.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lfilecount.Location = new System.Drawing.Point(647, 308);
            this.lfilecount.Name = "lfilecount";
            this.lfilecount.Size = new System.Drawing.Size(25, 14);
            this.lfilecount.TabIndex = 9;
            this.lfilecount.Text = "00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File txt";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::BookLauncher.Properties.Resources.Puzzles;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(232, 275);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 273);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(551, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(89, 35);
            this.simpleButton1.TabIndex = 13;
            this.simpleButton1.Text = "Genere";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // BModifier
            // 
            this.BModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BModifier.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BModifier.ImageOptions.Image")));
            this.BModifier.Location = new System.Drawing.Point(646, 5);
            this.BModifier.Name = "BModifier";
            this.BModifier.Size = new System.Drawing.Size(89, 35);
            this.BModifier.TabIndex = 14;
            this.BModifier.Text = "Cancel";
            this.BModifier.Click += new System.EventHandler(this.BModifier_Click);
            // 
            // bParcourir1
            // 
            this.bParcourir1.Location = new System.Drawing.Point(428, 55);
            this.bParcourir1.Name = "bParcourir1";
            this.bParcourir1.Size = new System.Drawing.Size(83, 23);
            this.bParcourir1.TabIndex = 36;
            this.bParcourir1.Text = "Select File";
            this.bParcourir1.Click += new System.EventHandler(this.bParcourir1_Click);
            // 
            // bCover1
            // 
            this.bCover1.Location = new System.Drawing.Point(428, 82);
            this.bCover1.Name = "bCover1";
            this.bCover1.Size = new System.Drawing.Size(83, 21);
            this.bCover1.TabIndex = 37;
            this.bCover1.Text = "Select Folder";
            this.bCover1.Click += new System.EventHandler(this.bCover1_Click);
            // 
            // Frm_Generate_keysearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "Frm_Generate_keysearch";
            this.Size = new System.Drawing.Size(780, 584);
            this.Load += new System.EventHandler(this.Frm_Generate_keysearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tCheminDossier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tnombrePuzzle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progbar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox tdescription;
        private System.Windows.Forms.TextBox ttitre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lchemin;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton BModifier;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lfilecount;
        private DevExpress.XtraEditors.ProgressBarControl progbar;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SpinEdit tnombrePuzzle;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit tCheminDossier;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.SimpleButton bCover1;
        private DevExpress.XtraEditors.SimpleButton bParcourir1;
    }
}
