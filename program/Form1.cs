using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using System.Windows.Forms;

namespace MainWindowApp
{
    public partial class Form1 : Form
    {
        private Process processLab0;
        private Process processDichotomyMethod;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (processLab0 == null)
            {
                processLab0 = Process.Start(Application.StartupPath + "//lab0//Year2Sem1Lab0.exe");
            }
            else
            {
                MessageBox.Show("Lab0 уже запущенна");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (processDichotomyMethod == null)
            {
                processDichotomyMethod = Process.Start(Application.StartupPath + "//DichotomyMethod//DichotomyMethod.exe");
            }
            else
            {
                MessageBox.Show("DichotomyMethod уже запущен");
            }
        }
    }
}
