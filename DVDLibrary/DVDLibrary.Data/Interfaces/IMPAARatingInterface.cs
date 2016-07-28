using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.Interfaces
{
    public interface IMPAARatingInterface
    {
        MPAARating GetRating(int mpaaRatingId);
        IEnumerable<MPAARating> GetAllRatings();
       
    }
}
