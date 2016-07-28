using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data.Interfaces
{
    public interface IJobRepository
    {
        Job GetJob(int id);
        List<Job> GetJobsByTitle(string name);
        IEnumerable<Job> GetAllJobs();
        void AddJob(Job job);
        void EditJob(Job job);
        void DeleteJob(int id);
    }
}
