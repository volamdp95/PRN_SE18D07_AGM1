using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using NguyenVanCau_SE18D07_A01.DataAccess;
using NguyenVanCau_SE18D07_A01.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NguyenVanCau_SE18D07_A01.Repositories.Implements
{
    public class RoomRepository : IRoomRepository
    {
        public List<Room> GetAll() => RoomDAO.Instance.GetAll();

        public Room? GetByID(int id) => RoomDAO.Instance.GetByID(id);

        public void Add(Room room) => RoomDAO.Instance.Add(room);

        public void Update(Room room) => RoomDAO.Instance.Update(room);

        public void Delete(int id) => RoomDAO.Instance.Delete(id);

        public List<Room> Search(string keyword) => RoomDAO.Instance.Search(keyword);

        public List<Room> GetAvailableRooms(DateTime from, DateTime to) // <-- Thêm method này
        {
            return RoomDAO.Instance.GetAvailableRooms(from, to);
        }
    }

}
