using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC_DataAccess
{
   public class CourseDL
    {
        public static DataTable GetAllCourses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Courses";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

        public static bool GetCourseInfoByCourseID(int CourseID, ref string Title, ref int Hours
            , ref decimal Price, ref DateTime StartDate, ref string Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Courses WHERE CourseID = @CourseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CourseID", CourseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Title = (string)reader["Title"];
                    Hours = (int)reader["Hours"];
                    Price = (decimal)reader["Price"];
                    StartDate = (DateTime)reader["StartDate"];
                    Status = (string)reader["Status"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetCourseInfoByTitle(string Title, ref int CourseID, ref int Hours
            , ref decimal Price, ref DateTime StartDate, ref string Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Courses WHERE Title = @Title";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Title", Title);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    CourseID = (int)reader["CourseID"];
                    Hours = (int)reader["Hours"];
                    Price = (decimal)reader["Price"];
                    StartDate = (DateTime)reader["StartDate"];
                    Status = (string)reader["Status"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool GetCourseInfoByStatus(string Status, ref int CourseID, ref string Title
            , ref int Hours, ref decimal Price, ref DateTime StartDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Courses WHERE Status = @Status";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Status", Status);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    CourseID = (int)reader["CourseID"];
                    Title = (string)reader["Title"];
                    Hours = (int)reader["Hours"];
                    Price = (decimal)reader["Price"];
                    StartDate = (DateTime)reader["StartDate"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddNewCourse(string Title, int Hours
            , decimal Price, DateTime StartDate, string Status)
        {
            int CourseID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Courses (Title,Hours,Price,StartDate,Status)
                     VALUES (@Title,@Hours,@Price,@StartDate,@Status);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Hours", Hours);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@Status", Status);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CourseID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return CourseID;
        }

        public static bool UpdateCourse(int CourseID, string Title, int Hours
            , decimal Price, DateTime StartDate, string Status)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Courses
                    set
                        Title = @Title,
                        Hours = @Hours,
                        Price = @Price,
                        StartDate = @StartDate,
                        Status = @Status
                        where CourseID = @CourseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CourseID", CourseID);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Hours", Hours);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@StartDate", StartDate);
            command.Parameters.AddWithValue("@Status", Status);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

        public static bool DeleteCourse(int CourseID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Courses
                        where CourseID = @CourseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CourseID", CourseID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }

        public static bool IsCourseExist(int CourseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Courses WHERE CourseID = @CourseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CourseID", CourseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsCourseActive(int CourseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Courses WHERE CourseID = @CourseID and Status = 1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CourseID", CourseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

    }
}
