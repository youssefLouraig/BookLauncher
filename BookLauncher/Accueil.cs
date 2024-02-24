using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BookLauncher.Forms;
using BookLauncher.Class;
using Microsoft.Win32;
using System.Threading;
using System.Threading.Tasks;
//telecharger dernier versiion chromedrive https://chromedriver.storage.googleapis.com/index.html
namespace BookLauncher
{
    public partial class Accueil : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Accueil()
        {
            //Thread thr = new Thread(new ThreadStart(start_splash));
            //thr.Start();
            //Thread.Sleep(5000);
            LoginForm frm = new LoginForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
 InitializeComponent();
            }
           
            //thr.Abort();
        }
       
        ///public static 
        LoginKDP Clogin = new LoginKDP();
        Thread Thred;
        Activer_Programme cactiv = new Activer_Programme();
        private void AccLoginKDP_Click(object sender, EventArgs e)
        {
            if (!Container.Controls.Contains(Frm_LoginKDP.login))
            {
                Container.Controls.Add(Frm_LoginKDP.login);
                Frm_LoginKDP.login.Dock = DockStyle.Fill;

            }
            Frm_LoginKDP.login.BringToFront();
            //Frm_LoginKDP FloginKdp = new Frm_LoginKDP();
            //FloginKdp.MdiParent = this;
            //FloginKdp.Show();
        }

        

        private void AccSaveBook_Click(object sender, EventArgs e)
        {
            if (!Container.Controls.Contains(Frm_Publishing.SaveBook))
            {
                Container.Controls.Add(Frm_Publishing.SaveBook);
                Frm_Publishing.SaveBook.Dock = DockStyle.Fill;

            }

            Frm_Publishing.SaveBook.BringToFront();
        }
        private bool programme_active()
        {
            //string codep1, codep;

            bool result = false;

            RegistryKey regVersion;
            regVersion = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\Microsoft\\Syst64\\1.0", true);
            //MessageBox.Show(Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "2223").ToString());
            if (regVersion == null)
            {
                // La clé n'existe pas ; crée la clé.
                regVersion = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\\Microsoft\\Syst64\\1.0");
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "datelimite", DateTime.Now.Date.ToString("dd/MM/yyyy"));
 Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "serial", "BBB");
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "2223");
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "depasse", "1985");
                result = true;
            }
            else if (Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", null) == null)
            {
                ///* TODO Change to default(_) if this is not a reference type */) == null/* TODO Change to default(_) if this is not a reference type */
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "datelimite", DateTime.Now.Date);
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "2223");
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "depasse", "1985");
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "serial", "BBB");
                result = true;
            }
            else if (Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "2223").ToString() == "2223")
            {
                string depasse;
                depasse = (String)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "depasse", "1985");
                
                if (depasse == "1985")
                {
                    DateTime readValue;
                    readValue = DateTime.Parse(Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "datelimite", null).ToString());
                    //MessageBox.Show(DatediffJours(DateTime.Now.Date, readValue).ToString());
                    if (DatediffJours(DateTime.Now.Date, readValue) > 7 || DatediffJours(DateTime.Now.Date, readValue) < 0)
                    {
                        //DateTime dt = new DateTime();
                        //dt.Subtract(
                        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "depasse", "2013");
                        MessageBox.Show("I'm sorry but you have exceeded the duration of use the program");
                        return false;
                    }
                    else
                        result = true;
                }
                else if (depasse == "2013")
                {
                    MessageBox.Show("I'm sorry but you have exceeded the duration of use the program");
                    result = false;
                }
            }
            else if (Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "2223").ToString() == "3157")
            {
                //****************************
                //depasse = (String)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "Type", "Month");
                //********************************
                AccoActiveProg.Enabled = false;
                AccoActiveProg.Text = "The program is activated";
                AccoActiveProg.Appearance.Normal.FontStyleDelta = FontStyle.Bold;
                AccoActiveProg.Appearance.Normal.ForeColor = Color.Green;


                result = true;
            }
           return result;
            //return true;
        }
        private void Verification_Activation()
        {
            //string serialactiv = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "serial", "BBB").ToString();
           string  serialactiv = "BBB";
            if (serialactiv != "BBB")
            {

            
                DateTime readValue;
                readValue = DateTime.Parse(Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "datelimite", null).ToString());           
                if (Activer_Programme.IsConnectedToInternet())
                {
                     bool activ = cactiv.Serial_valide(serialactiv);
                    Module.Verification_Activation_enligne = true;
                   // MessageBox.Show(activ.ToString() +"   " + serialactiv);
                     if (activ)
                         {
                      string dateExpir = cactiv.DateActivation;
                     
                        //switch (typeActive)
                        //{
                        //    case "Trial": nombreJRS = 20; break;
                        //    case "Month": nombreJRS = 31; break;
                        //    case "Year": nombreJRS = 365; break;
                        //    default: nombreJRS = 10; break;
                        //}
                        DateTime dt = DateTime.Now.Date;
                        try
                        {
                           // dt = cactiv.GetInternetTime("time.nist.gov", true);
                            dt = cactiv.GetInternetTime("time.windows.com", true);

                        }
                        catch //(Exception ex)
                        {

                        }
                        //30/03/2020
                        DateTime dtexpr = new DateTime(int.Parse(dateExpir.Substring(6, 4)), int.Parse(dateExpir.Substring(3, 2)), int.Parse(dateExpir.Substring(0, 2)));
                       
                        //MessageBox.Show(dt.ToString() + "   " + dateExpir  + " difference " + DatediffJours(dt, dtexpr));
                        if (DatediffJours(dt, dtexpr) > 0 )
                        {

                            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "2223");
                            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "depasse", "2013");
                        }
                        else
                        {
   Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "3157");
                        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "datelimite", dateExpir);
                        }

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

        public string complet(string cod)
        {
            // cod = new string("0", 16 - cod.Length) + cod;
            cod = new String('0', (16 - cod.Length)) + cod;
            //cod +=cod;
            return cod;
        }


        private void AccListeBook_Click(object sender, EventArgs e)
        {
            if (!Container.Controls.Contains(Frm_ListeBooks.ListBook))
            {
                Container.Controls.Add(Frm_ListeBooks.ListBook);
                Frm_ListeBooks.ListBook.Dock = DockStyle.Fill;

            }

            Frm_ListeBooks.ListBook.BringToFront();
        }

        private void AccoImportBook_Click(object sender, EventArgs e)
        {
            if (!Container.Controls.Contains(Frm_ImportExcel.ImportBook))
            {
                Container.Controls.Add(Frm_ImportExcel.ImportBook);
                Frm_ImportExcel.ImportBook.Dock = DockStyle.Fill;
            }

            Frm_ImportExcel.ImportBook.BringToFront();
        }

        private void AccoActiveProg_Click(object sender, EventArgs e)
        {
            if (!Container.Controls.Contains(Frm_Active.Activeprog))
            {
                Container.Controls.Add(Frm_Active.Activeprog);
                Frm_Active.Activeprog.Dock = DockStyle.Fill;
            }

            Frm_Active.Activeprog.BringToFront();
        }

        private void Accueil_Shown(object sender, EventArgs e)
        {


        }

        private void Accueil_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            Application.Exit();
           
        }

        private void Accueil_FormClosing(object sender, FormClosingEventArgs e)
        {
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\theme\1.0", "SkinName", Module.Skinnameprog);

        }
        static async Task<DateTime> ReadDate()
        {
            DateTime DateNow = await Module.GetNISTDate(true);

            return DateNow;
        }
        private void Accueil_Load(object sender, EventArgs e)
        {
            //Task task = new Task(delegate () { MessageBox.Show(ReadDate().ToString()); });
            //task.Start();

            Module.Verification_Activation_enligne = false;
            //MessageBox.Show("salam");
            //if (!programme_active())
                if (false)
                {
                AccSaveBook.Enabled = false;
                AccListeBook.Enabled = false;
                AccoImportBook.Enabled = false;
                AccLoginKDP.Enabled = false;
                AccLoginApp.Enabled = false;
                accordionControlElement6.Enabled = false;
accordionControlElement7.Enabled = false;
            }
           
                Clogin.return_Login();
                Module.Nom_Utilisateur = Clogin.Email;
                Module.Mot_passe = Clogin.Password;
            Thred = new Thread(delegate () { Verification_Activation(); });
            Thred.Start();


        }

        private void AccLoginApp_Click(object sender, EventArgs e)
        {
            if (!Container.Controls.Contains(Frm_UpdateLoginApp.loginAPP))
            {
                Container.Controls.Add(Frm_UpdateLoginApp.loginAPP);
                Frm_UpdateLoginApp.loginAPP.Dock = DockStyle.Fill;

            }
            Frm_UpdateLoginApp.loginAPP.BringToFront();
        }

        private void accorAbout_Click(object sender, EventArgs e)
        {
            if (!Container.Controls.Contains(FrmAbout.AboutApp))
            {
                Container.Controls.Add(FrmAbout.AboutApp);
                FrmAbout.AboutApp.Dock = DockStyle.Fill;

            }
            FrmAbout.AboutApp.BringToFront();
        }

        private void accordionControlElement6_Click(object sender, EventArgs e)
        {
            if (!Container.Controls.Contains(Frm_Generate_Mazes.Mazes))
            {
                Container.Controls.Add(Frm_Generate_Mazes.Mazes);
                Frm_Generate_Mazes.Mazes.Dock = DockStyle.Fill;
            }

            Frm_Generate_Mazes.Mazes.BringToFront();
        }

        private void accordionControlElement7_Click(object sender, EventArgs e)
        {
            if (!Container.Controls.Contains(Frm_Generate_keysearch.Mazes))
            {
                Container.Controls.Add(Frm_Generate_keysearch.Mazes);
                Frm_Generate_keysearch.Mazes.Dock = DockStyle.Fill;
            }

            Frm_Generate_keysearch.Mazes.BringToFront();
        }
    }
}
