using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TC_Bussines;

namespace Training_Center_Management_System.Student
{
    public partial class ucStudent: UserControl
    {
        private DataTable _dtStudent;
        public ucStudent()
        {
            InitializeComponent();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucStudent_Load(object sender, EventArgs e)
        {
            _dtStudent = StudentBL.GetAllStudents();
            cbFilterBy.Text = "None";
            DGVStudents.DataSource = _dtStudent;
            lblRecordsCount.Text = DGVStudents.Rows.Count.ToString();

            if (DGVStudents.Rows.Count>0)
            {
                DGVStudents.Columns[0].HeaderText = "Student ID";
                DGVStudents.Columns[0].Width = 80;

                DGVStudents.Columns[1].HeaderText = "Full Name";
                DGVStudents.Columns[1].Width = 200;

                DGVStudents.Columns[2].HeaderText = "Phone";
                DGVStudents.Columns[2].Width = 120;

                DGVStudents.Columns[3].HeaderText = "Email";
                DGVStudents.Columns[3].Width = 120;

                DGVStudents.Columns[4].HeaderText = "Date of Birth";
                DGVStudents.Columns[4].Width = 120;

                DGVStudents.Columns[5].HeaderText = "Registation Date";
                DGVStudents.Columns[5].Width = 120;

            }
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            frmAddEditStudent frmAdd = new frmAddEditStudent();
            frmAdd.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int StudentID = (int)DGVStudents.CurrentRow.Cells[0].Value;

            MessageBox.Show($"Are you sare you want to delete this {StudentID}", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (StudentBL.DeleteStudent(StudentID))
            {
                MessageBox.Show("Student has been deleted successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ucStudent_Load(null, null);
            }

            else
                MessageBox.Show("Student is not delted due to data connected to it.", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);



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
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Student ID":
                    FilterColumn = "StudentID";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "Student Name":
                    FilterColumn = "FullName";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtStudent.DefaultView.RowFilter = "";
                lblRecordsCount.Text = DGVStudents.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "FullName" && FilterColumn != "Email" && FilterColumn != "Phone")
                //in this case we deal with numbers not string.
                _dtStudent.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtStudent.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

            lblRecordsCount.Text = _dtStudent.Rows.Count.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int StudentID = (int)DGVStudents.CurrentRow.Cells[0].Value;

            frmAddEditStudent frmAdd = new frmAddEditStudent(StudentID);
            frmAdd.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            int StudentID = (int)DGVStudents.CurrentRow.Cells[0].Value;
            frmShowStudentInfo frmShow = new frmShowStudentInfo(StudentID);
            frmShow.ShowDialog();
        }
    }
}
