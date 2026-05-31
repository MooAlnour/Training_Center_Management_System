using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TC_Bussines;

namespace Training_Center_Management_System.Student
{
    public partial class frmShowStudentInfo: Form
    {
        private StudentBL _Student;

        private int _StudentID = -1;

        public frmShowStudentInfo(int StudentID)
        {
            InitializeComponent();
            _StudentID = StudentID;
        }

        private void lblPhone_Click(object sender, EventArgs e)
        {

        }

        private void frmShowStudentInfo_Load(object sender, EventArgs e)
        {
            _Student = StudentBL.FindByStudentID(_StudentID);
            if (_Student == null)
            {
                MessageBox.Show("No Student with StudentID = " + _StudentID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillStudentInfo();
        }


        private void _FillStudentInfo()
        {
            _StudentID = _Student.StudentID;
            lblStudentID.Text = _Student.StudentID.ToString();
            lblFullName.Text = _Student.FullName;
            lblEmail.Text = _Student.Email;
            lblPhone.Text = _Student.Phone;
            lblDateOfBirth.Text = _Student.DataOfBrith.ToShortDateString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
