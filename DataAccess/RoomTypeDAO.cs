using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NguyenVanCau_SE18D07_A01.DataAccess
{
    public class RoomTypeDAO
    {
        private static RoomTypeDAO instance = null;
        private static readonly object lockObj = new();

        private List<RoomType> roomTypes;

        private RoomTypeDAO()
        {
            // Khởi tạo dữ liệu mẫu
            roomTypes = new List<RoomType>
            {
                new RoomType
                {
                    RoomTypeID = 1,
                    RoomTypeName = "Deluxe",
                    TypeDescription = "Phòng cao cấp dành cho 2 người",
                    TypeNote = "Có ban công, view biển"
                },
                new RoomType
                {
                    RoomTypeID = 2,
                    RoomTypeName = "Standard",
                    TypeDescription = "Phòng tiêu chuẩn",
                    TypeNote = "Giá rẻ, phù hợp gia đình"
                }
            };
        }

        public static RoomTypeDAO Instance
        {
            get
            {
                lock (lockObj)
                {
                    return instance ??= new RoomTypeDAO();
                }
            }
        }

        public List<RoomType> GetAll() => roomTypes;

        public RoomType? GetByID(int id) => roomTypes.FirstOrDefault(rt => rt.RoomTypeID == id);

        public void Add(RoomType type)
        {
            type.RoomTypeID = roomTypes.Any() ? roomTypes.Max(rt => rt.RoomTypeID) + 1 : 1;
            roomTypes.Add(type);
        }

        public void Update(RoomType type)
        {
            var existing = roomTypes.FirstOrDefault(rt => rt.RoomTypeID == type.RoomTypeID);
            if (existing != null)
            {
                existing.RoomTypeName = type.RoomTypeName;
                existing.TypeDescription = type.TypeDescription;
                existing.TypeNote = type.TypeNote;
            }
        }

        public void Delete(int id)
        {
            var toRemove = roomTypes.FirstOrDefault(rt => rt.RoomTypeID == id);
            if (toRemove != null)
            {
                roomTypes.Remove(toRemove); // hoặc RoomTypeStatus nếu dùng soft delete
            }
        }
    }
}
