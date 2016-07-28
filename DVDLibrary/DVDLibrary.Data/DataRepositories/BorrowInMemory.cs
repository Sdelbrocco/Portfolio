using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.DataRepositories
{
    public class BorrowInMemory : IBorrowRepository
    {
        public Borrow GetBorrow(int borrowId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Borrow> GetAllBorrows()
        {
            throw new NotImplementedException();
        }

        public void AddBorrow(Borrow borrow)
        {
            throw new NotImplementedException();
        }

        public void EditBorrow(Borrow borrow)
        {
            throw new NotImplementedException();
        }

        public void DeleteBorrow(int borrowId)
        {
            throw new NotImplementedException();
        }
    }
}
