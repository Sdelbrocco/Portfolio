using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Models;

namespace HRPortal.Data.DataRepositories
{
    public class JobInData : IJobRepository
    {
        public Job GetJob(int id)
        {
            throw new NotImplementedException();
        }

        public List<Job> GetJobsByTitle(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Job> GetAllJobs()
        {
            throw new NotImplementedException();
        }

        public void AddJob(Job job)
        {
            throw new NotImplementedException();
        }

        public void EditJob(Job job)
        {
            throw new NotImplementedException();
        }

        public void DeleteJob(int id)
        {
            throw new NotImplementedException();
        }
    }
}
