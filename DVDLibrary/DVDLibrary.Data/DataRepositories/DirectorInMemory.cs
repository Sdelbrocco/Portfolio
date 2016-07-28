using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.DataRepositories
{
    public class DirectorInMemory : IDirectorRepository
    {
        public Director GetDirector(int directorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Director> GetAllDirectors()
        {
            throw new NotImplementedException();
        }

        public void AddDirector(Director director)
        {
            throw new NotImplementedException();
        }

        public void EditDirector(Director director)
        {
            throw new NotImplementedException();
        }

        public void DeleteDirector(int directorId)
        {
            throw new NotImplementedException();
        }
    }
}
