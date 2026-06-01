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

namespace Training_Center_Management_System.Course
{
    public partial class frmCoursesList: Form
    {
        private DataTable _dtCourse;

        public frmCoursesList()
        {
            InitializeComponent();
        }

        private void frmCoursesList_Load(object sender, EventArgs e)
        {
            _dtCourse = CourseBL.GetAllCourses();
            cbFilterBy.Text = "None";
            dgvCourses.DataSource = _dtCourse;
            lblRecordsCount.Text = dgvCourses.Rows.Count.ToString();

            if (dgvCourses.Rows.Count > 0)
            {
                dgvCourses.Columns[0].HeaderText = "Course ID";
                dgvCourses.Columns[0].Width = 80;

                dgvCourses.Columns[1].HeaderText = "Title";
                dgvCourses.Columns[1].Width = 180;

                dgvCourses.Columns[2].HeaderText = "Hours";
                dgvCourses.Columns[2].Width = 100;

                dgvCourses.Columns[3].HeaderText = "Price";
                dgvCourses.Columns[3].Width = 100;

                dgvCourses.Columns[4].HeaderText = "Start Date";
                dgvCourses.Columns[4].Width = 120;

                dgvCourses.Columns[5].HeaderText = "Status";
                dgvCourses.Columns[5].Width = 90;

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
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Course ID":
                    FilterColumn = "CourseID";
                    break;
                case "Title":
                    FilterColumn = "Title";
                    break;
                case "Price":
                    FilterColumn = "Price";
                    break;
                case "Status":
                    FilterColumn = "Status";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtCourse.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvCourses.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "Title")
                //in this case we deal with numbers not string.
                _dtCourse.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtCourse.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

            lblRecordsCount.Text = _dtCourse.Rows.Count.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
