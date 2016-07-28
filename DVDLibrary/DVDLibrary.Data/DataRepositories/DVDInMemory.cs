using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.DataRepositories
{
    public class DVDInMemory : IDVDRepository
    {
        public DVD GetDvd(int dvdId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DVD> GetAllDvds()
        {
            throw new NotImplementedException();
        }

        public void AddDvd(DVD dvd)
        {
            throw new NotImplementedException();
        }

        public void EditDvd(DVD dvd)
        {
            throw new NotImplementedException();
        }

        public void DeleteDvd(int dvdId)
        {
            throw new NotImplementedException();
        }
    }
}
