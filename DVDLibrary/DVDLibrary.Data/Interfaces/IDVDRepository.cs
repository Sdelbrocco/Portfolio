using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.Interfaces
{
    public interface IDVDRepository
    {
        DVD GetDvd(int dvdId);
        IEnumerable<DVD> GetAllDvds();
        void AddDvd(DVD dvd);
        void EditDvd(DVD dvd);
        void DeleteDvd(int dvdId);
    }
}
