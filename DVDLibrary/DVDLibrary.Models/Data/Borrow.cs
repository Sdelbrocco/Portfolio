using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Data
{
    public class Borrow
    {
        public int BorrowID { get; set; }
        public int UserID { get; set; }
        public int DVDID { get; set; }
        public DateTime Borrowed { get; set; }
        public DateTime Returned { get; set; }
    }
}
