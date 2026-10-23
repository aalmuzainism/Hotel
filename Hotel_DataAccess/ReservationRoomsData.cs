using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_DataAccess
{
    public class clsReservationRoomsData
    {

        public static bool GetReservationRoomInfoByID(int ReservationRoomID, ref int ReservationID, ref int RoomID, ref DateTime CheckInDate,
                                    ref int CheckInBy, ref DateTime CheckOutDate, ref DateTime ActualCheckOutDate, ref int CheckOutBy, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT * FROM ReservationRooms WHERE ReservationRoomID = @ReservationRoomID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReservationRoomID", ReservationRoomID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ReservationID = (int)reader["ReservationID"];
                    RoomID = (int)reader["RoomID"];
                    CheckInDate = (DateTime)reader["CheckInDate"];

                    if (reader["CheckInBy"] != DBNull.Value)
                        CheckInBy = (int)reader["CheckInBy"];
                    else
                        CheckInBy = -1;

                    CheckOutDate = (DateTime)reader["CheckOutDate"];

                    if (reader["ActualCheckOutDate"] != DBNull.Value)
                        ActualCheckOutDate = (DateTime)reader["ActualCheckOutDate"];
                    else
                        ActualCheckOutDate = ActualCheckOutDate = DateTime.MaxValue;

                    if (reader["CheckOutBy"] != DBNull.Value)
                        CheckOutBy = (int)reader["CheckOutBy"];
                    else
                        CheckOutBy = -1;

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

        public static bool GetReservationRoomInfoByReservationID(int ReservationID, ref int ReservationRoomID, ref int RoomID, ref DateTime CheckInDate,
                                    ref int CheckInBy, ref DateTime CheckOutDate, ref DateTime ActualCheckOutDate, ref int CheckOutBy, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT * FROM ReservationRooms WHERE ReservationID = @ReservationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReservationID", ReservationID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ReservationRoomID = (int)reader["ReservationRoomID"];
                    RoomID = (int)reader["RoomID"];
                    CheckInDate = (DateTime)reader["CheckInDate"];

                    if (reader["CheckInBy"] != DBNull.Value)
                        CheckInBy = (int)reader["CheckInBy"];
                    else
                        CheckInBy = -1;

                    CheckOutDate = (DateTime)reader["CheckOutDate"];

                    if (reader["ActualCheckOutDate"] != DBNull.Value)
                        ActualCheckOutDate = (DateTime)reader["ActualCheckOutDate"];
                    else
                        ActualCheckOutDate = ActualCheckOutDate = DateTime.MaxValue;

                    if (reader["CheckOutBy"] != DBNull.Value)
                        CheckOutBy = (int)reader["CheckOutBy"];
                    else
                        CheckOutBy = -1;

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

        public static bool GetReservationRoomInfoByRoomID(int RoomID, ref int ReservationRoomID, ref int ReservationID, ref DateTime CheckInDate,
                                    ref int CheckInBy, ref DateTime CheckOutDate, ref DateTime ActualCheckOutDate, ref int CheckOutBy, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"SELECT * FROM ReservationRooms
                             WHERE ReservationRooms.RoomID = @RoomID AND (ReservationRooms.Status = 1 OR ReservationRooms.Status = 2)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomID", RoomID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ReservationRoomID = (int)reader["ReservationRoomID"];
                    ReservationID = (int)reader["ReservationID"];
                    CheckInDate = (DateTime)reader["CheckInDate"];

                    if (reader["CheckInBy"] != DBNull.Value)
                        CheckInBy = (int)reader["CheckInBy"];
                    else
                        CheckInBy = -1;

                    CheckOutDate = (DateTime)reader["CheckOutDate"];

                    if (reader["ActualCheckOutDate"] != DBNull.Value)
                        ActualCheckOutDate = (DateTime)reader["ActualCheckOutDate"];
                    else
                        ActualCheckOutDate = DateTime.MaxValue;

                    if (reader["CheckOutBy"] != DBNull.Value)
                        CheckOutBy = (int)reader["CheckOutBy"];
                    else
                        CheckOutBy = -1;

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

        public static bool GetReservationRoomInfoByRoomIDForCheckOut(int RoomID, ref int ReservationRoomID, ref int ReservationID, ref DateTime CheckInDate,
                                    ref int CheckInBy, ref DateTime CheckOutDate, ref DateTime ActualCheckOutDate, ref int CheckOutBy, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"SELECT * FROM ReservationRooms
                             WHERE ReservationRooms.RoomID = @RoomID AND (ReservationRooms.Status = 2)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomID", RoomID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ReservationRoomID = (int)reader["ReservationRoomID"];
                    ReservationID = (int)reader["ReservationID"];
                    CheckInDate = (DateTime)reader["CheckInDate"];

                    if (reader["CheckInBy"] != DBNull.Value)
                        CheckInBy = (int)reader["CheckInBy"];
                    else
                        CheckInBy = -1;

                    CheckOutDate = (DateTime)reader["CheckOutDate"];

                    if (reader["ActualCheckOutDate"] != DBNull.Value)
                        ActualCheckOutDate = (DateTime)reader["ActualCheckOutDate"];
                    else
                        ActualCheckOutDate = DateTime.MaxValue;

                    if (reader["CheckOutBy"] != DBNull.Value)
                        CheckOutBy = (int)reader["CheckOutBy"];
                    else
                        CheckOutBy = -1;

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

        public static bool GetReservationRoomInfoByRoomIDForCheckIn(int RoomID, ref int ReservationRoomID, ref int ReservationID, ref DateTime CheckInDate,
                                    ref int CheckInBy, ref DateTime CheckOutDate, ref DateTime ActualCheckOutDate, ref int CheckOutBy, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"SELECT * FROM ReservationRooms
                             WHERE ReservationRooms.RoomID = @RoomID AND (ReservationRooms.Status = 1)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomID", RoomID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ReservationRoomID = (int)reader["ReservationRoomID"];
                    ReservationID = (int)reader["ReservationID"];
                    CheckInDate = (DateTime)reader["CheckInDate"];

                    if (reader["CheckInBy"] != DBNull.Value)
                        CheckInBy = (int)reader["CheckInBy"];
                    else
                        CheckInBy = -1;

                    CheckOutDate = (DateTime)reader["CheckOutDate"];

                    if (reader["ActualCheckOutDate"] != DBNull.Value)
                        ActualCheckOutDate = (DateTime)reader["ActualCheckOutDate"];
                    else
                        ActualCheckOutDate = DateTime.MaxValue;

                    if (reader["CheckOutBy"] != DBNull.Value)
                        CheckOutBy = (int)reader["CheckOutBy"];
                    else
                        CheckOutBy = -1;

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

        public static int AddNewReservationRoom(int ReservationID, int RoomID, DateTime CheckInDate, DateTime CheckOutDate, byte Status)
        {
            int ReservationRoomID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"INSERT INTO ReservationRooms
                                        (ReservationID, RoomID, CheckInDate, CheckOutDate, Status)
                            VALUES      (@ReservationID, @RoomID, @CheckInDate, @CheckOutDate, @Status);
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@ReservationID", ReservationID);
            command.Parameters.AddWithValue("@RoomID", RoomID);
            command.Parameters.AddWithValue("@CheckInDate", CheckInDate);
            command.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);
            command.Parameters.AddWithValue("@Status", Status);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ReservationRoomID = insertedID;
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

            return ReservationRoomID;
        }

        public static bool UpdateReservationRoom(int ReservationRoomID, int ReservationID, int RoomID, DateTime CheckInDate,
                                                DateTime CheckOutDate, byte Status)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"UPDATE ReservationRooms
                             SET ReservationID = @ReservationID,
                                 RoomID = @RoomID,
                                 CheckInDate = @CheckInDate,
                                 CheckOutDate = @CheckOutDate,
                                 Status = @Status
                             WHERE ReservationRoomID = @ReservationRoomID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@ReservationRoomID", ReservationRoomID);
            command.Parameters.AddWithValue("@ReservationID", ReservationID);
            command.Parameters.AddWithValue("@RoomID", RoomID);
            command.Parameters.AddWithValue("@CheckInDate", CheckInDate);
            command.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);
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

        public static bool CheckIn(int ReservationRoomID, int CheckInBy)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"UPDATE ReservationRooms
                             SET CheckInBy = @CheckInBy,
                                 Status = 2
                             WHERE ReservationRoomID = @ReservationRoomID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@ReservationRoomID", ReservationRoomID);

            if (CheckInBy != -1)
                command.Parameters.AddWithValue("@CheckInBy", CheckInBy);
            else
                return false;


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

        public static bool CheckOut(int ReservationRoomID, DateTime ActualCheckOutDate, int CheckOutBy)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"UPDATE ReservationRooms
                             SET ActualCheckOutDate = @ActualCheckOutDate,
                                 CheckOutBy = @CheckOutBy,
                                 Status = 3
                             WHERE ReservationRoomID = @ReservationRoomID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@ReservationRoomID", ReservationRoomID);

            if (ActualCheckOutDate != DateTime.MaxValue)
                command.Parameters.AddWithValue("@ActualCheckOutDate", ActualCheckOutDate);
            else
                return false;


            if (CheckOutBy != -1)
                command.Parameters.AddWithValue("@CheckOutBy", CheckOutBy);
            else
                return false;



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

        public static bool Cancel(int ReservationRoomID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"UPDATE ReservationRooms
                             SET ReservationRooms.Status = 4
                             WHERE ReservationRoomID = @ReservationRoomID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@ReservationRoomID", ReservationRoomID);

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

        public static bool DeleteReservationRoom(int ReservationRoomID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"DELETE ReservationRooms WHERE ReservationRoomID = @ReservationRoomID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@ReservationRoomID", ReservationRoomID);

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

        public static bool IsReservationRoomExist(int ReservationRoomID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT Found=1 FROM ReservationRooms WHERE ReservationRoomID = @ReservationRoomID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReservationRoomID", ReservationRoomID);

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

        public static bool IsReservationRoomCheckedIn(int ReservationRoomID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"SELECT Found=1 FROM ReservationRooms WHERE ReservationRooms.ReservationRoomID = @ReservationRoomID
                             AND ReservationRooms.Status = 2";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReservationRoomID", ReservationRoomID);

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

        public static bool IsReservationRoomNotCheckedIn(int ReservationRoomID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"SELECT Found=1 FROM ReservationRooms WHERE ReservationRooms.ReservationRoomID = @ReservationRoomID
                             AND ReservationRooms.Status = 1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ReservationRoomID", ReservationRoomID);

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

        public static bool IsRoomBooked(int RoomID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"SELECT Found=1 From ReservationRooms
                            WHERE ReservationRooms.RoomID = @RoomID AND (ReservationRooms.Status = 1 OR ReservationRooms.Status = 2)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomID", RoomID);

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

        public static bool IsReservationRoomWithDateByRoomNumber(int RoomNumber, DateTime CheckInDate, DateTime CheckOutDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"SELECT FOUND=1 FROM Rooms
                             INNER JOIN ReservationRooms
                             ON ReservationRooms.RoomID = Rooms.RoomID
                             
                             WHERE Rooms.RoomNumber = @RoomNumber
                             AND (@CheckOutDate > CheckInDate)
                             AND (@CheckInDate < CheckOutDate)
                             AND (ReservationRooms.Status = 1 OR ReservationRooms.Status = 2)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomNumber", RoomNumber);
            command.Parameters.AddWithValue("@CheckInDate", CheckInDate);
            command.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);

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

        public static bool GetReservationRoomWithDateByRoomNumber(int RoomID, ref DateTime CheckInDate, ref DateTime CheckOutDate, ref int ReservationRoomID,
                                        ref int ReservationID, ref int CheckInBy, ref DateTime ActualCheckOutDate, ref int CheckOutBy, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"SELECT * FROM Rooms
                             INNER JOIN ReservationRooms
                             ON ReservationRooms.RoomID = Rooms.RoomID
                             
                             WHERE Rooms.RoomID = @RoomID
                             AND (@CheckOutDate > CheckInDate)
                             AND (@CheckInDate < CheckOutDate)
                             AND (ReservationRooms.Status = 1 OR ReservationRooms.Status = 2)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomID", RoomID);
            command.Parameters.AddWithValue("@CheckInDate", CheckInDate);
            command.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    ReservationRoomID = (int)reader["ReservationRoomID"];
                    ReservationID = (int)reader["ReservationID"];

                    if (reader["CheckInBy"] != DBNull.Value)
                        CheckInBy = (int)reader["CheckInBy"];
                    else
                        CheckInBy = -1;

                    CheckInDate = (DateTime)reader["CheckInDate"];
                    CheckOutDate = (DateTime)reader["CheckOutDate"];


                    if (reader["ActualCheckOutDate"] != DBNull.Value)
                        ActualCheckOutDate = (DateTime)reader["ActualCheckOutDate"];
                    else
                        ActualCheckOutDate = ActualCheckOutDate = DateTime.MaxValue;


                    if (reader["CheckOutBy"] != DBNull.Value)
                        CheckOutBy = (int)reader["CheckOutBy"];
                    else
                        CheckOutBy = -1;

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

        public static bool IsRoomBookedWithDateByRoomID(int RoomID, DateTime CheckInDate, DateTime CheckOutDate)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"SELECT FOUND=1 FROM Rooms
                             INNER JOIN ReservationRooms
                             ON ReservationRooms.RoomID = Rooms.RoomID
                             
                             WHERE Rooms.RoomID = @RoomID
                             AND (@CheckOutDate > CheckInDate)
                             AND (@CheckInDate < CheckOutDate)
                             AND (ReservationRooms.Status = 1 OR ReservationRooms.Status = 2)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomID", RoomID);
            command.Parameters.AddWithValue("@CheckInDate", CheckInDate);
            command.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);

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

        public static DataTable GetAllAvailableRoomsWithRoomCount(byte RoomCount, DateTime CheckInDate, DateTime CheckOutDate)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"SELECT * FROM Rooms
                             WHERE Rooms.RoomCount = @RoomCount
                             AND NOT Exists ( 
                             SELECT 1 FROM ReservationRooms
                             WHERE ReservationRooms.RoomID = Rooms.RoomID
                             AND CheckInDate < @CheckOutDate
                             AND CheckOutDate > @CheckInDate
                             AND (ReservationRooms.Status = 1 OR ReservationRooms.Status = 2) )";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@RoomCount", RoomCount);
            command.Parameters.AddWithValue("@CheckInDate", CheckInDate);
            command.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);

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

        public static DataTable GetAllAvailableRooms(DateTime CheckInDate, DateTime CheckOutDate)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"SELECT * FROM Rooms
                             WHERE NOT Exists
                             ( 
                             SELECT 1 FROM ReservationRooms
                             WHERE ReservationRooms.RoomID = Rooms.RoomID
                             AND CheckInDate < @CheckOutDate
                             AND CheckOutDate > @CheckInDate
                             AND (ReservationRooms.Status = 1 OR ReservationRooms.Status = 2)
                             )";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@CheckInDate", CheckInDate);
            command.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);

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

        public static DataTable GetAllReservationRooms()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = "SELECT * FROM ReservationRooms";

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

        public static DataTable GetAllReservationRoomsCheckInToday(DateTime CheckInDate)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"SELECT * FROM ReservationRooms
                            WHERE CAST( ReservationRooms.CheckInDate AS date) = @CheckInDate AND ReservationRooms.Status = 1";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@CheckInDate", CheckInDate);

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

        public static DataTable GetAllReservationRoomsCheckOutToday(DateTime CheckOutDate)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"SELECT * FROM ReservationRooms
                            WHERE CAST( ReservationRooms.CheckOutDate AS date) = @CheckOutDate AND (ReservationRooms.Status = 2 OR ReservationRooms.Status = 1)";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@CheckOutDate", CheckOutDate);

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

        public static DataTable GetAllReservationRoomsForPersonByNationalID(string NationalID)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"SELECT ReservationRooms.* FROM ReservationRooms
                             INNER JOIN Reservations ON Reservations.ReservationID = ReservationRooms.ReservationID
                             INNER JOIN People ON People.PersonID = Reservations.PersonID
                             WHERE People.NationalID = @NationalID AND (ReservationRooms.Status = 1 OR ReservationRooms.Status = 2)";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@NationalID", NationalID);

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

    }
}