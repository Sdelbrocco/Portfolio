using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Models;
using HRPortal.Models.Enums;

namespace HRPortal.Data.Repositories
{
    public class JobRepository : IJobRepository
    {
        private static List<Job> _jobs;

        static JobRepository()
        {
            _jobs = new List<Job>
            {
                new Job { Id = 1, CompanyId = 1, Title = "Marketing Director", JobDescription = "Direct Marketing People"},
                new Job { Id = 2, CompanyId = 1, Title = "Junior Developer", JobDescription = "Develop Junior Stuff"},
                new Job { Id = 3, CompanyId = 1, Title = "Senior Developer", JobDescription = "Develop Senior Stuff"},
                new Job { Id = 4, CompanyId = 1, Title = "Advertising Consultant", JobDescription = "Consult Advertising people"}
            };
        }


        public Job GetJob(int id)
        {
            return _jobs.FirstOrDefault(j => j.Id == id);
        }


        public List<Job> GetJobsByTitle(string name)
        {
            return _jobs.FindAll(j => j.Title == name);
        }


        public IEnumerable<Job> GetAllJobs()
        {
            return _jobs;
        }


        public void AddJob(Job job)
        {
            job.Id = GetNextID();
            _jobs.Add(job);
        }


        private int GetNextID()
        {
            if (_jobs.Count == 0)
            {
                return 1;
            }
            int id = _jobs.First(x => x.Id == _jobs.Max(n => n.Id)).Id;
            return ++id;
        }


        public void EditJob(Job job)
        {
            var selectedJob = _jobs.FirstOrDefault(j => j.Id == job.Id);

            selectedJob.Title = job.Title;
            selectedJob.JobDescription = job.JobDescription;
            selectedJob.Applications = job.Applications;
            selectedJob.Status = job.Status;
        }


        public void DeleteJob(int id)
        {
            _jobs.RemoveAll(j => j.Id == id);
        }

    }
}
