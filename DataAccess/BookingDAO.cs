using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NguyenVanCau_SE18D07_A01.DataAccess
{
    public class BookingDAO
    {
        private static BookingDAO instance = null;
        private static readonly object lockObj = new();

        private List<Booking> bookings;

        private BookingDAO()
        {
            bookings = new List<Booking>();
        }

        public static BookingDAO Instance
        {
            get
            {
                lock (lockObj)
                {
                    return instance ??= new BookingDAO();
                }
            }
        }

        public List<Booking> GetAll() => bookings;

        public List<Booking> GetByCustomer(Customer customer)
        {
            return bookings.Where(b => b.Customer.CustomerID == customer.CustomerID).ToList();
        }

        public void Add(Booking booking)
        {
            booking.BookingID = bookings.Any() ? bookings.Max(b => b.BookingID) + 1 : 1;
            booking.BookingDate = DateTime.Now;
            bookings.Add(booking);
        }
        public void Delete(int bookingId)
        {
            var booking = bookings.FirstOrDefault(b => b.BookingID == bookingId);
            if (booking != null)
            {
                bookings.Remove(booking);
            }
        }
    }
}
