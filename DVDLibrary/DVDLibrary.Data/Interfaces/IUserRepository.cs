using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int userId);
        IEnumerable<User> GetAllUsers();
        void AddUser(User user);
        void EditUser(User user);
        void DeleteUser(int userId);
    }
}
