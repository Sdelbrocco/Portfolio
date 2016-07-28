using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.Interfaces
{
    public interface IGenreRepository
    {
        Genre GetGenre(int genreId);
        IEnumerable<Genre> GetAllGenres();
        void AddGenre(Genre genre);
        void EditGenre(Genre genre);
        void DeleteGenre(int genreId);
    }
}
