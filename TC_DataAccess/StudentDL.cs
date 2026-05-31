using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC_DataAccess
{
   public class StudentDL
    {
        public static DataTable GetAllStudents()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Students";

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

        public static bool GetStudentInfoByStudentID(int StudentID, ref string FullName,ref string Phone
               ,ref string Email,ref DateTime DataOfBrith, ref DateTime RegistrationDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Students WHERE StudentID = @StudentID";

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
                    FullName = (string)reader["FullName"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    RegistrationDate = (DateTime)reader["RegistrationDate"];
                    DataOfBrith = (DateTime)reader["DateOfBirth"];

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

        public static bool GetStudentInfoByFullName(string FullName, ref int StudentID, ref string Phone
               , ref string Email, ref DateTime DataOfBrith, ref DateTime RegistrationDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Students WHERE FullName = @FullName;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FullName", FullName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    RegistrationDate = (DateTime)reader["RegistrationDate"];
                    DataOfBrith = (DateTime)reader["DataOfBrith"];
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

        public static bool GetStudentInfoByPhone(string Phone, ref int StudentID, ref string FullName
              , ref string Email, ref DateTime DataOfBrith, ref DateTime RegistrationDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Students WHERE Phone = @Phone";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Phone", Phone);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;
                    FullName = (string)reader["FullName"];
                    StudentID = (int)reader["StudentID"];
                    Email = (string)reader["Email"];
                    RegistrationDate = (DateTime)reader["RegistrationDate"];
                    DataOfBrith = (DateTime)reader["DataOfBrith"];

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

        public static int AddNewStudent(string FullName, string Phone
               , string Email,DateTime DataOfBrith, DateTime RegistrationDate)
        {
            int StudentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Students (FullName,Phone,Email,DateOfBirth,RegistrationDate)
                             VALUES (@FullName,@Phone,@Email,@DateOfBirth,@RegistrationDate);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FullName", FullName);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@DateOfBirth", DataOfBrith);
            command.Parameters.AddWithValue("@RegistrationDate", RegistrationDate);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    StudentID = insertedID;
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

            return StudentID;
        }

        public static bool UpdateStudent(int StudentID,string FullName, string Phone
               , string Email, DateTime DateOfBrith)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Students  
                            set 
                                FullName = @FullName,
                                Phone = @Phone,
                                DateOfBirth = @DateOfBirth,
                                Email = @Email
                                where StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@StudentID", StudentID);
            command.Parameters.AddWithValue("@FullName", FullName);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBrith);



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

        public static bool DeleteStudent(int StudentID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Students 
                                where StudentID = @StudentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@StudentID", StudentID);

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

        public static bool IsEmailExist(string Email)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Students WHERE Email = @Email";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Phone", Email);

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

        public static bool IsPhoneExist(string Phone)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Students WHERE Phone = @Phone";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Phone", Phone);

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
