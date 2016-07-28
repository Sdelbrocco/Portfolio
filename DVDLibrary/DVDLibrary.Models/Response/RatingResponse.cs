using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Models.Response
{
    public class RatingResponse : Response
    {
        public IEnumerable<Rating> RatingList { get; set; }
    }
}
