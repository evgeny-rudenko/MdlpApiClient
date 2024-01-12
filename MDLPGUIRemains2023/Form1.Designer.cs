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
            this.toolStripStatusLabelRows = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCheque = new System.Windows.Forms.Button();
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
            this.cbCheque = new System.Windows.Forms.CheckBox();
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
            this.datagridKiz.Location = new System.Drawing.Point(24, 358);
            this.datagridKiz.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.datagridKiz.Name = "datagridKiz";
            this.datagridKiz.ReadOnly = true;
            this.datagridKiz.RowHeadersWidth = 82;
            this.datagridKiz.Size = new System.Drawing.Size(3034, 917);
            this.datagridKiz.TabIndex = 0;
            this.datagridKiz.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridKiz_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 23);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(316, 100);
            this.button1.TabIndex = 1;
            this.button1.Text = "Загрузить данные МДЛП";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelRows});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1281);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(3082, 42);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelRows
            // 
            this.toolStripStatusLabelRows.Name = "toolStripStatusLabelRows";
            this.toolStripStatusLabelRows.Size = new System.Drawing.Size(79, 32);
            this.toolStripStatusLabelRows.Text = "Строк";
            // 
            // btnCheque
            // 
            this.btnCheque.Enabled = false;
            this.btnCheque.Location = new System.Drawing.Point(80, 135);
            this.btnCheque.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCheque.Name = "btnCheque";
            this.btnCheque.Size = new System.Drawing.Size(316, 100);
            this.btnCheque.TabIndex = 3;
            this.btnCheque.Text = "Есть чеки, но не списано";
            this.btnCheque.UseVisualStyleBackColor = true;
            this.btnCheque.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(80, 246);
            this.button3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(316, 100);
            this.button3.TabIndex = 4;
            this.button3.Text = "Оборот приостановлен";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "SGTIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 135);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Наименование";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(524, 210);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Серия товара";
            // 
            // tbGTINFilter
            // 
            this.tbGTINFilter.Location = new System.Drawing.Point(706, 62);
            this.tbGTINFilter.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbGTINFilter.Name = "tbGTINFilter";
            this.tbGTINFilter.Size = new System.Drawing.Size(534, 31);
            this.tbGTINFilter.TabIndex = 9;
            // 
            // tbGoodFilter
            // 
            this.tbGoodFilter.Location = new System.Drawing.Point(702, 135);
            this.tbGoodFilter.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbGoodFilter.Name = "tbGoodFilter";
            this.tbGoodFilter.Size = new System.Drawing.Size(534, 31);
            this.tbGoodFilter.TabIndex = 10;
            // 
            // tbSeriesFilter
            // 
            this.tbSeriesFilter.Location = new System.Drawing.Point(706, 196);
            this.tbSeriesFilter.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tbSeriesFilter.Name = "tbSeriesFilter";
            this.tbSeriesFilter.Size = new System.Drawing.Size(534, 31);
            this.tbSeriesFilter.TabIndex = 11;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1292, 246);
            this.button4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(430, 100);
            this.button4.TabIndex = 12;
            this.button4.Text = "Списать в МДЛП";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(748, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(424, 48);
            this.label4.TabIndex = 13;
            this.label4.Text = "Фильтры для поиска";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(524, 277);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 14;
            this.label5.Text = "Статус";
            // 
            // txtStatusFilter
            // 
            this.txtStatusFilter.Location = new System.Drawing.Point(706, 271);
            this.txtStatusFilter.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtStatusFilter.Name = "txtStatusFilter";
            this.txtStatusFilter.Size = new System.Drawing.Size(534, 31);
            this.txtStatusFilter.TabIndex = 15;
            // 
            // cbSG
            // 
            this.cbSG.AutoSize = true;
            this.cbSG.Location = new System.Drawing.Point(1292, 137);
            this.cbSG.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cbSG.Name = "cbSG";
            this.cbSG.Size = new System.Drawing.Size(414, 29);
            this.cbSG.TabIndex = 16;
            this.cbSG.Text = "Только препараты с истекающим СГ";
            this.cbSG.UseVisualStyleBackColor = true;
            // 
            // datagridSpisaine
            // 
            this.datagridSpisaine.AllowUserToAddRows = false;
            this.datagridSpisaine.AllowUserToDeleteRows = false;
            this.datagridSpisaine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridSpisaine.Location = new System.Drawing.Point(1772, 87);
            this.datagridSpisaine.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.datagridSpisaine.Name = "datagridSpisaine";
            this.datagridSpisaine.ReadOnly = true;
            this.datagridSpisaine.RowHeadersWidth = 82;
            this.datagridSpisaine.Size = new System.Drawing.Size(1286, 260);
            this.datagridSpisaine.TabIndex = 17;
            this.datagridSpisaine.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridSpisaine_CellContentDoubleClick);
            this.datagridSpisaine.DoubleClick += new System.EventHandler(this.datagridSpisaine_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1772, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(311, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Список товаров для списания";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1292, 23);
            this.button5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(430, 100);
            this.button5.TabIndex = 19;
            this.button5.Text = "Списать из списка";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // cbCheque
            // 
            this.cbCheque.AutoSize = true;
            this.cbCheque.Location = new System.Drawing.Point(1292, 198);
            this.cbCheque.Name = "cbCheque";
            this.cbCheque.Size = new System.Drawing.Size(324, 29);
            this.cbCheque.TabIndex = 20;
            this.cbCheque.Text = "Загрузить и проверить чеки";
            this.cbCheque.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(3082, 1323);
            this.Controls.Add(this.cbCheque);
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
            this.Controls.Add(this.btnCheque);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datagridKiz);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
        private System.Windows.Forms.Button btnCheque;
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
        private System.Windows.Forms.CheckBox cbCheque;
    }
}

