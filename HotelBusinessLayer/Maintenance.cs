using Hotel_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBusinessLayer
{
    public class clsMaintenance
    {

        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;

        public int MaintenanceID { get; set; }
        public int RoomID { get; set; }
        clsRooms RoomInfo { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }

        public clsMaintenance()
        {
            this.MaintenanceID = -1;
            this.RoomID = -1;
            this.Description = "";
            this.Status = 0;

            this.Mode = enMode.AddNew;
        }

        private clsMaintenance(int MaintenanceID, int RoomID, string Description, byte Status)
        {
            this.MaintenanceID = MaintenanceID;
            this.RoomID = RoomID;
            this.RoomInfo = clsRooms.GetRoomInfoByID(this.RoomID);
            this.Description = Description;
            this.Status = Status;

            this.Mode = enMode.Update;
        }

        public static clsMaintenance GetMaintenanceInfoByID(int MaintenanceID)
        {
            int RoomID = -1;
            string Description = "";
            byte Status = 0;

            if (clsMaintenanceData.GetMaintenanceInfoByID(MaintenanceID, ref RoomID, ref Description, ref Status))
            {
                return new clsMaintenance(MaintenanceID, RoomID, Description, Status);
            }
            else
            {
                return null;
            }
        }
        public static clsMaintenance GetMaintenanceInfoByRoomID(int RoomID)
        {
            int MaintenanceID = -1;
            string Description = "";
            byte Status = 0;

            if (clsMaintenanceData.GetMaintenanceInfoByRoomID(RoomID, ref MaintenanceID, ref Description, ref Status))
            {
                return new clsMaintenance(MaintenanceID, RoomID, Description, Status);
            }
            else
            {
                return null;
            }
        }

        private bool _AddNewMaintenance()
        {
            this.MaintenanceID = clsMaintenanceData.AddNewMaintenance(this.RoomID, this.Description, this.Status);

            return (this.MaintenanceID != -1);
        }

        private bool _UpdateMaintenance()
        {
            return clsMaintenanceData.UpdateMaintenance(this.MaintenanceID, this.RoomID, this.Description, this.Status);
        }

        public bool MaintenanceComplete()
        {
            if (this.Status != 1)
                return false;

            return clsMaintenanceData.MaintenanceComplete(this.MaintenanceID);
        }
        public bool MaintenanceCancel()
        {
            if (this.Status == 2) // 2 = Completed
                return false;

            return clsMaintenanceData.MaintenanceCancel(this.MaintenanceID);
        }

        public bool DeleteMaintenance()
        {
            return clsMaintenanceData.DeleteMaintenance(this.MaintenanceID);
        }

        public static bool IsMaintenanceExistByRoomID(int RoomID)
        {
            return clsMaintenanceData.IsMaintenanceExistByRoomID(RoomID);
        }

        public static DataTable GetAllMaintenance()
        {
            return clsMaintenanceData.GetAllMaintenance();
        }

        public static bool DoesRoomNeedMaintenance(int RoomID)
        {
            return clsMaintenanceData.DoesRoomNeedMaintenance(RoomID);
        }

        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewMaintenance())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateMaintenance();


            }

            return false;
        }

    }
}
