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

namespace Training_Center_Management_System.Payment
{
    public partial class frmPaymentList: Form
    {
        private DataTable _dtPayment;
        string ErrorMessage = "";
        public frmPaymentList()
        {
            InitializeComponent();
        }

        private void frmPaymentList_Load(object sender, EventArgs e)
        {
            _dtPayment = PaymentBL.GetAllPayments();
            cbFilterBy.Text = "None";
            dgvPayment.DataSource = _dtPayment;
            lblRecordsCount.Text = dgvPayment.Rows.Count.ToString();
            if (dgvPayment.Rows.Count>0)
            {
                dgvPayment.Columns[0].HeaderText = "Payment ID";
                dgvPayment.Columns[0].Width = 100;
               
                dgvPayment.Columns[1].HeaderText = "Enrollment ID";
                dgvPayment.Columns[1].Width = 100;
                
                dgvPayment.Columns[2].HeaderText = "Payment Date";
                dgvPayment.Columns[2].Width = 100;

                dgvPayment.Columns[3].HeaderText = "Amount";
                dgvPayment.Columns[3].Width = 100;

                dgvPayment.Columns[4].HeaderText = "Method";
                dgvPayment.Columns[4].Width = 100;

                dgvPayment.Columns[5].HeaderText = "Note";
                dgvPayment.Columns[5].Width = 350;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int PaymentID = (int)dgvPayment.CurrentRow.Cells[0].Value;
            DialogResult Result = MessageBox.Show(
                $"Are you sure you want to delete This Payment = " + PaymentID.ToString(),
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (Result == DialogResult.Yes)
            {
                if (PaymentBL.DeletePayment(PaymentID,ref ErrorMessage))
                {
                    MessageBox.Show(
                        "Payment has been deleted successfully.",
                        "Deleted",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    frmPaymentList_Load(null, null);
                }
                else
                {
                    MessageBox.Show(
                        "Error ." + ErrorMessage,
                        "Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditPayment frmAddEditPayment = new frmAddEditPayment();
            frmAddEditPayment.ShowDialog();
            frmPaymentList_Load(null, null);

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvPayment.CurrentRow.Cells[0].Value;
            frmAddEditPayment frmAddEdit = new frmAddEditPayment(ID);
            frmAddEdit.ShowDialog();
            frmPaymentList_Load(null, null);
        }

        //محتاج مراجعة 
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
                _dtPayment.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPayment.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "")
                //in this case we deal with numbers not string.
                _dtPayment.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtPayment.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

            lblRecordsCount.Text = _dtPayment.Rows.Count.ToString();
                
        }
    }
}
