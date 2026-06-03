using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TC_Bussines;

namespace Training_Center_Management_System.Student.Control
{
    public partial class ctrStudentInfo: UserControl
    {
        private StudentBL _Student;

        private int _StudentID = -1;

        public int StudentID
        {
            get { return _StudentID; }
        }

        public StudentBL SelectedStudentInfo
        {
            get { return _Student; }
        }
        public ctrStudentInfo()
        {
            InitializeComponent();
        }
        public void LoadStudentInfo(int StudentID)
        {
            _Student = StudentBL.FindByStudentID(StudentID);
            if (_Student == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with StudentID = " + StudentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void ResetPersonInfo()
        {
            lblStudentID.Text = "[????]";
            lblFullName.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblRegisteredDate.Text = "[????]";
        }

        public void LoadStudentInfo(string StudentName)
        {
            _Student = StudentBL.FindByFullName(StudentName);
            if (_Student == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Student with StudentName = " + StudentName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        private void _FillPersonInfo()
        {
            _StudentID = _Student.StudentID;
            lblStudentID.Text = _Student.StudentID.ToString();
            lblFullName.Text = _Student.FullName;
            lblEmail.Text = _Student.Email;
            lblPhone.Text = _Student.Phone;
            lblDateOfBirth.Text = _Student.DataOfBrith.ToShortDateString();
            lblRegisteredDate.Text = _Student.RegistrationDate.ToShortDateString();
            
        }
    }
}
