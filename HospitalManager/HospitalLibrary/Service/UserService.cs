using System;
using System.Collections.Generic;
using HospitalLibrary.DataAccess;
using HospitalLibrary.Repository;

namespace HospitalLibrary.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            _userRepository.AddUser(user);
        }

        public User GetUser(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void UpdateUser(User user)
        {
            _userRepository.UpdateUser(user);
        }

        public void RemoveUser(int userId)
        {
            _userRepository.DeleteUser(userId);
        }

        public IEnumerable<User> AvailableUsers()
        {
            return _userRepository.GetAllUsers().Where(user => (bool)user.IsAvailable);
        }
    }
}
