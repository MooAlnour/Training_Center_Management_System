using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Training_Center_Management_System.Course;
using Training_Center_Management_System.Global_Classes;
using Training_Center_Management_System.Login;
using Training_Center_Management_System.Student;

namespace Training_Center_Management_System.Main
{
    public partial class frmMain: Form
    {
        frmLogin _frmLogin;

        public frmMain()
        {
            InitializeComponent();
            panelheader.MouseDown += panelheader_MouseDown;
            lblTitle.MouseDown += panelheader_MouseDown;
            timer1.Start();
            //_frmLogin = frm;

        }
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void panelheader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void frmMainn_Load(object sender, EventArgs e)
        {
          //  lblUserName.Text = clsGlobal.CurrentUser.UserName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            frmStudentList form = new frmStudentList();
            form.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToString("dddd d/M/yyyy");

            lblTimer.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            frmCoursesList frm = new frmCoursesList();
            frm.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            //_frmLogin.Show();
            this.Close();
        }
    }
}
