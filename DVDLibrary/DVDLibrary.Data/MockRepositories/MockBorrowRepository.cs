using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.MockRepositories
{
    public class MockBorrowRepository : IBorrowRepository
    {
        private static List<Borrow> _borrows;

        public MockBorrowRepository()
        {
            _borrows = new List<Borrow>
            {
                new Borrow
                {
                    BorrowID = 1,
                    DVDID = 1,
                    UserID = 1,
                    Borrowed = new DateTime(1990, 10, 10),
                    Returned = new DateTime(2016, 07, 27)
                },
                new Borrow
                {
                    BorrowID = 2,
                    DVDID = 1,
                    UserID = 1,
                    Borrowed = new DateTime(2016, 06, 27),
                    Returned = new DateTime(2016, 07, 27)
                },
                new Borrow
                {
                    BorrowID = 3,
                    DVDID = 1,
                    UserID = 1,
                    Borrowed = new DateTime(2015, 07, 27),
                    Returned = new DateTime(2016, 07, 27)
                }
            };
        }

        public Borrow GetBorrow(int borrowId)
        {
            return _borrows.FirstOrDefault(b => b.BorrowID == borrowId);
        }

        public IEnumerable<Borrow> GetAllBorrows()
        {
            return _borrows;
        }

        public void AddBorrow(Borrow borrow)
        {
            borrow.BorrowID = GetNextID();
            _borrows.Add(borrow);
        }

        public void EditBorrow(Borrow borrow)
        {
            var selectedBorrow = _borrows.FirstOrDefault(x => x.BorrowID == borrow.BorrowID);

            selectedBorrow.UserID = borrow.UserID;
            selectedBorrow.DVDID = borrow.DVDID;
            selectedBorrow.Borrowed = borrow.Borrowed;
            selectedBorrow.Returned = borrow.Returned;
        }

        public void DeleteBorrow(int borrowId)
        {
            _borrows.RemoveAll(x => x.BorrowID == borrowId);
        }

        private int GetNextID()
        {
            if (_borrows.Count == 0)
            {
                return 1;
            }
            int id = _borrows.First(x => x.BorrowID == _borrows.Max(n => n.BorrowID)).BorrowID;
            return ++id;
        }
    }
}
