using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVanCau_SE18D07_A01.NguyenVanCauWPF.ViewModels
{
    public class BookingViewModel
    {
        public string RoomNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Booking OriginalBooking { get; set; }       
        public string RoomDescription { get; set; }
        public string RoomTypeName { get; set; }
    }
}
