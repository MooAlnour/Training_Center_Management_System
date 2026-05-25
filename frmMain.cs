using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Training_Center_Management_System.Users;
using Training_Center_Management_System.Student;
using Training_Center_Management_System.Course;
using Training_Center_Management_System.Enrollment;
using Training_Center_Management_System.Reports;
using Training_Center_Management_System.Pyment;
namespace Training_Center_Management_System
{
    public partial class frmMain: Form
    {
        public frmMain()
        {
            InitializeComponent();
            panelheader.MouseDown += panelheader_MouseDown;
            lblTitle.MouseDown += panelheader_MouseDown;
            loadform(new frmDashbord());
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          lblDate.Text = DateTime.Now.ToString("dddd d/M/yyyy");

          lblTimer.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelheader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnEnrollments_Click(object sender, EventArgs e)
        {
            loadform(new frmEnrollment());
        }

        private void btndashbaord_Click(object sender, EventArgs e)
        {
            loadform(new frmDashbord());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            loadform(new frmUsersList());
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            loadform(new frmStudent());
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            loadform(new frmCourse());
            
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            loadform(new frmPayment());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            loadform(new frmReport());
        }
    }
}
