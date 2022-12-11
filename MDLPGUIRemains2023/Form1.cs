using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDLPGUIRemains2023
{
    public partial class Form1 : Form
    {
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MDLPGUIRemains2023.Utils.KizStorage kizStorage = new Utils.KizStorage();
            kizStorage.ReadMDLCSV();

            DataTable dt = kizStorage.KizList.ToDataTable2();
            dt.TableName = "KizTable";
            datagridKiz.DataSource = dt;
            


        }
    }
}
