using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using BookLauncher.Class;
using OpenQA.Selenium.Chrome;

namespace BookLauncher.Forms
{
    public partial class Frm_Publishing : DevExpress.XtraEditors.XtraUserControl
    {
        public Frm_Publishing()
        {
            InitializeComponent();
            ttitle.LostFocus += ttitle_LostFocus;
            ttitle.GotFocus += ttitle_GotFocus;
        }
        private void ttitle_LostFocus(object sender, EventArgs  e)
        {
           
        }
private void ttitle_GotFocus(object sender, EventArgs e)
        {
           
        }

        DataTable tcover = new DataTable();
        private void Ajt_List_FileCover(int NB, string Nom, string chemin, string Status)
        {
            filcover.NBook = NB;
            filcover.NomFile = Nom;
            filcover.Status = Status;
            filcover.CheminFile = chemin;
            filcover.DatePublier = DateTime.Now.Date;
            ListFileCov.Add(filcover);
        }
        private static Frm_Publishing _saveBOOk;
        public static Frm_Publishing SaveBook
        {
            get
            {
                if (_saveBOOk == null) _saveBOOk = new Frm_Publishing();
                return _saveBOOk;
            }
        }
        OpenFileDialog opnFil = new OpenFileDialog();
        string chemin;
        Categorie Ccatg = new Categorie();
        FileCover filcover = new FileCover();
        Book book = new Book();
        List<FileCover> ListFileCov = new List<FileCover>();
        List<Control> listcontrols = new List<Control>();
        List<string> lcov = new List<string>();
        private void ttitle_MouseEnter(object sender, EventArgs e)
        {
            if (ttitle.Text == "Book Title")
            {
                ttitle.Text = "";
                ttitle.ForeColor = Color.Black;

            }
        }

        private void ttitle_MouseLeave(object sender, EventArgs e)
        {
            if (ttitle.Text == "")
            {
                ttitle.Text = "Book Title";
                ttitle.ForeColor = Color.Gray;

            }
        }

        private void tsubtitle_MouseEnter(object sender, EventArgs e)
        {
            if (tsubtitle.Text == "Subtitle")
            {
                tsubtitle.Text = "";
                tsubtitle.ForeColor = Color.Black;

            }
        }

        private void tsubtitle_MouseLeave(object sender, EventArgs e)
        {
            if (tsubtitle.Text == "")
            {
                tsubtitle.Text = "Subtitle";
                tsubtitle.ForeColor = Color.Gray;

            }
        }

        private void tDescription_MouseEnter(object sender, EventArgs e)
        {
            if (tDescription.Text == "Description")
            {
                tDescription.Text = "";
                tDescription.ForeColor = Color.Black;

            }
        }

        private void tDescription_MouseLeave(object sender, EventArgs e)
        {
            if (tDescription.Text == "")
            {
                tDescription.Text = "Description";
                tDescription.ForeColor = Color.Gray;

            }
        }

        private void tPrefix_MouseEnter(object sender, EventArgs e)
        {
            if (tPrefix.Text == "Prefix")
            {
                tPrefix.Text = "";
                tPrefix.ForeColor = Color.Black;

            }
        }

        private void tPrefix_MouseLeave(object sender, EventArgs e)
        {
            if (tPrefix.Text == "")
            {
                tPrefix.Text = "Prefix";
                tPrefix.ForeColor = Color.Gray;

            }
        }

        private void tFirst_Name_MouseEnter(object sender, EventArgs e)
        {
            if (tFirst_Name.Text == "First Name")
            {
                tFirst_Name.Text = "";
                tFirst_Name.ForeColor = Color.Black;

            }
        }

        private void tFirst_Name_MouseLeave(object sender, EventArgs e)
        {
            if (tFirst_Name.Text == "")
            {
                tFirst_Name.Text = "First Name";
                tFirst_Name.ForeColor = Color.Gray;

            }
        }

        private void tMiddle_Name_MouseEnter(object sender, EventArgs e)
        {
            if (tMiddle_Name.Text == "Middle Name")
            {
                tMiddle_Name.Text = "";
                tMiddle_Name.ForeColor = Color.Black;

            }
        }

        private void tMiddle_Name_MouseLeave(object sender, EventArgs e)
        {
            if (tMiddle_Name.Text == "")
            {
                tMiddle_Name.Text = "Middle Name";
                tMiddle_Name.ForeColor = Color.Gray;

            }
        }

        private void tLast_Name_MouseEnter(object sender, EventArgs e)
        {
            if (tLast_Name.Text == "Last Name")
            {
                tLast_Name.Text = "";
                tLast_Name.ForeColor = Color.Black;

            }
        }

