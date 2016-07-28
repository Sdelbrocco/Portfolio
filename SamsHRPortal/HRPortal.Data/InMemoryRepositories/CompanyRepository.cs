using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Models;

namespace HRPortal.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private static List<Company> _companies;

        static CompanyRepository()
        {
            //sample data
            _companies = new List<Company>()
            {
                new Company {Id = 1, Name = "Google", Description = "A nice company"},
                new Company { Id = 2, Name = "Yahoo", Description = "A mean company"},
                new Company {Id = 3, Name = "Ask Jeeves", Description = "Were working on it"},
                new Company { Id = 4, Name = "Bing", Description = "Whats bing?"}
            };
        }


        public Company GetCompany(int id)
        {
            return _companies.FirstOrDefault(c => c.Id == id);
        }


        public List<Company> GetCompaniesByName(string name)
        {
            return _companies.FindAll(c => c.Name == name);
        }


        public IEnumerable<Company> GetAllCompanies()
        {
            return _companies;
        }


        public void AddCompany(Company newCompany)
        {
            newCompany.Id = GetNextID();
            _companies.Add(newCompany);
        }


        public void EditCompany(Company company)
        {
            var selectedCompany = _companies.First(c => c.Id == company.Id);

            selectedCompany.Name = company.Name;
            selectedCompany.Jobs = company.Jobs;
        }


        public void DeleteCompany(int id)
        {
            _companies.Remove(_companies.FirstOrDefault(c => c.Id == id));
        }


        private int GetNextID()
        {
            if (_companies.Count == 0)
            {
                return 1;
            }
            int id = _companies.First(x => x.Id == _companies.Max(n => n.Id)).Id;
            return ++id;
        }
    }
}
