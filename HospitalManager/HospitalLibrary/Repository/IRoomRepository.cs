using HospitalLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Repository
{
    public interface IRoomRepository
    {
        public bool CheckRoomAvailable(int roomId);
        public void HardDeleteRoom(int roomId);
        public void UpdateRoom(Room room);
        public Room GetRoomById(int roomId);
        public IEnumerable<Room> GetAllRooms();
        public void AddRoom(Room room);
    }
}