        private void tLast_Name_MouseLeave(object sender, EventArgs e)
        {
            if (tLast_Name.Text == "")
            {
                tLast_Name.Text = "Last Name";
                tLast_Name.ForeColor = Color.Gray;

            }
        }

        private void tPrice_MouseEnter(object sender, EventArgs e)
        {
            if (tPrice.Text == "Price")
            {
                tPrice.Text = "";
                tPrice.ForeColor = Color.Black;

            }
        }

        private void tPrice_MouseLeave(object sender, EventArgs e)
        {
            if (tPrice.Text == "")
            {
                tPrice.Text = "Price";
                tPrice.ForeColor = Color.Gray;

            }
        }

        private void tKeyword1_MouseEnter(object sender, EventArgs e)
        {
            if (tKeyword1.Text == "Keyword 1")
            {
                tKeyword1.Text = "";
                tKeyword1.ForeColor = Color.Black;

            }
        }

        private void tKeyword1_MouseLeave(object sender, EventArgs e)
        {
            if (tKeyword1.Text == "")
            {
                tKeyword1.Text = "Keyword 1";
                tKeyword1.ForeColor = Color.Gray;

            }
        }

        private void tKeyword2_MouseEnter(object sender, EventArgs e)
        {
            if (tKeyword2.Text == "Keyword 2")
            {
                tKeyword2.Text = "";
                tKeyword2.ForeColor = Color.Black;

            }
        }

        private void tKeyword2_MouseLeave(object sender, EventArgs e)
        {
            if (tKeyword2.Text == "")
            {
                tKeyword2.Text = "Keyword 2";
                tKeyword2.ForeColor = Color.Gray;

            }
        }

        private void tKeyword3_MouseEnter(object sender, EventArgs e)
        {
            if (tKeyword3.Text == "Keyword 3")
            {
                tKeyword3.Text = "";
                tKeyword3.ForeColor = Color.Black;

            }
        }

        private void tKeyword3_MouseLeave(object sender, EventArgs e)
        {
            if (tKeyword3.Text == "")
            {
                tKeyword3.Text = "Keyword 3";
                tKeyword3.ForeColor = Color.Gray;

            }
        }

        private void tKeyword4_MouseEnter(object sender, EventArgs e)
        {
            if (tKeyword4.Text == "Keyword 4")
            {
                tKeyword4.Text = "";
                tKeyword4.ForeColor = Color.Black;

            }
        }

        private void tKeyword4_MouseLeave(object sender, EventArgs e)
        {
            if (tKeyword4.Text == "")
            {
                tKeyword4.Text = "Keyword 4";
                tKeyword4.ForeColor = Color.Gray;

            }
        }

        private void tKeyword5_MouseEnter(object sender, EventArgs e)
        {
            if (tKeyword5.Text == "Keyword 5")
            {
                tKeyword5.Text = "";
                tKeyword5.ForeColor = Color.Black;

            }
        }

        private void tKeyword5_MouseLeave(object sender, EventArgs e)
        {
            if (tKeyword5.Text == "")
            {
                tKeyword5.Text = "Keyword 5";
                tKeyword5.ForeColor = Color.Gray;

            }
        }

        private void tKeyword6_MouseEnter(object sender, EventArgs e)
        {
            if (tKeyword6.Text == "Keyword 6")
            {
                tKeyword6.Text = "";
                tKeyword6.ForeColor = Color.Black;

            }
        }

        private void tKeyword6_MouseLeave(object sender, EventArgs e)
        {
            if (tKeyword6.Text == "")
            {
                tKeyword6.Text = "Keyword 6";
                tKeyword6.ForeColor = Color.Gray;

            }
        }

        private void tKeyword7_MouseEnter(object sender, EventArgs e)
        {
            if (tKeyword7.Text == "Keyword 7")
            {
                tKeyword7.Text = "";
                tKeyword7.ForeColor = Color.Black;

            }
        }

        private void tKeyword7_MouseLeave(object sender, EventArgs e)
        {
            if (tKeyword7.Text == "")
            {
                tKeyword7.Text = "Keyword 7";
                tKeyword7.ForeColor = Color.Gray;

            }
        }

        private void tCategory1_MouseEnter(object sender, EventArgs e)
        {
            if (tCategory1.Text == "Category 1")
            {
                tCategory1.Text = "";
                tCategory1.ForeColor = Color.Black;

            }
        }

