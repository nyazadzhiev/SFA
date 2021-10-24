using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoApp.Data;
using ToDoApp.Entities;

namespace ToDoApp.Services
{
    class UserService
    {
        private const string StoreFileName = "Users.json";
        private readonly FileDatabase _storage;
        private readonly List<User> _applicationUsers = new List<User>();
        private static int userIdGenerator = 0;
        public User CurrentUser { get; private set; }

        public UserService()
        {
            _storage = new FileDatabase();
            List<User> usersFromFile = _storage.Read<List<User>>(StoreFileName);
            if (usersFromFile == null)
            {
                CreateUser("admin", "adminpassword", "Admin", "Admin");
            }
            else
            {
                _applicationUsers = usersFromFile;
            }
        }

        private void SaveToFile()
        {
            _storage.Write(StoreFileName, _applicationUsers);
        }

        public bool CreateUser(string username, string password, string firstName, string lastName)
        {
            if (_applicationUsers.Any(u => u.Username == username))
            {
                return false;
            }

            userIdGenerator++;

            DateTime now = DateTime.Now;

            _applicationUsers.Add(new User()
            {
                Username = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Id = userIdGenerator,
                CreatedAt = now
            });

            SaveToFile();

            return true;
        }

        public void Login(string userName, string password)
        {
            CurrentUser = _applicationUsers.FirstOrDefault(u => u.Username == userName && u.Password == password);
        }

        public void LogOut()
        {
            CurrentUser = null;
        }

        public User getUserById(int id)
        {
            return _applicationUsers.FirstOrDefault(u => u.Id == id);
        }

        public User getUserByUsername(string username)
        {
            return _applicationUsers.FirstOrDefault(u => u.Username == username);
        }
    }
}
