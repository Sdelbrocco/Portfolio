using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data.Interfaces
{
    public interface ICompanyRepository
    {
        Company GetCompany(int id);
        List<Company> GetCompaniesByName(string name);
        IEnumerable<Company> GetAllCompanies();
        void AddCompany(Company company);
        void EditCompany(Company company);
        void DeleteCompany(int id);
    }
}
