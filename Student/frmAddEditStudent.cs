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
using Training_Center_Management_System.Properties;

namespace Training_Center_Management_System.Student
{
    public partial class frmAddEditStudent: Form
    {
        public delegate void DataBackEventHandler(object sender, int StudentID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _StudentID = -1;

        string ErrorM = "";

        StudentBL _Student;
        public frmAddEditStudent()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;

        }
        public frmAddEditStudent(int StudentID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _StudentID = StudentID;
        }
        private void _ResetDefualtValues()
        {
            
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New Student";
                _Student = new StudentBL();
            }
            else
            {
                lblTitle.Text = "Update Student";
            }
            
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //this will set default country to jordan.

            txtFirstName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";


        }

        private void _LoadData()
        {

            _Student = StudentBL.FindByStudentID(_StudentID);

            if (_Student == null)
            {
                MessageBox.Show("No Person with ID = " + _StudentID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            lblStudentID.Text = _StudentID.ToString();
            txtFirstName.Text = _Student.FullName;
            dtpDateOfBirth.Value = _Student.DataOfBrith;

           
            txtPhone.Text = _Student.Phone;
            txtEmail.Text = _Student.Email;
        }

        private void frmAddEditStudent_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            _Student.FullName = txtFirstName.Text.Trim();
            
            _Student.Email = txtEmail.Text.Trim();
            _Student.Phone = txtPhone.Text.Trim();
            _Student.DataOfBrith = dtpDateOfBirth.Value;

            
            if (_Student.Save(ref ErrorM))
            {
                lblStudentID.Text = _Student.StudentID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Student";
                DataBack?.Invoke(this, _Student.StudentID);

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
            }
            else
                MessageBox.Show($"Error:{ErrorM}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsValidatoin.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            }
            ;
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtPhone, null);
            }

            //Make sure the national number is not used by another person
            if (txtPhone.Text.Trim() != _Student.Phone && StudentBL.IsStudentPhoneExist(txtPhone.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Phone Number is used for another Student!");

            }
            else
            {
                errorProvider1.SetError(txtPhone, null);
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtFirstName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFirstName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFirstName, null);
            }
        }
    }
}
