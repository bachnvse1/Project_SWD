using System.Collections.Generic;
using HospitalLibrary.DataAccess;
using HospitalLibrary.Repository;

namespace HospitalLibrary.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        // Add a new room
        public void AddRoom(Room room)
        {
            _roomRepository.AddRoom(room);
        }

        // Retrieve all rooms
        public IEnumerable<Room> GetAllRooms()
        {
            return _roomRepository.GetAllRooms();
        }

        // Get a single room by its ID
        public Room GetRoomById(int roomId)
        {
            return _roomRepository.GetRoomById(roomId);
        }

        // Update an existing room
        public void UpdateRoom(Room room)
        {
            _roomRepository.UpdateRoom(room);
        }

        // Hard delete a room by its ID
        public void HardDeleteRoom(int roomId)
        {
            _roomRepository.HardDeleteRoom(roomId);
        }

        // Check if a room is available
        public bool CheckRoomAvailable(int roomId)
        {
            return _roomRepository.CheckRoomAvailable(roomId);
        }
    }
}
