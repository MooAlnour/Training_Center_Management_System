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
using Training_Center_Management_System.Global_Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Training_Center_Management_System.Course
{
    public partial class frmAddEditCourse: Form
    {
        string ErrorMessage = "";
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        //public enum enCourseStatus
        //{
        //    NonActive = 0,
        //    Active = 1,
        //    Completed = 2,
        //    Cancelled = 3
        //};
        //private enCourseStatus _Status;

        int _CourseID;

        CourseBL _Course;

        public frmAddEditCourse()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditCourse(int CourseID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _CourseID = CourseID;
        }
        private void _ResetDefualtValues()
        {

            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Course";
                _Course = new CourseBL();
            }
            else
            {
                lblTitle.Text = "Update Course";
            }

            dtpStartDate.MinDate = DateTime.Today.AddYears(-1);
            dtpStartDate.MaxDate = DateTime.Today.AddYears(1);

            txtCourseTitle.Text = "";
            rbActive.Checked = true;
            nudHours.Value = 0;
            nudPrice.Value = 0;


        }

        private void _LoadData()
        {

            _Course = CourseBL.FindByCourseID(_CourseID);

            if (_Course == null)
            {
                MessageBox.Show("No Course with ID = " + _CourseID, "Course Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            _CourseID = _Course.CourseID;
            lblCourseID.Text = _CourseID.ToString();
            txtCourseTitle.Text = _Course.Title;
            dtpStartDate.Value = _Course.StartDate;
            nudHours.Value = _Course.Hours;
            nudPrice.Value = _Course.Price;

            if (_Course.Status == 0)
                rbNonActive.Checked = true;
            else
                rbActive.Checked = true;
        }

        private void frmAddEditCourse_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCourseTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCourseTitle.Text.Trim()))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtCourseTitle, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCourseTitle, null);
            }

            if (CourseBL.IsCourseExist(txtCourseTitle.Text.Trim()))
            {
               // e.Cancel = true;
                errorProvider1.SetError(txtCourseTitle, " Course Title is used for another Course!");

            }
            else
            {
                errorProvider1.SetError(txtCourseTitle, null);
            }
        }

        private void nudHours_Validating(object sender, CancelEventArgs e)
        {
            if (nudHours.Value <= 0) 
            {
                e.Cancel = true;
                errorProvider1.SetError(nudHours, "Hourse Most be > 0 !");
            }
            else
            {
                errorProvider1.SetError(nudHours, null);
            }
        }

        private void nudPrice_Validating(object sender, CancelEventArgs e)
        {
            if (nudPrice.Value <= 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(nudHours, "Price Most be > 0 !");
            }
            else
            {
                errorProvider1.SetError(nudHours, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _Course.Title = txtCourseTitle.Text.Trim();
            _Course.Hours = (int)nudHours.Value;
            _Course.Price = nudPrice.Value;
            _Course.StartDate = dtpStartDate.Value;

            if (rbNonActive.Checked)
                _Course.Status = CourseBL.enCourseStatus.NonActive;
            else
                _Course.Status = CourseBL.enCourseStatus.Active;

            if (_Course.Save(ref ErrorMessage))
            {
                lblCourseID.Text = _Course.CourseID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Course";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
            }
            else
                MessageBox.Show($"Error: " + ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
