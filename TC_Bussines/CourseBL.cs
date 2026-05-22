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
            public string Status { set; get; }

            public CourseBL()
            {
                this.CourseID = -1;
                this.Title = "";
                this.Hours = 0;
                this.Price = 0;
                this.StartDate = DateTime.Now;
                this.Status = "";

                Mode = enMode.AddNew;
            }

            private CourseBL(int courseID, string title, int hours,
                decimal price, DateTime startDate, string status)
            {
                this.CourseID = courseID;
                this.Title = title;
                this.Hours = hours;
                this.Price = price;
                this.StartDate = startDate;
                this.Status = status;

                Mode = enMode.Update;
            }

            public static CourseBL FindByCourseID(int courseID)
            {

                string title = "", status = "";
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
                string status = "";

                bool IsFound = CourseDL.GetCourseInfoByTitle(Title,
                    ref courseID, ref hours, ref price, ref startDate, ref status);

                if (IsFound)
                    return new CourseBL(courseID, Title, hours, price, startDate, status);
                else
                    return null;

            }

            private bool _AddNewCourse()
            {

                this.CourseID = CourseDL.AddNewCourse(this.Title,
                    this.Hours, this.Price, this.StartDate, this.Status);

                return (this.CourseID != -1);

            }

            private bool _UpdateCourse()
            {

                return CourseDL.UpdateCourse(this.CourseID,
                    this.Title, this.Hours, this.Price, this.StartDate, this.Status);

            }

            public bool Save()
            {

                switch (Mode)
                {

                    case enMode.AddNew:

                        if (_AddNewCourse())
                        {

                            Mode = enMode.Update;
                            return true;

                        }
                        else
                        {
                            return false;
                        }

                    case enMode.Update:

                        return _UpdateCourse();

                }

                return false;

            }

            public static DataTable GetAllCourses()
            {
                return CourseDL.GetAllCourses();
            }

            public static bool DeleteCourse(int ID)
            {
                return CourseDL.DeleteCourse(ID);
            }

            public static bool IsCourseExist(int CourseID)
            {
                return CourseDL.IsCourseExist(CourseID);
            }
            public static bool IsCourseActive(int CourseID)
            {
            return CourseDL.IsCourseActive(CourseID);
            }

    }

}
