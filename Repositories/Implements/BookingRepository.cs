using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVanCau_SE18D07_A01.Repositories.Implements
{
    public class BookingRepository
    {
        private static List<Booking> bookings = new()
        {
            new Booking
            {
                BookingID = 1,
                Customer = new Customer { CustomerFullName = "Alice" },
                Room = new Room { RoomNumber = "101" },
                BookingDate = new DateTime(2025, 6, 1),
                TotalPrice = 120
            },
            new Booking
            {
                BookingID = 2,
                Customer = new Customer { CustomerFullName = "Bob" },
                Room = new Room { RoomNumber = "102" },
                BookingDate = new DateTime(2025, 6, 5),
                TotalPrice = 200
            },
            new Booking
            {
                BookingID = 3,
                Customer = new Customer { CustomerFullName = "Charlie" },
                Room = new Room { RoomNumber = "103" },
                BookingDate = new DateTime(2025, 6, 10),
                TotalPrice = 150
            }
        };

        public List<Booking> GetAll() => bookings;
    }
}
