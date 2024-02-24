using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using System.Data;

using OpenQA.Selenium;
using System.Threading;
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Imaging;
using OpenQA.Selenium.Interactions;
using System.Windows.Forms;
using Microsoft.Win32;

namespace BookLauncher.Class
{
    class Launcher_Multip
    {
        DataTable dt = new DataTable();
        
        public ChromeDriver dvr;
        Categorie Ccatg = new Categorie();
        string titl;
        public Book book { get; set; }
        WebDriverWait wait;
        public static string Message { get; set; }
        string cheminbureau = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        Thread Thred;
        Activer_Programme cactiv = new Activer_Programme();
        private void scanecran(string Etape)
        {
            Screenshot ss = ((ITakesScreenshot)dvr).GetScreenshot();
            if (!Directory.Exists(cheminbureau + @"\Screenshot\"))
            {
                Directory.CreateDirectory(cheminbureau + @"\Screenshot\");
            }
            // System.Windows.Forms.MessageBox.Show(cheminbureau + @"\Screenshot\");
            ss.SaveAsFile(@cheminbureau + @"\Screenshot\" + Etape + DateTime.Now.Millisecond + ".Jpeg", ScreenshotImageFormat.Jpeg);
        }
        void launcher()
        {
            //dvr = new ChromeDriver();
            Message = "";
        }
         
        public void Ouvrir_chrome()
        {
            try
            {
                if (Module.Verification_Activation_enligne != true)
                {
                    //Thred = new Thread(delegate () { Verification_Activation(); });
                    //Thred.Start();
                }

                dvr.Navigate().GoToUrl("http://kdp.amazon.com/");
                titl = dvr.Title;
                dvr.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                scanecran("Open chrome");
                //dvr.Quit();
            }

        }
        public void Sign_in()
        {
            try
            {
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(20));
#pragma warning disable CS0618 // Le type ou le membre est obsolète
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("signinButton-announce")));
#pragma warning restore CS0618 // Le type ou le membre est obsolète
                IWebElement butsign = dvr.FindElement(By.Id("signinButton-announce"));
                butsign.Click();
                titl = dvr.Title;
                Thread.Sleep(1000);
                IWebElement email = dvr.FindElement(By.Id("ap_email"));

                IWebElement password = dvr.FindElement(By.Id("ap_password"));

                IWebElement valide = dvr.FindElement(By.Id("signInSubmit"));
                email.SendKeys(Module.Nom_Utilisateur);
                Thread.Sleep(1000);
                password.SendKeys(Module.Mot_passe);
                Thread.Sleep(1000);
                valide.Click();
            
                titl = dvr.Title;
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(120));
                wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Bookshelf")));
               // var links = dvr.FindElements(By.ClassName("a-button-input"));
                //Sauvegarde_Cookies();
                // scanecran("sign in");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                scanecran("Sign In");
                //dvr.Quit();
            }
        }
        private void Sauvegarde_Cookies()
        {
            //var cookie = new Cookie("test2", "cookie2");
            //dvr.Manage().Cookies.AddCookie(cookie);
            List<Cookie> allCookies = dvr.Manage().Cookies.AllCookies.ToList<Cookie>();
            foreach (Cookie cookie in allCookies)
            {
                dvr.Manage().Cookies.AddCookie(cookie);
            }
            //dvr.Manage().Cookies.AddCookie(new Cookie("foo", "bar"));
        }
        public void Bookshelf()
        {
            try
            {
                //dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/bookshelf?language=en_US");
                dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/create");
                titl = dvr.Title;
                /*
                var links = dvr.FindElements(By.ClassName("a-button-input"));
                foreach (var item in links)
                {
                    if (item.GetAttribute("aria-labelledby").Equals("create-paperback-button-announce"))
                    {
                        item.Click();
                        break;
                    }
                }
                */
                dvr.FindElement(By.XPath("//span[contains(text(),'Create paperback')]")).Click();
                //MessageBox.Show(titl);
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(10));

                titl = dvr.Title;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                scanecran("Book Shelf");
            }
        }

