using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Hotel_DataAccess
{
    public class clsMaintenanceData
    {

        public static bool GetMaintenanceInfoByID(int MaintenanceID, ref int RoomID, ref string Description, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT * FROM Maintenance WHERE MaintenanceID = @MaintenanceID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("MaintenanceID", MaintenanceID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    RoomID = (int)reader["RoomID"];
                    Description = (string)reader["Description"];
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

        public static bool GetMaintenanceInfoByRoomID(int RoomID, ref int MaintenanceID, ref string Description, ref byte Status)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT * FROM Maintenance WHERE RoomID = @RoomID AND Status = 1";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("RoomID", RoomID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    MaintenanceID = (int)reader["MaintenanceID"];
                    Description = (string)reader["Description"];
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

        public static int AddNewMaintenance(int RoomID, string Description, byte Status)
        {
            int MaintenanceID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"INSERT INTO Maintenance (RoomID, Description, Status)
                                VALUES (@RoomID, @Description, @Status);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@RoomID", RoomID);
            command.Parameters.AddWithValue("@Description", Description);
            command.Parameters.AddWithValue("@Status", Status);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    MaintenanceID = insertedID;
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

            return MaintenanceID;
        }

        public static bool UpdateMaintenance(int MaintenanceID, int RoomID, string Description, byte Status)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"UPDATE Maintenance
                             SET RoomID = @RoomID,
                                 Description = @Description,
                                 Status = @Status
                             WHERE MaintenanceID = @MaintenanceID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);
            command.Parameters.AddWithValue("@RoomID", RoomID);
            command.Parameters.AddWithValue("@Description", Description);
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

        public static bool DeleteMaintenance(int MaintenanceID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"DELETE Maintenance WHERE MaintenanceID = @MaintenanceID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);

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

        public static bool IsMaintenanceExistByRoomID(int RoomID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = "SELECT Found=1 FROM Maintenance WHERE RoomID = @RoomID AND Status = 1";

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

        public static DataTable GetAllMaintenance()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = "SELECT * FROM Maintenance";

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

        public static bool MaintenanceComplete(int MaintenanceID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"UPDATE Maintenance
                             SET Status = 2
                             WHERE MaintenanceID = @MaintenanceID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);


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

        public static bool MaintenanceCancel(int MaintenanceID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string qeury = @"UPDATE Maintenance
                             SET Status = 3
                             WHERE MaintenanceID = @MaintenanceID";

            SqlCommand command = new SqlCommand(qeury, connection);

            command.Parameters.AddWithValue("@MaintenanceID", MaintenanceID);


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

        public static bool DoesRoomNeedMaintenance(int RoomID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSetings.ConnectionString);

            string query = @"SELECT Found=1 From Maintenance
                            WHERE Maintenance.RoomID = @RoomID AND (Maintenance.Status = 1)";

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
    }
}
