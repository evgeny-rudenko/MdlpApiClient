using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MdlpApiClient;

namespace MDLPGUIInvoice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rtbSgtins.Clear();
            var logger = new SimpleLogger();
            logger.Info("Поучаем информацию о коробе");

            
            var client = new MdlpClient(credentials: new ResidentCredentials
            {
                
                
                ClientID = Properties.Settings.Default.ClientID, // из кабинета ЧЗ  - учетные системы
                ClientSecret = Properties.Settings.Default.ClientSecret, // из кабинета ЧЗ - учетные системы
                UserID = Properties.Settings.Default.UserID  // Отпечаток подписи пользователя - можно посмотреть в свойствах сертификата
                
            });


            // получение содержимого короба по SSCC
            //MdlpApiClient.DataContracts.SsccFullHierarchyResponse<MdlpApiClient.DataContracts.HierarchySsccInfo> sgtins = client.GetSsccFullHierarchy("046014989961618459");
            MdlpApiClient.DataContracts.SsccFullHierarchyResponse<MdlpApiClient.DataContracts.HierarchySsccInfo> sgtins;
            try
            {
                 sgtins = client.GetSsccFullHierarchy(txtSSCC.Text.ToString());
            }
            catch (Exception ex)    
            {

                MessageBox.Show("Произошла ошибка при получении кодов. Проверьте SSCC");
                logger.Fatal(ex.Message);
                return;
            }


            if (sgtins.Down.ChildSgtins.Count()==0)
            {
                MessageBox.Show("Нет данных о содержимом короба");
                return;
            }

            foreach(var el in sgtins.Down.ChildSgtins)
            {
                rtbSgtins.AppendText(el.Sgtin + "\r\n");
                rtbSgtins.ScrollToCaret();

            }
           /// client.Dispose();
            logger.Info("Закончили получение данных о коробке");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbSgtins.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtSSCC.Text = "046014989961618459";
        }
    }
}
