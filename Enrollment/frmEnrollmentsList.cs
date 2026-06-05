using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TC_Bussines;

namespace Training_Center_Management_System.Enrollment
{
    public partial class frmEnrollmentsList : Form
    {
        string ErrorMasseage = "";
        private DataTable _dtEnrollment;
        public frmEnrollmentsList()
        {
            InitializeComponent();
        }

        private void frmEnrollmentsList_Load(object sender, EventArgs e)
        {
            _dtEnrollment = EnrollmentBL.GetAllEnrollments();
            cbFilterBy.Text = "None";
            dgvEnrollments.DataSource = _dtEnrollment;
            lblRecordsCount.Text = dgvEnrollments.Rows.Count.ToString();

            if (dgvEnrollments.Rows.Count > 0)
            {
                dgvEnrollments.Columns[0].HeaderText = "EnrollmentID";
                dgvEnrollments.Columns[0].Width = 80;

                dgvEnrollments.Columns[1].HeaderText = "StudentID";
                dgvEnrollments.Columns[1].Width = 100;

                dgvEnrollments.Columns[2].HeaderText = "CourseID";
                dgvEnrollments.Columns[2].Width = 180;

                dgvEnrollments.Columns[3].HeaderText = "Enrollment Date";
                dgvEnrollments.Columns[3].Width = 120;

                dgvEnrollments.Columns[4].HeaderText = "Status";
                dgvEnrollments.Columns[4].Width = 90;

                dgvEnrollments.Columns[5].HeaderText = "Grade";
                dgvEnrollments.Columns[5].Width = 100;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilterBy.Text != "None");

            if (cbFilterBy.Text == "None")
            {
                txtSearch.Enabled = false;
            }
            else
                txtSearch.Enabled = true;

            txtSearch.Text = "";
            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            //            Enrollment ID
            //Course ID
            //Student ID
            //Grade

            switch (cbFilterBy.Text)
            {
                case "Course ID":
                    FilterColumn = "CourseID";
                    break;
                case "Enrollment ID":
                    FilterColumn = "EnrollmentID";
                    break;
                case "Student ID":
                    FilterColumn = "StudentID";
                    break;
                case "Grade":
                    FilterColumn = "Grade";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtEnrollment.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvEnrollments.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "")
                //in this case we deal with numbers not string.
                _dtEnrollment.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtEnrollment.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

            lblRecordsCount.Text = _dtEnrollment.Rows.Count.ToString();

        }

        private void btnAddEnrollment_Click(object sender, EventArgs e)
        {
            frmEnrollmentAddEdit enrollmentAddEdit = new frmEnrollmentAddEdit();
            enrollmentAddEdit.ShowDialog();
            frmEnrollmentsList_Load(null, null);
        }

        private void btnEditEnrollment_Click(object sender, EventArgs e)
        {
            int EnrollmentID = (int)dgvEnrollments.CurrentRow.Cells[0].Value; ;
            frmEnrollmentAddEdit enrollmentAddEdit = new frmEnrollmentAddEdit(EnrollmentID);
            enrollmentAddEdit.ShowDialog();
            frmEnrollmentsList_Load(null, null);
        }

        private void btnDeleteEnrollment_Click(object sender, EventArgs e)
        {
            int EnrollmentID = (int)dgvEnrollments.CurrentRow.Cells[0].Value; ;
            DialogResult Result = MessageBox.Show(
                $"Are you sure you want to delete Enrollment ID  = " + EnrollmentID,
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (Result == DialogResult.Yes)
            {
                if (EnrollmentBL.DeleteEnrollment(EnrollmentID))
                {
                    MessageBox.Show(
                        "EnrollmentID has been deleted successfully.",
                        "Deleted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    frmEnrollmentsList_Load(null, null);
                }
                else
                {
                    MessageBox.Show(
                        "Enrollment was not deleted because there is related data.",
                        "Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
