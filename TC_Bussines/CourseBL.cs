using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC_DataAccess;

namespace TC_Bussines
{
 
    public class CourseBL
    {
     

            public enum enMode { AddNew = 0, Update = 1 };
            public enMode Mode = enMode.AddNew;

            public int CourseID { set; get; }
            public string Title { set; get; }
            public int Hours { set; get; }
            public decimal Price { set; get; }
            public DateTime StartDate { set; get; }
            public enum enCourseStatus
             {
            NonActive = 0,
            Active = 1,
            Completed = 2,
            Cancelled = 3
        };

             public enCourseStatus Status = enCourseStatus.Active;

        public CourseBL()
            {
                this.CourseID = -1;
                this.Title = "";
                this.Hours = 0;
                this.Price = 0;
                this.StartDate = DateTime.Now;
                this.Status =0;

                Mode = enMode.AddNew;
            }

            private CourseBL(int courseID, string title, int hours,
                decimal price, DateTime startDate, byte status)
            {
                this.CourseID = courseID;
                this.Title = title;
                this.Hours = hours;
                this.Price = price;
                this.StartDate = startDate;
                this.Status = (enCourseStatus)status;

                Mode = enMode.Update;
            }

            public static CourseBL FindByCourseID(int courseID)
            {

            string title = ""; byte status = 0;
                int hours = 0;
                decimal price = 0;
                DateTime startDate = DateTime.Now;

                bool IsFound = CourseDL.GetCourseInfoByCourseID(courseID,
                    ref title, ref hours, ref price, ref startDate, ref status);

                if (IsFound)
                    return new CourseBL(courseID, title, hours, price, startDate, status);
                else
                    return null;

            }

            public static CourseBL FindByTitle(string Title)
            {

                int courseID = -1;
                int hours = 0;
                decimal price = 0;
                DateTime startDate = DateTime.Now;
                byte status = 0;

                bool IsFound = CourseDL.GetCourseInfoByTitle(Title,
                    ref courseID, ref hours, ref price, ref startDate, ref status);

                if (IsFound)
                    return new CourseBL(courseID, Title, hours, price, startDate, status);
                else
                    return null;

            }

          private bool _ValidateCourseData(ref string ErrorMessage)
        {


            if (Price <= 0)
            {
                ErrorMessage = "Price must be greater than 0.";
                return false;
            }

            if (IsCourseExist(Title))
            {
                ErrorMessage = "Course are already Add to list.";
                return false;
            }
            return true;
        }

           private bool _CanDeleteCourse(ref string ErrorMessage)
        {


            if (IsCourseActive(CourseID))
            {
                ErrorMessage = "Course are Active.";
                return false;
            }

            return true;
        }

           private bool _AddNewCourse(ref string ErrorMessage)
            {
            if (!_ValidateCourseData(ref ErrorMessage))
                return false;

                this.CourseID = CourseDL.AddNewCourse(this.Title,
                    this.Hours, this.Price, this.StartDate,(byte) this.Status);

                return (this.CourseID != -1);

            }

            private bool _UpdateCourse(ref string ErrorMessage)
            {
            if (Price <= 0)
            {
                ErrorMessage = "Price must be greater than 0.";
                return false;
            }
            return CourseDL.UpdateCourse(this.CourseID,
                    this.Title, this.Hours, this.Price, this.StartDate, (byte)this.Status);

            }

            public bool Save(ref string ErrorMessage)
            {

                switch (Mode)
                {

                    case enMode.AddNew:

                        if (_AddNewCourse(ref ErrorMessage))
                        {

                            Mode = enMode.Update;
                            return true;

                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:

                        return _UpdateCourse(ref ErrorMessage);

                }

                return false;

            }

            public static DataTable GetAllCourses()
            {
                return CourseDL.GetAllCourses();
            }

            public DataTable GetAllStudentEnrollment()
        {
            return EnrollmentDL.GetEnrollmentByCourseID(CourseID);
        }

        public static DataTable GetCourseByEnrollment(int StudentID)
        {
            return CourseDL.GetCourseByEnrollment(StudentID);
        }
            public static bool DeleteCourse(int ID, ref string ErrorMessage)
            {
            if (EnrollmentBL.IsCourseEnrolled(ID))
                return false;
            if (IsCourseActive(ID))
                return false;

            return CourseDL.DeleteCourse(ID);
            }

            public static bool IsCourseExist(int CourseID)
            {
                return CourseDL.IsCourseExist(CourseID);
            }

            public static bool IsCourseExist(string Title)
        {
            return CourseDL.IsCourseExist(Title);
        }
            public static bool IsCourseActive(int CourseID)
            {
            return CourseDL.IsCourseActive(CourseID);
            }
            public bool Cancel()

      
       {
            if (EnrollmentBL.IsCourseEnrolled(CourseID))
                return false;

            return CourseDL.UpdateStatus(CourseID, 3);
        }
            public bool SetComplete()

        {
            return CourseDL.UpdateStatus(CourseID, 2);
        }

    }

}
