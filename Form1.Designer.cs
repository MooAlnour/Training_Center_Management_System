namespace Training_Center_Management_System
{
    partial class Form1
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
            this.ucStudent1 = new Training_Center_Management_System.Student.ucStudent();
            this.SuspendLayout();
            // 
            // ucStudent1
            // 
            this.ucStudent1.BackColor = System.Drawing.Color.White;
            this.ucStudent1.Cursor = System.Windows.Forms.Cursors.No;
            this.ucStudent1.Location = new System.Drawing.Point(23, 12);
            this.ucStudent1.Name = "ucStudent1";
            this.ucStudent1.Size = new System.Drawing.Size(1048, 777);
            this.ucStudent1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 714);
            this.Controls.Add(this.ucStudent1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Student.ucStudent ucStudent1;
    }
}