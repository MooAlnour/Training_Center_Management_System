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

namespace Training_Center_Management_System
{
    public partial class frmMain: Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private static DataTable _dtAllUsers;

        private void Form1_Load(object sender, EventArgs e)
        {
            _dtAllUsers = UserBL.GetAllUsers();

            dataGridView1.DataSource = _dtAllUsers;
        }
    }
}
