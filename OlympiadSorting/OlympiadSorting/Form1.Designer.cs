namespace OlympiadSorting
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sortsListBox = new System.Windows.Forms.CheckedListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnUserData = new System.Windows.Forms.Button();
            this.btnRandomData = new System.Windows.Forms.Button();
            this.btnFromExcel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortOrderCheckBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sortsListBox
            // 
            this.sortsListBox.CheckOnClick = true;
            this.sortsListBox.FormattingEnabled = true;
            this.sortsListBox.Items.AddRange(new object[] {
            "Пузырьком",
            "Вставками",
            "Шейкерная",
            "Быстрая",
            "BOGO"});
            this.sortsListBox.Location = new System.Drawing.Point(12, 54);
            this.sortsListBox.Name = "sortsListBox";
            this.sortsListBox.Size = new System.Drawing.Size(120, 94);
            this.sortsListBox.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(294, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(494, 196);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Сортировки";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Controls.Add(this.btnUserData);
            this.flowLayoutPanel1.Controls.Add(this.btnRandomData);
            this.flowLayoutPanel1.Controls.Add(this.btnFromExcel);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(151, 54);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(122, 90);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnUserData
            // 
            this.btnUserData.Location = new System.Drawing.Point(3, 3);
            this.btnUserData.Name = "btnUserData";
            this.btnUserData.Size = new System.Drawing.Size(114, 23);
            this.btnUserData.TabIndex = 0;
            this.btnUserData.Text = "Ручной ввод";
            this.btnUserData.UseVisualStyleBackColor = true;
            this.btnUserData.Click += new System.EventHandler(this.btnUserData_Click);
            // 
            // btnRandomData
            // 
            this.btnRandomData.Location = new System.Drawing.Point(3, 32);
            this.btnRandomData.Name = "btnRandomData";
            this.btnRandomData.Size = new System.Drawing.Size(114, 23);
            this.btnRandomData.TabIndex = 1;
            this.btnRandomData.Text = "Случайные данные";
            this.btnRandomData.UseVisualStyleBackColor = true;
            this.btnRandomData.Click += new System.EventHandler(this.btnRandomData_Click);
            // 
            // btnFromExcel
            // 
            this.btnFromExcel.Location = new System.Drawing.Point(3, 61);
            this.btnFromExcel.Name = "btnFromExcel";
            this.btnFromExcel.Size = new System.Drawing.Size(114, 23);
            this.btnFromExcel.TabIndex = 2;
            this.btnFromExcel.Text = "Данные из Excel";
            this.btnFromExcel.UseVisualStyleBackColor = true;
            this.btnFromExcel.Click += new System.EventHandler(this.btnFromExcel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ввод данных";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 154);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(261, 96);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьToolStripMenuItem,
            this.сортироватьToolStripMenuItem,
            this.ClearResultsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.очиститьToolStripMenuItem.Text = "Очистить массив";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // сортироватьToolStripMenuItem
            // 
            this.сортироватьToolStripMenuItem.Name = "сортироватьToolStripMenuItem";
            this.сортироватьToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.сортироватьToolStripMenuItem.Text = "Сортировать";
            this.сортироватьToolStripMenuItem.Click += new System.EventHandler(this.сортироватьToolStripMenuItem_Click);
            // 
            // ClearResultsToolStripMenuItem
            // 
            this.ClearResultsToolStripMenuItem.Name = "ClearResultsToolStripMenuItem";
            this.ClearResultsToolStripMenuItem.Size = new System.Drawing.Size(204, 20);
            this.ClearResultsToolStripMenuItem.Text = "Очистить результаты сортировки";
            this.ClearResultsToolStripMenuItem.Click += new System.EventHandler(this.ClearResultsToolStripMenuItem_Click);
            // 
            // sortOrderCheckBox
            // 
            this.sortOrderCheckBox.AutoSize = true;
            this.sortOrderCheckBox.Location = new System.Drawing.Point(12, 256);
            this.sortOrderCheckBox.Name = "sortOrderCheckBox";
            this.sortOrderCheckBox.Size = new System.Drawing.Size(150, 17);
            this.sortOrderCheckBox.TabIndex = 7;
            this.sortOrderCheckBox.Text = "От большего к меьшему";
            this.sortOrderCheckBox.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(294, 256);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(494, 182);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sortOrderCheckBox);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.sortsListBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox sortsListBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnUserData;
        private System.Windows.Forms.Button btnRandomData;
        private System.Windows.Forms.Button btnFromExcel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортироватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClearResultsToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.CheckBox sortOrderCheckBox;
    }
}

