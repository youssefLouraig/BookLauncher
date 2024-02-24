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
using BookLauncher.Class;
namespace BookLauncher.Forms
{
    public partial class Frm_LoginKDP : DevExpress.XtraEditors.XtraUserControl
    {
        public Frm_LoginKDP()
        {
            InitializeComponent();
        }
        LoginKDP Clogn = new LoginKDP();
        BindingSource bindingSource1 = new BindingSource();
        private static Frm_LoginKDP _Login;
        public static Frm_LoginKDP login
        {
            get
            {
                if (_Login == null) _Login = new Frm_LoginKDP();
                return _Login;
            }
        }
        private void Frm_LoginKDP_Load(object sender, EventArgs e)
        {
            tEmail.Text = Module.Nom_Utilisateur;
            tPassword.Text = Module.Mot_passe;
            
        }

        private void Blogin_Click(object sender, EventArgs e)
        {
            try
            {
            if(tEmail.Text !="" && tPassword.Text != "")
            {
                Clogn.Email = tEmail.Text.ToString();
                Clogn.Password = tPassword.Text.ToString();
                //MessageBox.Show(Module.Nom_Utilisateur);
                Clogn.Modifier_Login();
                 Module.Nom_Utilisateur = tEmail.Text;
                Module.Mot_passe= tPassword.Text ;
                lValide.Visible = true;
                pictvalide.Visible = true;
                //this.Close();
            }
            else
            {
                lValide.Visible = false;
                pictvalide.Visible = false;
                if (tEmail.Text == "")
                {
                    errorProvider1.SetError(tEmail, "this email field cannot be empty");
                }
                else
                {
                    errorProvider1.SetError(tPassword, "this Password field cannot be empty");
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //this.Close();
            Parent.Controls.Remove(this);
            //MessageBox.Show(Parent.Name);
            //Dispose();
        }
    }
}