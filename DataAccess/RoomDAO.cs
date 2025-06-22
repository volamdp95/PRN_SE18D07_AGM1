using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVanCau_SE18D07_A01.DataAccess
{
    public class RoomDAO
    {
        private static RoomDAO instance = null;
        private static readonly object lockObj = new();
        private List<Room> rooms;

        // Khởi tạo dữ liệu mẫu
        private RoomDAO()
        {
            rooms = new List<Room>
            {
                new Room
                {
                    RoomID = 1,
                    RoomNumber = "101",
                    RoomDescription = "Deluxe Sea View Room",
                    RoomMaxCapacity = 2,
                    RoomStatus = 1,
                    RoomPricePerDate = 1500000,
                    RoomTypeID = 1
                },
                new Room
                {
                    RoomID = 2,
                    RoomNumber = "102",
                    RoomDescription = "Standard Garden View Room",
                    RoomMaxCapacity = 3,
                    RoomStatus = 1,
                    RoomPricePerDate = 1200000,
                    RoomTypeID = 2
                }
            };
        }

        public static RoomDAO Instance
        {
            get
            {
                lock (lockObj)
                {
                    return instance ??= new RoomDAO();
                }
            }
        }

        public List<Room> GetAll() => rooms.Where(r => r.RoomStatus == 1).ToList();

        public Room? GetByID(int id) => rooms.FirstOrDefault(r => r.RoomID == id);

        public void Add(Room room)
        {
            room.RoomID = rooms.Any() ? rooms.Max(r => r.RoomID) + 1 : 1;
            rooms.Add(room);
        }

        public void Update(Room room)
        {
            var existing = rooms.FirstOrDefault(r => r.RoomID == room.RoomID);
            if (existing != null)
            {
                existing.RoomNumber = room.RoomNumber;
                existing.RoomDescription = room.RoomDescription;
                existing.RoomMaxCapacity = room.RoomMaxCapacity;
                existing.RoomPricePerDate = room.RoomPricePerDate;
                existing.RoomTypeID = room.RoomTypeID;
                existing.RoomStatus = room.RoomStatus;
            }
        }

        public void Delete(int id)
        {
            var room = rooms.FirstOrDefault(r => r.RoomID == id);
            if (room != null)
            {
                room.RoomStatus = 2; // Soft delete
            }
        }

        public List<Room> Search(string keyword)
        {
            keyword = keyword?.ToLower() ?? "";
            return rooms.Where(r =>
                r.RoomNumber.ToLower().Contains(keyword) ||
                r.RoomDescription.ToLower().Contains(keyword)
            ).Where(r => r.RoomStatus == 1).ToList();
        }

        public List<Room> GetAvailableRooms(DateTime from, DateTime to)
        {
            return rooms.Where(r => r.RoomStatus == 1).ToList();
        }
    }
}
