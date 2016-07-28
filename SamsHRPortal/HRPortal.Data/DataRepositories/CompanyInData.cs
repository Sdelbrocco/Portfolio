using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Models;

namespace HRPortal.Data.DataRepositories
{
    public class CompanyInData : ICompanyRepository
    {
        public Company GetCompany(int id)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetCompaniesByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        public void AddCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public void EditCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public void DeleteCompany(int id)
        {
            throw new NotImplementedException();
        }
    }
}
