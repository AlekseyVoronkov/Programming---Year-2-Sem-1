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
            this.clbMethods = new System.Windows.Forms.CheckedListBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(411, 390);
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
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
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
            // clbMethods
            // 
            this.clbMethods.CheckOnClick = true;
            this.clbMethods.FormattingEnabled = true;
            this.clbMethods.Items.AddRange(new object[] {
            "Метод Жордана Гаусса",
            "Метод Крамера",
            "Метод Гаусса"});
            this.clbMethods.Location = new System.Drawing.Point(639, 48);
            this.clbMethods.Name = "clbMethods";
            this.clbMethods.Size = new System.Drawing.Size(149, 49);
            this.clbMethods.TabIndex = 12;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.ColumnHeadersVisible = false;
            this.dataGridView2.Location = new System.Drawing.Point(429, 48);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(204, 390);
            this.dataGridView2.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.clbMethods);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
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
        private System.Windows.Forms.CheckedListBox clbMethods;
        private System.Windows.Forms.ToolStripMenuItem tsmMatrixSize;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}

