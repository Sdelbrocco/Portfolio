using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.MockRepositories
{
    public class MockRatingRepository : IRatingRepository
    {
        private List<Rating> _ratings;

        public MockRatingRepository()
        {
            _ratings = new List<Rating>
            {
                new Rating
                {
                    RatingID = 1,
                    UserID = 1,
                    MovieID = 1,
                    Stars = 7.9,
                    UserNotes = "This movie was ok"
                },
                new Rating
                {
                    RatingID = 1,
                    UserID = 1,
                    MovieID = 1,
                    Stars = 3.5,
                    UserNotes = "This movie sucks!!!"
                },
                new Rating
                {
                    RatingID = 1,
                    UserID = 2,
                    MovieID = 2,
                    Stars = 5.0,
                    UserNotes = "I fell asleep"
                }
            };
        }


        public Rating GetRating(int ratingId)
        {
            return _ratings.FirstOrDefault(x => x.RatingID == ratingId);
        }

        public IEnumerable<Rating> GetAllRatings()
        {
            return _ratings;
        }

        public void AddRating(Rating rating)
        {
            rating.RatingID = GetNextID();
            _ratings.Add(rating);
        }

        public void EditRating(Rating rating)
        {
            var selectedRating = _ratings.FirstOrDefault(x => x.RatingID == rating.RatingID);

            selectedRating.UserID = rating.UserID;
            selectedRating.MovieID = rating.MovieID;
            selectedRating.Stars = rating.Stars;
            selectedRating.UserNotes = rating.UserNotes;
        }

        public void DeleteRating(int ratingId)
        {
            _ratings.Remove(_ratings.FirstOrDefault(x => x.RatingID == ratingId));
        }

        private int GetNextID()
        {
            if (_ratings.Count == 0)
            {
                return 1;
            }
            int id = _ratings.First(x => x.RatingID == _ratings.Max(n => n.RatingID)).RatingID;
            return ++id;
        }
    }
}
