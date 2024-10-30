using System;
using System.Collections.Generic;
using HospitalLibrary.DataAccess;

namespace HospitalLibrary.Repository
{
    public interface IUserRepository
    {
        // Method to add a new user
        void AddUser(User user);

        // Method to get a user by ID
        User GetUserById(int userId);

        // Method to get all users
        IEnumerable<User> GetAllUsers();

        // Method to update a user
        void UpdateUser(User user);

        // Method to delete a user
        void DeleteUser(int userId);
    }
}
