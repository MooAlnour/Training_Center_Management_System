using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC_DataAccess
{
    public class EnrollmentDL
    {
        public static DataTable GetAllEnrollments()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Enrollments";

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

        public static bool GetEnrollmentInfoByEnrollmentID(int EnrollmentID, ref int StudentID, ref int CourseID
            , ref DateTime EnrollmentDate, ref decimal Grade, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Enrollments WHERE StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", EnrollmentID);

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

                    EnrollmentID = (int)reader["StudentID"];
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

                    EnrollmentID = (int)reader["StudentID"];
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
                        StudentID = @StudentID,
                        CourseID = @CourseID,
                        EnrollmentDate = @EnrollmentDate,
                        Grade = @Grade,
                        Status = @Status
                        where StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", EnrollmentID);
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
                        where StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", EnrollmentID);

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

            string query = "SELECT Found=1 FROM Enrollments WHERE StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", StudentID);

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

    }
}
