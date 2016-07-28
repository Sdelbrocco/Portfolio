using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.DataRepositories
{
    public class RatingInMemory : IRatingRepository
    {
        public Rating GetRating(int rating)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rating> GetAllRatings()
        {
            throw new NotImplementedException();
        }

        public void AddRating(Rating rating)
        {
            throw new NotImplementedException();
        }

        public void EditRating(Rating rating)
        {
            throw new NotImplementedException();
        }

        public void DeleteRating(int ratingId)
        {
            throw new NotImplementedException();
        }
    }
}
