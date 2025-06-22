using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVanCau_SE18D07_A01.BusinessObjects.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; } // max length 50
        public string RoomDescription { get; set; } // max 220
        public int RoomMaxCapacity { get; set; }
        public int RoomStatus { get; set; } // 1: Active, 2: Deleted
        public decimal RoomPricePerDate { get; set; }
        public int RoomTypeID { get; set; } // Foreign key to RoomType

        public override string ToString()
        {
            return $"Room {RoomNumber} (Capacity: {RoomMaxCapacity})";
        }
    }
}
