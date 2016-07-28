using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.DataRepositories
{
    public class MPAARatingInMemory : IMPAARatingInterface
    {
        public MPAARating GetRating(int mpaaRatingId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MPAARating> GetAllRatings()
        {
            throw new NotImplementedException();
        }
    }
}
