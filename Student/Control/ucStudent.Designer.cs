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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.DGVStudents = new System.Windows.Forms.DataGridView();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.CornflowerBlue;
            this.txtSearch.Location = new System.Drawing.Point(783, 30);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(246, 36);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // DGVStudents
            // 
            this.DGVStudents.AllowUserToAddRows = false;
            this.DGVStudents.AllowUserToDeleteRows = false;
            this.DGVStudents.BackgroundColor = System.Drawing.Color.White;
            this.DGVStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVStudents.Location = new System.Drawing.Point(3, 221);
            this.DGVStudents.Name = "DGVStudents";
            this.DGVStudents.ReadOnly = true;
            this.DGVStudents.RowHeadersWidth = 51;
            this.DGVStudents.RowTemplate.Height = 24;
            this.DGVStudents.Size = new System.Drawing.Size(1042, 323);
            this.DGVStudents.TabIndex = 7;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Location = new System.Drawing.Point(148, 568);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(21, 16);
            this.lblRecordsCount.TabIndex = 100;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 561);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 99;
            this.label2.Text = "# Records:";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.Color.CornflowerBlue;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Student ID",
            "Phone",
            "Student Name",
            "Email"});
            this.cbFilterBy.Location = new System.Drawing.Point(566, 37);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(210, 24);
            this.cbFilterBy.TabIndex = 103;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(462, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 101;
            this.label1.Text = "Filter By:";
            // 
            // btnView
            // 
            this.btnView.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnView.Image = global::Training_Center_Management_System.Properties.Resources.icons8_view_32;
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnView.Location = new System.Drawing.Point(248, 19);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(91, 67);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "View";
            this.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnView.UseVisualStyleBackColor = false;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAddStudent.Image = global::Training_Center_Management_System.Properties.Resources.icons8_add_32;
            this.btnAddStudent.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddStudent.Location = new System.Drawing.Point(345, 19);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(91, 67);
            this.btnAddStudent.TabIndex = 0;
            this.btnAddStudent.Text = "Add";
            this.btnAddStudent.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddStudent.UseVisualStyleBackColor = false;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnDelete.Image = global::Training_Center_Management_System.Properties.Resources.icons8_delete_32;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.Location = new System.Drawing.Point(151, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 67);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button3.Image = global::Training_Center_Management_System.Properties.Resources.icons8_edit_32;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(54, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 67);
            this.button3.TabIndex = 2;
            this.button3.Text = "Edit";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ucStudent
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DGVStudents);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnAddStudent);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.button3);
            this.Cursor = System.Windows.Forms.Cursors.No;
            this.Name = "ucStudent";
            this.Size = new System.Drawing.Size(1048, 644);
            this.Load += new System.EventHandler(this.ucStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView DGVStudents;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label1;
    }
}
