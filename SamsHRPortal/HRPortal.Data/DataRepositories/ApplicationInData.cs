using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Models;

namespace HRPortal.Data.DataRepositories
{
    public class ApplicationInData : IApplicationRepository
    {
        public Application GetApp(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Application> GetAllApps()
        {
            throw new NotImplementedException();
        }

        public void AddApp(Application application)
        {
            //TODO: Write to file "Applications.txt"

            throw new NotImplementedException();
        }

        public void EditApp(Application application)
        {
            throw new NotImplementedException();
        }

        public void DeleteApp(int id)
        {
            throw new NotImplementedException();
        }
    }
}
