using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Data
{
    public class Movie
    {
        public int MovieID { get; set; }
        public int RatingId { get; set; }

        public int NumberOfCopies { get; set; }
        public string MovieTitle { get; set; }
        public string MovieSubtitle { get; set; }
        public string RunTime { get; set; }
        public Rating Rating { get; set; }

        public DateTime ReleaseDate { get; set; }
        public string StudioName { get; set; }

        public int DirectorID { get; set; }
        public int GenreID { get; set; }
    }
}
