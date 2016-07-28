using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.MockRepositories
{
    public class MockMovieRepository : IMovieRepository
    {
        private static List<Movie> _movies;


        public MockMovieRepository()
        {
            _movies = new List<Movie>
            {
                new Movie
                {
                    MovieID = 1,
                    NumberOfCopies = 2,
                    MovieTitle = "Jason Bourne",
                    MovieSubtitle = "Identity",
                    RunTime = "1h 59m",
                    RatingId = 1,
                    ReleaseDate = new DateTime(2002, 06, 06),
                    StudioName = "Universal",
                    GenreID = 1
                },
                new Movie
                {
                    MovieID = 2,
                    NumberOfCopies = 2,
                    MovieTitle = "Jason Bourne",
                    MovieSubtitle = "Supremacy",
                    RunTime = "1h 50m",
                    RatingId = 1,
                    ReleaseDate = new DateTime(2004, 07, 23),
                    StudioName = "Universal",
                    GenreID = 1
                },
                new Movie
                {
                    MovieID = 3,
                    NumberOfCopies = 2,
                    MovieTitle = "Jason Bourne",
                    MovieSubtitle = "Ultimatum",
                    RunTime = "1h 56m",
                    RatingId = 1,
                    ReleaseDate = new DateTime(2007, 08, 03),
                    StudioName = "Universal",
                    GenreID = 1
                }
            };    
        }


        public Movie GetMovie(int movieId)
        {
            return _movies.FirstOrDefault(m => m.MovieID == movieId);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _movies;
        }

        public void AddMovie(Movie movie)
        {
            movie.MovieID = GetNextID();
            _movies.Add(movie);
        }

        public void EditMovie(Movie movie)
        {
            var selectedMovie = _movies.FirstOrDefault(m => m.MovieID == movie.MovieID);

            selectedMovie.RatingId = movie.RatingId;
            selectedMovie.NumberOfCopies = movie.NumberOfCopies;
            selectedMovie.MovieTitle = movie.MovieTitle;
            selectedMovie.MovieSubtitle = movie.MovieSubtitle;
            selectedMovie.RunTime = movie.RunTime;
            selectedMovie.Rating = movie.Rating;
            selectedMovie.ReleaseDate = movie.ReleaseDate;
            selectedMovie.StudioName = movie.StudioName;
            selectedMovie.GenreID = movie.GenreID;
        }

        public void DeleteMovie(int movieId)
        {
            _movies.RemoveAll(m => m.MovieID == movieId);
        }

        private int GetNextID()
        {
            if (_movies.Count == 0)
            {
                return 1;
            }
            int id = _movies.First(x => x.MovieID == _movies.Max(n => n.MovieID)).MovieID;
            return ++id;
        }
    }
}
