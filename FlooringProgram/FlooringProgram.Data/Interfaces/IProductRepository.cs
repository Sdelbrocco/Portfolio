﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public interface IProductRepository
    {
        Product GetProductByName(string name);
        List<Product> GetAllProducts(DateTime dateTime);
    }
}