        public void Paperback_Details()
        {

            dvr.FindElement(By.Id("data-print-book-title")).SendKeys(book.Book_title);
            dvr.FindElement(By.Id("data-print-book-subtitle")).SendKeys(book.sub_title);
            dvr.FindElement(By.Id("data-print-book-primary-author-first-name")).SendKeys(book.First_Name);
            dvr.FindElement(By.Id("data-print-book-primary-author-middle-name")).SendKeys(book.Mid_Name);
            dvr.FindElement(By.Id("data-print-book-primary-author-last-name")).SendKeys(book.Last_Name);
            dvr.FindElement(By.Id("data-print-book-primary-author-suffix")).SendKeys(book.Suffix);
            //dvr.FindElementByName("data[print_book][description]").SendKeys(book.Description);
            dvr.FindElement(By.Id("cke_1_contents")).SendKeys(book.Description);

            try
            {
                //I own the copyright and I hold necessary publishing rights
                dvr.FindElement(By.Id("non-public-domain")).Click();
                //IWebElement pubright2 = dvr.FindElementById("public-domain");
                //if (Rpubright1.Checked)
                //{
                //    pubright1.Click();
                //}
                //else
                //{
                //    pubright2.Click();
                //}
                dvr.FindElement(By.Name("data[print_book][keywords][0]")).SendKeys(book.Kayword1);
                dvr.FindElement(By.Name("data[print_book][keywords][1]")).SendKeys(book.Kayword2);
                dvr.FindElement(By.Name("data[print_book][keywords][2]")).SendKeys(book.Kayword3);
                dvr.FindElement(By.Name("data[print_book][keywords][3]")).SendKeys(book.Kayword4);
                dvr.FindElement(By.Name("data[print_book][keywords][4]")).SendKeys(book.Kayword5);
                dvr.FindElement(By.Name("data[print_book][keywords][5]")).SendKeys(book.Kayword6);
                dvr.FindElement(By.Name("data[print_book][keywords][6]")).SendKeys(book.Kayword7);
                dvr.FindElement(By.Id("data-print-book-categories-button-proto-announce")).Click();
                //titl = dvr.Title;
                //await Task.Delay(3000);
                //IWebElement catg1 = dvr.FindElementById("checkbox-fiction_general");
                //catg1.SendKeys(OpenQA.Selenium.Keys.Space );
                if (book.Category1 != "")
                {
                    Thread.Sleep(1000);
                    TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                    string catg1 = ti.ToTitleCase(book.Category1);
                    string catg2 = ti.ToTitleCase(book.Category2);
                    string[] categ1 = Regex.Split(catg1, " > ");
                    string[] categ2 = Regex.Split(catg2, " > ");

                    int i = 0;
                    if (categ1[0] != "Fiction" && categ1[0] != "Nonfiction")
                    {
                        if (Ccatg.Existe_Categorie_Nom("Fiction > " + catg1))
                        {
                            catg1 = "Fiction > " + catg1;
                        }
                        else if (Ccatg.Existe_Categorie_Nom("Nonfiction > " + catg1))
                        {
                            catg1 = "Nonfiction > " + catg1;
                        }
                    }
                    if (categ2[0] != "Fiction" && categ2[0] != "Nonfiction")
                    {
                        if (Ccatg.Existe_Categorie_Nom("Fiction > " + catg2))
                        {
                            catg2 = "Fiction > " + catg2;
                        }
                        else if (Ccatg.Existe_Categorie_Nom("Nonfiction > " + catg2))
                        {
                            catg2 = "Nonfiction > " + catg2;
                        }
                    }
                    string[] categorie1 = Regex.Split(catg1, " > ");
                    string[] categorie2 = Regex.Split(catg2, " > ");


                    for (i = 0; i < categorie1.Length - 1; i++)
                    {
                        wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(30));
                        wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(ti.ToTitleCase(categorie1[i].ToString()))));
                        IWebElement cat1 = dvr.FindElement(By.LinkText(categorie1[i].ToString()));
                        dvr.ExecuteScript("arguments[0].scrollIntoView(true);", cat1);
                        cat1.Click();

                    }
                    // MessageBox.Show(catg1);

