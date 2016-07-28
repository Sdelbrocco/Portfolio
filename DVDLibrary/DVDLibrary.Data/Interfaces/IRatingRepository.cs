using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.Interfaces
{
    public interface IRatingRepository
    {
        Rating GetRating(int rating);
        IEnumerable<Rating> GetAllRatings();
        void AddRating(Rating rating);
        void EditRating(Rating rating);
        void DeleteRating(int ratingId);
    }
}
