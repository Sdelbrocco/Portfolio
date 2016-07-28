using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.MockRepositories
{
    public class MockMPAARatingRepository : IMPAARatingInterface
    {
        private static List<MPAARating> _mpaaRatings;

        public MockMPAARatingRepository()
        {
            _mpaaRatings = new List<MPAARating>
            {
                new MPAARating
                {
                    MPAARatingID = 1,
                    MPAAName = "G",
                    Description = "General Audiances. All ages admitted."
                },
                new MPAARating
                {
                    MPAARatingID = 2,
                    MPAAName = "PG",
                    Description = "Parental Guidance Suggested. Some material may not be suitable for children."
                },
                new MPAARating
                {
                    MPAARatingID = 3,
                    MPAAName = "PG-13",
                    Description = "Parents Strongly Cautioned. Some material may be inappropriate for children under 13."
                },
                new MPAARating
                {
                    MPAARatingID = 4,
                    MPAAName = "R",
                    Description = "Restricted. Under 17 requires accompanying parent or adult guardian."
                }
            };
        }


        public MPAARating GetRating(int mpaaRatingId)
        {
            return _mpaaRatings.FirstOrDefault(x => x.MPAARatingID == mpaaRatingId);
        }

        public IEnumerable<MPAARating> GetAllRatings()
        {
            return _mpaaRatings;
        }
    }
}
