using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

using System.Data;
//using AutoItX3Lib;
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
    class Launcher
    {
        DataTable dt = new DataTable();
        //AutoItX3 autoi = new AutoItX3();
        public static ChromeDriver dvr;
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
        private void Verification_Activation()
        {
            string typeActive = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "Type", "Trial").ToString();
            if (typeActive != "Trial")
            {


                DateTime readValue;
                readValue = DateTime.Parse(Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "datelimite", null).ToString());
                string serialactiv = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "serial", "BBB").ToString();

                if (Activer_Programme.IsConnectedToInternet())
                {
                    bool activ = cactiv.Serial_valide(serialactiv);
                    Module.Verification_Activation_enligne = true;
                    if (activ)
                    {
                        typeActive = cactiv.typeActivation;

                        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "3157");
                        //short nombreJRS = 0;
                        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "Type", typeActive);
                        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "datelimite", cactiv.DateActivation);
                        //switch (typeActive)
                        //{
                        //    case "Trial": nombreJRS = 20; break;
                        //    case "Month": nombreJRS = 31; break;
                        //    case "Year": nombreJRS = 365; break;
                        //    default: nombreJRS = 10; break;
                        //}


                        //if (DatediffJours(DateTime.Now.Date, readValue) > nombreJRS || DatediffJours(DateTime.Now.Date, readValue) < 0)
                        //{

                        //    Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "2223");
                        //    Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "depasse", "2013");
                        //}

                    }
                    else
                    {
                        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "2223");
                        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "depasse", "2013");
                    }

                    Thred.Abort();
                }
            }

        }
        private short DatediffJours(DateTime dt1, DateTime dt2)
        {
            //System.Linq.SqlClient.SqlMethods.DateDiff(dt1, dt2);
            System.TimeSpan diffResult = dt1.Subtract(dt2);
            return short.Parse(diffResult.Days.ToString());
        }
        public void Ouvrir_chrome()
        {
            try
            {
                //if (Module.Verification_Activation_enligne != true)
                //{
                //    Thred = new Thread(delegate () { Verification_Activation(); });
                //    Thred.Start();
                //}

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
        public void Sign_in(bool emailkdp)
        {
            try
            {
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(20));
#pragma warning disable CS0618 // Le type ou le membre est obsolète
                // wait.Until(ExpectedConditions.ElementIsVisible(By.Id("signinButton-announce")));
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("align-end")));
                //signinButton
#pragma warning restore CS0618 // Le type ou le membre est obsolète
                //IWebElement butsign = dvr.FindElementById("signinButton-announce");
                IWebElement butsign = dvr.FindElement(By.ClassName("align-end"));
                
                
                butsign.Click();
                titl = dvr.Title;
                Thread.Sleep(1000);
                if (emailkdp)
                {
 IWebElement email = dvr.FindElement(By.Id(("ap_email")));

                IWebElement password = dvr.FindElement(By.Id("ap_password"));

                IWebElement valide = dvr.FindElement(By.Id("signInSubmit"));
                email.SendKeys(Module.Nom_Utilisateur);
                Thread.Sleep(1000);
                password.SendKeys(Module.Mot_passe);
                Thread.Sleep(1500);
                valide.Click();
                }
               
            
                titl = dvr.Title;
               // wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(300));
               //// wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Bookshelf")));
               // wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[4]/div[1]/div[2]/div[1]/div[5]/div[2]/div[1]/div[1]/div[1]/a[2]/span[1]/span[1]")));
                //var links = dvr.FindElements(By.ClassName("a-button-input")).ElementAt();
                //item.GetAttribute("aria-labelledby").Equals("create-paperback-button-announce")
                //Sauvegarde_Cookies();
                IWebElement Butcreer = dvr.FindElement(By.CssSelector("#create-new-experience-button"));
                 Butcreer.Click();
 wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(300));
                // wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Bookshelf")));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[4]/div[2]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[4]/div[1]/div[2]/div[1]/span[1]/span[1]/button[1]/span[1]")));
                Console.WriteLine("Find button Create paperback");
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
                dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/create");
                //titl = dvr.Title;
                //var links = dvr.FindElements(By.ClassName("a-button-input"));
                //foreach (var item in links)
                //{
                //    if (item.GetAttribute("aria-labelledby").Equals("create-paperback-button-announce"))
                //    {
                //        item.Click();
                //        break;
                //    }
                //}
                // ----------------------Button PaperBack--------------------
                dvr.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[4]/div[2]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[4]/div[1]/div[2]/div[1]/span[1]/span[1]/button[1]/span[1]")).Click();
                // ----------------------Button Continue setup--------------------
                //zme-indie-bookshelf-dual-print-actions-draft-book-actions-E5KMGAZTYAJ-main-action
                //dvr.FindElementById("zme-indie-bookshelf-dual-print-actions-draft-book-actions-E5KMGAZTYAJ-main-action").Click();

                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(10));

                titl = dvr.Title;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                scanecran("Book Shelf");
            }
        }
        public void HardCover()
        {
            try
            {
                dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/create");
                //titl = dvr.Title;
                //var links = dvr.FindElements(By.ClassName("a-button-input"));
                //foreach (var item in links)
                //{
                //    if (item.GetAttribute("aria-labelledby").Equals("create-paperback-button-announce"))
                //    {
                //        item.Click();
                //        break;
                //    }
                //}
                // ----------------------Button PaperBack--------------------
                dvr.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[4]/div[2]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[4]/div[1]/div[3]/div[1]/span[1]/span[1]/button[1]/span[1]")).Click();
                // ----------------------Button Continue setup--------------------
                //zme-indie-bookshelf-dual-print-actions-draft-book-actions-E5KMGAZTYAJ-main-action
                //dvr.FindElementById("zme-indie-bookshelf-dual-print-actions-draft-book-actions-E5KMGAZTYAJ-main-action").Click();

                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(10));

                titl = dvr.Title;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                scanecran("create hardcover button");
            }
        }
        public void ButtonContinuesetup()
        {
            try
            {
                dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/create");
                titl = dvr.Title;
                //var links = dvr.FindElements(By.ClassName("a-button-input"));
                //foreach (var item in links)
                //{
                //    if (item.GetAttribute("aria-labelledby").Equals("create-paperback-button-announce"))
                //    {
                //        item.Click();
                //        break;
                //    }
                //}
                // ----------------------Button PaperBack--------------------
                //dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[4]/div[1]/div[2]/div[1]/div[5]/div[2]/div[1]/div[1]/div[1]/a[2]/span[1]/span[1]")).Click();
                // ----------------------Button Continue setup--------------------
                //zme-indie-bookshelf-dual-print-actions-draft-book-actions-E5KMGAZTYAJ-main-action
                dvr.FindElement(By.Id("zme-indie-bookshelf-dual-print-actions-draft-book-actions-E5KMGAZTYAJ-main-action")).Click();

                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(10));

                titl = dvr.Title;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                scanecran("Button Continue setup");
            }
        }
        public void Paperback_Details()
        {

            dvr.FindElement(By.Id("data-print-book-title")).SendKeys(book.Book_title);
            dvr.FindElement(By.Id("data-print-book-subtitle")).SendKeys(book.sub_title);
            dvr.FindElement(By.Id("data-print-book-primary-author-first-name")).SendKeys(book.First_Name);
         
            dvr.FindElement(By.Id("data-print-book-primary-author-middle-name")).SendKeys(book.Mid_Name);
            dvr.FindElement(By.Id("data-print-book-primary-author-last-name")).SendKeys(book.Last_Name);
          
            dvr.FindElement(By.CssSelector("#data-print-book-primary-author-suffix")).SendKeys(book.Suffix);
            Thread.Sleep(500);
            //dvr.FindElementByName("data[print_book][description]").SendKeys(book.Description);
            //dvr.FindElementById("cke_1_contents").SendKeys(book.Description);
            //dvr.FindElementsByClassName("data[print_book][description]").First().SendKeys(book.Description);
            dvr.FindElement(By.Id("cke_17")).Click();
            Thread.Sleep(1000);
            Console.WriteLine("Description :" +book.Description);
           
dvr.FindElement(By.TagName("textarea")).SendKeys(book.Description);

            Thread.Sleep(500);



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
                        wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(80));
                        string nomcatg = ti.ToTitleCase(categorie1[i].ToString());
                        
                        wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(ti.ToTitleCase(categorie1[i].ToString()))));

                        IWebElement cat1 = dvr.FindElement(By.LinkText(nomcatg));
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
                        if ((!categorie1.Contains(categorie2[i].ToString())) )
                        {
                            wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(80));
                            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(ti.ToTitleCase(categorie2[i].ToString()))));
                            IWebElement cat2 = dvr.FindElement(By.LinkText(categorie2[i].ToString()));
                            dvr.ExecuteScript("arguments[0].scrollIntoView(true);", cat2);
                           // nexist = true;
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
                    Thread.Sleep(3000);
                    //MessageBox.Show(nodeid2);
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


                if (book.HardBook)
                {
wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("data-view-is-lcb")));
               var lcb=  dvr.FindElement(By.Id("data-view-is-lcb"));
               var large=  dvr.FindElement(By.Id("data-print-book-large-print"));
                    ((IJavaScriptExecutor)dvr).ExecuteScript("arguments[0].checked = true;", lcb);
                    ((IJavaScriptExecutor)dvr).ExecuteScript("arguments[0].checked = true;", large);
                }
                else
                {
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
                }
                

                Thread.Sleep(1500);
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("save-and-continue-announce")));
                IWebElement butsave = dvr.FindElement(By.Id("save-and-continue-announce"));
                //#save-and-continue-announce
                dvr.ExecuteScript("arguments[0].scrollIntoView(true);", butsave);
                //MessageBox.Show("click");
                butsave.Click();
                //if (dvr.FindElementById("ap_password").Displayed)
                //{
                //    dvr.FindElementById("ap_password").SendKeys(Module.Mot_passe);
                //    Thread.Sleep(1000);
                //    dvr.FindElementById("signInSubmit").Click();
                //    Thread.Sleep(1500);
                //}
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
        public void paperBack_Contentcomplete()
        {
            dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/bookshelf");
            wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(40));
            // by.ClassName =a-color-secondary a-text-bold
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[4]/div[1]/div[2]/div[1]/div[6]/div[1]/div[2]/div[4]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/div[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/div[1]/div[2]/span[2]/span[1]/span[1]/button[1]/span[1]")));
            var butContune= dvr.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[4]/div[1]/div[2]/div[1]/div[6]/div[1]/div[2]/div[4]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/div[1]/div[3]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/div[1]/div[2]/span[2]/span[1]/span[1]/button[1]/span[1]"));
            dvr.ExecuteScript("arguments[0].scrollIntoView(true);", butContune);
            butContune.Click();
 wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(40));
 wait.Until(ExpectedConditions.ElementIsVisible(By.Id("hardcover_edit_pricing-AM3DSP8J587")));
            var lcb = dvr.FindElement(By.Id("hardcover_edit_pricing-AM3DSP8J587"));
            lcb.Click();
            //Actions builder = new Actions(dvr);
            //builder.ContextClick(butContune).Build().Perform();
            //WebElement elementOpen = dvr.FindElement(By.LinkText("Open")); /*This will select menu after right click */

            //elementOpen.Click();
            wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(20));
            //data[print_book][amazon_channel][us][price_vat_exclusive]
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("body.title-setup.a-m-us.a-aui_72554-c.a-aui_accordion_a11y_role_354025-c.a-aui_killswitch_csa_logger_372963-c.a-aui_launch_2021_ally_fixes_392482-c.a-aui_pci_risk_banner_210084-c.a-aui_preload_261698-c.a-aui_rel_noreferrer_noopener_309527-c.a-aui_template_weblab_cache_333406-c.a-aui_tnr_v2_180836-c.a-meter-animate:nth-child(2) div.a-container:nth-child(2) div.a-row.a-spacing-extra-large.potter-slot:nth-child(2) div.slot:nth-child(2) div.form-contents.a-declarative:nth-child(3) div.a-section.a-spacing-none.a-spacing-top-small.a-padding-extra-large.kdp-card:nth-child(19) div.a-row div.a-column.a-span10.a-span-last:nth-child(2) div.a-row.a-spacing-none:nth-child(3) div.a-column.a-span12.potter-directive-column div.a-section.potter-pricing-grid div.a-section.a-spacing-none.potter-pricing-grid-listener.potter-pricing-grid-metadata-available div.a-section.potter-pricing-grid-container div.a-section.a-spacing-none.potter-pricing-grid-home-marketplace-content:nth-child(4) div.jele-directive div.a-section.a-spacing-none.potter-pricing-grid-listener.potter-pricing-grid-marketplace-row.potter-pricing-grid-us.potter-pricing-grid-row-home-marketplace div.a-row div.a-row.potter-pricing-grid-columns.potter-pricing-grid-split-marketplace-name div.a-column.a-span8.potter-pricing-grid-column-group-container:nth-child(1) div.a-row.potter-pricing-grid-column-group.potter-pricing-grid-marketplace-columns div.a-column.a-span5.potter-pricing-grid-column:nth-child(2) div.a-section.potter-pricing-grid-cell-wrapper div.a-row.potter-pricing-grid-cell.potter-pricing-grid-marketplace-price-cell div.a-column.a-span12 div.a-row.potter-pricing-grid-cell-content.potter-pricing-grid-cell-content-padded div.a-column.a-span12 div.a-section.a-spacing-none.potter-pricing-grid-hidden-on-conversion:nth-child(1) div.a-section.a-spacing-none.potter-pricing-grid-price-container.potter-pricing-grid-listener:nth-child(1) div.a-row.a-spacing-none div.a-column.a-span8:nth-child(1) div:nth-child(1) div.a-section.a-spacing-micro.jele-currency-input.potter-pricing-grid-price-input > input.a-input-text.price-input")));
            dvr.FindElement(By.CssSelector("body.title-setup.a-m-us.a-aui_72554-c.a-aui_accordion_a11y_role_354025-c.a-aui_killswitch_csa_logger_372963-c.a-aui_launch_2021_ally_fixes_392482-c.a-aui_pci_risk_banner_210084-c.a-aui_preload_261698-c.a-aui_rel_noreferrer_noopener_309527-c.a-aui_template_weblab_cache_333406-c.a-aui_tnr_v2_180836-c.a-meter-animate:nth-child(2) div.a-container:nth-child(2) div.a-row.a-spacing-extra-large.potter-slot:nth-child(2) div.slot:nth-child(2) div.form-contents.a-declarative:nth-child(3) div.a-section.a-spacing-none.a-spacing-top-small.a-padding-extra-large.kdp-card:nth-child(19) div.a-row div.a-column.a-span10.a-span-last:nth-child(2) div.a-row.a-spacing-none:nth-child(3) div.a-column.a-span12.potter-directive-column div.a-section.potter-pricing-grid div.a-section.a-spacing-none.potter-pricing-grid-listener.potter-pricing-grid-metadata-available div.a-section.potter-pricing-grid-container div.a-section.a-spacing-none.potter-pricing-grid-home-marketplace-content:nth-child(4) div.jele-directive div.a-section.a-spacing-none.potter-pricing-grid-listener.potter-pricing-grid-marketplace-row.potter-pricing-grid-us.potter-pricing-grid-row-home-marketplace div.a-row div.a-row.potter-pricing-grid-columns.potter-pricing-grid-split-marketplace-name div.a-column.a-span8.potter-pricing-grid-column-group-container:nth-child(1) div.a-row.potter-pricing-grid-column-group.potter-pricing-grid-marketplace-columns div.a-column.a-span5.potter-pricing-grid-column:nth-child(2) div.a-section.potter-pricing-grid-cell-wrapper div.a-row.potter-pricing-grid-cell.potter-pricing-grid-marketplace-price-cell div.a-column.a-span12 div.a-row.potter-pricing-grid-cell-content.potter-pricing-grid-cell-content-padded div.a-column.a-span12 div.a-section.a-spacing-none.potter-pricing-grid-hidden-on-conversion:nth-child(1) div.a-section.a-spacing-none.potter-pricing-grid-price-container.potter-pricing-grid-listener:nth-child(1) div.a-row.a-spacing-none div.a-column.a-span8:nth-child(1) div:nth-child(1) div.a-section.a-spacing-micro.jele-currency-input.potter-pricing-grid-price-input > input.a-input-text.price-input")).SendKeys(book.Price);
            Thread.Sleep(1000);
            if (book.priceuk != "")
            {
                ////body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(40));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/span[1]")));
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                Thread.Sleep(900);
                //dvr.FindElement(By.Name("data[print_book][amazon_channel][uk][price_vat_exclusive]")). = "";
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.priceuk);
                Thread.Sleep(900);
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                Thread.Sleep(900);
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricede);
                Thread.Sleep(900);
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                Thread.Sleep(900);
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricefr);
                Thread.Sleep(900);
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                Thread.Sleep(900); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricees);
                Thread.Sleep(600); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[5]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                Thread.Sleep(900); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[5]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.priceit);
                Thread.Sleep(600); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                Thread.Sleep(900); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricenl);
                Thread.Sleep(600); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                Thread.Sleep(900); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricepl);
                Thread.Sleep(600); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[8]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                Thread.Sleep(900); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[8]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricese);


                if (!book.HardBook)
                {
Thread.Sleep(600); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[7]/div[1]/div[9]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                Thread.Sleep(900); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[7]/div[1]/div[9]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricecojp);

