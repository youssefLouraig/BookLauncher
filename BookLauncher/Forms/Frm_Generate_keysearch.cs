using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Net;
using System.Drawing.Imaging;

namespace BookLauncher.Forms
{
    public partial class Frm_Generate_keysearch : DevExpress.XtraEditors.XtraUserControl
    {
        public Frm_Generate_keysearch()
        {
            InitializeComponent();
        }
        BindingSource bindingSource1 = new BindingSource();
        private static Frm_Generate_keysearch _Mazes;
        public static Frm_Generate_keysearch Mazes
        {
            get
            {
                if (_Mazes == null) _Mazes = new Frm_Generate_keysearch();
                return _Mazes;
            }
        }
        DataTable dt = new DataTable();
        ChromeDriver dvr;
        OpenFileDialog opnFil = new OpenFileDialog();
        string chemin;
        List<String> listnoms = new List<string>();
        private void bParcourir_Click(object sender, EventArgs e)
        {
           
        }

        private void choose_15_noms()
        {
            Random aleatoire = new Random();
            int inx = 0;
            listnoms.Clear();
            while (inx < 15)
            {
                string s = listBox2.Items[aleatoire.Next(0, listBox2.Items.Count - 1)].ToString();
                if (!listnoms.Contains(s))
                {
                    listnoms.Add(s);
                    inx++;
                }

            }
        }
        private void RemplirlesNOm()
        {

            if (File.Exists(lchemin.Text.ToString()))
            {
                listBox2.Items.Clear();
                StreamReader objtstrem = new StreamReader(lchemin.Text.ToString());
                string s = objtstrem.ReadLine();
                while (!Convert.IsDBNull(s))
                {
                    //if (s.Length > 4)
                    //{
                    //MessageBox.Show(s);
                    if (s != null)
                    {
                        if (s.Length > 2)
                            if (s.Length > 2)
                            {
                                listBox2.Items.Add(s.Trim());
                            }

                    }
                    else
                    {
                        break;
                    }

                    //}
                    s = objtstrem.ReadLine();

                }
                objtstrem.Close();
            }
        }

        private void Frm_Generate_keysearch_Load(object sender, EventArgs e)
        {
            chemin = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        private void listBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Delete)
                {
                    listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                    lfilecount.Text = listBox2.Items.Count.ToString();
                }
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //https://thewordsearch.com/maker/
            if (tCheminDossier.Text == "" || ttitre.Text == "" || tnombrePuzzle.Text == "" || lchemin.Text == "")
            {
                MessageBox.Show("There are empty text boxes", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ChromeDriverService serv = ChromeDriverService.CreateDefaultService();
            serv.HideCommandPromptWindow = true;
            dvr = new ChromeDriver(serv);
            
          
            string titl = dvr.Title;
            short count = (short)tnombrePuzzle.Value;
            progbar.Visible = true;
            progbar.Properties.Maximum = count;
            progbar.EditValue = 0;

            try
            {

               

                short j = 0;
                
                while (j < count)
                {
                    try
                    {
                        dvr.Navigate().GoToUrl("https://thewordsearch.com/maker/");
                        dvr.Manage().Window.Maximize();
                        //dvr.FindElementByXPath("//input[@id='st1']").SendKeys("");
                        dvr.FindElement(By.XPath("//label[contains(text(),'Personal, family, friends etc.')]")).Click();
                        dvr.FindElement(By.Name("title")).SendKeys(ttitre.Text.ToString());
                        dvr.FindElement(By.Name("desc")).SendKeys(tdescription.Text.ToString());

                        choose_15_noms();
                    Thread.Sleep(2000);
                    int indxNoms = 0;
                    for (short i = 0; i < 30; i++)
                    {
                        if (indxNoms < listnoms.Count)
                        {
                            try
                            {
                                dvr.FindElement(By.ClassName("wsw" + i)).Clear();
dvr.FindElement(By.ClassName("wsw" + i)).SendKeys(listnoms[indxNoms].ToString());
                            indxNoms++;
                            }catch//(Exception ex)
                            {
                                continue;
                            }
                            
                        }
                        else
                        {
                            break;
                        }
                    }
                    dvr.FindElement(By.Id("subBtn")).Click();
                    Thread.Sleep(2000);

                    titl = dvr.Title.ToString();
                    dvr.FindElement(By.ClassName("mdBtn")).Click();
                    Thread.Sleep(2000);
                    dvr.FindElement(By.ClassName("downloadBtn")).Click();
                    Thread.Sleep(2000);
                    dvr.SwitchTo().Window(dvr.WindowHandles[1]);
                    //class :download-image
                    WebDriverWait wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(40));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("download-image")));
                    IWebElement element = dvr.FindElement(By.ClassName("download-image"));
                    String logoSRC = element.GetAttribute("src");
                    //MessageBox.Show(logoSRC);
                    SaveImage(tCheminDossier.Text + @"\" + ttitre.Text.ToString() + " " + j + ".png", ImageFormat.Png, logoSRC);
                        j++;
                        Thread.Sleep(4000);
                        dvr.Close();
                        dvr.SwitchTo().Window(dvr.WindowHandles[0]);
                        
                        progbar.Increment(1);
                        Application.DoEvents();
                    }
                    catch //(Exception ex)
                    {
                        continue;
                    }
                    dvr.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SaveImage(string filename, ImageFormat format, string imageUrl)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(imageUrl);
            Bitmap bitmap; bitmap = new Bitmap(stream);

            if (bitmap != null)
            {
                bitmap.Save(filename, format);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();
        }
        private void BModifier_Click(object sender, EventArgs e)
        {
            //dvr.Close();
            Parent.Controls.Remove(this);
        }

        private void bCover_Click(object sender, EventArgs e)
        {
           
        }

        private void bParcourir1_Click(object sender, EventArgs e)
        {
            opnFil.Filter = "Fichier Texte (*.txt)|*.txt";
            opnFil.FileName = "";
            opnFil.InitialDirectory = chemin;
            if (opnFil.ShowDialog() == DialogResult.OK)
            {

                lchemin.Text = opnFil.FileName;
                RemplirlesNOm();
                lfilecount.Text = listBox2.Items.Count.ToString();
            }
        }

        private void bCover1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tCheminDossier.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
