using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.MockRepositories
{
    public class MockGenreRepository : IGenreRepository
    {
        private static List<Genre> _genres;

        public MockGenreRepository()
        {
            _genres = new List<Genre>
            {
                new Genre
                {
                    GenreId = 1,
                    GenreDescription = "Action"
                },
                new Genre
                {
                    GenreId = 2,
                    GenreDescription = "Comedy"
                },
                new Genre
                {
                    GenreId = 3,
                    GenreDescription = "Horror"
                },
                new Genre
                {
                    GenreId = 4,
                    GenreDescription = "Documentary"
                },
                new Genre
                {
                    GenreId = 5,
                    GenreDescription = "Musical"
                }
            };
        }

        public Genre GetGenre(int genreId)
        {
            return _genres.FirstOrDefault(g => g.GenreId == genreId);
        }


        public IEnumerable<Genre> GetAllGenres()
        {
            return _genres;
        }


        public void AddGenre(Genre genre)
        {
            genre.GenreId = GetNextID();
            _genres.Add(genre);
        }


        public void EditGenre(Genre genre)
        {
            var selectedGenre = _genres.FirstOrDefault(g => g.GenreId == genre.GenreId);

            selectedGenre.GenreDescription = genre.GenreDescription;
        }


        public void DeleteGenre(int genreId)
        {
            _genres.RemoveAll(g => g.GenreId == genreId);
        }


        private int GetNextID()
        {
            if (_genres.Count == 0)
            {
                return 1;
            }
            int id = _genres.First(x => x.GenreId == _genres.Max(n => n.GenreId)).GenreId;
            return ++id;
        }
    }
}
