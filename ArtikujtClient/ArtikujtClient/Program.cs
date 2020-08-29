using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtikujtClient
{
    static class Program
    {
        public static ArtikullForm ArtikullForm { get; private set; }
        public static KerkoForm KerkoForm { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ArtikullForm = new ArtikullForm();
            KerkoForm = new KerkoForm();
            Application.Run(ArtikullForm);
        }
    }
}
