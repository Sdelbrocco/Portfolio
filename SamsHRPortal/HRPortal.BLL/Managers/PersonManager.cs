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
    class PersonManager
    {
        private IPersonRepository _personrepo;
        //private ICompanyRepository _companyRepository;


        public PersonManager()
        {
            _personrepo = RepositoryFactory.GetPersonRepo();
        }


        public IEnumerable<Person> GetAllPeople()
        {
            IEnumerable<Person> people = _personrepo.GetAllPeople();

            return people;
        }


        public Person GetPerson(int id)
        {
            return _personrepo.GetPerson(id);
        }


        //public JobResponse AddJob(Job job)
        //{
        //    JobResponse response = new JobResponse();
        //    if (_companyRepository.GetCompany(job.CompanyId) == null)
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

        //public void EditJob(Job job)
        //{
        //    _jobrepo.EditJob(job);
        //}

        //public void DeleteJob(Job job)
        //{
        //    _jobrepo.DeleteJob(job.Id);
        //}
    }
}
