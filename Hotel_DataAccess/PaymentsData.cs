using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq.Expressions;

namespace Hotel_DataAccess
{
    public class clsPaymentsData
    {

        public static bool GetPaymentInfoByID(int PaymentID, ref int ReservationID, ref DateTime PaymentDate, ref double Amount, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT * FROM Payments WHERE PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PaymentID", PaymentID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ReservationID = (int)reader["ReservationID"];
                    PaymentDate = (DateTime)reader["PaymentDate"];
                    Amount = (double)reader["Amount"];
                    Status = (byte)reader["Status"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {

                isFound = false;

            }
            finally
            {
                connection.Close();
            }


            return isFound;
        }

        public static bool GetPaymentInfoByReservationID(int ReservationID, ref int PaymentID, ref DateTime PaymentDate, ref double Amount, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT * FROM Payments WHERE ReservationID = @ReservationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ReservationID", ReservationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    PaymentID = (int)reader["PaymentID"];
                    PaymentDate = (DateTime)reader["PaymentDate"];
                    Amount = (double)reader["Amount"];
                    Status = (byte)reader["Status"];

                }
                reader.Close();

            }
            catch (Exception ex)
            {

                isFound = false;

            }
            finally
            {
                connection.Close();
            }


            return isFound;
        }

        public static int AddNewPayment(int ReservationID, DateTime PaymentDate, double Amount, byte Status)
        {
            int PaymentID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"INSERT INTO Payments (ReservationID, PaymentDate, Amount, Status)
                                VALUES (@ReservationID, @PaymentDate, @Amount, @Status);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReservationID", ReservationID);
            command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@Status", Status);


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

        public static bool UpdatePayment(int PaymentID, int ReservationID, DateTime PaymentDate, double Amount, byte Status)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"UPDATE Payments
                             SET ReservationID = @ReservationID,
                                 PaymentDate = @PaymentDate,
                                 Amount = @Amount,
                                 Status = @Status
                             WHERE PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@PaymentID", PaymentID);
            command.Parameters.AddWithValue("@ReservationID", ReservationID);
            command.Parameters.AddWithValue("@PaymentDate", PaymentDate);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@Status", Status);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
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

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"DELETE Payments WHERE PaymentID = @PaymentID";

            SqlCommand command = new SqlCommand(qeury, connection);

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

        public static bool IsPaymentExistByPaymentID(int PaymentID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

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
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsPaymentExistByReservationID(int ReservationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT Found=1 FROM Payments WHERE ReservationID = @ReservationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReservationID", ReservationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllPayments()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = "SELECT * FROM Payments";

            SqlCommand command = new SqlCommand(qeury, connection);

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

        public static double GetTotalAmountByReservationID(int ReservationID)
        {
            double TotalAmount = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString))
            {
                string qeury = @"SELECT SUM(Rooms.Price) FROM ReservationRooms
                                 INNER JOIN Rooms ON ReservationRooms.RoomID = Rooms.RoomID
                                 WHERE ReservationRooms.ReservationID = @ReservationID AND ReservationRooms.Status = 1;
                                 SELECT SCOPE_IDENTITY();";

                using (SqlCommand command = new SqlCommand(qeury, connection))
                {

                    command.Parameters.AddWithValue("@ReservationID", ReservationID);

                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        if (result != null && double.TryParse(result.ToString(), out double TPAmount))
                        {
                            TotalAmount = TPAmount;
                        }
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine(ex);
                    }
                }


            }

            return TotalAmount;
        }

    }
}
