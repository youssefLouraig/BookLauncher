using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookLauncher.Class;
using System.IO;
using excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Globalization;
using DevExpress.XtraGrid.Views.Grid;
using OpenQA.Selenium.Chrome;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using System.Threading;
using System.Diagnostics;

namespace BookLauncher.Forms
{

    public partial class Frm_ImportExcel : UserControl
    {
        public Frm_ImportExcel()
        {
            InitializeComponent();
        }
        Dictionary<string, string, string> listsizehard = new Dictionary<string, string, string>();
        Dictionary<string, string, string> listsizeperp = new Dictionary<string, string, string>();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint SetThreadExecutionState([In] uint esFlags);
        string cheminbureau;
        short numberLigne;
        Charge_Excel fCExcel = new Charge_Excel();

        OpenFileDialog opnFil = new OpenFileDialog();
        List<short> listIndx = new List<short>();
        Book book = new Book();
        //Launcher Claunc;
        string chemin;
        string cheminfile;
        Categorie catg = new Categorie();
        private static Frm_ImportExcel _ImportBOOk;
        public static Frm_ImportExcel ImportBook
        {
            get
            {
                if (_ImportBOOk == null) _ImportBOOk = new Frm_ImportExcel();
                return _ImportBOOk;
            }
        }
        private double Return_MinPrice(bool isHardBook,string nom)
        {
            double price=0;
            switch (nom)
            {
                case "priceuk": price = isHardBook ? 8.67 : 10.17;
                    break;
                case "Price": price = isHardBook ? 11.57 : 15.42;
                    break;
                case "pricede":
                    price = isHardBook ? 9.90 : 13.00;
                    break;
                case "pricefr":
                    price = isHardBook ? 9.90 : 13.00;
                    break;
                case "pricees":
                    price = isHardBook ? 9.90 : 13.00;
                    break;
                case "priceit":
                    price = isHardBook ? 9.90 : 13.00;
                    break;
                case "pricenl":
                    price = isHardBook ? 9.90 : 13.00;
                    break;
                case "pricepl":
                    price = isHardBook ? 46.57 : 60.62;
                    break;
                case "pricese":
                    price = isHardBook ? 100.08 : 132.15;
                    break;
                case "pricecojp":
                    price = 1092;
                    break;
                case "priceca":
                    price = 19.85;
                    break;
                case "priceau":
                    price = 18.02;
                    break;
            }


            return price;
        }
        private double Return_MaxPrice( string nom)
        {
            double price = 0;
            switch (nom)
            {
                case "pricede":
                case "pricefr":
                case "pricees":
                case "priceit":
                case "pricenl":
                case "priceuk":
                case "Price":
                    price =  250.00;
                    break;
               
                case "pricepl":
                    price =  1200;
                    break;
                case "pricese":
                    price =  2500.00;
                    break;
                case "pricecojp":
                    price = 30000;
                    break;
                case "priceca":
                case "priceau":
                    price = 350.00;
                    break;
            }


            return price;
        }
        private string remplacer_virgule(string prix )
        {
            string s = prix;
            if (prix.Contains(","))
            {
                s = prix.Replace(",", ".");
            }
            return s;
        }
        private double return_doubleIfnotdouble(string num)
        {
            if (Module.IsDouble(num))
            {
                return Convert.ToDouble(num);
            }
            else
            {
                return 10;
            }
        }
        private void Frm_ImportExcel_Load(object sender, EventArgs e)
        {
            chemin = "";
            cheminbureau = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            temail.Text = Module.Nom_Utilisateur;
            tpassword.Text = Module.Mot_passe;

            listsizehard.Add("5.5", "8.5", "5.5 x 8.5 in (13.97 x 21.59 cm)");
            listsizehard.Add("6", "9", "6 x 9 in (15.24x22.86cm)");
            listsizehard.Add("6.14", "9.21", "6.14 x 9.21 in (15.6 x 23.39 cm)");
            listsizehard.Add("7", "10", "7 x 10 in (17.78 x 25.4 cm)");
            listsizehard.Add("8.25", "11", "8.25 x 11 in (20.95 x 27.94 cm)");
            listsizeperp.Add("6", "9", "6 x 9 in (15.24x22.86cm)");
            listsizeperp.Add("5", "8", "5 x 8 in (12.7x20.32 cm)");
            listsizeperp.Add("5.25", "8", "5.25 x 8 in (13.34x20.32cm)");
            listsizeperp.Add("5.5", "8.5", "5.5 x 8.5 in (13.97x21.59)");
            listsizeperp.Add("5.06", "7.81", "5.06 x 7.81 in (12.85 x 19.84 cm)");
            listsizeperp.Add("6.14", "9.21", "6.14 x 9.21 in (15.6 x 23.39 cm)");
            listsizeperp.Add("6.69", "9.61", "6.69 x 9.61 in (16.99 x 24.4 cm)");
            listsizeperp.Add("7", "10", "7 x 10 in (17.78 x 25.4 cm)");
            listsizeperp.Add("7.44", "9.69", "7.44 x 9.69 in (18.9 x 24.61 cm)");
            listsizeperp.Add("7.5", "9.25", "7.5 x 9.25 in (19.05 x 23.5 cm)");
            listsizeperp.Add("8", "10", "8 x 10 in (20.32 x 25.4 cm)");
            listsizeperp.Add("8.5", "11", "8.5 x 11 in (21.59 x 27.94 cm)");
            listsizeperp.Add("8.5", "8.5", "8.5 x 8.5 in (21.59 x 21.59 cm)");
            listsizeperp.Add("8.27", "11.69", "8.27 x 11.69 in (21 x 29.7 cm)");
            listsizeperp.Add("8.25", "6", "8.25 x 6 in (20.96 x 15.24 cm)");
            listsizeperp.Add("8.25", "8.25", "8.25 x 8.25 in (20.96 x 20.96 cm)");
            //listsizeperp.Add("6","9", "6 x 9 in (15.24x22.86cm)");


        }

