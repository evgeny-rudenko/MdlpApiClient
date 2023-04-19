using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MdlpApiClient;
using System.IO;

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
            client.Tracer = Console.WriteLine;
            /*MdlpApiClient.DataContracts.BranchFilter bf = new MdlpApiClient.DataContracts.BranchFilter();
            MdlpApiClient.DataContracts.BranchEntry[] branches = client.GetBranches(bf, 0, 100).Entries; // у нас их всего 18 штук
            


            foreach (MdlpApiClient.DataContracts.BranchEntry br in branches )
            {
                Console.WriteLine(br.OrgName);
                Console.WriteLine(br.ID);
            }
            */

            // получение содержимого короба по SSCC
            var sgtins = client.GetSsccFullHierarchy("046014989961618459");
            
            var logger = new SimpleLogger();
            logger.Info("Запуск приложения");

            

            string pathName = "";
            string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string docPath = Path.Combine(executablePath, Properties.Settings.Default.DocFolder);
            List<string> processedDocuments = new List<string>(); 
            if (File.Exists("processed.txt"))
            {
                processedDocuments = File.ReadLines("processed.txt").ToList();
            }


            DirectoryInfo d = new DirectoryInfo(docPath); 

            FileInfo[] Files = d.GetFiles("*.xml"); //получаем список файлов для списания
            string str = "";

            Console.WriteLine("Начинаем обрабатывать документы");
            logger.Info("Начинаем обрабатывать документы");
            foreach (FileInfo file in Files)
            {

                logger.Info($"Обработка файла {file.Name}"); 
                Console.WriteLine(file.Name);
                string document = File.ReadAllText(file.FullName);
                if (processedDocuments.Contains(file.Name))
                {
                    Console.WriteLine($"Файл {file.Name} уже обработан ранее");
                    continue;
                }    

                try 
                {
                    Console.WriteLine(  $"Отправка документа {file.FullName}");
                    client.SendDocument(document);
                    System.Threading.Thread.Sleep(2000); /// таймауты несколько раз поменялись и субъективно с таймаутами из документации отсылка ломается
                }
                catch (Exception ex)
                {
                    logger.Error($"Ошибка при обработке файла {file.Name}");
                    logger.Error(ex.Message);
                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);
                    
                }
                finally
                {
                    logger.Info($"Отправлен документ {file.Name}");
                    processedDocuments.Add(file.Name);
                    File.WriteAllLines("processed.txt", processedDocuments);

                }
            }

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
