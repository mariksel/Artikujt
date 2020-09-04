using ArtikutClient.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtikujtClient
{
    static class Program
    {
        public static ArtikullForm ArtikullForm { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database.SetInitializer<ApplicationDBContext>(null);

            if (CheckDatabaseConnection())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ArtikullForm = new ArtikullForm();
                Application.Run(ArtikullForm);
            }

            
        }

        private static bool CheckDatabaseConnection()
        {
            try
            {
                using (var repo = new ArtikullRepository())
                {
                    repo.CheckConnection();

                }
                var config = ClientSync.Instance;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.InnerException != null)
                {
                    message = ex.InnerException.Message;
                }
                MessageBox.Show( message, "Probleme me databazen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
