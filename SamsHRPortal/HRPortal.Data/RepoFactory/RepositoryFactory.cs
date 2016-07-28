using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.DataRepositories;
using HRPortal.Data.Interfaces;
using HRPortal.Data.Repositories;

namespace HRPortal.Data.RepoFactory
{
    public static class RepositoryFactory
    {
        public static IApplicationRepository GetApplicationRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new ApplicationRepository(); ;
            }
            return new ApplicationInData();
        }

        public static ICategoryRepository GeCategoryRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new CategoryRepository();
            }
            return new CategoryInData();
        }

        public static ICompanyRepository GetCompanyRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new CompanyRepository();
            }
            return new CompanyInData();
        }

        public static IJobRepository GetJobRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new JobRepository();
            }
            return new JobInData();
        }

        public static IPersonRepository GetPersonRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new PersonRepository();
            }
            return new PersonInData();
        }

        public static IPolicyRepository GetPolicyRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new PolicyRepository();
            }
            return new PolicyInData();
        }
    }
}
