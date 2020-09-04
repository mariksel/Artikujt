using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerSync
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (CheckDatabaseConnection())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ServerSyncForm());
            }
        }


        private static bool CheckDatabaseConnection()
        {
            try
            {
                using (var repo = new ArtikullRepository())
                {
                    repo.CheckConnection();
                    ServerSyncForm.Configuration = repo.Configurations.First();
                }
                
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                {
                    message = ex.InnerException.Message;
                }
                MessageBox.Show(message, "Probleme me databazen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
