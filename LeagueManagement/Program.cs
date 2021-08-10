using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LeagueManagement.thaind.common;
using LeagueManagement.thaind.dao;
using log4net;
using log4net.Config;

namespace LeagueManagement
{
    static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XmlConfigurator.Configure(new FileInfo(Directory.GetCurrentDirectory() + @"\config\log4net.xml"));
            ConnectionProvider.LoadConfig(Directory.GetCurrentDirectory() + @"\config\connection_configuration.json");
            Config.LoadConfig();
            DataContextProvider.LoadConfig(Directory.GetCurrentDirectory() + @"\config\connection_configuration.json");
            Log.Info("run ok");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}