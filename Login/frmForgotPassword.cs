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
    public partial class frmForgotPassword: Form
    {
        private int _UserID;
        private UserBL _User;
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

            lblSecurityQuestion.Enabled = true;
            lblSecurityQuestion.Text = user.SecurityQuestion;
            label2.Enabled = true;
            txtSecurityAnswer.Enabled = true;
            txtchekAnswer.Enabled = true;

        }

        private void txtchekAnswer_Click_1(object sender, EventArgs e)
        {
            if (!UserBL.IsSecurityQuestionRight(_UserID, txtSecurityAnswer.Text.Trim()))
            {
                MessageBox.Show("Invalid Answer.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnNext.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            tpLoginInfo.Enabled = true;

        }

        private void frmForgotPassword_Load(object sender, EventArgs e)
        {
            lblSecurityQuestion.Visible = false;
            lblSecurityQuestion.Visible = false;
            label2.Enabled = false;
            txtSecurityAnswer.Enabled = false;
            txtchekAnswer.Enabled = false;
            tpLoginInfo.Enabled = false;

        }
    }
}
