namespace CoordinateDescent
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
            this.rtbAnswers = new System.Windows.Forms.RichTextBox();
            this.tbEpsilon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStarty = new System.Windows.Forms.TextBox();
            this.tbStartx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFunc = new System.Windows.Forms.TextBox();
            this.plot1 = new OxyPlot.WindowsForms.PlotView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.посторитьГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.расчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbIterations = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbStep = new System.Windows.Forms.TextBox();
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbAnswers
            // 
            this.rtbAnswers.Location = new System.Drawing.Point(461, 36);
            this.rtbAnswers.Name = "rtbAnswers";
            this.rtbAnswers.Size = new System.Drawing.Size(285, 96);
            this.rtbAnswers.TabIndex = 21;
            this.rtbAnswers.Text = "";
            // 
            // tbEpsilon
            // 
            this.tbEpsilon.Location = new System.Drawing.Point(79, 105);
            this.tbEpsilon.Name = "tbEpsilon";
            this.tbEpsilon.Size = new System.Drawing.Size(100, 20);
            this.tbEpsilon.TabIndex = 19;
            this.tbEpsilon.Text = "0.000001";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Epsilon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Старт y";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbStarty
            // 
            this.tbStarty.Location = new System.Drawing.Point(196, 70);
            this.tbStarty.Name = "tbStarty";
            this.tbStarty.Size = new System.Drawing.Size(74, 20);
            this.tbStarty.TabIndex = 16;
            this.tbStarty.Text = "0.1";
            // 
            // tbStartx
            // 
            this.tbStartx.Location = new System.Drawing.Point(66, 70);
            this.tbStartx.Name = "tbStartx";
            this.tbStartx.Size = new System.Drawing.Size(74, 20);
            this.tbStartx.TabIndex = 15;
            this.tbStartx.Text = "0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Старт x";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "F(x,y)";
            // 
            // tbFunc
            // 
            this.tbFunc.Location = new System.Drawing.Point(79, 36);
            this.tbFunc.Name = "tbFunc";
            this.tbFunc.Size = new System.Drawing.Size(100, 20);
            this.tbFunc.TabIndex = 12;
            this.tbFunc.Text = "xyln(x^2+y^2)";
            // 
            // plot1
            // 
            this.plot1.BackColor = System.Drawing.SystemColors.Control;
            this.plot1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.plot1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plot1.Location = new System.Drawing.Point(0, 138);
            this.plot1.Name = "plot1";
            this.plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot1.Size = new System.Drawing.Size(746, 317);
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
            this.ClearToolStripMenuItem});
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
            // tbIterations
            // 
            this.tbIterations.Location = new System.Drawing.Point(267, 105);
            this.tbIterations.Name = "tbIterations";
            this.tbIterations.Size = new System.Drawing.Size(74, 20);
            this.tbIterations.TabIndex = 23;
            this.tbIterations.Text = "8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Итерации";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Минимум",
            "Максимум"});
            this.checkedListBox1.Location = new System.Drawing.Point(279, 27);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(83, 34);
            this.checkedListBox1.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Что ищем - ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(285, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Шаг";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbStep
            // 
            this.tbStep.Location = new System.Drawing.Point(318, 70);
            this.tbStep.Name = "tbStep";
            this.tbStep.Size = new System.Drawing.Size(74, 20);
            this.tbStep.TabIndex = 28;
            this.tbStep.Text = "0.1";
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.ClearToolStripMenuItem.Text = "Очистить";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 455);
            this.Controls.Add(this.tbStep);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbIterations);
            this.Controls.Add(this.rtbAnswers);
            this.Controls.Add(this.tbEpsilon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbStarty);
            this.Controls.Add(this.tbStartx);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbAnswers;
        private System.Windows.Forms.TextBox tbEpsilon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbStarty;
        private System.Windows.Forms.TextBox tbStartx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFunc;
        private OxyPlot.WindowsForms.PlotView plot1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem расчетыToolStripMenuItem;
        private System.Windows.Forms.TextBox tbIterations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem посторитьГрафикToolStripMenuItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbStep;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
    }
}
