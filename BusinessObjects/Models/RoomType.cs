using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVanCau_SE18D07_A01.BusinessObjects.Models
{
    public class RoomType
    {
        public int RoomTypeID { get; set; }
        public string RoomTypeName { get; set; } // max 50
        public string TypeDescription { get; set; } // max 250
        public string TypeNote { get; set; } // max 250

        public override string ToString()
        {
            return RoomTypeName;
        }
    }
}