                    Thread.Sleep(2000);
                    var cat = dvr.FindElements(By.TagName("Input"));
                    string nodeid1 = Ccatg.Valeur_Categorie_Nom(catg1);
                    Thread.Sleep(2000);
                    dvr.FindElement(By.Id(nodeid1)).Click();
                    bool nexist = false;
                    for (i = 0; i < categorie2.Length - 1; i++)
                    {
                        // System.Windows.Forms.MessageBox.Show(categorie2[i].ToString());
                        if ((!categorie1.Contains(categorie2[i].ToString())) && nexist==false)
                        {
                            wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(30));
                            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(ti.ToTitleCase(categorie2[i].ToString()))));
                            IWebElement cat2 = dvr.FindElement(By.LinkText(categorie2[i].ToString()));
                            dvr.ExecuteScript("arguments[0].scrollIntoView(true);", cat2);
                            nexist = true;
                            cat2.Click();
                        }
                        else if (nexist)
                        {
//                            wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(30));
                            
//                            var fv= dvr.FindElementsByLinkText(categorie2[i].ToString());
//MessageBox.Show(fv.Count.ToString());
//                            Thread.Sleep(3000);
//                            //wait.Until(ExpectedConditions.ElementIsVisible(fv[1]);
//                            IWebElement cat2 = dvr.FindElementByLinkText(categorie2[i].ToString());
//                            MessageBox.Show(fv[1].Text);
//                            dvr.ExecuteScript("arguments[0].scrollIntoView(true);", fv[1]);
//                            nexist = true;
//                            fv[1].Click();
                        }
                    }

                    string nodeid2 = Ccatg.Valeur_Categorie_Nom(catg2);
                    Thread.Sleep(2000);

                    dvr.FindElement(By.Id(nodeid2)).Click();

                }
                else
                {
                    Thread.Sleep(2000);
                    dvr.FindElement(By.Id("checkbox-non--classifiable")).Click();
                    //var cat = dvr.FindElements(By.TagName("Input"));

                    ////string nodeid = "";
                    //foreach (var ilm in cat)
                    //{
                    //    if (ilm.GetAttribute("nodeid") == "non--classifiable")
                    //    {
                    //        ilm.Click();
                    //        Thread.Sleep(2000);
                    //        break;
                    //    }
                    //}
                }
                Thread.Sleep(4000);
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[class='a-button-input'][aria-labelledby='category-chooser-ok-button-announce']")));
                dvr.FindElement(By.CssSelector("input[class='a-button-input'][aria-labelledby='category-chooser-ok-button-announce']")).Click(); //ancien  id="category-chooser-ok-button"
                //category-chooser-ok-button-announce       category-chooser-ok-button-announce



                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("data[print_book][is_adult_content]-radio")));
                var adult = dvr.FindElements(By.Name("data[print_book][is_adult_content]-radio"));

                if (book.Adult == "No")
                {
                    ((IJavaScriptExecutor)dvr).ExecuteScript("arguments[0].checked = true;", adult[0]);
                }
                else
                {
                    ((IJavaScriptExecutor)dvr).ExecuteScript("arguments[0].checked = true;", adult[1]);
                }

                Thread.Sleep(1500);
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("save-and-continue-announce")));
                IWebElement butsave = dvr.FindElement(By.Id("save-and-continue-announce"));
                dvr.ExecuteScript("arguments[0].scrollIntoView(true);", butsave);
               
               // butsave.Click();
                
             
                titl = dvr.Title;
                //ap_password

            }
            catch (Exception ex)
            {
                Message = ex.Message;
                //System.Windows.Forms.MessageBox.Show(Message);

                scanecran("PaperBack Details");
            }
        }

        public void Paperback_Content()
        {
            try
            {
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(40));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='free-print-isbn-accordion-row']//i[@class='a-icon a-accordion-radio a-icon-radio-active']")));
                //wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(40));
                //wait.Until(ExpectedConditions.ElementIsVisible(By.Id("free-print-isbn-btn-announce")));

                //double Dlspeed = Math.Round((performanceCounter1.NextValue() / 1024), 0); // Vitesse DL
                //double Ulspeed = Math.Round((performanceCounter2.NextValue() / 1024), 0); // Vitess UL
                if (book.ISBN == "")
                {
                    dvr.FindElement(By.Id("free-print-isbn-btn-announce")).Click();
                    wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(20));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("print-isbn-confirm-button-announce")));
                    IWebElement AssISBN = dvr.FindElement(By.Id("print-isbn-confirm-button-announce"));
                    Thread.Sleep(1500);
                    AssISBN.Click();
                }
                else
                {
                    dvr.FindElement(By.ClassName("a-icon a-accordion-radio a-icon-radio-active")).Click();
                    wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(10));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("print-isbn-owner-isbn-input")));
                    dvr.FindElement(By.Id("print-isbn-owner-isbn-input")).SendKeys(book.ISBN);
                    Thread.Sleep(1000);
                    dvr.FindElement(By.Id("print-isbn-owner-imprint-input")).SendKeys(book.ISBN);
                }
                short typ = 1;
                if (book.type_paper == "Black & white interior with cream paper")
                {
                    typ = 0;
                }
                else if (book.type_paper == "Color interior with white paper")
                {
                    typ = 2;
                }

                dvr.FindElement(By.XPath("//button[@id='a-autoid-" + typ + "-announce']")).Click();
                Thread.Sleep(1000);
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("a-autoid-" + typ + "-announce")));
                IWebElement Butn = dvr.FindElement(By.Id("a-autoid-" + typ + "-announce"));
                dvr.ExecuteScript("arguments[0].scrollIntoView(true);", Butn);
                //trim-size-btn-announce
                Butn.Click();
                string sizepaper = "trim-size-popular-option-0-3-announce";
                if (book.size_paper != "6 x 9 in (15.24x22.86cm)")
                {
                    dvr.FindElement(By.Id("trim-size-btn-announce")).Click();
                    wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(40));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("trim-size-popular-option-0-0-announce")));
                    switch (book.size_paper)
                    {
                        case "5 x 8 in (12.7x20.32 cm)":
                            sizepaper = "trim-size-popular-option-0-0-announce"; break;
                        case "5.25 x 8 in (13.34x20.32cm)":
                            sizepaper = "trim-size-popular-option-0-1-announce"; break;
                        case "5.5 x 8.5 in (13.97x21.59)":
                            sizepaper = "trim-size-popular-option-0-2-announce"; break;
                        case "5.06 x 7.81 in (12.85 x 19.84 cm)":
                            sizepaper = "trim-size-standard-option-0-0-announce"; break;
                        case "6.14 x 9.21 in (15.6 x 23.39 cm)":
                            sizepaper = "trim-size-standard-option-0-1-announce"; break;
                        case "6.69 x 9.61 in (16.99 x 24.4 cm)":
                            sizepaper = "trim-size-standard-option-0-2-announce"; break;
                        case "7 x 10 in (17.78 x 25.4 cm)":
                            sizepaper = "trim-size-standard-option-0-3-announce"; break;
                        case "7.44 x 9.69 in (18.9 x 24.61 cm)":
                            sizepaper = "trim-size-standard-option-1-0-announce"; break;
                        case "7.5 x 9.25 in (19.05 x 23.5 cm)":
                            sizepaper = "trim-size-standard-option-1-1-announce"; break;
                        case "8 x 10 in (20.32 x 25.4 cm)":
                            sizepaper = "trim-size-standard-option-1-2-announce"; break;
                        case "8.5 x 11 in (21.59 x 27.94 cm)":
                            //8.5 x 11 in (21.59 x 27.94 cm)  trim-size-standard-option-1-3-announce
                            sizepaper = "trim-size-standard-option-1-3-announce"; break;
                        //trim-size-standard-option-1-3-announce
                        case "8.27 x 11.69 in (21 x 29.7 cm)":
                            sizepaper = "trim-size-nonstandard-option-0-0-announce"; break;
                        case "8.25 x 6 in (20.96 x 15.24 cm)":
                            sizepaper = "trim-size-nonstandard-option-0-1-announce"; break;
                        case "8.25 x 8.25 in (20.96 x 20.96 cm)":
                            sizepaper = "trim-size-nonstandard-option-0-2-announce"; break;
                        case "8.5 x 8.5 in (21.59 x 21.59 cm)":
                            sizepaper = "trim-size-nonstandard-option-0-3-announce"; break;
                        //trim-size-nonstandard-option-0-3-announce
                        default:
                            sizepaper = "trim-size-popular-option-0-3-announce";
                            break;
                    }
                    wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(6));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.Id(sizepaper)));
                    //
                    Actions actions = new Actions(dvr);
                    actions.MoveToElement(dvr.FindElement(By.Id(sizepaper)))
                    .Click()
                    .Build()
                    .Perform();
                    //IWebElement but = dvr.FindElement(By.Id(sizepaper));
                    //dvr.ExecuteScript("arguments[0].scrollIntoView(true);", but);
                    //Thread.Sleep(2000);
                    //but.Click();
                    //but.Click();
                    Thread.Sleep(2000);
                }

                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(100));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("a-autoid-4-announce")));
                if (book.Bleed == "Bleed")
                {
                    dvr.FindElement(By.Id("a-autoid-4-announce")).Click();
                }
                else
                {

                    dvr.FindElement(By.Id("a-autoid-3-announce")).Click();
                }
                if (book.Finish == "Glossy")
                {
                    dvr.FindElement(By.Id("a-autoid-6-announce")).Click();
                }
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(30));
                //IWebElement uploadElement = dvr.FindElement(By.Id("data-print-book-publisher-interior-file-upload-browse-button-announce"));
                //// enter the file path onto the file-selection input field
                //uploadElement.Click();
                dvr.FindElement(By.Id("data-print-book-publisher-interior-file-upload-browse-button-announce")).Click();
                FileInfo finf = new FileInfo(book.Interior_File);
                long taille = finf.Length;
                Thread.Sleep(3000);
                SendKeys.SendWait(book.Interior_File);
                Thread.Sleep(5000);
                SendKeys.SendWait(@"{Enter}");
                Thread.Sleep(2000);
                ////****************************** Upload interior using Autol3*************
                //Thread.Sleep(1500); //                                                   *                       
                //AutoItX3 autoi = new AutoItX3();//                                       *
                //autoi.WinActivate("Open");//                                             *
                //autoi.Send(book.Interior_File);//                                        *
                //autoi.Sleep(1500);//                                                     *
                //autoi.Send("{Enter}");//                                                 *
                //Thread.Sleep(1000);//                                                    *
                ////************************************************************************

                wait = new WebDriverWait(dvr, TimeSpan.FromMinutes((double)(taille / 50000)));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Processing your file...')]")));
                //string g = dvr.FindElement(By.XPath("//div[@id='data-print-book-publisher-cover-choice-accordion']//div[@class='a-box a-accordion-active']//div[@class='a-accordion-row-a11y']")).GetAttribute("aria-checked");
                string g = "true";
                //if (dvr.FindElementById("ap_password").Displayed)
                //{
                //    dvr.FindElementById("ap_password").SendKeys(Module.Mot_passe);
                //    Thread.Sleep(1000);
                //    dvr.FindElementById("signInSubmit").Click();
                //    Thread.Sleep(1500);
                //}
                if (g == "true")
                {
                    //wait = new WebDriverWait(dvr, TimeSpan.FromMinutes((double)(taille / 600000)));
                    //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='data-print-book-publisher-cover-choice-accordion']//i[@class='a-icon a-accordion-radio a-icon-radio-inactive']")));
                    //IWebElement elem = dvr.FindElement(By.XPath("//div[@id='data-print-book-publisher-cover-choice-accordion']//i[@class='a-icon a-accordion-radio a-icon-radio-inactive']"));
                    //elem.Click();
                    //elem.Click();
                    Actions actions = new Actions(dvr);
                    actions.MoveToElement(dvr.FindElement(By.XPath("//div[@id='data-print-book-publisher-cover-choice-accordion']//i[@class='a-icon a-accordion-radio a-icon-radio-inactive']")))
                    .Click()
                    .Build()
                    .Perform();

                }

                System.Windows.Forms.Application.DoEvents();
                Thread.Sleep(2000);
                wait = new WebDriverWait(dvr, TimeSpan.FromMinutes((double)(taille / 50000)));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("data-print-book-publisher-cover-file-upload-browse-button-announce")));
                IWebElement uploadCover = dvr.FindElement(By.Id("data-print-book-publisher-cover-file-upload-browse-button-announce"));
                // enter the file path onto the file-selection input field
                uploadCover.Click();
                finf = new FileInfo(book.Cover_File);
                taille = finf.Length;

                Thread.Sleep(2000);
                SendKeys.SendWait(@book.Cover_File);
                Thread.Sleep(5000);
                SendKeys.SendWait(@"{Enter}");
                Thread.Sleep(2000);
                //************* Upload File cover Using Autol3************
                //autoi.WinActive("Ouvrir");
                //autoi.Send(@"C:\");
                //Thread.Sleep(1000);
                //autoi.Send("{Enter}");
                //autoi.Sleep(1500);
                //autoi.ControlSend("Ouvrir", "", "Edit1", @book.Cover_File);
                //autoi.Sleep(1000);
                //autoi.ControlClick("Ouvrir", "Ou&vrir", "Button1");
                //autoi.Sleep(1000);
                //***********************************************************

                try
                {
                    wait = new WebDriverWait(dvr, TimeSpan.FromMinutes((double)(taille / 5000)));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='data-print-book-publisher-cover-file-upload-success']//span[@class='success-header'][contains(text(),'Cover uploaded successfully!')]")));
                }
                catch //(Exception ex)
                {
                    wait = new WebDriverWait(dvr, TimeSpan.FromMinutes((double)(taille / 5000)));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='data-print-book-publisher-cover-file-upload-success']//div[@class='a-alert-content'][contains(text(),'Processing your file...')]")));
                }
                //if (dvr.FindElementById("ap_password").Displayed)
                //{
                //    dvr.FindElementById("ap_password").SendKeys(Module.Mot_passe);
                //    Thread.Sleep(1000);
                //    dvr.FindElementById("signInSubmit").Click();
                //    Thread.Sleep(1500);
                //}
                Thread.Sleep(2000);
                System.Windows.Forms.Application.DoEvents();
                try
                {
                    wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(5));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[@id='print-preview-noconfirm-announce']")));
                    dvr.FindElement(By.XPath("//button[@id='print-preview-noconfirm-announce']")).Click();
                }
                catch //(Exception ex)
                {
                    Actions actions = new Actions(dvr);
                    actions.MoveToElement(dvr.FindElement(By.XPath("//button[@id='print-preview-announce']")))
                    .Click()
                    .Build()
                    .Perform();
                }
                //if (dvr.FindElementById("ap_password").Displayed)
                //{
                //    dvr.FindElementById("ap_password").SendKeys(Module.Mot_passe);
                //    Thread.Sleep(1000);
                //    dvr.FindElementById("signInSubmit").Click();
                //    Thread.Sleep(1500);
                //}
                ////button[@id='print-preview-noconfirm-announce']
                ///print-preview-confirm-button-announce
                /////div[@id='a-popover-content-3']//div//button[@id='print-preview-confirm-button-announce']
                Thread.Sleep(5000);
                var elemnts = dvr.FindElements(By.CssSelector("#print-preview-confirm-button-announce"));
                if (elemnts.Count == 2)
                {
                    try
                    {
                        elemnts[1].Click();
                    }
                    catch //(Exception ex)
                    {
                        //elemnts[1].Click();
                        //MessageBox.Show(elemnts[1].Text);
                    }
                }

                //if (dvr.FindElementById("ap_password").Displayed)
                //{
                //    dvr.FindElementById("ap_password").SendKeys(Module.Mot_passe);
                //    Thread.Sleep(1000);
                //    dvr.FindElementById("signInSubmit").Click();
                //    Thread.Sleep(1500);
                //}
                Thread.Sleep(2000);
                string ti = dvr.Title;

                wait = new WebDriverWait(dvr, TimeSpan.FromMinutes((double)(taille / 10000)));//(double)(taille / 50000)
                wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Approve")));
                if (dvr.FindElement(By.LinkText("Approve")).Enabled)
                {

                    //dvr.FindElement(By.TagName("")).Click();
                    dvr.FindElement(By.LinkText("Approve")).Click();
                    ti = dvr.Title;
                }
                else
                {
                    Message = "Exist error :";
                    scanecran("Paperback Content Cover and Interior");
                    return;
                }

                System.Windows.Forms.Application.DoEvents();
                //****************************************************************************
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("save-and-continue-announce")));
                dvr.FindElement(By.Id("save-and-continue-announce")).Click();

                ti = dvr.Title;
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Name("data[print_book][amazon_channel][us][price_vat_exclusive]")));
                dvr.FindElement(By.Name("data[print_book][amazon_channel][us][price_vat_exclusive]")).SendKeys(book.Price);
                //checkedbox     name :data[print_book][amazon_channel][us][lsi][publisher_enrolled]
                Thread.Sleep(3000);
                dvr.FindElement(By.XPath("//div[@class='a-checkbox a-checkbox-standalone a-checkbox-fancy']//i[@class='a-icon a-icon-checkbox']")).Click();
                Thread.Sleep(3000);
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(50));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("save-and-publish-announce")));
                dvr.FindElement(By.Id("save-and-publish-announce")).Click();

                ti = dvr.Title;

                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(120));
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("a-button-input")));
                dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/bookshelf");
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                scanecran("Paperback Content");
            }
        }
    }
}
