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

namespace Training_Center_Management_System.Payment
{
    public partial class frmAddEditPayment: Form
    {
        private int _PaymentID = -1;

        private PaymentBL _Payment;

        private EnrollmentBL _Enrollment;

        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;

        string ErrorM = "";
        private int _StudentID;

        public frmAddEditPayment()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditPayment(int PaymentID)
        {
            InitializeComponent();
            _PaymentID = PaymentID;
            _Mode = enMode.Update;
        }

        private void frmAddEditPayment_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void _LoadData()
        {
            btnSearch.Enabled = false;
            cbCourse.Enabled = false;

            _Payment = PaymentBL.FindByPaymentID(_PaymentID);

            if (_Payment == null)
            {
                MessageBox.Show(
                    "Payment Not Found",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                this.Close();
                return;
            }

            // Payment Info
            lblPaymentID.Text = _Payment.PaymentID.ToString();

            dtpPaymentDate.Value = _Payment.PaymentDate;

            nudAmountPaid.Value =
                Convert.ToDecimal(_Payment.Amount);

            txtNotes.Text = _Payment.Notes;

            cmbPaymentMethod.SelectedIndex =
                (_Payment.Method == "Cash") ? 0 : 1;
            lblTotalFee.Text = _Payment.Amount.ToString("N0") + "$";

            // Enrollment
            _Enrollment =
                EnrollmentBL.FindByEnrollmentID(_Payment.EnrollmentID);

            if (_Enrollment == null)
            {
                MessageBox.Show(
                    "Enrollment Not Found",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            _StudentID = _Enrollment.StudentID;
            _FillCourseInComoboBox();

            // Student
            FillStudentInfo();
        }

        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Payment";
                _Payment = new PaymentBL();
            }
            else
            {
                lblTitle.Text = "Update Payment";
            }
            dtpPaymentDate.MaxDate = DateTime.Today;
            cmbPaymentMethod.SelectedIndex = 1;
            cbCourse.Visible = false;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmFindStudent frmShow = new frmFindStudent();
            frmShow.DataBack += FrmShow_StudentID;
            frmShow.ShowDialog();
            FillStudentInfo();
        }

        private void FrmShow_StudentID(object sender, int StudentID)
        {
            _StudentID = StudentID;
        }

        private void FillStudentInfo()
        {
            StudentBL student = StudentBL.FindByStudentID(_StudentID);

            if (student == null)
                return;

            lblStudentID.Text =
                student.StudentID.ToString();

            lblStudentName.Text =
                student.FullName;

            lblStudentEmail.Text =
                student.Email;

            if (_Mode == enMode.AddNew)
            {
                _Enrollment =
                    EnrollmentBL.FindByStudentID(_StudentID);
            }

            _FillCourseInComoboBox();

            cbCourse.Visible = true;

        }

        private void _FillCourseInComoboBox()
        {
            cbCourse.Items.Clear();

            DataTable dtCourse = CourseBL.GetCourseByEnrollment(_StudentID);

            foreach (DataRow row in dtCourse.Rows)
            {
                cbCourse.Items.Add(row["Title"]);
            }
            cbCourse.SelectedIndex = 0;
        }

        private void cbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            CourseBL Course = CourseBL.FindByTitle(cbCourse.Text);
            decimal CoursePrice = Course.Price;
            lblTotalFee.Text = CoursePrice.ToString("N0") + "$";
            

            _Enrollment = EnrollmentBL.FindByStudentAndCourse(_StudentID,Course.CourseID);
            decimal TotalPaid = PaymentBL.GetTotalPaid(_Enrollment.EnrollmentID);
            decimal Remaining = CoursePrice - TotalPaid;
            lblTotalPaid.Text = TotalPaid.ToString("N0") + "$";

            lblRemaining.Text = Remaining.ToString("N0") + "$";

            if (Remaining == 0)
            {
                btnSave.Enabled = false;
                MessageBox.Show("You can,t Paid more then Coures Price");
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

            if (_StudentID == -1)
            {
                MessageBox.Show("Select Student Frist", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbCourse.SelectedIndex == -1)
            {
                MessageBox.Show("Select Course Frist", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal totalPaid = PaymentBL.GetTotalPaid(_Enrollment.EnrollmentID);

            decimal remaining =
                _Enrollment.CourseInfo.Price - totalPaid;

            // لو تعديل دفعة لازم نرجع قيمة الدفعة الحالية
            if (_Mode == enMode.Update)
            {
                remaining += _Payment.Amount;
            }

            if (remaining <= 0)
            {
                MessageBox.Show("Course price already completed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (nudAmountPaid.Value > remaining)
            {
                MessageBox.Show("You can't pay more than remaining amount","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }


            _Payment.EnrollmentID = _Enrollment.EnrollmentID;
            _Payment.PaymentDate = dtpPaymentDate.Value;
            _Payment.Amount = nudAmountPaid.Value;
            _Payment.Method = cmbPaymentMethod.Text; ;
            _Payment.Notes = txtNotes.Text;

            if (_Payment.Save(ref ErrorM))
            {
                lblPaymentID.Text = _Payment.PaymentID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Payment";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSearch.Enabled = false;
                btnSave.Enabled = false;
                cbCourse.Enabled = false;

            }
            else
                MessageBox.Show($"Error: " + ErrorM, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void nudAmountPaid_Validating(object sender, CancelEventArgs e)
        {
            if (nudAmountPaid.Value <= 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(nudAmountPaid, "Amount Most be > 0 !");
            }
            else
            {
                errorProvider1.SetError(nudAmountPaid, null);
            }
        }

        public static decimal GetRemainingBalance(int EnrollmentID)
        {
            EnrollmentBL enrollment =
                EnrollmentBL.FindByEnrollmentID(EnrollmentID);

            decimal TotalFee =
                CourseBL
                .FindByCourseID(enrollment.CourseID)
                .Price;

            decimal TotalPaid =
                PaymentBL
                .GetTotalPaid(EnrollmentID);

            return TotalFee - TotalPaid;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void nudAmountPaid_ValueChanged(object sender, EventArgs e)
        {
            //if (_Enrollment != null)
            //{
            //    lblTotalPaid.Text =(remaining - nudAmountPaid.Value).ToString("N0");
            //}
        }
    }
}
