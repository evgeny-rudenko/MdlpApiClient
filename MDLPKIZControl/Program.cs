using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MdlpApiClient;

namespace MDLPKIZControl
{
    internal class Program
    {
        /// <summary>
        /// Ловим ошибки при выполнении программы. Нужно разобраться - ошибка в самой программе, или в серверной части
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            //Console.WriteLine(e.ExceptionObject.ToString());
            // Console.WriteLine("Press Enter to continue");
            // Console.ReadLine();

            // Instantiate the class
            var logger = new SimpleLogger(); // Will create a fresh new log file if it doesn't exist.
                                             // To log Trace message
                                             //logger.Trace("--> Trace in message here...");
                                             // To log Info message
                                             //logger.Info("Anything to info here...");
                                             // To log Debug message
                                             //logger.Debug("Something to debug...");
                                             // To log Warning message
                                             //logger.Warning("Anything to put as a warning log...");
                                             // To log Error message
                                             //logger.Error("Error message...");
                                             // To log Fatal error message


            Exception ee = (Exception)e.ExceptionObject;
            //ee.Data.Add("Apteka", Properties.Settings.Default.Apteka); Добавляем параметр, чтобы было проще смотреть аггрегацию лога в интернете
            logger.Fatal(e.ExceptionObject.ToString());

            //var ravenClient = new RavenClient("https://55028c333be94bc7a6d9a6e3d667e8c5@sentry.io/1340646");
            //ravenClient.Capture(new SharpRaven.Data.SentryEvent(ee));
         //   MessageBox.Show("Ошибка при выполнении программы проверки МДЛП.");
            Environment.Exit(1);
        }
        static void Main(string[] args)
        {
            //System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
            var client = new MdlpClient(credentials: new ResidentCredentials
            {
                ClientID = Properties.Settings.Default.ClientID, // из кабинета ЧЗ  - учетные системы
                ClientSecret = Properties.Settings.Default.ClientSecret, // из кабинета ЧЗ - учетные системы
                UserID = Properties.Settings.Default.UserID  // Отпечаток подписи пользователя - можно посмотреть в свойствах сертификата

            });
            //MdlpClient.

            MdlpApiClient.DataContracts.BranchFilter bf = new MdlpApiClient.DataContracts.BranchFilter();
            MdlpApiClient.DataContracts.BranchEntry[] branches = client.GetBranches(bf, 0, 100).Entries; // у нас их всего 18 штук



            foreach (MdlpApiClient.DataContracts.BranchEntry br in branches )
            {
                
            }


            // получение содержимого короба по SSCC
            //var sgtins = client.GetSsccFullHierarchy("046014989961618459");
            
            var logger = new SimpleLogger();
            logger.Info("Запуск приложения");


        }
        
        /// <summary>
        /// Формируем остатки без движения по точкам 
        /// </summary>
        /// <param name="be"></param>
        static void GetRemains (MdlpApiClient.DataContracts.BranchEntry be)
        {
            
        }
    }
}