        private void BInterior_Click(object sender, EventArgs e)
        {

            opnFil.Filter = "Fichier Excel 2007 (*.xlsx)|*.xlsx|Fichier Excel 2003 (*.xls)|*.xls";
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
                if (tManuscript.ForeColor != Color.Gray && temail.Text != "" && tpassword.Text != "")
                {
                    listIndx.Clear();
                    //FileInfo fl = new FileInfo(tManuscript.Text);
                    String constr;
                    if (fl.Extension == "xls")
                    {
                        constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tManuscript.Text + ";Extended Properties='Excel 8.0;HDR=YES';";
                    }
                    else
                    {
                        constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + tManuscript.Text + ";Extended Properties='Excel 12.0 Xml;HDR=YES';";
                    }

                    OleDbConnection con = new OleDbConnection(constr);
                    cheminfile = tManuscript.Text;
                    OleDbCommand oconn = new OleDbCommand("Select * From [KDP Automation$]", con);
                    try
                    {
                        con.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Fichier ouvert ,ferme le avant utiliser :" + ex.Message);
                        Process[] proc = Process.GetProcessesByName("EXCEL");
                        //EXCEL
                        if (proc.Length != 0)
                        {
                            foreach (Process worker in proc)
                            {
                                worker.Kill();
                                worker.WaitForExit();
                                worker.Dispose();
                            }

                        }
                        return;
                    }

                    OleDbDataReader sda;
                    DataTable data = new DataTable();
                    sda = oconn.ExecuteReader();
                    data.Load(sda);
                    con.Close();
                    gridBooks.DataSource = data;
                    //connecExcel.Open()
                    //Dim t As New DataTable
                    //Dim cmd As New OleDbCommand("select * from [" & Tnomfueille.Text & "$]", connecExcel)
                    //Dim dr As OleDbDataReader
                    //dr = cmd.ExecuteReader()
                    //t.Load(dr)
                    //connecExcel.Close()
                }

            }
        }


        //string catg1, catg2;
        TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

