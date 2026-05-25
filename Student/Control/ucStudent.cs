using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Training_Center_Management_System.Student
{
    public partial class ucStudent: UserControl
    {
        public ucStudent()
        {
            InitializeComponent();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ucStudent_Load(object sender, EventArgs e)
        {
            DGVStudents.Rows.Add(new object[] { 1, "أحمد محمد علي", "0501234567", "ahmed@example.com", new DateTime(2000, 5, 15), new DateTime(2024, 9, 1) });
            DGVStudents.Rows.Add(new object[] { 2, "سارة خالد عبدالله", "0512345678", "sara@example.com", new DateTime(2001, 8, 22), new DateTime(2024, 9, 2) });
            DGVStudents.Rows.Add(new object[] { 3, "محمد إبراهيم حسين", "0523456789", "mohammed@example.com", new DateTime(1999, 12, 10), new DateTime(2024, 9, 3) });
            DGVStudents.Rows.Add(new object[] { 4, "نورة عبدالرحمن الفهد", "0534567890", "noura@example.com", new DateTime(2002, 3, 5), new DateTime(2024, 9, 5) });
            DGVStudents.Rows.Add(new object[] { 5, "عمر يوسف سليمان", "0545678901", "omar@example.com", new DateTime(2000, 11, 20), new DateTime(2024, 9, 7) });
            DGVStudents.Rows.Add(new object[] { 6, "فاطمة علي حسن", "0556789012", "fatima@example.com", new DateTime(2001, 7, 14), new DateTime(2024, 9, 8) });
            DGVStudents.Rows.Add(new object[] { 7, "خالد منصور العتيبي", "0567890123", "khalid@example.com", new DateTime(1998, 9, 30), new DateTime(2024, 9, 10) });
            DGVStudents.Rows.Add(new object[] { 8, "ليلى سامر محمود", "0578901234", "laila@example.com", new DateTime(2003, 1, 18), new DateTime(2024, 9, 12) });
        }
    }
}
