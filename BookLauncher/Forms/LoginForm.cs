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
using System.Threading;
using BookLauncher.Class;
namespace BookLauncher.Forms
{
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            Thread thr = new Thread(new ThreadStart(start_splash));
            thr.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            thr.Abort();
        }
        Users cuser = new Users();
        private void start_splash()
        {
            Application.Run(new SplashBookLauncher());
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Blogin_Click(object sender, EventArgs e)
        {
            if(tUser.Text!="" && tPassword.Text != "")
            {
                if(tUser.Text==nom && tPassword.Text == motpass)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    errorProvider1.SetError(tPassword, "User or Password Erroné");
                }

            }
           
        }
        string nom;
        string motpass;
        private void LoginForm_Load(object sender, EventArgs e)
        {
            cuser.Return_User();
            nom = cuser.NameUser;
            motpass = cuser.Motpasse;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Module.Skinnameprog;
        }
    }
}