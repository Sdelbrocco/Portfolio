using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Data.RepoFactory;
using HRPortal.Data.Repositories;
using HRPortal.Models;
using HRPortal.Models.Response;

namespace HRPortal.BLL.Managers
{
    public class CompanyManager
    {
        private ICompanyRepository _comprepo;

        public CompanyManager()
        {
            _comprepo = RepositoryFactory.GetCompanyRepo();
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            IEnumerable<Company> Companies = _comprepo.GetAllCompanies();

            return Companies;
        }

        public Company GetCompany(int id)
        {
            return _comprepo.GetCompany(id);
        }

        //public CompanyResponse AddComp(Company company)
        //{
        //    CompanyResponse response = new CompanyResponse();
        //    if (_comprepo.GetCompany(job.CompanyId) == null)
        //    {
        //        response.Message = "Invalid Company";
        //        return response;

        //    }
        //    try
        //    {
        //        _jobrepo.AddJob(job);
        //        response.Success = true;
        //        response.JobList = new List<Job>() { job };
        //    }
        //    catch (Exception e)
        //    {
        //        response.Message = e.Message;
        //        return response;
        //    }
        //    return response;
        //}
    }
}
