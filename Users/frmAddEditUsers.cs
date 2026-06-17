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

namespace Training_Center_Management_System.Users
{
    public partial class frmAddEditUsers: Form
    {
        UserBL _User;
        int _UserID = -1;
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        string ErrorM = "";
        public frmAddEditUsers(int userID)
        {
            InitializeComponent();
            _UserID = userID;
            _Mode = enMode.Update;
        }
        public frmAddEditUsers()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        private void _LoadData()
        {

            _User = UserBL.FindByUserID(_UserID);

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found
            lblUserID.Text = _UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtSecurityQuestion.Text = _User.SecurityQuestion;


            if (_User.IsActive)
                cbActive.Checked = true;
            else
                cbActive.Checked = false;

            if (_User.Role == "Admin")
                cmbRole.SelectedIndex = 0;
            else
                cmbRole.SelectedIndex = 1;
        }

        private void frmAddEditUsers_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblTitle.Text = "Add New User";
                _User = new UserBL();
            }
            else
            {
                lblTitle.Text = "Update User";
            }

            txtConfirmPassword.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            cmbRole.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _User.UserName = txtUserName.Text;
            _User.PasswordHash = txtPassword.Text;
            _User.Role = cmbRole.SelectedItem.ToString();
            _User.IsActive = cbActive.Checked;
            _User.SecurityQuestion = txtSecurityQuestion.Text;
            _User.SecurityAnswerHash = txtSecurityAnswerHash.Text;

            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);


                // Trigger the event to send data back to the caller form.
            }
            else
                MessageBox.Show($"Error:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtUserName, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
        }

        private void txtSecurityQuestion_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSecurityQuestion.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtSecurityQuestion, "Security Question cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtSecurityQuestion, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
            ;
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
            ;
        }

        private void txtSecurityAnswerHash_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSecurityAnswerHash.Text.Trim()))
            {
                //e.Cancel = true;
                errorProvider1.SetError(txtSecurityAnswerHash, "Security Answer  cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtSecurityAnswerHash, null);
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0' && txtConfirmPassword.PasswordChar == '\0')
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }
            else
            {
                // اظهار الباسورد
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
        }
    }
}
