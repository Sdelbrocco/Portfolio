﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public interface ITaxRepository
    {
        Tax GetTaxByNameAbbrev(string name);
        List<Tax> GetAllTaxes();
    }
}