﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public class TaxResponse : Response
    {
        public List<Tax> TaxInfo { get; set; }
    }
}
