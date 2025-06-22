using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVanCau_SE18D07_A01.NguyenVanCauWPF.ViewModels
{
    public class RoomViewModel
    {
        public string RoomNumber { get; set; }
        public string RoomTypeName { get; set; }
        public string PriceDisplay { get; set; }
        public Room OriginalRoom { get; set; }
        public string RoomDescription { get; set; }
    }
}
