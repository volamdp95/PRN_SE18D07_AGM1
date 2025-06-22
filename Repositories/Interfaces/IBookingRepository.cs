using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVanCau_SE18D07_A01.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        List<Booking> GetAll();
        Booking GetById(int id);
        void Add(Booking booking);
        void Update(Booking booking);
        void Delete(int id);
        List<Booking> GetByDateRange(DateTime startDate, DateTime endDate);
    }
}
