using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MdlpApiClient;


namespace MDLPReports
{
    class Program
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
        
            /// выходим из программы и пишем в лог , если запускаем на клиенте
            /// проще отладка
            if (Properties.Settings.Default.Debug)
            {
                System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
            }

            var client = new MdlpClient(credentials: new ResidentCredentials
            {
                ClientID = Properties.Settings.Default.ClientID, // из кабинета ЧЗ  - учетные системы
                ClientSecret = Properties.Settings.Default.ClientSecret, // из кабинета ЧЗ - учетные системы
                UserID = Properties.Settings.Default.UserID  // Отпечаток подписи пользователя - можно посмотреть в свойствах сертификата


            });
            // во время отладки пишет лог обмена с сервером  API на экран 
            // можно реализовать и другой трейсер
            if (Properties.Settings.Default.Debug)
            {
                client.Tracer = Console.WriteLine;
            }


            //var result = client.
        }
    }
}
