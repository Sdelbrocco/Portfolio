using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data.Interfaces
{
    public interface IApplicationRepository
    {
        Application GetApp(int id);
        IEnumerable<Application> GetAllApps();
        void AddApp(Application application);
        void EditApp(Application application);
        void DeleteApp(int id);
    }
}
