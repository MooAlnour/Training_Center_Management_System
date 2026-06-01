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

namespace Training_Center_Management_System.Course
{
    public partial class frmAddEditCourse: Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        int _CourseID;
        CourseBL _Course;
        public frmAddEditCourse()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddEditCourse(int CourseID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _CourseID = CourseID;
        }

        private void frmAddEditCourse_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
