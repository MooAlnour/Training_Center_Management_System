using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC_DataAccess;
using static System.Net.Mime.MediaTypeNames;

namespace TC_Bussines
{
   public class EnrollmentBL
    {
        
            public enum enMode { AddNew = 0, Update = 1 };
            public enMode Mode = enMode.AddNew;
      
            public enum enEnrollmentStatus
        {
            Pending = 1,
            Active = 2,
            Completed = 3,
            Cancelled = 4,
            Suspended = 5
        };
       
            public enEnrollmentStatus Status = enEnrollmentStatus.Active;

            public int EnrollmentID { set; get; }
            public int StudentID { set; get; }

            public  StudentBL StudentInfo;
            public int CourseID { set; get; }

            public CourseBL CourseInfo;
            public DateTime EnrollmentDate { set; get; }
            public decimal Grade { set; get; }
       
              public EnrollmentBL()
            {
                this.EnrollmentID = -1;
                this.StudentID = -1;
                this.CourseID = -1;
                this.EnrollmentDate = DateTime.Now;
                this.Grade = 0;
                this.Status =enEnrollmentStatus.Active;

                Mode = enMode.AddNew;
            }

            private EnrollmentBL(int enrollmentID, int studentID, int courseID,
                DateTime enrollmentDate, decimal grade, enEnrollmentStatus status)
            {
                this.EnrollmentID = enrollmentID;
                this.StudentID = studentID;
                StudentInfo = StudentBL.FindByStudentID(StudentID);
                this.CourseID = courseID;
                CourseInfo = CourseBL.FindByCourseID(CourseID);
                this.EnrollmentDate = enrollmentDate;
                this.Grade = grade;
                this.Status = status;
                Mode = enMode.Update;
            }

            public static EnrollmentBL FindByEnrollmentID(int enrollmentID)
            {

                int studentID = -1;
                int courseID = -1;
                decimal grade = 0;
                DateTime enrollmentDate = DateTime.Now;
            byte status = 1 ;

                bool IsFound = EnrollmentDL.GetEnrollmentInfoByEnrollmentID(
                    enrollmentID,
                    ref studentID,
                    ref courseID,
                    ref enrollmentDate,
                    ref grade,
                    ref status);

                if (IsFound)
                    return new EnrollmentBL(enrollmentID, studentID, courseID,
                        enrollmentDate, grade,(enEnrollmentStatus) status);
                else
                    return null;

            }

            public static EnrollmentBL FindByStudentID(int StudentID)
            {

                int enrollmentID = -1;
                int courseID = -1;
                decimal grade = 0;
                DateTime enrollmentDate = DateTime.Now;
                byte status = 1 ;

                bool IsFound = EnrollmentDL.GetEnrollmentInfoByStudentID(
                    StudentID,
                    ref enrollmentID,
                    ref courseID,
                    ref enrollmentDate,
                    ref grade,
                    ref status);

                if (IsFound)
                    return new EnrollmentBL(enrollmentID, StudentID, courseID,
                        enrollmentDate, grade,(enEnrollmentStatus) status);
                else
                    return null;

            }

            private bool _ValidateEnrollmentData(ref string ErrorMessage) {

            
            if (IsStudentEnrolledInCourse())
            {
                ErrorMessage = "Student is already enrolled in this course.";
                return false;
            }

            if (!CourseBL.IsCourseExist(CourseID))
            {
                ErrorMessage = "Course are not Found.";
                return false;
            }

            if (!CourseBL.IsCourseActive(CourseID))
            {
                ErrorMessage = "the Course are not Active.";
                return false;
            }

            return true;
        }
            public bool Cancel()

            {
            return EnrollmentDL.UpdateStatus(EnrollmentID, 4);
              }
            public bool SetComplete()

             {
            return EnrollmentDL.UpdateStatus(EnrollmentID, 3);
            }

            private bool _AddNewEnrollment(ref string ErrorMessage)
            {
            _ValidateEnrollmentData(ref ErrorMessage);
                this.EnrollmentID = EnrollmentDL.AddNewEnrollment(
                    this.StudentID,
                    this.CourseID,
                    this.EnrollmentDate,
                    this.Grade,
                    (byte)this.Status);

                return (this.EnrollmentID != -1);

            }

            private bool _UpdateEnrollment()
            {

                return EnrollmentDL.UpdateEnrollment(
                    this.EnrollmentID,
                    this.StudentID,
                    this.CourseID,
                    this.EnrollmentDate,
                    this.Grade,
                    (byte)this.Status);

            }

            public bool Save(ref string ErrorMessage)
            {

                switch (Mode)
                {

                    case enMode.AddNew:

                        if (_AddNewEnrollment(ref ErrorMessage))
                        {

                            Mode = enMode.Update;
                            return true;

                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:

                        return _UpdateEnrollment();

                }

                return false;

            }

            public static DataTable GetAllEnrollments()
            {
                return EnrollmentDL.GetAllEnrollments();
            }

            public static bool DeleteEnrollment(int ID)
            {
                return EnrollmentDL.DeleteEnrollment(ID);
            }

            public static bool IsEnrollmentExist(int ID)
            {
                return EnrollmentDL.IsEnrollmentExist(ID);
            }
       
            public static bool IsStudentEnrolled(int StudentID)
        
             {
               return EnrollmentDL.IsStudentEnrolled(StudentID);
             }
            public static bool IsEnrollmentCancelled(int ID)
        {
            return EnrollmentDL.IsEnrollmentCancelled(ID);
        }
            public  bool IsStudentEnrolledInCourse()
        {

            return EnrollmentDL.IsStudentEnrolledInCourse(StudentID, CourseID);
        }
            public static bool IsStudentEnrolledInCourse(int StudentID, int CourseID) {
           
             return EnrollmentDL.IsStudentEnrolledInCourse(StudentID, CourseID);
            }
        public static bool IsCourseEnrolled(int CourseID)
        {
            return EnrollmentDL.IsCourseEnrolled(CourseID);
        }
            public static bool UpdateStatus(int EnrollmentID, enEnrollmentStatus Status)
        {
            return EnrollmentDL.UpdateStatus(EnrollmentID, (short)Status);
        }
    }

}

