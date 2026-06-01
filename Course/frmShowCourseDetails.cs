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

namespace Training_Center_Management_System.Course
{
    public partial class frmShowCourseDetails: Form
    {
        private CourseBL _Course;
        private DataTable _dtEnrollmentStudents;
        private int _CourseID = -1;
        public enum enCourseStatus
        {
            NonActive = 0,
            Active = 1,
            Completed = 2,
            Cancelled = 3
        };
        public frmShowCourseDetails(int courseID)
        {
            InitializeComponent();
            _CourseID = courseID;
        }

        private void dgvEnrolledStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmShowCourseDetails_Load(object sender, EventArgs e)
        {
            _Course= CourseBL.FindByCourseID(_CourseID);
            if (_Course == null)
            {
                MessageBox.Show("No Course with CourseID = " + _CourseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillStudentInfo();
        }

        private void _FillStudentInfo()
        {
            lblCourseID.Text = _Course.CourseID.ToString();
            lblTitle.Text = _Course.Title;
            lblHours.Text = _Course.Hours.ToString();
            lblPrice.Text = _Course.Price.ToString()+"$";
            lblStartDate.Text = _Course.StartDate.ToShortDateString();

            lblStatus.Text = ((CourseBL.enCourseStatus)_Course.Status).ToString();

            _dtEnrollmentStudents = _Course.GetAllStudentEnrollment();
            dgvEnrolledStudents.DataSource = _dtEnrollmentStudents;
            
            if (dgvEnrolledStudents.Rows.Count > 0)
            {
                dgvEnrolledStudents.Columns[0].HeaderText = "Student Name";
                dgvEnrolledStudents.Columns[0].Width = 110;

                dgvEnrolledStudents.Columns[1].HeaderText = "Status";
                dgvEnrolledStudents.Columns[1].Width = 110;

                dgvEnrolledStudents.Columns[2].HeaderText = "Grade";
                dgvEnrolledStudents.Columns[2].Width = 110;

                dgvEnrolledStudents.Columns[2].HeaderText = "Enrollment Date";
                dgvEnrolledStudents.Columns[2].Width = 110;
            }
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            frmAddEditCourse frmAdd = new frmAddEditCourse(_CourseID);
            frmAdd.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
