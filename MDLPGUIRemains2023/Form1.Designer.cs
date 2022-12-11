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
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbGTINFilter = new System.Windows.Forms.TextBox();
            this.tbGoodFilter = new System.Windows.Forms.TextBox();
            this.tbSeriesFilter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.datagridKiz)).BeginInit();
            this.SuspendLayout();
            // 
            // datagridKiz
            // 
            this.datagridKiz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridKiz.Location = new System.Drawing.Point(40, 246);
            this.datagridKiz.Name = "datagridKiz";
            this.datagridKiz.Size = new System.Drawing.Size(1461, 417);
            this.datagridKiz.TabIndex = 0;
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 666);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1541, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(40, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 52);
            this.button2.TabIndex = 3;
            this.button2.Text = "Есть чеки, но не списано";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(40, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 52);
            this.button3.TabIndex = 4;
            this.button3.Text = "На остатках МДЛП";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(40, 186);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(158, 52);
            this.button4.TabIndex = 5;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
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
            this.label2.Location = new System.Drawing.Point(262, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Наименование";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 148);
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
            this.tbGoodFilter.Location = new System.Drawing.Point(353, 90);
            this.tbGoodFilter.Name = "tbGoodFilter";
            this.tbGoodFilter.Size = new System.Drawing.Size(269, 20);
            this.tbGoodFilter.TabIndex = 10;
            // 
            // tbSeriesFilter
            // 
            this.tbSeriesFilter.Location = new System.Drawing.Point(353, 148);
            this.tbSeriesFilter.Name = "tbSeriesFilter";
            this.tbSeriesFilter.Size = new System.Drawing.Size(269, 20);
            this.tbSeriesFilter.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1541, 688);
            this.Controls.Add(this.tbSeriesFilter);
            this.Controls.Add(this.tbGoodFilter);
            this.Controls.Add(this.tbGTINFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.datagridKiz);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Остатки МДЛП, Списание и контроль";
            ((System.ComponentModel.ISupportInitialize)(this.datagridKiz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView datagridKiz;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbGTINFilter;
        private System.Windows.Forms.TextBox tbGoodFilter;
        private System.Windows.Forms.TextBox tbSeriesFilter;
    }
}

