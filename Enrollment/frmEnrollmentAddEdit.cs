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
using Training_Center_Management_System.Student;

namespace Training_Center_Management_System.Enrollment
{
    public partial class frmEnrollmentAddEdit: Form
    {
        private int _StudentID = -1;
        StudentBL _Student;

        int _EnrollmentID = -1;
        EnrollmentBL _Enrollment;

        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;

        string ErrorM = "";

        public frmEnrollmentAddEdit()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmEnrollmentAddEdit(int EnrollmentID)
        {
            InitializeComponent();
            _EnrollmentID = EnrollmentID;
            _Mode = enMode.Update;
        }
        private void FillStudentInfo()
        {
            _Student = StudentBL.FindByStudentID(_StudentID);
            lblStudentID.Text = _StudentID.ToString();
            lblStudentName.Text = _Student.FullName;
            lblStudentEmail.Text = _Student.Email;
        }
        private void _ResetDefualtValues()
        {
            _FillCourseInComoboBox();
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Student";
                _Student = new StudentBL();
            }
            else
            {
                lblTitle.Text = "Update Student";
            }

            dtpStartDate.MaxDate = DateTime.Now.AddYears(-1);
            dtpStartDate.Value = dtpStartDate.MaxDate;

            //should not allow adding age more than 100 years
            dtpStartDate.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to jordan.

        }

        private void _FillCourseInComoboBox()
        {
            DataTable dtCourse = CourseBL.GetAllCourses();

            foreach (DataRow row in dtCourse.Rows)
            {
                cbCourse.Items.Add(row["Title"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmFindStudent frmShow = new frmFindStudent();
            frmShow.DataBack += FrmShow_StudentID;
            frmShow.ShowDialog();
            FillStudentInfo();
        }

        private void FrmShow_StudentID(object sender, int StudentID)
        {
            MessageBox.Show(StudentID.ToString());
            _StudentID = StudentID;
        }

        private void frmEnrollmentAddEdit_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void _LoadData()
        {
            _Enrollment = EnrollmentBL.FindByEnrollmentID(_EnrollmentID);

            if (_Enrollment == null)
            {
                MessageBox.Show("No Enrollment with ID = " + _EnrollmentID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            _Student = StudentBL.FindByStudentID(_Enrollment.StudentID);
            //the following code will not be executed if the person was not found
            lblStudentID.Text = _StudentID.ToString();
            lblStudentName.Text = _Student.FullName;
            lblStudentEmail.Text = _Student.Email;
            cbCourse.SelectedIndex = cbCourse.FindString(_Enrollment.CourseInfo.Title);
            dtpStartDate.Value = _Enrollment.EnrollmentDate;
            nudGrade.Value = _Enrollment.Grade;
            //cbStatus.SelectedIndex=cbStatus.FindString()

        }
    }
}
