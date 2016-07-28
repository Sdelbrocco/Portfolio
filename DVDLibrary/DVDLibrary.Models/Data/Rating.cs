using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Data
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public double Stars { get; set; }
        public string UserNotes { get; set; }
    }
}
