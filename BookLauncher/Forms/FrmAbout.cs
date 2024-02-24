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
using System.Reflection;
using DevExpress.Skins;
using BookLauncher.Class;
namespace BookLauncher.Forms
{
    public partial class FrmAbout : DevExpress.XtraEditors.XtraUserControl
    {
        public FrmAbout()
        {
            InitializeComponent();
            this.Text = String.Format("À propos de {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = AssemblyDescription;
        }
        #region Accesseurs d'attribut de l'assembly

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
        private void FrmAbout_Load(object sender, EventArgs e)
        {
            SkinContainerCollection skins = SkinManager.Default.Skins;
            for (int i = 0; i < skins.Count; i++)
            {
                tskins.Properties.Items.Add(skins[i].SkinName);
            }
            tskins.SelectedText = Class.Module.Skinnameprog;


        }
       
        BindingSource bindingSource1 = new BindingSource();
        private static FrmAbout _AboutApp;
        public static FrmAbout AboutApp
        {
            get
            {
                if (_AboutApp == null) _AboutApp = new FrmAbout();
                return _AboutApp;
            }
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            //this.Close();
            Parent.Controls.Remove(this);
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tskins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tskins.SelectedIndex > -1)
            {

                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName  = tskins.SelectedText;
                BookLauncher.Class.Module.Skinnameprog = tskins.SelectedText;
            }
        }
    }
}
