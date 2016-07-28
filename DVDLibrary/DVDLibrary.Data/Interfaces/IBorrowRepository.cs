using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.Interfaces
{
    public interface IBorrowRepository
    {
        Borrow GetBorrow(int borrowId);
        IEnumerable<Borrow> GetAllBorrows();
        void AddBorrow(Borrow borrow);
        void EditBorrow(Borrow borrow);
        void DeleteBorrow(int borrowId);
    }
}
