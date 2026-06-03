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

namespace Training_Center_Management_System.Student.Control
{
    public partial class ctrlStudentCardWithFilter: UserControl
    {
        public event Action<int> OnStudentSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void StudentSelected(int StudentID)
        {
            Action<int> handler = OnStudentSelected;
            if (handler != null)
            {
                handler(StudentID); // Raise the event with the parameter
            }
        }


        private bool _ShowAddStudent = true;
        public bool ShowAddStudent
        {
            get
            {
                return _ShowAddStudent;
            }
            set
            {
                _ShowAddStudent = value;
                btnAddNewPerson.Visible = _ShowAddStudent;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }
        public ctrlStudentCardWithFilter()
        {
            InitializeComponent();
        }

        private int _StudentID = -1;

        public int StudentID
        {
            get { return _StudentID; }
        }

        public StudentBL SelectedStudentInfo
        {
            get { return ctrStudentInfo1.SelectedStudentInfo; }
        }

        public void LoadPersonInfo(int StudentID)
        {

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = StudentID.ToString();
            FindNow();

        }

        private void FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Student ID":
                    ctrStudentInfo1.LoadStudentInfo(int.Parse(txtFilterValue.Text));
                    break;
                case "Full Name":
                    ctrStudentInfo1.LoadStudentInfo(txtFilterValue.Text);
                    break;
            }
            if (OnStudentSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnStudentSelected(ctrStudentInfo1.StudentID);
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            FindNow();
        }

        private void DataBackEvent(object sender, int StudentID)
        {
            // Handle the data received

            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = StudentID.ToString();
            ctrStudentInfo1.LoadStudentInfo(StudentID);
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {

                btnFind.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilterBy.Text == "Student ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditStudent frmAddEdit = new frmAddEditStudent();
            frmAddEdit.DataBack += DataBackEvent;
            frmAddEdit.ShowDialog();
        }

    }
}
