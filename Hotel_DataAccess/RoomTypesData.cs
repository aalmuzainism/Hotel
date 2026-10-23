using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Hotel_DataAccess
{
    public class clsRoomTypesData
    {

        public static bool GetRoomTypeInfoByID(int RoomTypeID, ref string Name, ref string Description)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT * FROM RoomTypes WHERE RoomTypeID = @RoomTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomTypeID", RoomTypeID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    Name = (string)reader["Name"];
                    Description = (string)reader["Description"];

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

        public static bool GetRoomTypeInfoByName(string Name, ref int RoomTypeID, ref string Description)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT * FROM RoomTypes WHERE Name = @Name";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    RoomTypeID = Convert.ToInt32( reader["RoomTypeID"]);
                    Description = Convert.ToString( reader["Description"]);

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

        public static int AddNewRoomType(string Name, string Description)
        {
            int RoomTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"INSERT INTO RoomTypes (Name, Description)
                                VALUES (@Name, @Description);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Description", Description);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    RoomTypeID = insertedID;
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

            return RoomTypeID;
        }

        public static bool UpdateRoomType(int RoomTypeID, string Name, string Description)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"UPDATE RoomTypes
                             SET Name = @Name,
                                 Description = @Description
                             WHERE RoomTypeID = @RoomTypeID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@RoomTypeID", RoomTypeID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Description", Description);

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

        public static bool DeleteRoomType(int RoomTypeID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"DELETE RoomTypes WHERE RoomTypeID = @RoomTypeID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@RoomTypeID", RoomTypeID);

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

        public static bool IsRoomTypeExist(int RoomTypeID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT Found=1 FROM RoomTypes WHERE RoomTypeID = @RoomTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomTypeID", RoomTypeID);

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

        public static DataTable GetAllRoomTypes()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = "SELECT * FROM RoomTypes";

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
