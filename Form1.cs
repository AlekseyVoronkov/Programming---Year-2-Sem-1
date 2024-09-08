using System;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Year2Sem1Lab0
{
    public partial class Form1 : Form
    {
        private List<Student> students = new List<Student>();

        public Form1()
        {
            InitializeComponent();
            GenerateData();
        }

        double cubeA = 0;
        double sphereR = 0;

        private void textBoxA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textBoxR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void countButton_Click(object sender, EventArgs e)
        {
            if (textBoxA.Text == "")
            {
                textBoxA.Text = "0";
            }

            if (textBoxR.Text == "")
            {
                textBoxR.Text = "0";
            }

            cubeA = Convert.ToDouble(textBoxA.Text, CultureInfo.InvariantCulture);
            sphereR = Convert.ToDouble(textBoxR.Text, CultureInfo.InvariantCulture);

            cubeVolume.Text = Convert.ToString(Math.Pow(cubeA, 3));
            double cubeV = Convert.ToDouble(cubeVolume.Text);

            sphereVolume.Text = Convert.ToString( (4 / 3 * Math.PI * Math.Pow(sphereR, 3)) );
            double sphereV = Convert.ToDouble(sphereVolume.Text);

            vastedMaterial.Text = Convert.ToString( (1 - sphereV / cubeV) * 100 );
        }


        private void GenerateData()
        {
            students.Add(new Student { LastName = "Smith", FirstName = "John", Group = "A1", Grade = 90 });
            students.Add(new Student { LastName = "Doe", FirstName = "Jane", Group = "A1", Grade = 85 });
            students.Add(new Student { LastName = "Brown", FirstName = "Emily", Group = "B2", Grade = 90 });
            students.Add(new Student { LastName = "Petrenko", FirstName = "Egor", Group = "A1", Grade = 90 });
            students.Add(new Student { LastName = "Voronkov", FirstName = "Aleksey", Group = "A1", Grade = 1 });
            students.Add(new Student { LastName = "Adolf", FirstName = "Hitler", Group = "B2", Grade = 90 });
            SaveDataToJson();
        }

        private void SaveDataToJson()
        {
            var jsonData = JsonConvert.SerializeObject(students);
            File.WriteAllText(Application.StartupPath + "\\students.json", jsonData);
        }

        private void LoadDataFromJson()
        {
            var jsonData = File.ReadAllText(Application.StartupPath + "\\students.json");
            students = JsonConvert.DeserializeObject<List<Student>>(jsonData);
        }

        private void textBoxGrade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void displayStudentsButton_Click(object sender, EventArgs e)
        {
            if (textBoxGrade.Text == "")
            {
                textBoxGrade.Text = "0";
            }

            if (textBoxGroup.Text == "")
            {
                textBoxGroup.Text = "0";
            }

            string group = textBoxGroup.Text;
            int grade = Convert.ToInt32(textBoxGrade.Text);
            var filteredStudents = students.Where(s => s.Group == group && s.Grade == grade).ToList();

            studentsList.Clear();

            foreach (var student in filteredStudents)
            {
                studentsList.AppendText($"{student.FirstName} {student.LastName} - Group: {student.Group}, Grade: {student.Grade}\r\n");
            }

            if (studentsList.Text.Length == 0) 
            {
                studentsList.AppendText("По заданным данным студентов не найдено");
            }

        }
    }

    [Serializable]
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Group { get; set; }
        public int Grade { get; set; }
    }
}
