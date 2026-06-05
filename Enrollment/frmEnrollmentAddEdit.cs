using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TC_Bussines;
using Training_Center_Management_System.Course;
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

            if (_Student==null)
            {
                return;
            }
            lblStudentID.Text = _StudentID.ToString();
            lblStudentName.Text = _Student.FullName;
            lblStudentEmail.Text = _Student.Email;
        }

        private void _ResetDefualtValues()
        {
            _FillCourseInComoboBox();
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Enrollment";
                _Enrollment= new EnrollmentBL();
            }
            else
            {
                lblTitle.Text = "Update Enrollment";
            }
            cbStatus.SelectedIndex = 0;
            nudGrade.Visible = (cbStatus.SelectedIndex == 1);
            label3.Visible= (cbStatus.SelectedIndex == 1);
            dtpStartDate.MinDate = DateTime.Today.AddMonths(-1);
            dtpStartDate.MaxDate = DateTime.Today.AddYears(1);

        }

        private void _FillCourseInComoboBox()
        {
            DataTable dtCourse = CourseBL.GetAllCourses();

            foreach (DataRow row in dtCourse.Rows)
            {
                cbCourse.Items.Add(row["Title"]);
            }
            cbCourse.SelectedIndex = 0;
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
           // MessageBox.Show(StudentID.ToString());
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
            lblTotalFee.Text = _Enrollment.CourseInfo.Price.ToString()+"$";
            //cbStatus.SelectedIndex=cbStatus.FindString()

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (_StudentID==-1)
            {
                MessageBox.Show("Select Student Frist", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbCourse.SelectedIndex == -1)
            {
                MessageBox.Show("Select Course Frist", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int CourseID = CourseBL.FindByTitle(cbCourse.Text).CourseID;
            _Enrollment.StudentID = _StudentID;
            _Enrollment.CourseID = CourseID;
            _Enrollment.EnrollmentDate = dtpStartDate.Value;

            if (cbStatus.Text == "Active")
                _Enrollment.Status = EnrollmentBL.enEnrollmentStatus.Active;
            else if(cbStatus.Text == "Completed")
                _Enrollment.Status = EnrollmentBL.enEnrollmentStatus.Completed;
            else
                _Enrollment.Status = EnrollmentBL.enEnrollmentStatus.Dropped;

            _Enrollment.Grade = nudGrade.Value;
            if (_Enrollment.Save(ref ErrorM))
            {
                lblEnrollmentID.Text = _Enrollment.EnrollmentID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Enrollment";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
            }
            else
                MessageBox.Show($"Error: " + ErrorM, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void nudGrade_Validating(object sender, CancelEventArgs e)
        {
            if (cbStatus.SelectedIndex==1)
            {
                if (nudGrade.Value <= 0)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(nudGrade, "Grade Most be > 0 !");
                }
                else
                {
                    errorProvider1.SetError(nudGrade, null);
                }
            }

        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.SelectedIndex==1)
            {
                label3.Visible = true;
                nudGrade.Visible = true;
            }
            else
            {
                label3.Visible = false;
                nudGrade.Visible = false;
            }

        }

        private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            CourseBL Course = CourseBL.FindByTitle(cbCourse.Text);
            lblTotalFee.Text = Course.Price.ToString("N2")+"$";
        }
    }
}
