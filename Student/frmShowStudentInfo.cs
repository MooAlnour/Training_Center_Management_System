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
        private DataTable _dtPaymentHistory;
        private DataTable _dtEnrollmentHistory;

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
            lblRegisteredDate.Text = _Student.RegistrationDate.ToShortDateString();
            _dtEnrollmentHistory = _Student.GetStudentEnrollment();
            _dtPaymentHistory = _Student.GetStudentPayment();

            dgvEnrollments.DataSource = _dtEnrollmentHistory;
            dgvPayments.DataSource = _dtPaymentHistory;
            if (dgvPayments.Rows.Count>0)
            {
                dgvPayments.Columns[0].HeaderText = "Amount";
                dgvPayments.Columns[0].Width = 110;

                dgvPayments.Columns[1].HeaderText = "Method";
                dgvPayments.Columns[1].Width = 110;

                dgvPayments.Columns[2].HeaderText = "Payment Date";
                dgvPayments.Columns[2].Width = 110;

            }

            if (dgvEnrollments.Rows.Count > 0)
            {
                dgvEnrollments.Columns[0].HeaderText = "CourseID";
                dgvEnrollments.Columns[0].Width = 110;

                dgvEnrollments.Columns[1].HeaderText = "Status";
                dgvEnrollments.Columns[1].Width = 110;

                dgvEnrollments.Columns[2].HeaderText = "Grade";
                dgvEnrollments.Columns[2].Width = 110;

                dgvEnrollments.Columns[2].HeaderText = "EnrollmentDate";
                dgvEnrollments.Columns[2].Width = 110;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditStudent_Click(object sender, EventArgs e)
        {
            frmAddEditStudent frmAdd = new frmAddEditStudent(_StudentID);
            frmAdd.ShowDialog();
        }
    }
}
