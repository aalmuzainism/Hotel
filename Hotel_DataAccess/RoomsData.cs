using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Hotel_DataAccess
{
    public class clsRoomsData
    {

        public static bool GetRoomInfoByID(int RoomID, ref byte RoomTypeID, ref int RoomNumber, ref byte RoomCount, ref byte KingBedCount, ref byte SingleBedCount,
                            ref byte LivingRoomCount, ref byte BathroomCount, ref byte FullKitchenCount, ref byte KitchenetteCount, ref double Price)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT * FROM Rooms WHERE RoomID = @RoomID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomID", RoomID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    RoomTypeID = (byte)reader["RoomTypeID"];
                    RoomNumber = (int)reader["RoomNumber"];
                    RoomCount = (byte)reader["RoomCount"];
                    KingBedCount = (byte)reader["KingBedCount"];
                    SingleBedCount = (byte)reader["SingleBedCount"];
                    LivingRoomCount = (byte)reader["LivingRoomCount"];
                    BathroomCount = (byte)reader["BathroomCount"];
                    FullKitchenCount = (byte)reader["FullKitchenCount"];
                    KitchenetteCount = (byte)reader["KitchenetteCount"];
                    Price = Convert.ToDouble(reader["Price"]);

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

        public static bool GetRoomInfoByRoomNumber(int RoomNumber, ref int RoomID, ref byte RoomTypeID, ref byte RoomCount, ref byte KingBedCount, ref byte SingleBedCount,
                            ref byte LivingRoomCount, ref byte BathroomCount, ref byte FullKitchenCount, ref byte KitchenetteCount, ref double Price)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT * FROM Rooms WHERE RoomNumber = @RoomNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomNumber", RoomNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    RoomID = (int)reader["RoomID"];
                    RoomTypeID = (byte)reader["RoomTypeID"];
                    RoomNumber = (int)reader["RoomNumber"];
                    RoomCount = (byte)reader["RoomCount"];
                    KingBedCount = (byte)reader["KingBedCount"];
                    SingleBedCount = (byte)reader["SingleBedCount"];
                    LivingRoomCount = (byte)reader["LivingRoomCount"];
                    BathroomCount = (byte)reader["BathroomCount"];
                    FullKitchenCount = (byte)reader["FullKitchenCount"];
                    KitchenetteCount = (byte)reader["KitchenetteCount"];
                    Price = Convert.ToDouble(reader["Price"]);

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

        public static int AddNewRoom(int RoomTypeID, int RoomNumber, byte RoomCount, byte KingBedCount, byte SingleBedCount, byte LivingRoomCount,
                                     byte BathroomCount, byte FullKitchenCount, byte KitchenetteCount, double Price)
        {
            int RoomID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"INSERT INTO Rooms (RoomTypeID, RoomNumber, RoomCount, KingBedCount, SingleBedCount, LivingRoomCount, BathroomCount, FullKitchenCount, KitchenetteCount, Price)
                                        VALUES (@RoomTypeID, @RoomNumber, @RoomCount, @KingBedCount, @SingleBedCount, @LivingRoomCount, @BathroomCount, @FullKitchenCount, @KitchenetteCount, @Price);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomTypeID", RoomTypeID);
            command.Parameters.AddWithValue("@RoomNumber", RoomNumber);
            command.Parameters.AddWithValue("@RoomCount", RoomCount);
            command.Parameters.AddWithValue("@KingBedCount", KingBedCount);
            command.Parameters.AddWithValue("@SingleBedCount", SingleBedCount);
            command.Parameters.AddWithValue("@LivingRoomCount", LivingRoomCount);
            command.Parameters.AddWithValue("@BathroomCount", BathroomCount);
            command.Parameters.AddWithValue("@FullKitchenCount", FullKitchenCount);
            command.Parameters.AddWithValue("@KitchenetteCount", KitchenetteCount);
            command.Parameters.AddWithValue("@Price", Price);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    RoomID = insertedID;
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

            return RoomID;
            
        }

        public static bool UpdateRoom(int RoomID, int RoomTypeID, int RoomNumber, byte RoomCount, byte KingBedCount, byte SingleBedCount, byte LivingRoomCount,
                                     byte BathroomCount, byte FullKitchenCount, byte KitchenetteCount, double Price)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"UPDATE Rooms
                             SET RoomTypeID = @RoomTypeID,
                                 RoomNumber = @RoomNumber,
                                 RoomCount = @RoomCount,
                                 KingBedCount = @KingBedCount,
                                 SingleBedCount = @SingleBedCount,
                                 LivingRoomCount = @LivingRoomCount,
                                 BathroomCount = @BathroomCount,
                                 FullKitchenCount = @FullKitchenCount,
                                 KitchenetteCount = @KitchenetteCount,
                                 Price = @Price
                             WHERE RoomID = @RoomID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@RoomID", RoomID);
            command.Parameters.AddWithValue("@RoomTypeID", RoomTypeID);
            command.Parameters.AddWithValue("@RoomNumber", RoomNumber);
            command.Parameters.AddWithValue("@RoomCount", RoomCount);
            command.Parameters.AddWithValue("@KingBedCount", KingBedCount);
            command.Parameters.AddWithValue("@SingleBedCount", SingleBedCount);
            command.Parameters.AddWithValue("@LivingRoomCount", LivingRoomCount);
            command.Parameters.AddWithValue("@BathroomCount", BathroomCount);
            command.Parameters.AddWithValue("@FullKitchenCount", FullKitchenCount);
            command.Parameters.AddWithValue("@KitchenetteCount", KitchenetteCount);
            command.Parameters.AddWithValue("@Price", Price);

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

        public static bool DeleteRoomByID(int RoomID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"DELETE Rooms WHERE RoomID = @RoomID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@RoomID", RoomID);

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

        public static bool DeleteRoomByRoomNumber(int RoomNumber)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"DELETE Rooms WHERE RoomNumber = @RoomNumber";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@RoomNumber", RoomNumber);

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

        public static bool IsRoomExistByRoomID(int RoomID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT Found=1 FROM Rooms WHERE RoomID = @RoomID";

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

        public static bool IsRoomExistByRoomNumber(int RoomNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT Found=1 FROM Rooms WHERE RoomNumber = @RoomNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomNumber", RoomNumber);

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

        public static DataTable GetAllRooms()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = "SELECT * FROM Rooms";

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


    }
}
