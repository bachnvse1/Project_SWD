using System.Collections.Generic;
using HospitalLibrary.DataAccess;

namespace HospitalLibrary.Service
{
    public interface IRoomService
    {
        // Method to add a new room
        void AddRoom(Room room);

        // Method to retrieve all rooms
        IEnumerable<Room> GetAllRooms();

        // Method to get a single room by its ID
        Room GetRoomById(int roomId);

        // Method to update room information
        void UpdateRoom(Room room);

        // Method to hard delete a room by its ID
        void HardDeleteRoom(int roomId);

        // Method to check if a room is available
        bool CheckRoomAvailable(int roomId);
    }
}
