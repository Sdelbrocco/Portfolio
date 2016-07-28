using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.DataRepositories
{
    public class UserInMemory : IUserRepository
    {
        public User GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
