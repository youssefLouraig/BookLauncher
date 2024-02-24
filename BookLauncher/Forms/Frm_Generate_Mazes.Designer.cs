namespace BookLauncher.Forms
{
    partial class Frm_Generate_Mazes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Generate_Mazes));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.bCover = new System.Windows.Forms.Button();
            this.tHEIGHT = new DevExpress.XtraEditors.TextEdit();
            this.tvalue5 = new System.Windows.Forms.RadioButton();
            this.tvalue4 = new System.Windows.Forms.RadioButton();
            this.tvalue3 = new System.Windows.Forms.RadioButton();
            this.tvalue2 = new System.Windows.Forms.RadioButton();
            this.tvalue1 = new System.Windows.Forms.RadioButton();
            this.tvalue0 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tSQUARESIZE = new DevExpress.XtraEditors.TextEdit();
            this.twidth = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.ttitle = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tCheminDossier = new DevExpress.XtraEditors.TextEdit();
            this.tNombreMoze = new DevExpress.XtraEditors.TextEdit();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.BModifier = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tHEIGHT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSQUARESIZE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twidth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ttitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCheminDossier.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNombreMoze.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pictureBox1);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.BModifier);
            this.panelControl1.Controls.Add(this.bCover);
            this.panelControl1.Controls.Add(this.tHEIGHT);
            this.panelControl1.Controls.Add(this.tvalue5);
            this.panelControl1.Controls.Add(this.tvalue4);
            this.panelControl1.Controls.Add(this.tvalue3);
            this.panelControl1.Controls.Add(this.tvalue2);
            this.panelControl1.Controls.Add(this.tvalue1);
            this.panelControl1.Controls.Add(this.tvalue0);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.tSQUARESIZE);
            this.panelControl1.Controls.Add(this.twidth);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.ttitle);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.tCheminDossier);
            this.panelControl1.Controls.Add(this.tNombreMoze);
            this.panelControl1.Location = new System.Drawing.Point(9, 3);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(552, 343);
            this.panelControl1.TabIndex = 0;
            // 
            // bCover
            // 
            this.bCover.Location = new System.Drawing.Point(404, 103);
            this.bCover.Name = "bCover";
            this.bCover.Size = new System.Drawing.Size(89, 23);
            this.bCover.TabIndex = 4;
            this.bCover.Text = "Select Folder";
            this.bCover.UseVisualStyleBackColor = true;
            this.bCover.Click += new System.EventHandler(this.bCover_Click);
            // 
            // tHEIGHT
            // 
            this.tHEIGHT.EditValue = "40";
            this.tHEIGHT.Location = new System.Drawing.Point(220, 156);
            this.tHEIGHT.Name = "tHEIGHT";
            this.tHEIGHT.Size = new System.Drawing.Size(76, 20);
            this.tHEIGHT.TabIndex = 9;
            // 
            // tvalue5
            // 
            this.tvalue5.AutoSize = true;
            this.tvalue5.Location = new System.Drawing.Point(98, 302);
            this.tvalue5.Name = "tvalue5";
            this.tvalue5.Size = new System.Drawing.Size(68, 17);
            this.tvalue5.TabIndex = 17;
            this.tvalue5.Text = "Inward X";
            this.tvalue5.UseVisualStyleBackColor = true;
            // 
            // tvalue4
            // 
            this.tvalue4.AutoSize = true;
            this.tvalue4.Location = new System.Drawing.Point(98, 283);
            this.tvalue4.Name = "tvalue4";
            this.tvalue4.Size = new System.Drawing.Size(118, 17);
            this.tvalue4.TabIndex = 16;
            this.tvalue4.Text = "Concentric Squares";
            this.tvalue4.UseVisualStyleBackColor = true;
            // 
            // tvalue3
            // 
            this.tvalue3.AutoSize = true;
            this.tvalue3.Location = new System.Drawing.Point(98, 264);
            this.tvalue3.Name = "tvalue3";
            this.tvalue3.Size = new System.Drawing.Size(122, 17);
            this.tvalue3.TabIndex = 15;
            this.tvalue3.Text = "Checkerboard Paths";
            this.tvalue3.UseVisualStyleBackColor = true;
            // 
            // tvalue2
            // 
            this.tvalue2.AutoSize = true;
            this.tvalue2.Location = new System.Drawing.Point(98, 245);
            this.tvalue2.Name = "tvalue2";
            this.tvalue2.Size = new System.Drawing.Size(124, 17);
            this.tvalue2.TabIndex = 14;
            this.tvalue2.Text = "Mostly Vertical Paths";
            this.tvalue2.UseVisualStyleBackColor = true;
            // 
            // tvalue1
            // 
            this.tvalue1.AutoSize = true;
            this.tvalue1.Location = new System.Drawing.Point(98, 226);
            this.tvalue1.Name = "tvalue1";
            this.tvalue1.Size = new System.Drawing.Size(137, 17);
            this.tvalue1.TabIndex = 13;
            this.tvalue1.Text = "Mostly Horizontal Paths";
            this.tvalue1.UseVisualStyleBackColor = true;
            // 
            // tvalue0
            // 
            this.tvalue0.AutoSize = true;
            this.tvalue0.Checked = true;
            this.tvalue0.Location = new System.Drawing.Point(98, 207);
            this.tvalue0.Name = "tvalue0";
            this.tvalue0.Size = new System.Drawing.Size(94, 17);
            this.tvalue0.TabIndex = 12;
            this.tvalue0.TabStop = true;
            this.tvalue0.Text = "Random Paths";
            this.tvalue0.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Height";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Maze square";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Width";
            // 
            // tSQUARESIZE
            // 
            this.tSQUARESIZE.EditValue = "40";
            this.tSQUARESIZE.Location = new System.Drawing.Point(98, 181);
            this.tSQUARESIZE.Name = "tSQUARESIZE";
            this.tSQUARESIZE.Size = new System.Drawing.Size(72, 20);
            this.tSQUARESIZE.TabIndex = 11;
            // 
            // twidth
            // 
            this.twidth.EditValue = "30";
            this.twidth.Location = new System.Drawing.Point(98, 156);
            this.twidth.Name = "twidth";
            this.twidth.Size = new System.Drawing.Size(72, 20);
            this.twidth.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Title";
            // 
            // ttitle
            // 
            this.ttitle.EditValue = "Titre Maze";
            this.ttitle.Location = new System.Drawing.Point(98, 130);
            this.ttitle.Name = "ttitle";
            this.ttitle.Size = new System.Drawing.Size(300, 20);
            this.ttitle.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Path folder";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Mozes";
            // 
            // tCheminDossier
            // 
            this.tCheminDossier.EditValue = "";
            this.tCheminDossier.Location = new System.Drawing.Point(98, 105);
            this.tCheminDossier.Name = "tCheminDossier";
            this.tCheminDossier.Properties.ReadOnly = true;
            this.tCheminDossier.Size = new System.Drawing.Size(300, 20);
            this.tCheminDossier.TabIndex = 3;
            // 
            // tNombreMoze
            // 
            this.tNombreMoze.EditValue = "10";
            this.tNombreMoze.Location = new System.Drawing.Point(98, 79);
            this.tNombreMoze.Name = "tNombreMoze";
            this.tNombreMoze.Size = new System.Drawing.Size(99, 20);
            this.tNombreMoze.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::BookLauncher.Properties.Resources.jjhjjhjhh;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(343, 226);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 112);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(357, 15);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(89, 35);
            this.simpleButton1.TabIndex = 18;
            this.simpleButton1.Text = "Genere";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // BModifier
            // 
            this.BModifier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BModifier.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BModifier.ImageOptions.Image")));
            this.BModifier.Location = new System.Drawing.Point(452, 15);
            this.BModifier.Name = "BModifier";
            this.BModifier.Size = new System.Drawing.Size(89, 35);
            this.BModifier.TabIndex = 19;
            this.BModifier.Text = "Cancel";
            this.BModifier.Click += new System.EventHandler(this.BModifier_Click);
            // 
            // Frm_Generate_Mazes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "Frm_Generate_Mazes";
            this.Size = new System.Drawing.Size(570, 364);
            this.Load += new System.EventHandler(this.Frm_Generate_Mazes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tHEIGHT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSQUARESIZE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twidth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ttitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCheminDossier.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNombreMoze.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit tHEIGHT;
        private System.Windows.Forms.RadioButton tvalue5;
        private System.Windows.Forms.RadioButton tvalue4;
        private System.Windows.Forms.RadioButton tvalue3;
        private System.Windows.Forms.RadioButton tvalue2;
        private System.Windows.Forms.RadioButton tvalue1;
        private System.Windows.Forms.RadioButton tvalue0;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit tSQUARESIZE;
        private DevExpress.XtraEditors.TextEdit twidth;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit ttitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit tCheminDossier;
        private DevExpress.XtraEditors.TextEdit tNombreMoze;
        private System.Windows.Forms.Button bCover;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton BModifier;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
