using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.DataAccess;

namespace HospitalLibrary.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DBContext _context;

        public RoomRepository(DBContext context)
        {
            _context = context;
        }

        // Create a new room
        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        // Get all rooms
        public IEnumerable<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }

        // Get a single room by ID
        public Room GetRoomById(int roomId)
        {
            return _context.Rooms.Find(roomId);
        }

        // Update an existing room
        public void UpdateRoom(Room room)
        {
            var existingRoom = _context.Rooms.Find(room.RoomId);
            if (existingRoom != null)
            {
                _context.Entry(existingRoom).CurrentValues.SetValues(room);
                _context.SaveChanges();
            }
        }
        // Permanently remove a room from the database (hard delete)
        public void HardDeleteRoom(int roomId)
        {
            var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }

        public bool CheckRoomAvailable(int roomId)
        {
            var room = _context.Rooms.Find(roomId);
            if (room != null)
            {
                return room.IsAvailable ?? false; // Returns false if IsAvailable is null or set to false
            }
            return false; // Returns false if room is not found
        }
    }
}
