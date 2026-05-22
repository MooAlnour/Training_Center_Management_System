using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC_DataAccess
{
   public class PaymentDL
    {
        public static DataTable GetAllPayments()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Payments";

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

        public static bool GetPaymentInfoByPaymentID(int PaymentID, ref int EnrollmentID, ref decimal Amount
            , ref DateTime PaymentDate, ref string Method, ref string Notes)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Payments WHERE PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PaymentID", PaymentID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    EnrollmentID = (int)reader["EnrollmentID"];
                    Amount = (decimal)reader["Amount"];
                    PaymentDate = (DateTime)reader["PaymentDate"];
                    Method = (string)reader["Method"];
                    Notes = (string)reader["Notes"];

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

        public static bool GetPaymentInfoByEnrollmentID(int EnrollmentID, ref int PaymentID, ref decimal Amount
            , ref DateTime PaymentDate, ref string Method, ref string Notes)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Payments WHERE EnrollmentID = @EnrollmentID";

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

                    PaymentID = (int)reader["PaymentID"];
                    Amount = (decimal)reader["Amount"];
                    PaymentDate = (DateTime)reader["PaymentDate"];
                    Method = (string)reader["Method"];
                    Notes = (string)reader["Notes"];

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

        public static bool GetPaymentInfoByMethod(string Method, ref int PaymentID, ref int EnrollmentID
            , ref decimal Amount, ref DateTime PaymentDate, ref string Notes)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Payments WHERE Method = @Method";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Method", Method);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    PaymentID = (int)reader["PaymentID"];
                    EnrollmentID = (int)reader["EnrollmentID"];
                    Amount = (decimal)reader["Amount"];
                    PaymentDate = (DateTime)reader["PaymentDate"];
                    Notes = (string)reader["Notes"];

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

        public static int AddNewPayment(int EnrollmentID, decimal Amount
            , DateTime PaymentDate, string Method, string Notes)
        {
            int PaymentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Payments (EnrollmentID,Amount,PaymentDate,Method,Notes)
                     VALUES (@EnrollmentID,@Amount,@PaymentDate,@Method,@Notes);
                     SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
            command.Parameters.AddWithValue("@Method", Method);
            command.Parameters.AddWithValue("@Notes", Notes);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PaymentID = insertedID;
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

            return PaymentID;
        }

        public static bool UpdatePayment(int PaymentID, int EnrollmentID, decimal Amount
            , DateTime PaymentDate, string Method, string Notes)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update Payments
                    set
                        EnrollmentID = @EnrollmentID,
                        Amount = @Amount,
                        PaymentDate = @PaymentDate,
                        Method = @Method,
                        Notes = @Notes
                        where PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PaymentID", PaymentID);
            command.Parameters.AddWithValue("@EnrollmentID", EnrollmentID);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
            command.Parameters.AddWithValue("@Method", Method);
            command.Parameters.AddWithValue("@Notes", Notes);

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

        public static bool DeletePayment(int PaymentID)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Payments
                        where PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PaymentID", PaymentID);

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

        public static bool IsPaymentExist(int PaymentID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Payments WHERE PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PaymentID", PaymentID);

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
