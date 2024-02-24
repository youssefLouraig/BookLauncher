using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using Microsoft.Win32;
using BookLauncher.Class;
namespace BookLauncher.Forms
{
    public partial class SplashBookLauncher : SplashScreen
    {
        public SplashBookLauncher()
        {
            InitializeComponent();
        }

        #region Overrides

        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
        }

        #endregion

        public enum SplashScreenCommand
        {
        }

        private void SplashBookLauncher_Load(object sender, EventArgs e)
        {
            RegistryKey SkinName = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\\Microsoft\\theme\\1.0");
            labelControl1.Text = "Copyright © Softcomputer 2019-" + DateTime.Now.Year;
            if (SkinName != null)
            {
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName =Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\theme\1.0", "SkinName", "Stardust").ToString();
                Module.Skinnameprog = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\theme\1.0", "SkinName", "Stardust").ToString();

            }
            else
            {
                Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\\theme\1.0");
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\theme\1.0", "SkinName", "Stardust");
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "Stardust";
                Module.Skinnameprog = "Stardust";
            }
        }
    }
}