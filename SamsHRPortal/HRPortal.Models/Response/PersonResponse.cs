using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models.Response
{
    public class PersonResponse : Response
    {
        public List<Person> PersonList { get; set; }
    }
}
