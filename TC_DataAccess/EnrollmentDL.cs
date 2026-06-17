using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TC_DataAccess
{
    public class EnrollmentDL
    {
        public static DataTable GetAllEnrollments()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                              Enrollments.EnrollmentID,
                            Students.FullName,
                            Courses.Title,
    
                            CASE Enrollments.Status
                                WHEN 1 THEN 'Active'
                                WHEN 2 THEN 'Completed'
                                WHEN 3 THEN 'Cancelled'
                                ELSE 'Unknown'
                            END AS Status,

                            Enrollments.Grade,
                            Enrollments.EnrollmentDate

                        FROM Enrollments
                        INNER JOIN Students
                            ON Students.StudentID = Enrollments.StudentID

                        INNER JOIN Courses
                            ON Courses.CourseID = Enrollments.CourseID";
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
        public static DataTable GetEnrollmentByStudentID(int StudentID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"Enrollments.CourseID, Status, Grade, EnrollmentDate from Enrollments where StudentID=@StudentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", StudentID);

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

        public static DataTable GetEnrollmentByCourseID(int CourseID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = $"SELECT \r\n    Students.FullName,\r\n    Enrollments.Status,\r\n    Enrollments.Grade,\r\n    Enrollments.EnrollmentDate\r\nFROM Students\r\nINNER JOIN Enrollments\r\n    ON Students.StudentID = Enrollments.StudentID\r\nWHERE Enrollments.CourseID = @CourseID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CourseID", CourseID);

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


        public static bool GetEnrollmentInfoByEnrollmentID(int EnrollmentID, ref int StudentID, ref int CourseID
            , ref DateTime EnrollmentDate, ref decimal Grade, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Enrollments WHERE EnrollmentID = @EnrollmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    StudentID = (int)reader["StudentID"];
                    CourseID = (int)reader["CourseID"];
                    EnrollmentDate = (DateTime)reader["EnrollmentDate"];
                    Grade = (decimal)reader["Grade"];
                    Status = (byte)reader["Status"];

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

        public static bool GetEnrollmentInfoByStudentID(int StudentID, ref int EnrollmentID, ref int CourseID
            , ref DateTime EnrollmentDate, ref decimal Grade, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Enrollments WHERE StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", StudentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    EnrollmentID = (int)reader["EnrollmentID"];
                    CourseID = (int)reader["CourseID"];
                    EnrollmentDate = (DateTime)reader["EnrollmentDate"];
                    Grade = (decimal)reader["Grade"];
                    Status = (byte)reader["Status"];

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

        public static bool GetEnrollmentInfoByCourseID(int CourseID, ref int EnrollmentID, ref int StudentID
            , ref DateTime EnrollmentDate, ref decimal Grade, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Enrollments WHERE CourseID = @CourseID";

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

                    EnrollmentID = (int)reader["EnrollmentID"];
                    StudentID = (int)reader["StudentID"];
                    EnrollmentDate = (DateTime)reader["EnrollmentDate"];
                    Grade = (decimal)reader["Grade"];
                    Status = (byte)reader["Status"];

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

        public static int AddNewEnrollment(int StudentID, int CourseID
            , DateTime EnrollmentDate, decimal Grade, byte Status)
        {
            int EnrollmentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Enrollments (StudentID,CourseID,EnrollmentDate,Grade,Status)
                     VALUES (@StudentID,@CourseID,@EnrollmentDate,@Grade,@Status);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", StudentID);
            command.Parameters.AddWithValue("@CourseID", CourseID);
            command.Parameters.AddWithValue("@EnrollmentDate", EnrollmentDate);
            command.Parameters.AddWithValue("@Grade", Grade);
            command.Parameters.AddWithValue("@Status", Status);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    EnrollmentID = insertedID;
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

            return EnrollmentID;
        }

        public static bool UpdateEnrollment(int EnrollmentID, int StudentID, int CourseID
            , DateTime EnrollmentDate, decimal Grade, byte Status)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Enrollments
                    set
                        CourseID = @CourseID,
                        CourseID = @CourseID,
                        EnrollmentDate = @EnrollmentDate,
                        Grade = @Grade,
                        Status = @Status
                        where CourseID = @CourseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);
            command.Parameters.AddWithValue("@StudentID", StudentID);
            command.Parameters.AddWithValue("@CourseID", CourseID);
            command.Parameters.AddWithValue("@EnrollmentDate", EnrollmentDate);
            command.Parameters.AddWithValue("@Grade", Grade);
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

        public static bool DeleteEnrollment(int EnrollmentID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Enrollments
                        where CourseID = @CourseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CourseID", EnrollmentID);

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
        public static bool IsEnrollmentExist(int EnrollmentID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Enrollments WHERE EnrollmentID = @EnrollmentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);

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
        public static bool IsEnrollmentCancelled(int EnrollmentID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Enrollments WHERE EnrollmentID = @EnrollmentID and Status=4";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);

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
        public static bool IsStudentEnrolled(int StudentID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Enrollments WHERE CourseID = @CourseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CourseID", StudentID);

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
        public static bool IsStudentEnrolledInCourse(int StudentID , int CourseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Enrollments WHERE StudentID = @StudentID and CourseID=@CourseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", StudentID);
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
        public static bool UpdateStatus(int EnrollmentID, short Status)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Enrollments  
                            set 
                                Status = @NewStatus, 
                            where EnrollmentID=@EnrollmentID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);
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
        public static bool IsCourseEnrolled(int CourseID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Enrollments WHERE CourseID = @CourseID ";

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

        public static bool FindByStudentAndCourse(int studentID, int courseID, ref int enrollmentID, ref DateTime enrollmentDate, ref decimal grade, ref byte status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Enrollments WHERE StudentID = @studentID and CourseID=@courseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", studentID);
            command.Parameters.AddWithValue("@CourseID", courseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    enrollmentID = (int)reader["EnrollmentID"];
                    enrollmentDate = (DateTime)reader["EnrollmentDate"];
                    grade = (decimal)reader["Grade"];
                    status = (byte)reader["Status"];

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
    }
}
