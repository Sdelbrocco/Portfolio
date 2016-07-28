using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public class Tax
    {
        public string StateName { get; set; }
        public decimal TaxRate { get; set; }
        public string StateAbbrev { get; set; }
    }
}
