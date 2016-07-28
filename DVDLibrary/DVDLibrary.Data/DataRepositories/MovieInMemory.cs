using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.DataRepositories
{
    public class MovieInMemory : IMovieRepository
    {
        public Movie GetMovie(int movieId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            throw new NotImplementedException();
        }

        public void AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void EditMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public void DeleteMovie(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