        private void tCategory1_MouseLeave(object sender, EventArgs e)
        {
            if (tCategory1.Text == "")
            {
                tCategory1.Text = "Category 1";
                tCategory1.ForeColor = Color.Gray;

            }
        }

        private void tCategory2_MouseEnter(object sender, EventArgs e)
        {
            if (tCategory2.Text == "Category 2")
            {
                tCategory2.Text = "";
                tCategory2.ForeColor = Color.Black;

            }
        }

        private void tCategory2_MouseLeave(object sender, EventArgs e)
        {
            if (tCategory2.Text == "")
            {
                tCategory2.Text = "Category 2";
                tCategory2.ForeColor = Color.Gray;

            }
        }

        private void tManuscript_MouseEnter(object sender, EventArgs e)
        {
            if (tManuscript.Text == "Manuscript")
            {
                tManuscript.Text = "";
                tManuscript.ForeColor = Color.Black;

            }
        }

        private void tManuscript_MouseLeave(object sender, EventArgs e)
        {
            if (tManuscript.Text == "")
            {
                tManuscript.Text = "Manuscript";
                tManuscript.ForeColor = Color.Gray;

            }
        }

        private void tBookCover_MouseEnter(object sender, EventArgs e)
        {
            if (tBookCover.Text == "Book Cover")
            {
                tBookCover.Text = "";
                tBookCover.ForeColor = Color.Black;

            }
        }

        private void tBookCover_MouseLeave(object sender, EventArgs e)
        {
            if (tBookCover.Text == "")
            {
                tBookCover.Text = "Book Cover";
                tBookCover.ForeColor = Color.Gray;

            }
        }

        private void BInterior_Click(object sender, EventArgs e)
        {

            opnFil.Filter = "Fichier PDF (*.Pdf)|*.pdf";
            opnFil.FileName = "";
            if (chemin == "")
            {
                opnFil.InitialDirectory = "C:\\";
            }
            else
            {
                opnFil.InitialDirectory = chemin;
            }
            if (opnFil.ShowDialog() == DialogResult.OK)
            {
                FileInfo fl = new FileInfo(opnFil.FileName);
                chemin = fl.DirectoryName.ToString();
                tManuscript.Text = opnFil.FileName;
                tManuscript.ForeColor = Color.Black;
                //Tpicture.BackgroundImage = Image.FromFile(opnFil.FileName);

            }
        }