        private void Bsend_Click(object sender, EventArgs e)
        {
            if (listIndx.Count == 0)
            {
                Process[] proc = Process.GetProcessesByName("chromedriver");
                //EXCEL
                if (proc.Length != 0)
                {
                    foreach (Process worker in proc)
                    {
                        worker.Kill();
                        worker.WaitForExit();
                        worker.Dispose();
                    }

                }
                excel.Application App = new excel.Application();
                excel.Workbook work = App.Workbooks.Open(cheminfile);
                excel.Worksheet x = App.Sheets[1];
                Launcher Claunc = new Launcher();
                SetThreadExecutionState(0x00000002);
                try
                {
                    ChromeDriverService serv = ChromeDriverService.CreateDefaultService();
                    serv.HideCommandPromptWindow = true;
                    //MessageBox.Show("salam");
                    Launcher.dvr = new ChromeDriver(serv);
                    //Launcher.dvr = new ChromeDriver();
                    Module.Nom_Utilisateur = temail.Text;
                    Module.Mot_passe = tpassword.Text;
                    Claunc.Ouvrir_chrome();
                    Claunc.Sign_in(groupAccuntKDP.Visible);

                    progbar.Visible = true;
                    progbar.Properties.Maximum = gridView1.RowCount * 2;
                    progbar.EditValue = 0;


                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        progbar.Increment(1);
                        Application.DoEvents();
                        if (!listIndx.Contains((short)i))
                        {
                            DataRow dtrw = gridView1.GetDataRow(i);
                            book.Interior_File = dtrw[0].ToString();
                            book.Cover_File = dtrw[1].ToString();
                            if (dtrw[0].ToString() == "")
                            {
                                progbar.Visible = false;
                                Application.DoEvents();
                                break;
                            }

                            if (!File.Exists(book.Interior_File))
                            {
                                numberLigne = (short)(i + 2);
                                x.Range["AA" + numberLigne].Value = "Interior file not exist";
                                continue;
                            }
                            if (!File.Exists(book.Cover_File))
                            {
                                numberLigne = (short)(i + 2);
                                x.Range["AA" + numberLigne].Value = "Cover file not exist";
                                continue;
                            }
                            Launcher.Message = "";
                            if (gridView1.IsRowSelected(i))
                            {
                                //DataRow dtrw = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
                                book.HardBook = (dtrw[38].ToString() == "" || dtrw[38].ToString().ToLower() == "false") ? false : true; // Hard
                                string width, height;
                                width = dtrw[23].ToString();
                                height = dtrw[24].ToString();
                                if (height.Contains(","))
                                {
                                    height = height.Replace(",", ".");
                                }
                                if (width.Contains(","))
                                {
                                    width = width.Replace(",", ".");
                                }

                                if (book.HardBook)
                                {
                                    if (!listsizehard.ContainsKey(width, height))
                                    {
                                        MessageBox.Show("Size (Height,Width) est Erroné ", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        return;
                                    }
                                }
                                else
                                {
                                    if (!listsizeperp.ContainsKey(width, height))
                                    {
                                        MessageBox.Show("Size (Height,Width) est Erroné ", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        return;
                                    }
                                }
                                book.Interior_File = dtrw[0].ToString();
                                book.Cover_File = dtrw[1].ToString();
                                book.Book_title = dtrw[2].ToString();
                                book.sub_title = dtrw[3].ToString();
                                book.Prefix = dtrw[4].ToString();
                                book.First_Name = dtrw[5].ToString();
                                book.Mid_Name = dtrw[6].ToString();
                                book.Last_Name = dtrw[7].ToString();
                                book.Suffix = dtrw[8].ToString();
                                book.Description = dtrw[9].ToString();
                                if (dtrw[9].ToString() == "")
                                {
                                    MessageBox.Show("Description est vide ");
                                    Environment.Exit(-1);
                                    return;
                                }
                                book.Kayword1 = dtrw[10].ToString();
                                book.Kayword2 = dtrw[11].ToString();
                                book.Kayword3 = dtrw[12].ToString();
                                book.Kayword4 = dtrw[13].ToString();
                                book.Kayword5 = dtrw[14].ToString();
                                book.Kayword6 = dtrw[15].ToString();
                                book.Kayword7 = dtrw[16].ToString();
                                string prix = dtrw[17].ToString();
                                double minprix = 0;
                                double Maxprix = 0;
                                minprix = Return_MinPrice(book.HardBook, "Price");
                                Maxprix = Return_MaxPrice("Price");
                                prix = (Convert.ToDouble(prix) < minprix && Convert.ToDouble(prix) != 0) || Convert.ToDouble(prix) > Maxprix ? minprix.ToString() : prix;
                                book.Price = remplacer_virgule(prix);

                                prix = dtrw[27].ToString();
                                prix = return_doubleIfnotdouble(prix).ToString();
                                minprix = Return_MinPrice(book.HardBook, "priceuk");
                                prix = (Convert.ToDouble(prix) < minprix && Convert.ToDouble(prix) != 0) || Convert.ToDouble(prix) > Maxprix ? minprix.ToString() : prix;
                                book.priceuk = remplacer_virgule(prix);

                                prix = dtrw[28].ToString();
                                prix = return_doubleIfnotdouble(prix).ToString();
                                minprix = Return_MinPrice(book.HardBook, "pricede");
                                prix = (Convert.ToDouble(prix) < minprix && Convert.ToDouble(prix) != 0) || Convert.ToDouble(prix) > Maxprix ? minprix.ToString() : prix;
                                book.pricede = remplacer_virgule(prix);
                               
                                prix = dtrw[29].ToString();
                                prix = return_doubleIfnotdouble(prix).ToString();
                                minprix = Return_MinPrice(book.HardBook, "pricefr");
                                prix = (Convert.ToDouble(prix) < minprix && Convert.ToDouble(prix) != 0) || Convert.ToDouble(prix) > Maxprix ? minprix.ToString() : prix;
                                book.pricefr = remplacer_virgule(prix);
                              
                                prix = dtrw[30].ToString();
                                prix = return_doubleIfnotdouble(prix).ToString();
                                minprix = Return_MinPrice(book.HardBook, "pricees");
                                prix = (Convert.ToDouble(prix) < minprix && Convert.ToDouble(prix) != 0) || Convert.ToDouble(prix) > Maxprix ? minprix.ToString() : prix;
                                book.pricees = remplacer_virgule(prix);
                               
                                prix = dtrw[31].ToString();
                                prix = return_doubleIfnotdouble(prix).ToString();
                                minprix = Return_MinPrice(book.HardBook, "priceit");
                                prix = (Convert.ToDouble(prix) < minprix && Convert.ToDouble(prix) != 0) || Convert.ToDouble(prix) > Maxprix ? minprix.ToString() : prix;
                                book.priceit = remplacer_virgule(prix);
                               
                                prix = dtrw[32].ToString();
                                prix = return_doubleIfnotdouble(prix).ToString();
                                minprix = Return_MinPrice(book.HardBook, "pricenl");
                                prix = (Convert.ToDouble(prix) < minprix && Convert.ToDouble(prix) != 0) || Convert.ToDouble(prix) > Maxprix ? minprix.ToString() : prix;
                                book.pricenl = remplacer_virgule(prix);
                                Maxprix = Return_MaxPrice("pricepl");
                                prix = dtrw[33].ToString();
                                prix = return_doubleIfnotdouble(prix).ToString();
                                minprix = Return_MinPrice(book.HardBook, "pricepl");
                                prix = (Convert.ToDouble(prix) < minprix && Convert.ToDouble(prix) != 0) || Convert.ToDouble(prix) > Maxprix ? minprix.ToString() : prix;
                                book.pricepl = remplacer_virgule(prix);
                                Maxprix = Return_MaxPrice("pricese");
                                prix = dtrw[34].ToString();
                                prix = return_doubleIfnotdouble(prix).ToString();
                                minprix = Return_MinPrice(book.HardBook, "pricese");
                                prix = (Convert.ToDouble(prix) < minprix && Convert.ToDouble(prix) != 0) || Convert.ToDouble(prix) > Maxprix ? minprix.ToString() : prix;
                                book.pricese = remplacer_virgule(prix);
                                Maxprix = Return_MaxPrice("pricecojp");
                                prix = dtrw[35].ToString();
                                prix = return_doubleIfnotdouble(prix).ToString();
                                minprix = Return_MinPrice(book.HardBook, "pricecojp");
                                prix = (Convert.ToDouble(prix) < minprix && Convert.ToDouble(prix) != 0) || Convert.ToDouble(prix) > Maxprix ? minprix.ToString() : prix;
                                book.pricecojp = remplacer_virgule(prix);
                               
                                prix = dtrw[36].ToString();
                                Maxprix = Return_MaxPrice("priceca");
                                prix = return_doubleIfnotdouble(prix).ToString();
                                minprix = Return_MinPrice(book.HardBook, "priceca");
                                prix = (Convert.ToDouble(prix) < minprix && Convert.ToDouble(prix) != 0) || Convert.ToDouble(prix) > Maxprix ? minprix.ToString() : prix;
                                book.priceca = remplacer_virgule(prix);

                                Maxprix = Return_MaxPrice("priceau");
                                prix = dtrw[37].ToString();
                                prix = return_doubleIfnotdouble(prix).ToString();
                                minprix = Return_MinPrice(book.HardBook, "priceau");
                                prix = (Convert.ToDouble(prix) < minprix && Convert.ToDouble(prix) != 0) || Convert.ToDouble(prix) > Maxprix ? minprix.ToString() : prix;
                                book.priceau = remplacer_virgule(prix);
                               
                                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                                if (dtrw[18].ToString() != "" && dtrw[19].ToString() == "")
                                {
                                    book.Category1 = "";
                                    book.Category2 = "";
                                }
                                else
                                {
                                    book.Category1 = ti.ToTitleCase(dtrw[18].ToString());
                                    book.Category2 = ti.ToTitleCase(dtrw[19].ToString());
                                }

                                book.ISBN = dtrw[20].ToString();
                                book.Adult = "No";
                                book.Bleed = dtrw[25].ToString();
                                book.Suffix = "";
                                book.type_paper = dtrw[22].ToString();
                                //6 x 9 in (15.24x22.86cm)

                                book.size_paper = book.HardBook ? listsizehard[width, height] : listsizeperp[width, height];



                                Claunc.book = book;
                                //Claunc.paperBack_Contentcomplete();
                                //return;
                                //Launcher.Message = "";
                                if (book.HardBook)
                                {
                                    Claunc.HardCover();
                                }
                                else
                                {
                                    Claunc.Bookshelf();
                                }


                                //Claunc.ButtonContinuesetup();

                                if (Launcher.Message != "")
                                {
                                    //MessageBox.Show(Launcher.Message);
                                    numberLigne = (short)(i + 2);
                                    x.Range["AA" + numberLigne].Value = Launcher.Message;

                                    continue;
                                }
                                //Launcher.Message = "";

                                Claunc.Paperback_Details();
                                if (Launcher.Message != "")
                                {
                                    //MessageBox.Show(Launcher.Message);
                                    numberLigne = (short)(i + 2);
                                    x.Range["AA" + numberLigne].Value = Launcher.Message;
                                    continue;

                                }
                                //Launcher.Message = "";
                                Claunc.Paperback_Content();
                                if (Launcher.Message != "")
                                {
                                    //MessageBox.Show(Launcher.Message);
                                    numberLigne = (short)(i + 2);
                                    x.Range["AA" + numberLigne].Value = Launcher.Message;
                                    continue;
                                }
                                numberLigne = (short)(i + 2);
                                x.Range["AA" + numberLigne].Value = "Send";
                                x.Range["AA" + numberLigne].Font.Bold = true;

                                //------------Complete Paper content ---------------
                                // Claunc.paperBack_Contentcomplete();
                            }



                        }

                        progbar.Increment(1);
                        Application.DoEvents();
                    }
                    work.Close(true, Type.Missing, Type.Missing);
                    App.Quit();
                    Launcher.dvr.Quit();
                    if (cshutdown.Checked)
                    {
                        System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    work.Close(true, Type.Missing, Type.Missing);
                    App.Quit();
                    Launcher.dvr.Quit();
                }
                Launcher.dvr.Quit();
                //SetThreadExecutionState()
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(cheminbureau);
            //for (int i = 0; i < gridView1.RowCount; i++)
            //{
            //    //progbar.Increment(1);
            //    //Application.DoEvents();
            //    if (!listIndx.Contains((short)i))
            //    {
            //        DataRow dtrw = gridView1.GetDataRow(i);

            //        //Launcher.Message = "";
            //        MessageBox.Show(gridView1.IsRowSelected(i).ToString());

            //    }
            //}
        }

        private void bclose_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataRow dtrw = gridView1.GetDataRow(0);
            book.Interior_File = dtrw[0].ToString();
            book.Cover_File = dtrw[1].ToString();
            MessageBox.Show(dtrw[23].ToString() + "x" + dtrw[24].ToString());
            if (dtrw[23].ToString() == "6")
            {
                book.size_paper = "6 x 9 in (15.24x22.86cm)";

            }
            else
            {
                switch (dtrw[23].ToString())
                {
                    case "5":
                        book.size_paper = "5 x 8 in (12.7x20.32 cm)"; break;
                    case "5.25":
                        book.size_paper = "5.25 x 8 in (13.34x20.32cm)"; break;
                    case "5.5":
                        book.size_paper = "5.5 x 8.5 in (13.97x21.59)"; break;
                    case "5.06":
                        book.size_paper = "5.06 x 7.81 in (12.85 x 19.84 cm)"; break;
                    case "6.14":
                        book.size_paper = "6.14 x 9.21 in (15.6 x 23.39 cm)"; break;
                    case "6.69":
                        book.size_paper = "6.69 x 9.61 in (16.99 x 24.4 cm)"; break;
                    case "7":
                        book.size_paper = "7 x 10 in (17.78 x 25.4 cm)"; break;
                    case "7.44":
                        book.size_paper = "7.44 x 9.69 in (18.9 x 24.61 cm)"; break;
                    case "7.5":
                        book.size_paper = "7.5 x 9.25 in (19.05 x 23.5 cm)"; break;
                    case "8":
                        book.size_paper = "8 x 10 in (20.32 x 25.4 cm)"; break;
                    case "8.5":
                        if (dtrw[24].ToString() == "11")
                        {
                            book.size_paper = "8.5 x 11 in (21.59 x 27.94 cm)";
                        }
                        else
                        {
                            book.size_paper = "8.5 x 8.5 in (21.59 x 21.59 cm)";
                        }
                        break;
                    case "8.27":
                        book.size_paper = "8.27 x 11.69 in (21 x 29.7 cm)"; break;
                    case "8.25":
                        if (dtrw[24].ToString() == "6")
                        {
                            book.size_paper = "8.25 x 6 in (20.96 x 15.24 cm)";
                        }
                        else
                        {
                            book.size_paper = "8.25 x 8.25 in (20.96 x 20.96 cm)";
                        }
                        break;
                    default:
                        book.size_paper = "6 x 9 in (15.24x22.86cm)";
                        break;
                }
            }
            // MessageBox.Show(book.size_paper);
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //GridView currentView = sender as GridView;
            //if (e.Column.FieldName == "Category #1 (Optional)")
            //{
            //    catg1 = currentView.GetRowCellValue(e.RowHandle, "Category #1 (Optional)").ToString();
            //    e.Appearance.ForeColor = Color.Black;
            //    if (catg1 != "")
            //    {
            //        catg1 = ti.ToTitleCase(catg1);
            //        if (!catg.Existe_Categorie_Nom(catg1))
            //        {
            //            e.Appearance.ForeColor = Color.Red;
            //            listIndx.Add((short)e.RowHandle);
            //        }

            //    }
            //}
            //if (e.Column.FieldName == "Category #2 (Optional)")
            //{
            //    catg2 = currentView.GetRowCellValue(e.RowHandle, "Category #2 (Optional)").ToString();
            //    e.Appearance.ForeColor = Color.Black;
            //    //e.Appearance.ForeColor = Color.Black;
            //    if (catg2 != "")
            //    {
            //        catg2 = ti.ToTitleCase(catg2);

            //        if (!catg.Existe_Categorie_Nom(catg1))
            //        {
            //            e.Appearance.ForeColor = Color.Red;
            //            if (!listIndx.Contains((short)e.RowHandle))
            //            {
            //                listIndx.Add((short)e.RowHandle);
            //            }
            //        }

            //    }
            //}
        }
        List<Book> listBooks = new List<Book>();
        Thread Thred;
        Thread Thred1;
        Thread Thred2;
        public void Travail_1()
        {
            // ClauncMul.dvr.SwitchTo().Window(tabs[1]);
            ClauncMul.dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/create");
            ClauncMul.Bookshelf();
            ClauncMul.book = listBooks[0];
            ClauncMul.Paperback_Details();
        }
        public void Travail_2()
        {
            ChromeDriverService serv = ChromeDriverService.CreateDefaultService();
            serv.HideCommandPromptWindow = true;
            //MessageBox.Show("salam");
            ClauncMul1.dvr = new ChromeDriver(serv);


            //ClauncMul1.dvr.SwitchTo().Window(tabs[2]);
            ClauncMul1.dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/create");
            ClauncMul1.Bookshelf();
            ClauncMul1.book = listBooks[1];
            ClauncMul1.Paperback_Details();
        }
        public void Travail_3()
        {
            ChromeDriverService serv = ChromeDriverService.CreateDefaultService();
            serv.HideCommandPromptWindow = true;
            //MessageBox.Show("salam");
            ClauncMul2.dvr = new ChromeDriver(serv);
            var cookies = ClauncMul.dvr.Manage().Cookies.AllCookies;
            foreach (var itm in cookies)
            {
                ClauncMul2.dvr.Manage().Cookies.AddCookie(itm);
            }
            //ClauncMul2.dvr.SwitchTo().Window(tabs[3]);
            ClauncMul2.dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/create");
            ClauncMul2.Bookshelf();
            ClauncMul2.book = listBooks[2];
            ClauncMul2.Paperback_Details();
        }
        Launcher_Multip ClauncMul = new Launcher_Multip();
        Launcher_Multip ClauncMul1 = new Launcher_Multip();
        Launcher_Multip ClauncMul2 = new Launcher_Multip();
        IList<string> tabs;
        List<Cookie> cookies = new List<Cookie>();
        private void BsendMult_Click(object sender, EventArgs e)
        {
            if (listIndx.Count == 0)
            {
                excel.Application App = new excel.Application();
                excel.Workbook work = App.Workbooks.Open(cheminfile);
                excel.Worksheet x = App.Sheets[1];
                //Launcher_Multip ClauncMul = new Launcher_Multip();
                SetThreadExecutionState(0x00000002);
                try
                {
                    ChromeDriverService serv = ChromeDriverService.CreateDefaultService();
                    serv.HideCommandPromptWindow = true;
                    //MessageBox.Show("salam");
                    ClauncMul.dvr = new ChromeDriver(serv);

                    ClauncMul.Ouvrir_chrome();
                    ClauncMul.Sign_in();

                    progbar.Visible = true;
                    progbar.Properties.Maximum = gridView1.RowCount * 2;
                    progbar.EditValue = 0;


                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        progbar.Increment(1);
                        Application.DoEvents();
                        if (!listIndx.Contains((short)i))
                        {
                            DataRow dtrw = gridView1.GetDataRow(i);
                            book.Interior_File = dtrw[0].ToString();
                            book.Cover_File = dtrw[1].ToString();
                            if (dtrw[0].ToString() == "")
                            {
                                progbar.Visible = false;
                                Application.DoEvents();
                                break;
                            }

                            if (!File.Exists(book.Interior_File))
                            {
                                numberLigne = (short)(i + 2);
                                x.Range["AA" + numberLigne].Value = "Interior file not exist";
                                continue;
                            }
                            if (!File.Exists(book.Cover_File))
                            {
                                numberLigne = (short)(i + 2);
                                x.Range["AA" + numberLigne].Value = "Cover file not exist";
                                continue;
                            }
                            Launcher.Message = "";

                            int indx = 0;
                            if (gridView1.IsRowSelected(i))
                            {
                                //DataRow dtrw = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
                                book.Interior_File = dtrw[0].ToString();
                                book.Cover_File = dtrw[1].ToString();
                                book.Book_title = dtrw[2].ToString();
                                book.sub_title = dtrw[3].ToString();
                                book.Prefix = dtrw[4].ToString();
                                book.First_Name = dtrw[5].ToString();
                                book.Mid_Name = dtrw[6].ToString();
                                book.Last_Name = dtrw[7].ToString();
                                book.Suffix = dtrw[8].ToString();
                                book.Description = dtrw[9].ToString();
                                book.Kayword1 = dtrw[10].ToString();
                                book.Kayword2 = dtrw[11].ToString();
                                book.Kayword3 = dtrw[12].ToString();
                                book.Kayword4 = dtrw[13].ToString();
                                book.Kayword5 = dtrw[14].ToString();
                                book.Kayword6 = dtrw[15].ToString();
                                book.Kayword7 = dtrw[16].ToString();
                                string prix = dtrw[17].ToString();
                                if (prix.Contains(","))
                                {
                                    prix = prix.Replace(",", ".");
                                }
                                book.Price = prix;
                                prix = dtrw[27].ToString();
                                if (prix.Contains(","))
                                {
                                    prix = prix.Replace(",", ".");
                                }
                                book.priceuk = prix;
                                prix = dtrw[28].ToString();
                                if (prix.Contains(","))
                                {
                                    prix = prix.Replace(",", ".");
                                }
                                book.pricede = prix;
                                prix = dtrw[29].ToString();
                                if (prix.Contains(","))
                                {
                                    prix = prix.Replace(",", ".");
                                }
                                book.pricefr = prix;
                                prix = dtrw[30].ToString();
                                if (prix.Contains(","))
                                {
                                    prix = prix.Replace(",", ".");
                                }
                                book.pricees = prix;
                                prix = dtrw[31].ToString();
                                if (prix.Contains(","))
                                {
                                    prix = prix.Replace(",", ".");
                                }
                                book.priceit = prix;
                                prix = dtrw[32].ToString();
                                if (prix.Contains(","))
                                {
                                    prix = prix.Replace(",", ".");
                                }
                                book.pricenl = prix;
                                prix = dtrw[33].ToString();
                                if (prix.Contains(","))
                                {
                                    prix = prix.Replace(",", ".");
                                }
                                book.pricepl = prix;
                                prix = dtrw[34].ToString();
                                if (prix.Contains(","))
                                {
                                    prix = prix.Replace(",", ".");
                                }
                                book.pricese = prix;
                                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                                if (dtrw[18].ToString() != "" && dtrw[19].ToString() == "")
                                {
                                    book.Category1 = "";
                                    book.Category2 = "";
                                }
                                else
                                {
                                    book.Category1 = ti.ToTitleCase(dtrw[18].ToString());
                                    book.Category2 = ti.ToTitleCase(dtrw[19].ToString());
                                }

                                book.ISBN = dtrw[20].ToString();
                                book.Adult = "No";
                                book.Bleed = dtrw[25].ToString();
                                book.Suffix = "";
                                book.type_paper = dtrw[22].ToString();
                                //6 x 9 in (15.24x22.86cm)
                                string width, height;
                                width = dtrw[23].ToString();
                                height = dtrw[24].ToString();
                                if (height.Contains(","))
                                {
                                    height = height.Replace(",", ".");
                                }
                                if (width.Contains(","))
                                {
                                    width = width.Replace(",", ".");
                                }
                                if (width == "6")
                                {
                                    book.size_paper = "6 x 9 in (15.24x22.86cm)";

                                }
                                else
                                {
                                    switch (width)
                                    {
                                        case "5":
                                            book.size_paper = "5 x 8 in (12.7x20.32 cm)"; break;
                                        case "5.25":
                                            book.size_paper = "5.25 x 8 in (13.34x20.32cm)"; break;
                                        case "5.5":
                                            book.size_paper = "5.5 x 8.5 in (13.97x21.59)"; break;
                                        case "5.06":
                                            book.size_paper = "5.06 x 7.81 in (12.85 x 19.84 cm)"; break;
                                        case "6.14":
                                            book.size_paper = "6.14 x 9.21 in (15.6 x 23.39 cm)"; break;
                                        case "6.69":
                                            book.size_paper = "6.69 x 9.61 in (16.99 x 24.4 cm)"; break;
                                        case "7":
                                            book.size_paper = "7 x 10 in (17.78 x 25.4 cm)"; break;
                                        case "7.44":
                                            book.size_paper = "7.44 x 9.69 in (18.9 x 24.61 cm)"; break;
                                        case "7.5":
                                            book.size_paper = "7.5 x 9.25 in (19.05 x 23.5 cm)"; break;
                                        case "8":
                                            book.size_paper = "8 x 10 in (20.32 x 25.4 cm)"; break;
                                        case "8.5":
                                            if (height == "11")
                                            {
                                                book.size_paper = "8.5 x 11 in (21.59 x 27.94 cm)";
                                            }
                                            else
                                            {
                                                book.size_paper = "8.5 x 8.5 in (21.59 x 21.59 cm)";
                                            }
                                            break;
                                        case "8.27":
                                            book.size_paper = "8.27 x 11.69 in (21 x 29.7 cm)"; break;
                                        case "8.25":
                                            if (height == "6")
                                            {
                                                book.size_paper = "8.25 x 6 in (20.96 x 15.24 cm)";
                                            }
                                            else
                                            {
                                                book.size_paper = "8.25 x 8.25 in (20.96 x 20.96 cm)";
                                            }
                                            break;
                                        default:
                                            book.size_paper = "6 x 9 in (15.24x22.86cm)";
                                            break;
                                    }
                                }
                                listBooks.Add(book);
                                // indx++;

                            }


                        }

                        progbar.Increment(1);
                        Application.DoEvents();
                    }
                    ClauncMul.dvr.FindElement(By.TagName("Body")).SendKeys(OpenQA.Selenium.Keys.Alt + "D" + OpenQA.Selenium.Keys.Enter);

                    //                  IJavaScriptExecutor js = (IJavaScriptExecutor)ClauncMul.dvr;
                    //                  js.ExecuteScript("window.open();");
                    //                  js.ExecuteScript("window.open();");
                    //                  js.ExecuteScript("window.open();");
                    //                  js.ExecuteScript("window.open();");
                    //                  tabs = new List<string>(ClauncMul.dvr.WindowHandles);
                    //ClauncMul.dvr.SwitchTo().Window(tabs[1]);
                    //ClauncMul.dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/bookshelf");
                    //ClauncMul.dvr.SwitchTo().Window(tabs[2]);
                    //ClauncMul.dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/bookshelf");
                    //ClauncMul.dvr.SwitchTo().Window(tabs[3]);
                    //ClauncMul.dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/bookshelf");

                    //cookies = ClauncMul.dvr.Manage().Cookies.AllCookies;

                    Thred = new Thread(delegate () { Travail_1(); });
                    Thred.Start();
                    Thred1 = new Thread(delegate () { Travail_2(); });
                    Thred1.Start();
                    Thred2 = new Thread(delegate () { Travail_3(); });
                    Thred2.Start();


                    //work.Close(true, Type.Missing, Type.Missing);
                    //App.Quit();
                    //Launcher.dvr.Quit();
                    //if (cshutdown.Checked)
                    //{
                    //    System.Diagnostics.Process.Start("Shutdown", "-s -t 10");
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //work.Close(true, Type.Missing, Type.Missing);
                    //App.Quit();
                    //ClauncMul.dvr.Quit();
                }
                ClauncMul.dvr.Quit();
                //SetThreadExecutionState()
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