Thread.Sleep(600); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[7]/div[1]/div[10]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                Thread.Sleep(900); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[7]/div[1]/div[10]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.priceca);

Thread.Sleep(600); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[7]/div[1]/div[11]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                Thread.Sleep(900); 
                dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[7]/div[1]/div[11]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.priceau);
                }
                //  Thread.Sleep(600);
            }

            if (false)
            {
Thread.Sleep(3000);
            dvr.FindElement(By.XPath("//div[@class='a-checkbox a-checkbox-standalone a-checkbox-fancy']//i[@class='a-icon a-icon-checkbox']")).Click();
            Thread.Sleep(3000);
            }
            //checkedbox     name :data[print_book][amazon_channel][us][lsi][publisher_enrolled]
            
            wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(50));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("save-and-publish-announce")));
            dvr.FindElement(By.Id("save-and-publish-announce")).Click();



            

            wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(120));
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("a-button-input")));
            dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/bookshelf");
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
                        case "5.5 x 8.5 in (13.97 x 21.59 cm)":
                            ////button[@id='trim-size-standard-option-0-0-announce']
                            sizepaper = "trim-size-standard-option-0-0-announce"; break;
                        case "8.25 x 11 in (20.95 x 27.94 cm)":
                            //button[@id='trim-size-standard-option-1-0-announce']
                            sizepaper = "trim-size-standard-option-1-0-announce"; break;
                        
                        case "6.14 x 9.21 in (15.6 x 23.39 cm)":
                            //button[@id='trim-size-standard-option-0-2-announce']
                            sizepaper = (book.HardBook) ? "trim-size-standard-option-0-2-announce": "trim-size-standard-option-0-1-announce"; break;
                        case "5 x 8 in (12.7x20.32 cm)":
                            sizepaper = "trim-size-popular-option-0-0-announce"; break;
                        case "5.25 x 8 in (13.34x20.32cm)":
                            sizepaper = "trim-size-popular-option-0-1-announce"; break;
                        case "5.5 x 8.5 in (13.97x21.59)":
                            sizepaper = "trim-size-popular-option-0-2-announce"; break;
                        case "5.06 x 7.81 in (12.85 x 19.84 cm)":
                            sizepaper = "trim-size-standard-option-0-0-announce"; break;
                        
                            
                        case "6.69 x 9.61 in (16.99 x 24.4 cm)":
                            sizepaper = "trim-size-standard-option-0-2-announce"; break;
                        case "7 x 10 in (17.78 x 25.4 cm)":
                           sizepaper ="trim-size-standard-option-0-3-announce"; break;
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
                SendKeys.SendWait(finf.FullName) ;
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

                wait = new WebDriverWait(dvr, TimeSpan.FromMinutes((double)(taille / 4000)));
                //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(text(),'Processing your file...')]")));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='data-print-book-publisher-interior-file-upload-success']")));
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
                wait = new WebDriverWait(dvr, TimeSpan.FromMinutes((double)(taille / 40000)));
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
                    wait = new WebDriverWait(dvr, TimeSpan.FromMinutes((double)(taille / 4000)));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='data-print-book-publisher-cover-file-upload-success']")));

                   //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='data-print-book-publisher-cover-file-upload-success']//span[@class='success-header'][contains(text(),'Cover uploaded successfully!')]")));
                }
                catch //(Exception ex)
                {
                    wait = new WebDriverWait(dvr, TimeSpan.FromMinutes((double)(taille / 4000)));
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
                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(20));
                //data[print_book][amazon_channel][us][price_vat_exclusive]
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("body.title-setup.a-m-us.a-aui_72554-c.a-aui_accordion_a11y_role_354025-c.a-aui_killswitch_csa_logger_372963-c.a-aui_launch_2021_ally_fixes_392482-c.a-aui_pci_risk_banner_210084-c.a-aui_preload_261698-c.a-aui_rel_noreferrer_noopener_309527-c.a-aui_template_weblab_cache_333406-c.a-aui_tnr_v2_180836-c.a-meter-animate:nth-child(2) div.a-container:nth-child(2) div.a-row.a-spacing-extra-large.potter-slot:nth-child(2) div.slot:nth-child(2) div.form-contents.a-declarative:nth-child(3) div.a-section.a-spacing-none.a-spacing-top-small.a-padding-extra-large.kdp-card:nth-child(19) div.a-row div.a-column.a-span10.a-span-last:nth-child(2) div.a-row.a-spacing-none:nth-child(3) div.a-column.a-span12.potter-directive-column div.a-section.potter-pricing-grid div.a-section.a-spacing-none.potter-pricing-grid-listener.potter-pricing-grid-metadata-available div.a-section.potter-pricing-grid-container div.a-section.a-spacing-none.potter-pricing-grid-home-marketplace-content:nth-child(4) div.jele-directive div.a-section.a-spacing-none.potter-pricing-grid-listener.potter-pricing-grid-marketplace-row.potter-pricing-grid-us.potter-pricing-grid-row-home-marketplace div.a-row div.a-row.potter-pricing-grid-columns.potter-pricing-grid-split-marketplace-name div.a-column.a-span8.potter-pricing-grid-column-group-container:nth-child(1) div.a-row.potter-pricing-grid-column-group.potter-pricing-grid-marketplace-columns div.a-column.a-span5.potter-pricing-grid-column:nth-child(2) div.a-section.potter-pricing-grid-cell-wrapper div.a-row.potter-pricing-grid-cell.potter-pricing-grid-marketplace-price-cell div.a-column.a-span12 div.a-row.potter-pricing-grid-cell-content.potter-pricing-grid-cell-content-padded div.a-column.a-span12 div.a-section.a-spacing-none.potter-pricing-grid-hidden-on-conversion:nth-child(1) div.a-section.a-spacing-none.potter-pricing-grid-price-container.potter-pricing-grid-listener:nth-child(1) div.a-row.a-spacing-none div.a-column.a-span8:nth-child(1) div:nth-child(1) div.a-section.a-spacing-micro.jele-currency-input.potter-pricing-grid-price-input > input.a-input-text.price-input")));
                dvr.FindElement(By.CssSelector("body.title-setup.a-m-us.a-aui_72554-c.a-aui_accordion_a11y_role_354025-c.a-aui_killswitch_csa_logger_372963-c.a-aui_launch_2021_ally_fixes_392482-c.a-aui_pci_risk_banner_210084-c.a-aui_preload_261698-c.a-aui_rel_noreferrer_noopener_309527-c.a-aui_template_weblab_cache_333406-c.a-aui_tnr_v2_180836-c.a-meter-animate:nth-child(2) div.a-container:nth-child(2) div.a-row.a-spacing-extra-large.potter-slot:nth-child(2) div.slot:nth-child(2) div.form-contents.a-declarative:nth-child(3) div.a-section.a-spacing-none.a-spacing-top-small.a-padding-extra-large.kdp-card:nth-child(19) div.a-row div.a-column.a-span10.a-span-last:nth-child(2) div.a-row.a-spacing-none:nth-child(3) div.a-column.a-span12.potter-directive-column div.a-section.potter-pricing-grid div.a-section.a-spacing-none.potter-pricing-grid-listener.potter-pricing-grid-metadata-available div.a-section.potter-pricing-grid-container div.a-section.a-spacing-none.potter-pricing-grid-home-marketplace-content:nth-child(4) div.jele-directive div.a-section.a-spacing-none.potter-pricing-grid-listener.potter-pricing-grid-marketplace-row.potter-pricing-grid-us.potter-pricing-grid-row-home-marketplace div.a-row div.a-row.potter-pricing-grid-columns.potter-pricing-grid-split-marketplace-name div.a-column.a-span8.potter-pricing-grid-column-group-container:nth-child(1) div.a-row.potter-pricing-grid-column-group.potter-pricing-grid-marketplace-columns div.a-column.a-span5.potter-pricing-grid-column:nth-child(2) div.a-section.potter-pricing-grid-cell-wrapper div.a-row.potter-pricing-grid-cell.potter-pricing-grid-marketplace-price-cell div.a-column.a-span12 div.a-row.potter-pricing-grid-cell-content.potter-pricing-grid-cell-content-padded div.a-column.a-span12 div.a-section.a-spacing-none.potter-pricing-grid-hidden-on-conversion:nth-child(1) div.a-section.a-spacing-none.potter-pricing-grid-price-container.potter-pricing-grid-listener:nth-child(1) div.a-row.a-spacing-none div.a-column.a-span8:nth-child(1) div:nth-child(1) div.a-section.a-spacing-micro.jele-currency-input.potter-pricing-grid-price-input > input.a-input-text.price-input")).SendKeys(book.Price);
                Thread.Sleep(1000);
                if (book.priceuk != "")
                {
                    ////body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]
                    wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(40));
                    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/span[1]")));
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                    Thread.Sleep(900);
                    //dvr.FindElement(By.Name("data[print_book][amazon_channel][uk][price_vat_exclusive]")). = "";
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.priceuk);
                    Thread.Sleep(900);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                    Thread.Sleep(900);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricede);
                    Thread.Sleep(900);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                    Thread.Sleep(900);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricefr);
                    Thread.Sleep(900);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                    Thread.Sleep(900);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[4]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricees);
                    Thread.Sleep(600);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[5]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                    Thread.Sleep(900);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[5]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.priceit);
                    Thread.Sleep(600);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                    Thread.Sleep(900);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[6]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricenl);
                    Thread.Sleep(600);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                    Thread.Sleep(900);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[7]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricepl);
                    Thread.Sleep(600);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[8]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                    Thread.Sleep(900);
                    dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[3]/div[1]/div[1]/div[1]/div[1]/div[6]/div[1]/div[8]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricese);


                    if (!book.HardBook)
                    {
                        Thread.Sleep(600);
                        dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[7]/div[1]/div[9]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                        Thread.Sleep(900);
                        dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[7]/div[1]/div[9]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.pricecojp);

                        Thread.Sleep(600);
                        dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[7]/div[1]/div[10]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                        Thread.Sleep(900);
                        dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[7]/div[1]/div[10]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.priceca);

                        Thread.Sleep(600);
                        dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[7]/div[1]/div[11]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).Clear();
                        Thread.Sleep(900);
                        dvr.FindElement(By.XPath("//body/div[@id='a-page']/div[@id='page-container']/div[3]/div[2]/div[2]/form[1]/div[1]/div[5]/div[1]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/div[7]/div[1]/div[11]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")).SendKeys(book.priceau);
                    }
                    //  Thread.Sleep(600);
                }

                if (false)
                {
                    Thread.Sleep(3000);
                    dvr.FindElement(By.XPath("//div[@class='a-checkbox a-checkbox-standalone a-checkbox-fancy']//i[@class='a-icon a-icon-checkbox']")).Click();
                    Thread.Sleep(3000);
                }
                //checkedbox     name :data[print_book][amazon_channel][us][lsi][publisher_enrolled]

                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(50));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id("save-and-publish-announce")));
                dvr.FindElement(By.Id("save-and-publish-announce")).Click();





                wait = new WebDriverWait(dvr, TimeSpan.FromSeconds(120));
                wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("a-button-input")));
                dvr.Navigate().GoToUrl("https://kdp.amazon.com/en_US/bookshelf");
            }
            catch (Exception ex)
            {
                //dvr.FindElement(By.Name("data[print_book][amazon_channel][uk][price_vat_exclusive]")).Clear();
                Message = ex.Message;
                scanecran("Paperback Content");
            }
        }
    }
}
