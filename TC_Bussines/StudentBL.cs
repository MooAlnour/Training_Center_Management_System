using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC_DataAccess;

namespace TC_Bussines
{
    public class StudentBL
    {

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int StudentID { set; get; }
        public string FullName { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public DateTime DataOfBrith { set; get; }
        public DateTime RegistrationDate { set; get; }

        public EnrollmentBL EnrollmentInfo;

        public StudentBL()
        {
            this.StudentID = -1;
            this.FullName = "";
            this.Phone = "";
            this.Email = "";
            this.DataOfBrith = DateTime.Now;
            this.RegistrationDate = DateTime.Now;

            Mode = enMode.AddNew;
        }

        private StudentBL(int studentID, string fullName, string phone,
            string email, DateTime dataOfBrith, DateTime registrationDate)
        {
            this.StudentID = studentID;
            EnrollmentInfo = EnrollmentBL.FindByStudentID(StudentID);
            this.FullName = fullName;
            this.Phone = phone;
            this.Email = email;
            this.DataOfBrith = dataOfBrith;
            this.RegistrationDate = registrationDate;

            Mode = enMode.Update;
        }

        public static StudentBL FindByStudentID(int studentID)
        {

            string fullName = "", phone = "", email = "";
            DateTime dataOfBrith = DateTime.Now;
            DateTime registrationDate = DateTime.Now;

            bool IsFound = StudentDL.GetStudentInfoByStudentID(
                studentID,
                ref fullName,
                ref phone,
                ref email,
                ref dataOfBrith,
                ref registrationDate);

            if (IsFound)
                return new StudentBL(studentID, fullName, phone,
                    email, dataOfBrith, registrationDate);
            else
                return null;

        }

        public static StudentBL FindByFullName(string FullName)
        {

            int studentID = -1;
            string phone = "", email = "";
            DateTime dataOfBrith = DateTime.Now;
            DateTime registrationDate = DateTime.Now;

            bool IsFound = StudentDL.GetStudentInfoByFullName(
                FullName,
                ref studentID,
                ref phone,
                ref email,
                ref dataOfBrith,
                ref registrationDate);

            if (IsFound)
                return new StudentBL(studentID, FullName, phone,
                    email, dataOfBrith, registrationDate);
            else
                return null;

        }

        private bool _ValidateStudentData(ref string ErrorMessage)
        {
            // دالة للتحقق من مدخلات الطالب الجديد  

            if (string.IsNullOrWhiteSpace(FullName))
            {
                ErrorMessage = "Full Name is required.";
                return false;
            }
            if (RegistrationDate > DateTime.Now)
            {
                ErrorMessage = "Registration date cannot be in the future.";
                return false;
            }

            if (IsStudentEmailExist(Email))
            {
                ErrorMessage = "Email already exists.";
                return false;
            }

            if (IsStudentPhoneExist(Phone) && Mode==enMode.AddNew)
            {
                ErrorMessage = "Phone already exists.";
                return false;
            }

            return true;
        }

        private bool _AddNewStudent(ref string ErrorMessage)
        {
            if (!_ValidateStudentData(ref ErrorMessage))
                return false;

            this.StudentID = StudentDL.AddNewStudent(
                this.FullName,
                this.Phone,
                this.Email,
                this.DataOfBrith,
                this.RegistrationDate);


            if (StudentID == -1)
            {
                ErrorMessage = "Failed to add student.";
                return false;
            }

            return true;

        }

        private bool _UpdateStudent(ref string ErrorMessage)
        {
            if (!_ValidateStudentData(ref ErrorMessage))
                return false;

            return StudentDL.UpdateStudent(
                this.StudentID,
                this.FullName,
                this.Phone,
                this.Email,
                this.DataOfBrith
                );

        }

        public bool Save(ref string ErrorMessage)
        {

            switch (Mode)
            {

                case enMode.AddNew:

                    if (_AddNewStudent(ref ErrorMessage))
                    {

                        Mode = enMode.Update;
                        return true;

                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateStudent(ref ErrorMessage);

            }

            return false;

        }

        public static DataTable GetAllStudents()
        {
            return StudentDL.GetAllStudents();
        }

        public static bool DeleteStudent(int ID)
        {
            if (EnrollmentBL.IsStudentEnrolled(ID))
                return false;

            return StudentDL.DeleteStudent(ID);
        }

        public static bool IsStudentEmailExist(string Email)
        {
            return StudentDL.IsEmailExist(Email);
        }

        public static bool IsStudentPhoneExist(string Phone)
        {
            return StudentDL.IsPhoneExist(Phone);
        }

        public DataTable GetStudentEnrollment()
        {
            return EnrollmentDL.GetEnrollmentByStudentID(StudentID);
        }

        public DataTable GetStudentPayment()
        {
            if (EnrollmentInfo != null)
            {
                return PaymentDL.GetPaymentByEnrollmentID(EnrollmentInfo.EnrollmentID);
            }
            return PaymentDL.GetPaymentByEnrollmentID(-1);
        }

    }
}
