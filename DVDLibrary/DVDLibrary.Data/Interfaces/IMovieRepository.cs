using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.Interfaces
{
    public interface IMovieRepository
    {
        Movie GetMovie(int movieId);
        IEnumerable<Movie> GetAllMovies();
        void AddMovie(Movie movie);
        void EditMovie(Movie movie);
        void DeleteMovie(int movieId);
    }
}