        private void bCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            if (chemin == "")
            {
                folderBrowser.InitialDirectory = "C:\\";
            }
            else
            {
                folderBrowser.InitialDirectory = chemin;
            }

            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                tBookCover.Text = folderPath;
                tBookCover.ForeColor = Color.Black;
                string[] array2 = Directory.GetFiles(tBookCover.Text, "*.pdf");
                FileInfo f;
                for (short i = 0; i < array2.LongLength; i++)
                {
                    f = new FileInfo(array2[i]);

                    AJouter_Ligne_fileCover(f.Name, f.FullName, "Nouveau", "");
                    //Ajt_List_FileCover(0,f.Name,f.FullName,"Nouveau");
                }
                gridCovers.DataSource = tcover;
                // ...
            }
        }
        private string Verification_zones()
        {
            string msg = "";
            if (ttitle.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(ttitle, "this Title field cannot be empty");
                //dxErrorProvider1.SetIconAlignment(ttitle,)
                msg = "Error";

            }
            if (tsubtitle.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(tsubtitle, "this Sub Title field cannot be empty");
                //dxErrorProvider1.SetIconAlignment(ttitle,)
                msg = "Error";

            }
            if (tDescription.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(tDescription, "this Description field cannot be empty");
                //dxErrorProvider1.SetIconAlignment(ttitle,)
                msg = "Error";

            }
            if (tFirst_Name.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(tFirst_Name, "this First Name field cannot be empty");
                //dxErrorProvider1.SetIconAlignment(ttitle,)
                msg = "Error";

            }
            if (tLast_Name.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(tLast_Name, "this Last Name field cannot be empty");
                msg = "Error";
            }
            if (tPrice.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(tPrice, "this Price field cannot be empty");
                msg = "Error";
            }
            if (tManuscript.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(tManuscript, "this Manuscript field cannot be empty");
                msg = "Error";
            }
            //*************keywords***********************
            if (tKeyword1.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(tKeyword1, "this Manuscript field cannot be empty");
                msg = "Error";
            }
            if (tKeyword2.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(tKeyword2, "this Manuscript field cannot be empty");
                msg = "Error";
            }
            if (tKeyword3.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(tKeyword3, "this Manuscript field cannot be empty");
                msg = "Error";
            }
            if (tKeyword4.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(tKeyword4, "this Manuscript field cannot be empty");
                msg = "Error";
            }
            if (tKeyword5.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(tKeyword5, "this Manuscript field cannot be empty");
                msg = "Error";
            }
            if (tKeyword6.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(tKeyword6, "this Manuscript field cannot be empty");
                msg = "Error";
            }
            if (tKeyword7.ForeColor == Color.Gray)
            {
                dxErrorProvider1.SetError(tKeyword7, "this Manuscript field cannot be empty");
                msg = "Error";
            }
            //*********************************************
            if (gridView1.SelectedRowsCount == 0)
            {
                dxErrorProvider1.SetError(gridCovers, "There is no cover file checked");
                msg = "Error";
            }
            return msg;
        }
        FileCover fl = new FileCover();
        private void Bsave_Click(object sender, EventArgs e)
        {
            if (Verification_zones() == "")
            {
                try
                {
                    book.Book_title = ttitle.Text;
                    book.sub_title = tsubtitle.Text;
                    book.Description = tDescription.Text;
                    book.First_Name = tFirst_Name.Text;
                    book.Prefix = (tPrefix.ForeColor == Color.Gray) ? "" : tPrefix.Text;
                    book.Mid_Name = (tMiddle_Name.ForeColor == Color.Gray) ? "" : tMiddle_Name.Text;
                    book.Last_Name = (tLast_Name.ForeColor == Color.Gray) ? "" : tLast_Name.Text;
                    book.Suffix = "";
                    book.Kayword1 = tKeyword1.Text;
                    book.Kayword2 = tKeyword2.Text;
                    book.Kayword3 = tKeyword3.Text;
                    book.Kayword4 = tKeyword4.Text;
                    book.Kayword5 = tKeyword5.Text;
                    book.Kayword6 = tKeyword6.Text;
                    book.Kayword7 = tKeyword7.Text;
                    book.Category1 = (tCategory1.ForeColor == Color.Gray) ? "" : tCategory1.Text;
                    book.Category2 = (tCategory2.ForeColor == Color.Gray) ? "" : tCategory2.Text;
                    if (book.Category1 != "")
                    {
                        if (!Ccatg.Existe_Categorie_Nom(book.Category1))
                        {
                            dxErrorProvider1.SetError(tCategory1, "Category 1 not exist");
                            return;
                        }
                    }
                    if (book.Category2 != "")
                    {
                        if (!Ccatg.Existe_Categorie_Nom(book.Category2))
                        {
                            dxErrorProvider1.SetError(tCategory2, "Category 2 not exist");
                            return;
                        }
                    }
                    book.Price = tPrice.Text;
                    book.type_paper = ttypepaper.Text;
                    book.size_paper = tsizepaper.Text;
                    book.Bleed = tbleed.Text;
                    book.Finish = tfinish.Text;
                    book.Interior_File = tManuscript.Text;
                    book.ISBN = "";
                    book.Adult = "No";
                    book.Ajouter_Book();
                    int nbook = book.Max_N_Book();
                    fl.NBook = nbook;
                    for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                    {
                        if (gridView1.GetSelectedRows()[i] >= 0)
                        {
                            DataRow dtrw = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
                            fl.NomFile = dtrw[0].ToString();
                            fl.Status = dtrw[2].ToString();
                            fl.CheminFile = dtrw[1].ToString();
                            fl.Ajouter_FileCover();
                        }
                    }

                    vide_zones();
                    MessageBox.Show("The save was made with success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

        }
        private void vide_zones()
        {

            ttitle.Text = "Book Title";
            ttitle.ForeColor = Color.Gray;
            tsubtitle.Text = "Subtitle";
            tsubtitle.ForeColor = Color.Gray;
            tDescription.Text = "Description";
            tDescription.ForeColor = Color.Gray;
            tPrefix.Text = "Prefix";
            tPrefix.ForeColor = Color.Gray;
            tFirst_Name.Text = "First Name";
            tFirst_Name.ForeColor = Color.Gray;
            tMiddle_Name.Text = "Middle Name";
            tMiddle_Name.ForeColor = Color.Gray;
            tLast_Name.Text = "Last Name";
            tLast_Name.ForeColor = Color.Gray;
            tCategory1.Text = "Category 1";
            tCategory1.ForeColor = Color.Gray;
            tCategory2.Text = "Category 2";
            tCategory2.ForeColor = Color.Gray;
            tKeyword1.Text = "Keyword 1";
            tKeyword1.ForeColor = Color.Gray;
            tKeyword2.Text = "Keyword 2"; tKeyword2.ForeColor = Color.Gray;
            tKeyword3.Text = "Keyword 3"; tKeyword3.ForeColor = Color.Gray;
            tKeyword4.Text = "Keyword 4"; tKeyword4.ForeColor = Color.Gray;
            tKeyword5.Text = "Keyword 5"; tKeyword5.ForeColor = Color.Gray;
            tKeyword6.Text = "Keyword 6"; tKeyword6.ForeColor = Color.Gray;
            tKeyword7.Text = "Keyword 7"; tKeyword7.ForeColor = Color.Gray;
            tManuscript.Text = "Manuscript"; tManuscript.ForeColor = Color.Gray;
            tBookCover.Text = "Book Cover"; tBookCover.ForeColor = Color.Gray;
            tcover.Rows.Clear();
            gridCovers.DataSource = tcover;
            tPrice.Text = "Price"; tPrice.ForeColor = Color.Gray;
            ttypepaper.Text = ttypepaper.Text = "Black & white interior with white paper";
            tsizepaper.Text = "6 x 9 in (15.24x22.86cm)";
            tbleed.Text = "No Bleed";
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            Frm_ListeBooks frm = new Frm_ListeBooks();
            //frm.MdiParent = this.MdiParent;
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    tNbook.Text = frm.Nbook.ToString();
            //    book.NBook = frm.Nbook;
            //    Affecter_Donnees();
            //}
        }

        private void Affecter_Donnees()
        {
            book.Affater_Book();
            if (book.Book_title != "")
            {
                ttitle.Text = book.Book_title;
                tsubtitle.Text = book.sub_title;
                tDescription.Text = book.Description;
                tFirst_Name.Text = book.First_Name;
                tPrefix.Text = book.Prefix;
                tMiddle_Name.Text = book.Mid_Name;
                tsubtitle.Text = book.sub_title;
                tLast_Name.Text = book.Last_Name;
                //book.Suffix = "";
                tKeyword1.Text = book.Kayword1;
                tKeyword2.Text = book.Kayword2;
                tKeyword3.Text = book.Kayword3;
                tKeyword4.Text = book.Kayword4;
                tKeyword5.Text = book.Kayword5;
                tKeyword6.Text = book.Kayword6;
                tKeyword7.Text = book.Kayword7;
                tCategory1.Text = book.Category1;
                tCategory2.Text = book.Category2;
                tPrice.Text = book.Price;
                ttypepaper.Text = book.type_paper;
                tsizepaper.Text = book.size_paper;
                tbleed.Text = book.Bleed;
                tfinish.Text = book.Finish;
                tManuscript.Text = book.Interior_File;
                book.ISBN = "";
                book.Adult = "No";
                // MessageBox.Show(listcontrols.Count.ToString());
                for (int i = 0; i < listcontrols.Count; i++)
                {
                    if (((Control)listcontrols[i]).Text == "")
                    {

                        ((Control)listcontrols[i]).ForeColor = Color.Gray;
                        switch (((Control)listcontrols[i]).Name.ToString())
                        {
                            case "ttitle": ((Control)listcontrols[i]).Text = "Book Title"; break;
                            case "tsubtitle": ((Control)listcontrols[i]).Text = "Sub Title"; break;
                            case "tDescription": ((Control)listcontrols[i]).Text = "Description"; break;
                            case "tPrefix": ((Control)listcontrols[i]).Text = "Prefix"; break;
                            case "tFirst_Name": ((Control)listcontrols[i]).Text = "First Name"; break;
                            case "tMiddle_Name": ((Control)listcontrols[i]).Text = "Middle Name"; break;
                            case "tLast_Name": ((Control)listcontrols[i]).Text = "Last Name"; break;
                            case "tCategory1": ((Control)listcontrols[i]).Text = "Category 1"; break;
                            case "tCategory2": ((Control)listcontrols[i]).Text = "Category 2"; break;
                            case "tKeyword1": ((Control)listcontrols[i]).Text = "Keyword 1"; break;
                            case "tKeyword2": ((Control)listcontrols[i]).Text = "Keyword 2"; break;
                            case "tKeyword3": ((Control)listcontrols[i]).Text = "Keyword 3"; break;
                            case "tKeyword4": ((Control)listcontrols[i]).Text = "Keyword 4"; break;
                            case "tKeyword5": ((Control)listcontrols[i]).Text = "Keyword 5"; break;
                            case "tKeyword6": ((Control)listcontrols[i]).Text = "Keyword 6"; break;
                            case "tKeyword7": ((Control)listcontrols[i]).Text = "Keyword 7"; break;
                            case "tPrice": ((Control)listcontrols[i]).Text = "Price"; break;
                            default: ((Control)listcontrols[i]).Text = ""; break;
                        }
                    }
                    else
                    {
                        ((Control)listcontrols[i]).ForeColor = Color.Black;
                    }
                }
                tcover.Rows.Clear();
                Affecter_File_cover();
            }

        }
        DataTable tcoverfile = new DataTable();
        private void Affecter_File_cover()
        {
            filcover.NBook = int.Parse(tNbook.Text.ToString());


            tcoverfile = filcover.Liste_Cover_FileCover_Book();
            if (tcoverfile.Rows.Count > 0)
            {
                for (int i = 0; i < tcoverfile.Rows.Count; i++)
                {
                    AJouter_Ligne_fileCover(tcoverfile.Rows[i][2].ToString(), tcoverfile.Rows[i][3].ToString(), tcoverfile.Rows[i][4].ToString(), tcoverfile.Rows[i][5].ToString());
                    gridView1.SelectAll();
                    //ListeCovers.SetItemChecked(ListeCovers.Items.Count - 1, true);
                    gridCovers.DataSource = tcover;
                }
            }
            // MessageBox.Show(lcov[1].ToString());
            Bsave.Enabled = false;
            BModifier.Enabled = true;
        }
        private void remplir_controle()
        {
            listcontrols.Add(ttitle);
            listcontrols.Add(tsubtitle);
            listcontrols.Add(tDescription);
            listcontrols.Add(tPrefix);
            listcontrols.Add(tFirst_Name);
            listcontrols.Add(tMiddle_Name);
            listcontrols.Add(tLast_Name);
            listcontrols.Add(tCategory1);
            listcontrols.Add(tCategory2);
            listcontrols.Add(tKeyword1);
            listcontrols.Add(tKeyword2);
            listcontrols.Add(tKeyword3);
            listcontrols.Add(tKeyword4);
            listcontrols.Add(tKeyword5);
            listcontrols.Add(tKeyword6);
            listcontrols.Add(tKeyword7);
            listcontrols.Add(tManuscript);
            listcontrols.Add(tBookCover);
            listcontrols.Add(tPrice);
        }
        
        private void Frm_Publishing_Load(object sender, EventArgs e)
        {
            remplir_controle();
            Creation_Table_Covers();
        }
        private void AJouter_Ligne_fileCover(string nomfil, string chemin, string stat, string datepubl)
        {
            DataRow rd;
            rd = tcover.NewRow();
            rd["NomFile"] = nomfil;
            rd["CheminFile"] = chemin;
            rd["Status"] = stat;
            rd["DatePublier"] = datepubl;
            tcover.Rows.Add(rd);

        }
        private void Creation_Table_Covers()
        {
            tcover.Columns.Add("NomFile", typeof(System.String));
            tcover.Columns.Add("CheminFile", typeof(System.String));
            tcover.Columns.Add("Status", typeof(System.String));
            tcover.Columns.Add("DatePublier", typeof(System.String));
            gridCovers.DataSource = tcover;
            gridView1.Columns[0].Width = 30;
            gridView1.Columns[1].Width = 130;
            gridView1.Columns[2].Width = 20;
        }
        private void Bpublier_Click(object sender, EventArgs e)
        {

            try
            {
                if (Verification_zones() == "")
                {
                    string exsitfil = exist_files();
                    if (exsitfil!="")
                    {
                        MessageBox.Show(exsitfil, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    book.Book_title = ttitle.Text;
                    book.sub_title = tsubtitle.Text;
                    book.Description = tDescription.Text;
                    book.First_Name = tFirst_Name.Text;
                    book.Prefix = (tPrefix.ForeColor == Color.Gray) ? "" : tPrefix.Text;
                    book.Mid_Name = (tMiddle_Name.ForeColor == Color.Gray) ? "" : tMiddle_Name.Text;
                    book.Last_Name = (tLast_Name.ForeColor == Color.Gray) ? "" : tLast_Name.Text;
                    book.Suffix = "";
                    book.Kayword1 = tKeyword1.Text;
                    book.Kayword2 = tKeyword2.Text;
                    book.Kayword3 = tKeyword3.Text;
                    book.Kayword4 = tKeyword4.Text;
                    book.Kayword5 = tKeyword5.Text;
                    book.Kayword6 = tKeyword6.Text;
                    book.Kayword7 = tKeyword7.Text;
                    book.Category1 = (tCategory1.ForeColor == Color.Gray) ? "" : tCategory1.Text;
                    book.Category2 = (tCategory2.ForeColor == Color.Gray) ? "" : tCategory2.Text;
                    book.Price = tPrice.Text;
                    book.type_paper = ttypepaper.Text;
                    book.size_paper = tsizepaper.Text;
                    book.Bleed = tbleed.Text;
                    book.Finish = tfinish.Text;
                    book.Interior_File = tManuscript.Text;
                    book.ISBN = "";
                    book.Adult = "No";
                    //book.Ajouter_Book();

                    int nbook = ancienNbook;
                    fl.NBook = nbook;


                   
                    if (Activer_Programme.IsConnectedToInternet())
                    {
                        MessageBox.Show(" internet does not exist");
                        return;
                    }
                    Launcher Claunc = new Launcher();
                    ChromeDriverService serv = ChromeDriverService.CreateDefaultService();
                    serv.HideCommandPromptWindow = true;
                    Launcher.dvr = new ChromeDriver(serv);
                    //Launcher.dvr = new ChromeDriver();
                    Launcher.Message = "";
                    Claunc.Ouvrir_chrome();
                    if (Launcher.Message != "")
                    {
                        MessageBox.Show(Launcher.Message);
                        return;
                    }
                    Claunc.Sign_in(false);
                    if (Launcher.Message != "")
                    {
                        MessageBox.Show(Launcher.Message);
                        return;
                    }
                    for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                    {
                        if (gridView1.GetSelectedRows()[i] >= 0)
                        {
                            DataRow dtrw = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
                            //fl.NomFile = dtrw[0].ToString();
                            //fl.Status = dtrw[2].ToString();
                            //fl.CheminFile = dtrw[1].ToString();
                            if (dtrw[2].ToString() == "Send")
                            {
                                continue;
                            }
                            fl.DatePublier = DateTime.Today;
                            book.Cover_File = dtrw[1].ToString();
                            book.ISBN = "";
                            Claunc.book = book;
                            Launcher.Message = "";
                            Claunc.Bookshelf();
                            if (Launcher.Message != "")
                            {
                                MessageBox.Show(Launcher.Message);
                                continue;
                            }
                            Launcher.Message = "";
                            Claunc.Paperback_Details();
                            if (Launcher.Message != "")
                            {
                                MessageBox.Show(Launcher.Message);
                                continue;
                            }
                            Launcher.Message = "";
                            Claunc.Paperback_Content();
                            if (Launcher.Message != "")
                            {
                                MessageBox.Show(Launcher.Message);
                                continue;
                            }
                            fl.CheminFile = book.Cover_File;
                            if (fl.Exists_Cover_FileCover())
                            {
                                fl.DatePublier = DateTime.Today;
                                fl.Status = "Send";
                                fl.Modifier_DatePub_FileCover();
                            }
                            //fl.Ajouter_FileCover();
                        }
                    }
                    vide_zones();
                    MessageBox.Show("Books Send", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //if(ListeCovers.Items.Count > 0)
            //{
            //    Launcher Claunc = new Launcher();
            //    Launcher.dvr = new ChromeDriver();
            //    Claunc.Ouvrir_chrome();
            //    Claunc.Sign_in();
            //    for (int i=0;i< ListeCovers.CheckedItems.Count;i++)
            //    {
            //        book.Cover_File = lcov[i].ToString();
            //        book.ISBN = "";
            //        Claunc.book = book;
            //        Launcher.Message = "";
            //        Claunc.Bookshelf();

            //        if (Launcher.Message != "")
            //        {
            //            MessageBox.Show(Launcher.Message);

            //            continue;
            //        }
            //        Launcher.Message = "";
            //        Claunc.Paperback_Details();
            //        if (Launcher.Message != "")
            //        {
            //            MessageBox.Show(Launcher.Message);
            //            continue;
            //        }
            //        Launcher.Message = "";
            //        Claunc.Paperback_Content();
            //        if (Launcher.Message != "")
            //        {
            //            MessageBox.Show(Launcher.Message);
            //            continue;
            //        }
            //    }

            //    MessageBox.Show("Fin");
            // }

        }
        private string exist_files()
        {
            string s = "";
            if (!File.Exists(tManuscript.Text))
            {
                s = "file Interior not exist";
            }
            else
            {
                for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                {
                    if (gridView1.GetSelectedRows()[i] >= 0)
                    {
                        DataRow dtrw = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
                        if (!File.Exists(dtrw[1].ToString()) && dtrw[1].ToString() !="Send")
                        {
                            s = s + " " + dtrw[1].ToString() + " not exist \n";
                        }
                    }
                }
            }

            return s;

        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }

        int ancienNbook;

        private void Brecherche_Click(object sender, EventArgs e)
        {
            if (tNbook.ForeColor != Color.Gray)
            {
                book.NBook = int.Parse(tNbook.Text.ToString());
                ancienNbook = int.Parse(tNbook.Text.ToString());
                //book.Affater_Book();
                Affecter_Donnees();
            }
            else
            {
                dxErrorProvider1.SetError(tNbook, "this N° Book field cannot be empty");
            }
        }

        private void tNbook_MouseEnter(object sender, EventArgs e)
        {
            if (tNbook.Text == "N° Book")
            {
                tNbook.Text = "";
                tNbook.ForeColor = Color.Black;

            }
        }
        private void tNbook_MouseLeave(object sender, EventArgs e)
        {
            if (tNbook.Text == "")
            {
                tNbook.Text = "N° Book";
                tNbook.ForeColor = Color.Gray;
            }
        }

        private void BModifier_Click(object sender, EventArgs e)
        {
            if (Verification_zones() == "")
            {
                try
                {
                    book.NBook = ancienNbook;
                    book.Book_title = ttitle.Text;
                    book.sub_title = tsubtitle.Text;
                    book.Description = tDescription.Text;
                    book.First_Name = tFirst_Name.Text;
                    book.Prefix = (tPrefix.ForeColor == Color.Gray) ? "" : tPrefix.Text;
                    book.Mid_Name = (tMiddle_Name.ForeColor == Color.Gray) ? "" : tMiddle_Name.Text;
                    book.Last_Name = (tLast_Name.ForeColor == Color.Gray) ? "" : tLast_Name.Text;
                    book.Suffix = "";
                    book.Kayword1 = tKeyword1.Text;
                    book.Kayword2 = tKeyword2.Text;
                    book.Kayword3 = tKeyword3.Text;
                    book.Kayword4 = tKeyword4.Text;
                    book.Kayword5 = tKeyword5.Text;
                    book.Kayword6 = tKeyword6.Text;
                    book.Kayword7 = tKeyword7.Text;
                    book.Category1 = (tCategory1.ForeColor == Color.Gray) ? "" : tCategory1.Text;
                    book.Category2 = (tCategory2.ForeColor == Color.Gray) ? "" : tCategory2.Text;
                    if (book.Category1 != "")
                    {
                        if (!Ccatg.Existe_Categorie_Nom(book.Category1))
                        {
                            dxErrorProvider1.SetError(tCategory1, "Category 1 not exist");
                            return;
                        }
                    }
                    if (book.Category2 != "")
                    {
                        if (!Ccatg.Existe_Categorie_Nom(book.Category2))
                        {
                            dxErrorProvider1.SetError(tCategory2, "Category 2 not exist");
                            return;
                        }
                    }
                    book.Price = tPrice.Text;
                    book.type_paper = ttypepaper.Text;
                    book.size_paper = tsizepaper.Text;
                    book.Bleed = tbleed.Text;
                    book.Finish = tfinish.Text;
                    book.Interior_File = tManuscript.Text;
                    book.ISBN = "";
                    book.Adult = "No";
                    book.Modifier_Book();
                    int nbook = book.Max_N_Book();
                    fl.NBook = ancienNbook;
                    fl.Supprimer_tout_FileCover();
                    for (int i = 0; i < gridView1.SelectedRowsCount; i++)
                    {
                        if (gridView1.GetSelectedRows()[i] >= 0)
                        {
                            DataRow dtrw = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
                            fl.NomFile = dtrw[0].ToString();
                            fl.Status = dtrw[2].ToString();
                            fl.CheminFile = dtrw[1].ToString();
                            if (fl.Status != "Nouveau")
                            {
                                fl.DatePublier = DateTime.Parse(dtrw[3].ToString());
                                fl.Ajouter_AncienFileCover();
                            }
                            else
                            {
                                fl.Ajouter_FileCover();
                            }


                        }
                    }

                    vide_zones();
                    MessageBox.Show("The update was made with success", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void Bdelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You really want to delete this book ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                book.NBook = ancienNbook;
                book.Supprimer_Book();
                fl.NBook = ancienNbook;
                fl.Supprimer_tout_FileCover();
                vide_zones();
                MessageBox.Show("deletion has been successfully completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Bnew_Click(object sender, EventArgs e)
        {
            vide_zones();

        }
    }
}