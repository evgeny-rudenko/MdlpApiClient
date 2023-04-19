namespace MDLPGUIRemains2023
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.datagridKiz = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbGTINFilter = new System.Windows.Forms.TextBox();
            this.tbGoodFilter = new System.Windows.Forms.TextBox();
            this.tbSeriesFilter = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStatusFilter = new System.Windows.Forms.TextBox();
            this.cbSG = new System.Windows.Forms.CheckBox();
            this.datagridSpisaine = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.toolStripStatusLabelRows = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.datagridKiz)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridSpisaine)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridKiz
            // 
            this.datagridKiz.AllowUserToAddRows = false;
            this.datagridKiz.AllowUserToDeleteRows = false;
            this.datagridKiz.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.datagridKiz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridKiz.Location = new System.Drawing.Point(12, 186);
            this.datagridKiz.Name = "datagridKiz";
            this.datagridKiz.ReadOnly = true;
            this.datagridKiz.Size = new System.Drawing.Size(1517, 477);
            this.datagridKiz.TabIndex = 0;
            this.datagridKiz.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridKiz_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "Загрузить данные МДЛП";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelRows});
            this.statusStrip1.Location = new System.Drawing.Point(0, 666);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1541, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(40, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 52);
            this.button2.TabIndex = 3;
            this.button2.Text = "Есть чеки, но не списано";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(40, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 52);
            this.button3.TabIndex = 4;
            this.button3.Text = "Оборот приостановлен";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "SGTIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Наименование";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Серия товара";
            // 
            // tbGTINFilter
            // 
            this.tbGTINFilter.Location = new System.Drawing.Point(353, 32);
            this.tbGTINFilter.Name = "tbGTINFilter";
            this.tbGTINFilter.Size = new System.Drawing.Size(269, 20);
            this.tbGTINFilter.TabIndex = 9;
            // 
            // tbGoodFilter
            // 
            this.tbGoodFilter.Location = new System.Drawing.Point(351, 70);
            this.tbGoodFilter.Name = "tbGoodFilter";
            this.tbGoodFilter.Size = new System.Drawing.Size(269, 20);
            this.tbGoodFilter.TabIndex = 10;
            // 
            // tbSeriesFilter
            // 
            this.tbSeriesFilter.Location = new System.Drawing.Point(353, 102);
            this.tbSeriesFilter.Name = "tbSeriesFilter";
            this.tbSeriesFilter.Size = new System.Drawing.Size(269, 20);
            this.tbSeriesFilter.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(646, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(215, 52);
            this.button4.TabIndex = 12;
            this.button4.Text = "Списать в МДЛП";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(374, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(219, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Фильтры для поиска";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Статус";
            // 
            // txtStatusFilter
            // 
            this.txtStatusFilter.Location = new System.Drawing.Point(353, 141);
            this.txtStatusFilter.Name = "txtStatusFilter";
            this.txtStatusFilter.Size = new System.Drawing.Size(269, 20);
            this.txtStatusFilter.TabIndex = 15;
            // 
            // cbSG
            // 
            this.cbSG.AutoSize = true;
            this.cbSG.Location = new System.Drawing.Point(646, 89);
            this.cbSG.Name = "cbSG";
            this.cbSG.Size = new System.Drawing.Size(215, 17);
            this.cbSG.TabIndex = 16;
            this.cbSG.Text = "Только препараты с истекающим СГ";
            this.cbSG.UseVisualStyleBackColor = true;
            // 
            // datagridSpisaine
            // 
            this.datagridSpisaine.AllowUserToAddRows = false;
            this.datagridSpisaine.AllowUserToDeleteRows = false;
            this.datagridSpisaine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridSpisaine.Location = new System.Drawing.Point(886, 45);
            this.datagridSpisaine.Name = "datagridSpisaine";
            this.datagridSpisaine.ReadOnly = true;
            this.datagridSpisaine.Size = new System.Drawing.Size(643, 135);
            this.datagridSpisaine.TabIndex = 17;
            this.datagridSpisaine.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridSpisaine_CellContentDoubleClick);
            this.datagridSpisaine.DoubleClick += new System.EventHandler(this.datagridSpisaine_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(886, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Список товаров для списания";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(646, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(215, 52);
            this.button5.TabIndex = 19;
            this.button5.Text = "Списать из списка";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // toolStripStatusLabelRows
            // 
            this.toolStripStatusLabelRows.Name = "toolStripStatusLabelRows";
            this.toolStripStatusLabelRows.Size = new System.Drawing.Size(40, 17);
            this.toolStripStatusLabelRows.Text = "Строк";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1541, 688);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.datagridSpisaine);
            this.Controls.Add(this.cbSG);
            this.Controls.Add(this.txtStatusFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tbSeriesFilter);
            this.Controls.Add(this.tbGoodFilter);
            this.Controls.Add(this.tbGTINFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datagridKiz);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Остатки МДЛП, Списание и контроль";
            ((System.ComponentModel.ISupportInitialize)(this.datagridKiz)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridSpisaine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridKiz;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbGTINFilter;
        private System.Windows.Forms.TextBox tbGoodFilter;
        private System.Windows.Forms.TextBox tbSeriesFilter;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStatusFilter;
        private System.Windows.Forms.CheckBox cbSG;
        private System.Windows.Forms.DataGridView datagridSpisaine;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRows;
    }
}

