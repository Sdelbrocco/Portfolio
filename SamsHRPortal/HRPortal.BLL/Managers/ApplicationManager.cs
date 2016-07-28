using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Data.RepoFactory;
using HRPortal.Models;
using HRPortal.Models.Response;

namespace HRPortal.BLL.Managers
{
    public class ApplicationManager
    {
        private readonly IApplicationRepository _apprepo;
        private readonly IJobRepository _jobRepository;
        private IPersonRepository _personRepository;


        public ApplicationManager(IPersonRepository personRepository)
        {
            _apprepo = RepositoryFactory.GetApplicationRepository();
            _jobRepository = RepositoryFactory.GetJobRepo();
            _personRepository = personRepository;

        }


        private IEnumerable<Application> GetAllApplications()
        {
            return _apprepo.GetAllApps();
        }


        public Application GetApplication(int id)
        {
            return _apprepo.GetApp(id);
        }


        public IEnumerable<Application> GetAllApps()
        {
            IEnumerable<Application> Applications = _apprepo.GetAllApps();

            return Applications;
        }


        public ApplicationResponse AddApp(Application newApplication)
        {
            ApplicationResponse response = new ApplicationResponse();
            if (_jobRepository.GetJob(newApplication.JobId) == null)
            {
                response.Message = "Invalid Job";
                return response;

            }
            int personId = 0;
            var person =
                _personRepository.GetAllPeople()
                    .FirstOrDefault(
                        p =>
                            p.FirstName.Equals(newApplication.Person.FirstName,
                                StringComparison.InvariantCultureIgnoreCase) &&
                             p.LastName.Equals(newApplication.Person.LastName,
                                StringComparison.InvariantCultureIgnoreCase) &&
                                 p.Address.Equals(newApplication.Person.Address,
                                StringComparison.InvariantCultureIgnoreCase)
                                );
            if (person == null)
            {
                _personRepository.AddPerson(newApplication.Person);
            }
            else
            {
                newApplication.Person.Id = personId;
            }


            try
            {
                _apprepo.AddApp(newApplication);
                response.Success = true;
                response.ApplicationList = new List<Application>() { newApplication };
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                return response;
            }
            return response;
        }

        
    }
}
