using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.Management;
using System.Threading;
using System.Management.Instrumentation;
using Microsoft.Win32;
using BookLauncher.Class;
namespace BookLauncher.Forms
{
    public partial class Frm_Active : DevExpress.XtraEditors.XtraUserControl
    {
        public Frm_Active()
        {
            InitializeComponent();
        }
        Activer_Programme Cactive = new Activer_Programme();
        private static Frm_Active _Activeprog;
        public static Frm_Active Activeprog
        {
            get
            {
                if (_Activeprog == null) _Activeprog = new Frm_Active();
                return _Activeprog;
            }
        }
        Activer_Programme cactiv = new Activer_Programme();
        private void Verification_Activation()
        {
            string serialactiv = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "serial", "BBB").ToString();
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
                        if (DatediffJours(dt, dtexpr) > 0)
                        {

                            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "2223");
                            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "depasse", "2013");
                        }
                        else
                        {
                            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "3157");
                            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "datelimite", dateExpir);
                            MessageBox.Show("The program has been reactivated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Restart();
                        }

                    }
                    else
                    {
                        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "2223");
                        Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "depasse", "2013");
                    }

                   // Thred.Abort();
                }
            }

        }
        private short DatediffJours(DateTime dt1, DateTime dt2)
        {
            //System.Linq.SqlClient.SqlMethods.DateDiff(dt1, dt2);
            System.TimeSpan diffResult = dt1.Subtract(dt2);
            return short.Parse(diffResult.Days.ToString());
        }
        private void textEdit2_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Bsend_Click(object sender, EventArgs e)
        {
            pictwait.Visible = true;
            if (TCodeClient.Text == "")
            {
                errorProvider1.SetError(TCodeClient, "Enter the email");
                pictwait.Visible = false;
                return;
            }
            else if (TCodeClient.Text.Length < 5)
            {
                errorProvider1.SetError(TCodeClient, "Email incorrect");
                pictwait.Visible = false;
                return;
            }
            if (tSerial.Text == "")
            {
                errorProvider1.SetError(tSerial, ("Enter the key"));
                pictwait.Visible = false;
                return;
            }
            panel3.Visible = true;
            pictconnexion.BackgroundImage = null;
            pictKeyValidation.BackgroundImage = null;
            pictsavekey.BackgroundImage = null;
            //MessageBox.Show(Activer_Programme.IsConnectedToInternet().ToString());
            if (!Activer_Programme.IsConnectedToInternet())
            {
                //MessageBox.Show("Connexion Internet n'exsite pas", "Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pictconnexion.BackgroundImage = Properties.Resources.Novalide;
                pictwait.Visible = false;
                return;
            }
            pictconnexion.BackgroundImage = Properties.Resources.valide;
            if (Cactive.Serial_existe(tSerial.Text) == false)
            {
                //MessageBox.Show("le serial qui est entré n'est pas valide", "Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                pictKeyValidation.BackgroundImage = Properties.Resources.Novalide;
                pictwait.Visible = false;
                return;
            }
            pictKeyValidation.BackgroundImage = Properties.Resources.valide;
            if (Cactive.Activer_programme_Deconnecter(TCodeClient.Text,tSerial.Text,"BookLauncher") == false)
            {

                pictsavekey.BackgroundImage = Properties.Resources.Novalide;
                pictwait.Visible = false;
                return;
            }
            pictsavekey.BackgroundImage = Properties.Resources.valide;
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "active", "3157");
            Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "serial", tSerial.Text.ToString());
           
 Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Syst64\1.0", "Type", Cactive.typeActivation);

            MessageBox.Show("Program activation completed successfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(0);

            pictwait.Visible = false;
            //MessageBox.Show("Validation ", "Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void tSerial_MouseEnter(object sender, EventArgs e)
        {

        }

        private void tSerial_MouseLeave(object sender, EventArgs e)
        {

        }

        private void bclose_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }

        private void Reactivation_Click(object sender, EventArgs e)
        {
            Verification_Activation();
        }
    }
}
