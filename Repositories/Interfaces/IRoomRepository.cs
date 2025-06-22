using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVanCau_SE18D07_A01.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        List<Room> GetAll();
        Room? GetByID(int id);
        void Add(Room room);
        void Update(Room room);
        void Delete(int id);
        List<Room> Search(string keyword);

        List<Room> GetAvailableRooms(DateTime from, DateTime to);
    }
}
