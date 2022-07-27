using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MdlpApiClient;
using System.Windows.Forms; /// для того чтобы показывать стандартные окна оповещений Windows


namespace MDLPConsole
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
            MessageBox.Show("Ошибка при выполнении программы проверки МДЛП.");
            Environment.Exit(1);
        }


        static void Main(string[] args)
        {

            // на ошибках не падаем, а логируем и выходим
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            var logger = new SimpleLogger();
            logger.Info("Запуск проверки");
            // клиент пока никуда не коннектится
            // те только создается новый объект соединения
            var client = new MdlpClient(credentials: new ResidentCredentials
            {
                ClientID = Properties.Settings.Default.ClientID, // из кабинета ЧЗ  - учетные системы
                ClientSecret = Properties.Settings.Default.ClientSecret, // из кабинета ЧЗ - учетные системы
                UserID = Properties.Settings.Default.UserID  // Отпечаток подписи пользователя - можно посмотреть в свойствах сертификата
                
            });
                
                       
            int daysForControl = Properties.Settings.Default.daysForControl; // проверяем только за последнюю неделю
            int invoicescounter = 0; //счетчик поличества исходящих документов прихода
            
            MdlpApiClient.DataContracts.DocFilter docFilter = new MdlpApiClient.DataContracts.DocFilter();
            docFilter.StartDate = DateTime.Now.AddDays(daysForControl*(-1));
            docFilter.EndDate = DateTime.Now;
            docFilter.DocType = 416;
            
            var doc_list = client.GetOutcomeDocuments(docFilter, 1, 100);
            invoicescounter += doc_list.Documents.Count();
            
            logger.Info($"Документов прихода типа 416 {doc_list.Documents.Count().ToString()} или больше ");
            docFilter.DocType = 702;
            doc_list = client.GetOutcomeDocuments(docFilter, 1, 100);
            invoicescounter += doc_list.Documents.Count();
            
            logger.Info($"Документов прихода типа 702 {doc_list.Documents.Count().ToString()} или больше ");
            logger.Info("Закончена проверка");

            if (invoicescounter == 0)
            {
                // нет ни одного документа 
                MessageBox.Show("Документов не обнаружено. Нужно проверить работу КИЗ Сервера!","Ошибка в процессе контроля!");
                logger.Warning("Нет приходных накладных в МДЛП");
                return;
            }
            else
            {
                MessageBox.Show($"Есть {invoicescounter.ToString()} исходящих документов за последнюю неделю", "Все в порядке");
                logger.Info($"Есть {invoicescounter.ToString()} исходящих документов за последнюю неделю");
            }
                        
        }
    }


}
