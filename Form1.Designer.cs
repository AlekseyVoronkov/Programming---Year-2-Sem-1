namespace SLAY
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGenerateData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmFromExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmClear = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmCalculate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMatrixSize = new System.Windows.Forms.ToolStripMenuItem();
            this.linear = new System.Windows.Forms.RadioButton();
            this.quadro = new System.Windows.Forms.RadioButton();
            this.plot1 = new OxyPlot.WindowsForms.PlotView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(273, 390);
            this.dataGridView1.TabIndex = 11;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGenerateData,
            this.tsmFromExcel,
            this.tsmExportExcel});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(62, 20);
            this.toolStripMenuItem1.Text = "Данные";
            // 
            // tsmGenerateData
            // 
            this.tsmGenerateData.Name = "tsmGenerateData";
            this.tsmGenerateData.Size = new System.Drawing.Size(202, 22);
            this.tsmGenerateData.Text = "Сгенерировать данные";
            this.tsmGenerateData.Click += new System.EventHandler(this.tsmGenerateData_Click);
            // 
            // tsmFromExcel
            // 
            this.tsmFromExcel.Name = "tsmFromExcel";
            this.tsmFromExcel.Size = new System.Drawing.Size(202, 22);
            this.tsmFromExcel.Text = "Данные из Excel";
            this.tsmFromExcel.Click += new System.EventHandler(this.tsmFromExcel_Click);
            // 
            // tsmExportExcel
            // 
            this.tsmExportExcel.Name = "tsmExportExcel";
            this.tsmExportExcel.Size = new System.Drawing.Size(202, 22);
            this.tsmExportExcel.Text = "Экспорт данных в Excel";
            this.tsmExportExcel.Click += new System.EventHandler(this.tsmExportExcel_Click);
            // 
            // tsmClear
            // 
            this.tsmClear.Name = "tsmClear";
            this.tsmClear.Size = new System.Drawing.Size(71, 20);
            this.tsmClear.Text = "Очистить";
            this.tsmClear.Click += new System.EventHandler(this.tsmClear_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.tsmClear,
            this.tsmCalculate,
            this.tsmMatrixSize});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(403, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmCalculate
            // 
            this.tsmCalculate.Name = "tsmCalculate";
            this.tsmCalculate.Size = new System.Drawing.Size(63, 20);
            this.tsmCalculate.Text = "Считать";
            this.tsmCalculate.Click += new System.EventHandler(this.tsmCalculate_Click);
            // 
            // tsmMatrixSize
            // 
            this.tsmMatrixSize.Name = "tsmMatrixSize";
            this.tsmMatrixSize.Size = new System.Drawing.Size(107, 20);
            this.tsmMatrixSize.Text = "Задать размеры";
            this.tsmMatrixSize.Click += new System.EventHandler(this.tsmMatrixSize_Click);
            // 
            // linear
            // 
            this.linear.AutoSize = true;
            this.linear.Location = new System.Drawing.Point(291, 48);
            this.linear.Name = "linear";
            this.linear.Size = new System.Drawing.Size(71, 17);
            this.linear.TabIndex = 13;
            this.linear.TabStop = true;
            this.linear.Text = "y = ax + b";
            this.linear.UseVisualStyleBackColor = true;
            this.linear.CheckedChanged += new System.EventHandler(this.linear_CheckedChanged);
            // 
            // quadro
            // 
            this.quadro.AutoSize = true;
            this.quadro.Location = new System.Drawing.Point(291, 71);
            this.quadro.Name = "quadro";
            this.quadro.Size = new System.Drawing.Size(106, 17);
            this.quadro.TabIndex = 14;
            this.quadro.TabStop = true;
            this.quadro.Text = "y = ax^2 + bx + c";
            this.quadro.UseVisualStyleBackColor = true;
            this.quadro.CheckedChanged += new System.EventHandler(this.quadro_CheckedChanged);
            // 
            // plot1
            // 
            this.plot1.BackColor = System.Drawing.SystemColors.Control;
            this.plot1.Dock = System.Windows.Forms.DockStyle.Right;
            this.plot1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.plot1.Location = new System.Drawing.Point(403, 0);
            this.plot1.Name = "plot1";
            this.plot1.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plot1.Size = new System.Drawing.Size(397, 450);
            this.plot1.TabIndex = 15;
            this.plot1.Text = "plot1";
            this.plot1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plot1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plot1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.quadro);
            this.Controls.Add(this.linear);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.plot1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmGenerateData;
        private System.Windows.Forms.ToolStripMenuItem tsmFromExcel;
        private System.Windows.Forms.ToolStripMenuItem tsmExportExcel;
        private System.Windows.Forms.ToolStripMenuItem tsmClear;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmCalculate;
        private System.Windows.Forms.ToolStripMenuItem tsmMatrixSize;
        private System.Windows.Forms.RadioButton linear;
        private System.Windows.Forms.RadioButton quadro;
        private OxyPlot.WindowsForms.PlotView plot1;
    }
}

