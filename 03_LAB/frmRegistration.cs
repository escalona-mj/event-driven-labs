using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_LAB_EXERCISE_ESCALONA
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo, _StudentNo;
        public frmRegistration()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management"
            };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /////return methods 
        public long StudentNumber(string studNum)
        {

            if (Regex.IsMatch(studNum, @"^[0-9]+$"))
            {
                _StudentNo = long.Parse(studNum);
            }
            else
            {
                throw new FormatException("No alphabetical letters are allowed in Student No. field.");
            }
            
            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }
            else
            {
                throw new FormatException("Please enter an 11-numerical valid number.");
            }
            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-z A-Z]+$") && Regex.IsMatch(FirstName, @"^[a-z A-Z]+$") && Regex.IsMatch(MiddleInitial, @"^[a-z A-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }
            else
            {
               throw new FormatException("Please only input letters in the Name field.");
            }
            return _FullName;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirtday.Value.ToString("yyyy-MM-dd");

                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
                /*txtAge.Clear();
                txtContactNo.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtMiddleInitial.Clear();
                txtStudentNo.Clear();
                cbPrograms.SelectedIndex = -1;
                cbGender.SelectedIndex = -1;*/
            }
            
            catch (FormatException FwE)
            {
                MessageBox.Show(FwE.Message);
            }


        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,2}$"))
            {
                _Age = Int32.Parse(age);
            }
            else
            {
               throw new FormatException("Please enter a vaild age.");
            }
            return _Age;
        }
    }
}
