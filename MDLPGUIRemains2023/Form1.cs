using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MDLPGUIRemains2023
{
    public partial class Form1 : Form
    {
        
        public List<kizSpisanie> kizSpisanies = new List<kizSpisanie>();
        public class kizSpisanie
        {
            public string sgtin { get; set; }
            public string status { get; set; }
            public string sell_name { get; set; }
            public string sys_id { get; set; }
        }

        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MDLPGUIRemains2023.Utils.KizStorage kizStorage = new Utils.KizStorage();

            // подгружаем список кизов которые прошли по чекам
            if (cbCheque.Checked)
            {
                kizStorage.ReadChequeKizFromFile();
            }

            if (Properties.Settings.Default.Debug)
            {
                
                // если в режиме отладки, то выбираем файл из параметров программы
                // чтобы каждый раз не тыкать выбор
                kizStorage.ReadMDLCSV(Properties.Settings.Default.DebugMdlpFile);
            }
            else
            {
                //тут нужно сделать выбор файла пользователем
                kizStorage.ReadMDLCSV(Properties.Settings.Default.DebugMdlpFile);
            }
            

            
            List<Utils.Kiz> kizs = new List<Utils.Kiz>();
            kizs = kizStorage.KizList.ToList(); // грузим в 
            kizs.RemoveAll(x => x.sell_name == null);
            
            // последовательно применяем фильтры 
            // фильтр по чекам
            /*
             var employees = employees1.IntersectBy(
               employees2.Select(e => e.SSN),
               e => e.SSN
                var MS = StudentCollection1.Select(x => x.Name)
                        . Intersect(StudentCollection2.Select(y => y.Name)).ToList();
             */
            if (cbCheque.Checked)
            {
                kizs = kizs.Where(x => kizStorage.ChequeKizList.Contains(x.sgtin.ToString())).ToList();
                


            }
            
            // фильтр по наименованию товара
            if (tbGoodFilter.Text.Length > 1)
            {
                kizs = kizs.Where(x => x.sell_name.ToLower().Contains(tbGoodFilter.Text.ToLower())).ToList();
            }
            
            // статус в обороте 
            if (txtStatusFilter.Text.Length>1)
            {
                kizs = kizs.Where(x => x.status.ToLower().Contains(txtStatusFilter.Text.ToLower())).ToList();
            }
            
            // сроки годности
            if (cbSG.Checked==true)
            {
                kizs = kizs.Where(x => x.expiration_date < DateTime.Now.AddDays(Properties.Settings.Default.SG) && x.expiration_date>DateTime.Now.AddDays (-3650) ).ToList() ;

            }

            kizs = kizs.Take(Properties.Settings.Default.RowsInGrid).ToList();
            this.datagridKiz.DataSource = kizs;
            this.datagridKiz.Refresh();
            this.toolStripStatusLabelRows.Text = "Строк в таблице " +  this.datagridKiz.RowCount.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (datagridKiz.Rows.Count > 0)
            {
                string filename = "spisanie.csv";
                List<Utils.Kiz> kizs = (List<Utils.Kiz>)datagridKiz.DataSource;
                StringBuilder s = new StringBuilder();
                foreach (Utils.Kiz k in kizs)
                {
                    s.AppendLine(k.sys_id + ";" + k.sgtin);
                }

                File.WriteAllText(filename, s.ToString());
                MessageBox.Show("Файл для списани сформирован");
            }
            else
            { MessageBox.Show("Пустая таблица"); }
        }

        /// <summary>
        /// Проверяем список КИЗ, которые уже могут быть списаны по чекам 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Добавляем в список на списание новую строку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void datagridKiz_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.datagridKiz.RowCount > 0)
            {

                kizSpisanie kiz = new kizSpisanie();

                kiz.sgtin =     this.datagridKiz.Rows[e.RowIndex].Cells["sgtin"].Value.ToString();
                kiz.status =    this.datagridKiz.Rows[e.RowIndex].Cells["status"].Value.ToString();
                kiz.sell_name = this.datagridKiz.Rows[e.RowIndex].Cells["sell_name"].Value.ToString();
                kiz.sys_id =    this.datagridKiz.Rows[e.RowIndex].Cells["sys_id"].Value.ToString();

                if (this.kizSpisanies.Where(x=> x.sgtin.Contains(kiz.sgtin)).ToArray().Length==0)
                {
                    this.kizSpisanies.Add(kiz);
                }

                List<kizSpisanie> list = new List<kizSpisanie>();
                list = kizSpisanies.Take(1000).ToList();
                this.datagridSpisaine.DataSource = list;
                this.datagridSpisaine.Refresh();




            }
        }

        private void datagridSpisaine_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void datagridSpisaine_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string sgtin = "";
            if (this.datagridSpisaine.RowCount > 0)
            {
                sgtin = this.datagridSpisaine.Rows[e.RowIndex].Cells["sgtin"].Value.ToString();
                List<kizSpisanie> list = new List<kizSpisanie>();
                list = kizSpisanies.Where(x => !x.sgtin.Contains(sgtin)).ToList();
                kizSpisanies = kizSpisanies.Where(x => !x.sgtin.Contains(sgtin)).ToList();
                this.datagridSpisaine.DataSource = list;
                this.datagridSpisaine.Refresh();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //списываем только то что есть в маленькой таблице
            if (datagridSpisaine.Rows.Count > 0)
            {
                string filename = "spisanie.csv";
                List<kizSpisanie> kizs = (List<kizSpisanie>)datagridSpisaine.DataSource;
                StringBuilder s = new StringBuilder();
                foreach (kizSpisanie k in kizs)
                {
                    s.AppendLine(k.sys_id + ";" + k.sgtin);
                }

                File.WriteAllText(filename, s.ToString());
                MessageBox.Show("Файл для списани сформирован");
            }
            else
            {
                MessageBox.Show("Пустая таблица");
            }
        }
    }
}
