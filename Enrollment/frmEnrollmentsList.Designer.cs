namespace Training_Center_Management_System.Enrollment
{
    partial class frmEnrollmentsList
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvEnrollments = new System.Windows.Forms.DataGridView();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnAddEnrollment = new System.Windows.Forms.Button();
            this.btnDeleteEnrollment = new System.Windows.Forms.Button();
            this.btnEditEnrollment = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrollments)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1402, 66);
            this.panel1.TabIndex = 117;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(403, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 41);
            this.label3.TabIndex = 0;
            this.label3.Text = "Enrollment List";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Location = new System.Drawing.Point(275, 674);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(21, 16);
            this.lblRecordsCount.TabIndex = 130;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(129, 665);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 129;
            this.label2.Text = "# Records:";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::Training_Center_Management_System.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1263, 665);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 37);
            this.btnClose.TabIndex = 128;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvEnrollments
            // 
            this.dgvEnrollments.AllowUserToAddRows = false;
            this.dgvEnrollments.AllowUserToDeleteRows = false;
            this.dgvEnrollments.BackgroundColor = System.Drawing.Color.White;
            this.dgvEnrollments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEnrollments.Location = new System.Drawing.Point(134, 222);
            this.dgvEnrollments.Name = "dgvEnrollments";
            this.dgvEnrollments.ReadOnly = true;
            this.dgvEnrollments.RowHeadersWidth = 51;
            this.dgvEnrollments.RowTemplate.Height = 24;
            this.dgvEnrollments.Size = new System.Drawing.Size(1256, 415);
            this.dgvEnrollments.TabIndex = 127;
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.BackColor = System.Drawing.Color.CornflowerBlue;
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.ForeColor = System.Drawing.Color.Black;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Enrollment ID",
            "Course ID",
            "Student ID",
            "Grade"});
            this.cbFilterBy.Location = new System.Drawing.Point(277, 175);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(210, 24);
            this.cbFilterBy.TabIndex = 126;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(129, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 125;
            this.label1.Text = "Filter By:";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(493, 175);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(246, 24);
            this.txtSearch.TabIndex = 124;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnViewDetails.Image = global::Training_Center_Management_System.Properties.Resources.icons8_view_32;
            this.btnViewDetails.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnViewDetails.Location = new System.Drawing.Point(12, 427);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(91, 67);
            this.btnViewDetails.TabIndex = 134;
            this.btnViewDetails.Text = "View";
            this.btnViewDetails.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnViewDetails.UseVisualStyleBackColor = false;
            // 
            // btnAddEnrollment
            // 
            this.btnAddEnrollment.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAddEnrollment.Image = global::Training_Center_Management_System.Properties.Resources.icons8_add_32;
            this.btnAddEnrollment.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAddEnrollment.Location = new System.Drawing.Point(12, 514);
            this.btnAddEnrollment.Name = "btnAddEnrollment";
            this.btnAddEnrollment.Size = new System.Drawing.Size(91, 67);
            this.btnAddEnrollment.TabIndex = 133;
            this.btnAddEnrollment.Text = "Add";
            this.btnAddEnrollment.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddEnrollment.UseVisualStyleBackColor = false;
            this.btnAddEnrollment.Click += new System.EventHandler(this.btnAddEnrollment_Click);
            // 
            // btnDeleteEnrollment
            // 
            this.btnDeleteEnrollment.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnDeleteEnrollment.Image = global::Training_Center_Management_System.Properties.Resources.icons8_delete_32;
            this.btnDeleteEnrollment.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeleteEnrollment.Location = new System.Drawing.Point(12, 343);
            this.btnDeleteEnrollment.Name = "btnDeleteEnrollment";
            this.btnDeleteEnrollment.Size = new System.Drawing.Size(91, 67);
            this.btnDeleteEnrollment.TabIndex = 132;
            this.btnDeleteEnrollment.Text = "Delete";
            this.btnDeleteEnrollment.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDeleteEnrollment.UseVisualStyleBackColor = false;
            this.btnDeleteEnrollment.Click += new System.EventHandler(this.btnDeleteEnrollment_Click);
            // 
            // btnEditEnrollment
            // 
            this.btnEditEnrollment.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEditEnrollment.Image = global::Training_Center_Management_System.Properties.Resources.icons8_edit_32;
            this.btnEditEnrollment.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditEnrollment.Location = new System.Drawing.Point(12, 258);
            this.btnEditEnrollment.Name = "btnEditEnrollment";
            this.btnEditEnrollment.Size = new System.Drawing.Size(91, 67);
            this.btnEditEnrollment.TabIndex = 131;
            this.btnEditEnrollment.Text = "Edit";
            this.btnEditEnrollment.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditEnrollment.UseVisualStyleBackColor = false;
            this.btnEditEnrollment.Click += new System.EventHandler(this.btnEditEnrollment_Click);
            // 
            // frmEnrollmentsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 716);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.btnAddEnrollment);
            this.Controls.Add(this.btnDeleteEnrollment);
            this.Controls.Add(this.btnEditEnrollment);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvEnrollments);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEnrollmentsList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enrollments List";
            this.Load += new System.EventHandler(this.frmEnrollmentsList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEnrollments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvEnrollments;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnAddEnrollment;
        private System.Windows.Forms.Button btnDeleteEnrollment;
        private System.Windows.Forms.Button btnEditEnrollment;
    }
}