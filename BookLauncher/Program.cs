using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using BookLauncher.Forms;
using DevExpress.XtraEditors;

namespace BookLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WindowsFormsSettings.ForceDirectXPaint();
            WindowsFormsSettings.SetDPIAware();
            WindowsFormsSettings.EnableFormSkins();
            //WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle("The Bezier");
            //SetSkinPlatte();DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("Verdana", GetDefaultSize());
            WindowsFormsSettings.ScrollUIMode = ScrollUIMode.Touch;
            WindowsFormsSettings.CustomizationFormSnapMode = DevExpress.Utils.Controls.SnapMode.OwnerControl;
         Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
           //Application.Run(new Form1());
           Application.Run(new Accueil());
        }
        static float GetDefaultSize()
        {
            return 9F;
        }
        static void SetSkinPlatte()
        {
            var skin = CommonSkins.GetSkin(WindowsFormsSettings.DefaultLookAndFeel);
            DevExpress.Utils.Svg.SvgPalette palette = skin.SvgPalettes["Office Colorful"];
        }
    }
}
