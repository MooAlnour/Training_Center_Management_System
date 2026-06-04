using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Training_Center_Management_System.Student
{
    public partial class frmFindStudent: Form
    {
        public delegate void DataBackEventHandler(object sender, int StudentID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public frmFindStudent()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //MessageBox.Show((DataBack == null).ToString());
            DataBack?.Invoke(this,ctrlStudentCardWithFilter1.StudentID);
            this.Close();
        }
    }
}
