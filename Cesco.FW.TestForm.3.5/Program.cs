using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using System.Diagnostics;
using System.Threading;

namespace Cesco.FW.TestForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] //vvvvvvv
        static void Main()
        {
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Lilian");
            try
            {
                Application.Run(new StartForm());
            }
            catch (Exception ex)
            {
                Application.Run(new ErrorTraceForm(ex, System.Reflection.MethodBase.GetCurrentMethod()));
            }
            
        }
    }
}