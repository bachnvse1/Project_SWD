using System.Collections.Generic;
using HospitalLibrary.DataAccess;

namespace HospitalLibrary.Service
{
    public interface IUserService
    {
        // Method to add a new user
        void CreateUser(User user);

        // Method to get a user by ID
        User GetUser(int userId);

        // Method to get all users
        IEnumerable<User> GetAllUsers();

        // Method to update a user
        void UpdateUser(User user);

        // Method to delete a user
        void RemoveUser(int userId);

        IEnumerable<User> AvailableUsers();
    }
}
