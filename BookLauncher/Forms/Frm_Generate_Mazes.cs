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
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Net;
using System.IO;
using System.Drawing.Imaging;
using OpenQA.Selenium;

namespace BookLauncher.Forms
{
    public partial class Frm_Generate_Mazes : DevExpress.XtraEditors.XtraUserControl
    {
        public Frm_Generate_Mazes()
        {
            InitializeComponent();
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
        ChromeDriver dvr;
        OpenFileDialog opnFil = new OpenFileDialog();
        //string chemin;
        BindingSource bindingSource1 = new BindingSource();
        private static Frm_Generate_Mazes _Mazes;
        public static Frm_Generate_Mazes Mazes
        {
            get
            {
                if (_Mazes == null) _Mazes = new Frm_Generate_Mazes();
                return _Mazes;
            }
        }
        private void Frm_Generate_Mazes_Load(object sender, EventArgs e)
        {

        }

        private void bCover_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                tCheminDossier.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (tCheminDossier.Text == "" || ttitle.Text=="" || tNombreMoze.Text =="")
            {
                MessageBox.Show("There are empty text boxes", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            ChromeDriverService serv = ChromeDriverService.CreateDefaultService();
            serv.HideCommandPromptWindow = true;
            dvr = new ChromeDriver(serv);
           
            dvr.Navigate().GoToUrl("http://puzzlemaker.discoveryeducation.com/AdvMazeSetupForm.asp");
            // titre Name=TITLE
            dvr.Manage().Window.Maximize();

            dvr.FindElement(By.Name("TITLE")).SendKeys(ttitle.Text);
            //dvr.FindElementByName("TITLE").SendKeys(ttitle.Text);
            Thread.Sleep(1000);
            //dvr.FindElementByXPath("//td[contains(text(),'Rectangle')]").Click();
            dvr.FindElements(By.Name("OPTIONS"))[0].Click();
            Thread.Sleep(1000);
            dvr.FindElement(By.Name("WIDTH")).Clear();
            dvr.FindElement(By.Name("WIDTH")).SendKeys(twidth.Text.ToString());
            Thread.Sleep(1000);
            dvr.FindElement(By.Name("HEIGHT")).Clear();
            dvr.FindElement(By.Name("HEIGHT")).SendKeys(tHEIGHT.Text.ToString());
            Thread.Sleep(1000);
            dvr.FindElement(By.Name("SQUARESIZE")).Clear();
            dvr.FindElement(By.Name("SQUARESIZE")).SendKeys(tSQUARESIZE.Text.ToString());
            Thread.Sleep(2000);
            var Radions = dvr.FindElements(By.Name("FILLSTYLE"));
            if (tvalue0.Checked)
            {
                Radions[0].Click();
            }
            else if (tvalue1.Checked)
            {
                Radions[1].Click();
            }
            else if (tvalue2.Checked)
            {
                Radions[2].Click();
            }
            else if (tvalue3.Checked)
            {
                Radions[3].Click();
            }
            else if (tvalue4.Checked)
            {
                Radions[4].Click();
            }
            else if (tvalue5.Checked)
            {
                Radions[5].Click();
            }
            for (int i = 0; i < int.Parse(tNombreMoze.Text); i++)
            {
                dvr.FindElement(By.Name("Action")).Click();
                var titl = dvr.Title;
                Thread.Sleep(2000);
                var browserTabs = dvr.CurrentWindowHandle;
                //dvr.SwitchTo().Window(browserTabs[1]);
                //List<String> browserTabs =(dvr.WindowHandles());
                dvr.SwitchTo().Window(dvr.WindowHandles[1]);
                //MessageBox.Show(dvr.Title);
                //check is it correct page opened or not (e.g. check page's title or url, etc.)
                //...
                //close tab and get back


                WebDriverWait wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(40));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//body[@id='body']/div[@id='globalBase']/div[@id='www-content-wrap']/div[@id='globalStage']/div[@id='de-content']/div[@id='pre-content']/img[1]")));
                IWebElement element = dvr.FindElement(By.XPath("//body[@id='body']/div[@id='globalBase']/div[@id='www-content-wrap']/div[@id='globalStage']/div[@id='de-content']/div[@id='pre-content']/img[1]"));
                String logoSRC = element.GetAttribute("src");
                //MessageBox.Show(logoSRC);
                SaveImage(tCheminDossier.Text + @"\" + ttitle.Text.ToString() +" " + i + ".png", ImageFormat.Png, logoSRC);

                //var actions = new Actions(dvr);
                //actions.MoveToElement(element)
                //.ContextClick()
                //.Build()
                //.Perform();
                //actions.SendKeys(OpenQA.Selenium.Keys.Control+"V").Build().Perform();
                //actions.SendKeys(OpenQA.Selenium.Keys.ArrowDown).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Click();
                Thread.Sleep(4000);
                
                dvr.SwitchTo().Window(dvr.WindowHandles[0]);
            }
dvr.Close();
            MessageBox.Show("Operation successfully completed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BModifier_Click(object sender, EventArgs e)
        {
            dvr.Close();
            Parent.Controls.Remove(this);

        }
    }
}
