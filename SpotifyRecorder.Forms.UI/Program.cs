using System;
using System.Windows.Forms;

namespace SpotifyRecorder.Forms.UI {
    public static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main() {
            try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            } catch (Exception e) {
                MessageBox.Show(e.Message + e.StackTrace);
            }
        }
    }
}
