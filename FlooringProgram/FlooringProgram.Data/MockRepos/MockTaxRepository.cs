using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class MockTaxRepository : ITaxRepository
    {
        private readonly List<Tax> taxList;

        public MockTaxRepository()
        {
            taxList = new List<Tax>()
            {
                new Tax() {StateName = "Ohio", TaxRate = 1.50m, StateAbbrev = "OH"},
                new Tax() {StateName = "Tennessee", TaxRate = 1.00m, StateAbbrev = "TN"},
                new Tax() {StateName = "Illinois", TaxRate = 3.00m, StateAbbrev = "IL"},
                new Tax() {StateName = "New York", TaxRate = 2.50m, StateAbbrev = "NY"},
                new Tax() {StateName = "Michigan", TaxRate = 2.00m, StateAbbrev = "MI"}
            };
        }

        public Tax GetTaxByNameAbbrev(string name)
        {
            return taxList.FirstOrDefault(t => t.StateAbbrev == name);
        }

        public List<Tax> GetAllTaxes()
        {
            return taxList;
        }
    }
}
