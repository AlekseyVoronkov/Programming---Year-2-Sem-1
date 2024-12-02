namespace DefiniteIntegralCalculation
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
            this.tbEpsilon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbB = new System.Windows.Forms.TextBox();
            this.tbA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFunc = new System.Windows.Forms.TextBox();
            this.plot1 = new OxyPlot.WindowsForms.PlotView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.посторитьГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tbInteralCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.очиститьРезультатыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbEpsilon
            // 
            this.tbEpsilon.Location = new System.Drawing.Point(79, 112);
            this.tbEpsilon.Name = "tbEpsilon";
            this.tbEpsilon.Size = new System.Drawing.Size(100, 20);
            this.tbEpsilon.TabIndex = 19;
            this.tbEpsilon.Text = "0.001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Epsilon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Правая граница";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbB
            // 
            this.tbB.Location = new System.Drawing.Point(288, 77);
            this.tbB.Name = "tbB";
            this.tbB.Size = new System.Drawing.Size(74, 20);
            this.tbB.TabIndex = 16;
            this.tbB.Text = "5";
            // 
            // tbA
            // 
            this.tbA.Location = new System.Drawing.Point(105, 77);
            this.tbA.Name = "tbA";
            this.tbA.Size = new System.Drawing.Size(74, 20);
            this.tbA.TabIndex = 15;
            this.tbA.Text = "-5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Левая граница";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "F(x)";
            // 
            // tbFunc
            // 
            this.tbFunc.Location = new System.Drawing.Point(79, 43);
            this.tbFunc.Name = "tbFunc";
            this.tbFunc.Size = new System.Drawing.Size(100, 20);
            this.tbFunc.TabIndex = 12;
            this.tbFunc.Text = "x^2-3";
            // 
            // plot1
            // 
            this.plot1.BackColor = System.Drawing.SystemColors.Control;
            this.plot1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plot1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plot1.Location = new System.Drawing.Point(0, 145);
            this.plot1.Name = "plot1";
            this.plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot1.Size = new System.Drawing.Size(746, 310);
            this.plot1.TabIndex = 11;
            this.plot1.Text = "plot1";
            this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.посторитьГрафикToolStripMenuItem,
            this.расчетыToolStripMenuItem,
            this.очиститьРезультатыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(746, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // посторитьГрафикToolStripMenuItem
            // 
            this.посторитьГрафикToolStripMenuItem.Name = "посторитьГрафикToolStripMenuItem";
            this.посторитьГрафикToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            this.посторитьГрафикToolStripMenuItem.Text = "Посторить График";
            this.посторитьГрафикToolStripMenuItem.Click += new System.EventHandler(this.посторитьГрафикToolStripMenuItem_Click);
            // 
            // расчетыToolStripMenuItem
            // 
            this.расчетыToolStripMenuItem.Name = "расчетыToolStripMenuItem";
            this.расчетыToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.расчетыToolStripMenuItem.Text = "Расчеты";
            this.расчетыToolStripMenuItem.Click += new System.EventHandler(this.расчетыToolStripMenuItem_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Метод прямоугольников",
            "Метод трапеций",
            "Метод парабол "});
            this.checkedListBox1.Location = new System.Drawing.Point(213, 22);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(149, 49);
            this.checkedListBox1.TabIndex = 25;
            // 
            // tbInteralCount
            // 
            this.tbInteralCount.Location = new System.Drawing.Point(288, 112);
            this.tbInteralCount.Name = "tbInteralCount";
            this.tbInteralCount.Size = new System.Drawing.Size(74, 20);
            this.tbInteralCount.TabIndex = 23;
            this.tbInteralCount.Text = "50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 26);
            this.label2.TabIndex = 24;
            this.label2.Text = "Колличество \r\nинтервалов ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(368, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(366, 110);
            this.dataGridView1.TabIndex = 26;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // очиститьРезультатыToolStripMenuItem
            // 
            this.очиститьРезультатыToolStripMenuItem.Name = "очиститьРезультатыToolStripMenuItem";
            this.очиститьРезультатыToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.очиститьРезультатыToolStripMenuItem.Text = "Очистить результаты";
            this.очиститьРезультатыToolStripMenuItem.Click += new System.EventHandler(this.очиститьРезультатыToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 455);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbInteralCount);
            this.Controls.Add(this.tbEpsilon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbB);
            this.Controls.Add(this.tbA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFunc);
            this.Controls.Add(this.plot1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbEpsilon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbB;
        private System.Windows.Forms.TextBox tbA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFunc;
        private OxyPlot.WindowsForms.PlotView plot1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem расчетыToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ToolStripMenuItem посторитьГрафикToolStripMenuItem;
        private System.Windows.Forms.TextBox tbInteralCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem очиститьРезультатыToolStripMenuItem;
    }
}

