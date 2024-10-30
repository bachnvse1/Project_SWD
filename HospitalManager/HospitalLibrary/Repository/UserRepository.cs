using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.DataAccess;   // Adjust this according to your data context namespace

namespace HospitalLibrary.Repository
{
    internal class UserRepository : IUserRepository
    {
        private readonly DBContext _context; // Assuming you have a context class for your database

        public UserRepository(DBContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
