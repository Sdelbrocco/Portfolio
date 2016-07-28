using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Models;

namespace FlooringProgram.BLL
{
    public class TaxManager
    {
        private readonly ITaxRepository _taxRepo;

        public TaxManager()
        {
            _taxRepo = RepositoryFactory.GetTaxRepo();
        }
        
        public TaxResponse GetTaxByState(string state)
        {
            var response = new TaxResponse();
            var tax = _taxRepo.GetTaxByNameAbbrev(state);

            try
            {
                if (tax == null)
                {
                    response.Success = false;
                    response.Message = "Invalid state type, try again...";
                }
                else
                {
                    response.Success = true;
                    response.TaxInfo = new List<Tax>();
                }
            }
            catch
            {
                response.Success = false;
                response.Message = "Something terrible went wrong, lets go back...";
            }

            return response;
        }

        public TaxResponse GetAllTaxes()
        {
            TaxResponse result = new TaxResponse();
            result.TaxInfo = _taxRepo.GetAllTaxes();
            
            return result;
        }

        public Tax GetTaxBy(string abbrev)
        {
            Tax result = _taxRepo.GetTaxByNameAbbrev(abbrev);

            return result;
        }
    }
}
