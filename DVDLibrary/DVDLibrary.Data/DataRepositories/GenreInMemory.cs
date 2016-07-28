using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.DataRepositories
{
    public class GenreInMemory : IGenreRepository
    {
        public Genre GetGenre(int genreId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            throw new NotImplementedException();
        }

        public void AddGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public void EditGenre(Genre genre)
        {
            throw new NotImplementedException();
        }

        public void DeleteGenre(int genreId)
        {
            throw new NotImplementedException();
        }
    }
}
