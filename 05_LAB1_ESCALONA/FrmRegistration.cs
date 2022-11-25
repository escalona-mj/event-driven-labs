using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05_LAB1_ESCALONA
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            FrmFileName Form = new FrmFileName();
            Form.ShowDialog();

            string getStudentNo = txtStudentNo.Text;
            string getFirstName = txtFirstName.Text;
            string getLastName = txtLastName.Text;
            string getMiddleInitial= txtMiddleInitial.Text;
            string getProgram = cbProgram.Text;
            string getAge = txtAge.Text;
            string getGender = cbGender.Text;
            string getContactNo = txtContactNo.Text;
            string getBirthday = dtpBirthday.Text;

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, FrmFileName.SetFileName)))
            {
                outputFile.WriteLine("Student No: " + getStudentNo);
                outputFile.WriteLine("Full Name: " + getLastName + ", " + getFirstName + " " + getMiddleInitial + ".");
                outputFile.WriteLine("Program: " + getProgram);
                outputFile.WriteLine("Gender: " + getGender);
                outputFile.WriteLine("Age: " + getAge);
                outputFile.WriteLine("Birthday: " + getBirthday);
                outputFile.WriteLine("Contact No: " + getContactNo);
            }
        }
    }
}
