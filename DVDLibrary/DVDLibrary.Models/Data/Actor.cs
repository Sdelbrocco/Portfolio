using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Data
{
    public class Actor
    {
        public int ActorID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Description { get; set; }
        public string DateOfBirth { get; set; }

        public string HometownCity { get; set; }
        public string HometownState { get; set; }
        
    }
}
