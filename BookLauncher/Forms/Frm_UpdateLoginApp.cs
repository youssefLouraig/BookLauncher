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
using BookLauncher.Class;
namespace BookLauncher.Forms
{
    public partial class Frm_UpdateLoginApp : DevExpress.XtraEditors.XtraUserControl
    {
        public Frm_UpdateLoginApp()
        {
            InitializeComponent();
        }
        Users Cuser = new Users();
        BindingSource bindingSource1 = new BindingSource();
        private static Frm_UpdateLoginApp _LoginAPP;
        public static Frm_UpdateLoginApp loginAPP
        {
            get
            {
                if (_LoginAPP == null) _LoginAPP = new Frm_UpdateLoginApp();
                return _LoginAPP;
            }
        }
        private void Blogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (tCurrentPass.Text !="" && tNewPassword.Text !="" && tNewPassword2.Text!="" && tNewUser.Text != "")
            {
                if (tCurrentPass.Text!=motpass)
                {
                    errorProvider1.SetError(tCurrentPass, "Password Erroné");
                    return;
                }
                if (tNewPassword.Text != tNewPassword2.Text)
                {
                    errorProvider1.SetError(tNewPassword2, "Password does not match");
                    return;
                }
                Cuser.NameUser = tNewUser.Text.ToString() ;
                Cuser.Motpasse = tNewPassword.Text.ToString();
                Cuser.Modifier_User(nomuser);
                lValide.Visible = true;
                pictvalide.Visible = true;
            }
            else
            {
                lValide.Visible = false;
                pictvalide.Visible = false;
                Alert_vide();
            }
        }

        private void Alert_vide()
        {
            if (tCurrentPass.Text == "")
            {
                errorProvider1.SetError(tCurrentPass, "this Current Password field cannot be empty");
            }
            if (tNewPassword.Text == "")
            {
                errorProvider1.SetError(tNewPassword, "this new Password field cannot be empty");
            }
            if (tNewUser.Text == "")
            {
                errorProvider1.SetError(tNewUser, "this new User field cannot be empty");
            }
            if (tNewPassword2.Text == "")
            {
                errorProvider1.SetError(tNewPassword2, "this new Password field cannot be empty");
            }
        }
        string motpass;
        string nomuser;
        private void Frm_UpdateLoginApp_Load(object sender, EventArgs e)
        {
            Cuser.Return_User();
            motpass = Cuser.Motpasse;
            nomuser= Cuser.NameUser;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //this.Close();
            Parent.Controls.Remove(this);
        }
    }
}
