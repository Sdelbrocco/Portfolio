using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPortal.Models.Response
{
    public class JobResponse : Response
    {
        public IEnumerable<Job> JobList { get; set; }
    }
}
