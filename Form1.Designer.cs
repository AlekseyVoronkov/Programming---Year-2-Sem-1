namespace GoldenRatioMethod
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
            this.tbFunc = new System.Windows.Forms.TextBox();
            this.plot1 = new OxyPlot.WindowsForms.PlotView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbA = new System.Windows.Forms.TextBox();
            this.tbB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbEpsilon = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rtbAnswers = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // tbFunc
            // 
            this.tbFunc.Location = new System.Drawing.Point(67, 6);
            this.tbFunc.Name = "tbFunc";
            this.tbFunc.Size = new System.Drawing.Size(100, 20);
            this.tbFunc.TabIndex = 0;
            this.tbFunc.Text = "(x-2)^2";
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
            this.plot1.TabIndex = 1;
            this.plot1.Text = "plot1";
            this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "F(x)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Левая граница";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tbA
            // 
            this.tbA.Location = new System.Drawing.Point(93, 40);
            this.tbA.Name = "tbA";
            this.tbA.Size = new System.Drawing.Size(74, 20);
            this.tbA.TabIndex = 5;
            this.tbA.Text = "-5";
            // 
            // tbB
            // 
            this.tbB.Location = new System.Drawing.Point(268, 40);
            this.tbB.Name = "tbB";
            this.tbB.Size = new System.Drawing.Size(74, 20);
            this.tbB.TabIndex = 6;
            this.tbB.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(173, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Правая граница";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Epsilon";
            // 
            // tbEpsilon
            // 
            this.tbEpsilon.Location = new System.Drawing.Point(67, 75);
            this.tbEpsilon.Name = "tbEpsilon";
            this.tbEpsilon.Size = new System.Drawing.Size(100, 20);
            this.tbEpsilon.TabIndex = 9;
            this.tbEpsilon.Text = "3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Выполнить расчеты";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rtbAnswers
            // 
            this.rtbAnswers.Location = new System.Drawing.Point(370, 6);
            this.rtbAnswers.Name = "rtbAnswers";
            this.rtbAnswers.Size = new System.Drawing.Size(364, 96);
            this.rtbAnswers.TabIndex = 11;
            this.rtbAnswers.Text = "";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(746, 455);
            this.Controls.Add(this.rtbAnswers);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.plot1);
            this.Controls.Add(this.tbEpsilon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbB);
            this.Controls.Add(this.tbA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFunc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFunc;
        private OxyPlot.WindowsForms.PlotView plot1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbA;
        private System.Windows.Forms.TextBox tbB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbEpsilon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rtbAnswers;
    }
}

