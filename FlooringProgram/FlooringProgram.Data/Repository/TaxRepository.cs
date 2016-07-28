using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;

namespace FlooringProgram.Data
{
    public class TaxRepository : ITaxRepository 
    {
        protected static List<Tax> Taxes { get; private set; }

        public TaxRepository()
        {
            Taxes = ReadFromFile();
        }

        private List<Tax> ReadFromFile()
        {
            var result = new List<Tax>();
            string FILENAME = @"Datafiles\Taxes.txt";
            using (StreamReader sr = File.OpenText(FILENAME))
            {
                string holder;
                holder = sr.ReadLine();
                List<string> holders = new List<string>();
                int row = 0;
                while ((holder = sr.ReadLine())!= null)
                {
                    holders.Add(holder);
                    for (int i = 0; i < holders.Count; i++)
                    {
                        string[] fields = holder.Split(',');
                        Tax newtax = new Tax();
                        newtax.StateAbbrev = fields[0];
                        newtax.StateName = fields[1];
                        newtax.TaxRate = decimal.Parse(fields[2]);
                        result.Add(newtax);
                    }
                }
       
            }
            return result;
        }
     
        public Tax GetTaxByNameAbbrev(string name)
        {
            return (from tax in Taxes
                where name == tax.StateAbbrev
                select tax).FirstOrDefault();
        }

        public List<Tax> GetAllTaxes()
        {
            return Taxes;
        }
    }
}
