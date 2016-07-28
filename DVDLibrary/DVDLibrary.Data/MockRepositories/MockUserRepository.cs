using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.MockRepositories
{
    public class MockUserRepository : IUserRepository
    {
        private List<User> _users;

        public MockUserRepository()
        {
            _users = new List<User>
            {
                new User
                {
                    UserID = 1,
                    FirstName = "Samantha",
                    LastName = "DelBrocco"
                },
                new User
                {
                    UserID = 2,
                    FirstName = "Chris",
                    LastName = "Mason"
                },
                new User
                {
                    UserID = 3,
                    FirstName = "Tom",
                    LastName = "Bohn"
                }
            };
        }


        public User GetUser(int userId)
        {
            return _users.FirstOrDefault(x => x.UserID == userId);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _users;
        }

        public void AddUser(User user)
        {
            user.UserID = GetNextID();
            _users.Add(user);
        }

        public void EditUser(User user)
        {
            var selectedUser = _users.FirstOrDefault(x => x.UserID == user.UserID);

            selectedUser.FirstName = user.FirstName;
            selectedUser.LastName = user.LastName;
        }

        public void DeleteUser(int userId)
        {
            _users.Remove(_users.FirstOrDefault(x => x.UserID == userId));
        }

        private int GetNextID()
        {
            if (_users.Count == 0)
            {
                return 1;
            }
            int id = _users.First(x => x.UserID == _users.Max(n => n.UserID)).UserID;
            return ++id;
        }
    }
}
