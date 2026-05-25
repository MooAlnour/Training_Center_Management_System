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

namespace Training_Center_Management_System.Login
{
    public partial class frmForgotPassword : Form
    {
        private enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode = enMode.AddNew;

        private int _UserID;

        private UserBL _User;
        public frmForgotPassword()
        {
            InitializeComponent();

        }

        private void btnFind_Click_1(object sender, EventArgs e)
        {
            UserBL user = UserBL.FindByUserName(txtUsername.Text.Trim());
            if (user == null)
            {
                MessageBox.Show("Invalid Username.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _UserID = user.UserID;
            _User = user;
            lblSecurityQuestion.Enabled = true;
            lblSQ.Enabled = true;
            label2.Enabled = true;
            txtSecurityAnswer.Enabled = true;
            lblSecurityQuestion.Text = user.SecurityQuestion;
            btnNext.Enabled = true;
        }

        private void frmForgotPassword_Load(object sender, EventArgs e)
        {
            lblSecurityQuestion.Enabled = false;
            lblSecurityQuestion.Enabled = false;
            label2.Enabled = false;
            txtSecurityAnswer.Enabled = false;
            tpLoginInfo.Enabled = false;
            btnNext.Enabled = false;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _Mode = enMode.Update;

            _User.UserName = lblUserName.Text.Trim();

            string NewPassword = txtPassword.Text.Trim();

            if (_User.ChangePassword2(_UserID,NewPassword))
            {
                lblUserID.Text = _User.UserID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblTitle.Text = "Update Password";
                this.Text = "Update Password ";

                MessageBox.Show("Password Update Successfully.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Error: Password Is not Update Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
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

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                errorProvider1.SetError(txtConfirmPassword,
                    "Passwords do not match");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, "");
            }

        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (!UserBL.IsSecurityQuestionRight(_UserID, txtSecurityAnswer.Text.Trim()))
            {
                MessageBox.Show("Invalid Answer.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnSave.Enabled = true;
            tpLoginInfo.Enabled = true;
            tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName;
            return;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }
    }
}
