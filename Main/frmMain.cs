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
using Training_Center_Management_System.Payment;
using System.Drawing.Drawing2D;
using Training_Center_Management_System.Global_Classes;
using Training_Center_Management_System.Main;
namespace Training_Center_Management_System
{
    public partial class frmMain: Form
    {
        public frmMain()
        {
            InitializeComponent();
            panelheader.MouseDown += panelheader_MouseDown;
            lblTitle.MouseDown += panelheader_MouseDown;
            LoadControl(new ucDashbord());
            RoundPanel(panelside, 30);
        }

        private void RoundPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            // Top Left
            path.AddArc(0, 0, radius, radius, 180, 90);

            // Top Right
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90);

            // Bottom Right
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90);

            // Bottom Left
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90);

            path.CloseFigure();

            panel.Region = new Region(path);
        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        

        public void LoadControl(object control)
        {
            mainpanel.Controls.Clear();

            UserControl uc = control as UserControl;

            uc.Dock = DockStyle.None;

            mainpanel.Controls.Add(uc);

            uc.BringToFront();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
        //    lblUserName.Text ="Welcome Back ["+ clsGlobal.CurrentUser.UserName+ "]";
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
            LoadControl(new ucEnrollment());
        }

        private void btndashbaord_Click(object sender, EventArgs e)
        {
          Form1 form= new Form1();
            form.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            LoadControl(new ucUsers());
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            LoadControl(new ucStudent());
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            LoadControl(new ucCourse());
            
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            LoadControl(new ucPayment());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            LoadControl(new ucReport());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
