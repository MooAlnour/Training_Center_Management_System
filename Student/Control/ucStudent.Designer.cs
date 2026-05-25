namespace Training_Center_Management_System.Student
{
    partial class ucStudent
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlGrid = new System.Windows.Forms.Panel();
            this.DGVStudents = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegistrationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudents)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlGrid
            // 
            this.PnlGrid.Controls.Add(this.DGVStudents);
            this.PnlGrid.Location = new System.Drawing.Point(3, 146);
            this.PnlGrid.Margin = new System.Windows.Forms.Padding(0);
            this.PnlGrid.Name = "PnlGrid";
            this.PnlGrid.Padding = new System.Windows.Forms.Padding(0, 0, 2, 2);
            this.PnlGrid.Size = new System.Drawing.Size(1046, 452);
            this.PnlGrid.TabIndex = 0;
            // 
            // DGVStudents
            // 
            this.DGVStudents.AllowUserToAddRows = false;
            this.DGVStudents.AllowUserToDeleteRows = false;
            this.DGVStudents.AllowUserToResizeColumns = false;
            this.DGVStudents.AllowUserToResizeRows = false;
            this.DGVStudents.BackgroundColor = System.Drawing.Color.White;
            this.DGVStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVStudents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.DGVStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVStudents.ColumnHeadersHeight = 54;
            this.DGVStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.FullName,
            this.Phone,
            this.Email,
            this.DateOfBirth,
            this.RegistrationDate});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(234)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStudents.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVStudents.EnableHeadersVisualStyles = false;
            this.DGVStudents.GridColor = System.Drawing.Color.White;
            this.DGVStudents.Location = new System.Drawing.Point(0, 0);
            this.DGVStudents.MultiSelect = false;
            this.DGVStudents.Name = "DGVStudents";
            this.DGVStudents.ReadOnly = true;
            this.DGVStudents.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStudents.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVStudents.RowHeadersVisible = false;
            this.DGVStudents.RowHeadersWidth = 40;
            this.DGVStudents.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DGVStudents.RowTemplate.Height = 40;
            this.DGVStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVStudents.Size = new System.Drawing.Size(1044, 450);
            this.DGVStudents.TabIndex = 0;
            this.DGVStudents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btnAddStudent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1048, 89);
            this.panel1.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.CornflowerBlue;
            this.txtSearch.Location = new System.Drawing.Point(619, 26);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(313, 36);
            this.txtSearch.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSearch.Image = global::Training_Center_Management_System.Properties.Resources.icons8_search_26;
            this.btnSearch.Location = new System.Drawing.Point(892, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 36);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnView.Image = global::Training_Center_Management_System.Properties.Resources.icons8_view_32;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnView.Location = new System.Drawing.Point(306, 15);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(91, 67);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnDelete.Image = global::Training_Center_Management_System.Properties.Resources.icons8_delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(209, 15);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 67);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button3.Image = global::Training_Center_Management_System.Properties.Resources.icons8_edit_32;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(112, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 67);
            this.button3.TabIndex = 2;
            this.button3.Text = "Edit";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAddStudent.Image = global::Training_Center_Management_System.Properties.Resources.icons8_add_32;
            this.btnAddStudent.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddStudent.Location = new System.Drawing.Point(15, 15);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(91, 67);
            this.btnAddStudent.TabIndex = 0;
            this.btnAddStudent.Text = "Add";
            this.btnAddStudent.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddStudent.UseVisualStyleBackColor = false;
            // 
            // StudentID
            // 
            this.StudentID.HeaderText = "Student ID";
            this.StudentID.MinimumWidth = 6;
            this.StudentID.Name = "StudentID";
            this.StudentID.ReadOnly = true;
            // 
            // FullName
            // 
            this.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FullName.HeaderText = "Full Name";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            this.FullName.Width = 140;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "Phone";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 145;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.HeaderText = "Date Of Birth";
            this.DateOfBirth.MinimumWidth = 6;
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.ReadOnly = true;
            this.DateOfBirth.Width = 140;
            // 
            // RegistrationDate
            // 
            this.RegistrationDate.HeaderText = "Registration Date";
            this.RegistrationDate.MinimumWidth = 6;
            this.RegistrationDate.Name = "RegistrationDate";
            this.RegistrationDate.ReadOnly = true;
            this.RegistrationDate.Width = 140;
            // 
            // ucStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.PnlGrid);
            this.Controls.Add(this.panel1);
            this.Name = "ucStudent";
            this.Size = new System.Drawing.Size(1048, 777);
            this.Load += new System.EventHandler(this.ucStudent_Load);
            this.PnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudents)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlGrid;
        private System.Windows.Forms.DataGridView DGVStudents;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegistrationDate;
    }
}
