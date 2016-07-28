using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Models;

namespace HRPortal.Data.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private static List<Application> _applications;

        static ApplicationRepository()
        {
            _applications = new List<Application>
            {
                new Application
                {
                    Id = 1,
                    JobId = 1,
                    Education = "Masters",
                    Salary = "$100,000,000",
                    Person = new Person()
                    {
                        Id = 1,
                        FirstName = "Samantha",
                        LastName = "DelBrocco",
                        Address = "123 S. Main St.",
                        PhoneNumber = "440-821-7260"
                    },
                    WorkHistory = "Starbucks 2016, Tribune 2013-2015"
                },
                new Application
                {
                    Id = 2,
                    JobId = 2,
                    Education = "GED",
                    Salary = "$5,000,000",
                    Person = new Person()
                    {
                        Id = 2,
                        FirstName = "Chris",
                        LastName = "Mason",
                        Address = "22 E. 4th St.",
                        PhoneNumber = "440-234-5689"
                    },
                    WorkHistory = "WaterMark 2016, Tribune 2013-2015"
                },
                new Application
                {
                    Id = 3,
                    JobId = 3,
                    Education = "Bachelors",
                    Salary = "$100",
                    Person = new Person()
                    {
                        Id = 2,
                        FirstName = "Audrey",
                        LastName = "Cooper",
                        Address = "112 Wabash Ave.",
                        PhoneNumber = "440-563-6894"
                    },
                    WorkHistory = "Starbucks 2016"
                },
                new Application
                {
                    Id = 4,
                    JobId = 4,
                    Education = "High School Diploma",
                    Salary = "$100,000",
                    Person = new Person()
                    {
                        Id = 2,
                        FirstName = "Danielle",
                        LastName = "DelBrocco",
                        Address = "124 N. LakeShore Dr.",
                        PhoneNumber = "440-234-5788"
                    },
                    WorkHistory = "CRU 2016, Cognitive Behavioral Therapist 2013-2015"
                }
            };
        }

        public Application GetApp(int id)
        {
            return _applications.FirstOrDefault(a => a.Id == id);
        }


        public IEnumerable<Application> GetAllApps()
        {
            return _applications;
        }


        public void AddApp(Application newApplication)
        {
            newApplication.Id = GetNextID();
            _applications.Add(newApplication);
        }


        private int GetNextID()
        {
            if (_applications.Count == 0)
            {
                return 1;
            }
            int id = _applications.First(x => x.Id == _applications.Max(n => n.Id)).Id;
            return ++id;
        }


        public void EditApp(Application application)
        {
            var selectedApp = _applications.First(a => a.Id == application.Id);

            selectedApp.JobId = application.JobId;
            selectedApp.Person = application.Person;
            selectedApp.Education = application.Education;
            selectedApp.Salary = application.Salary;
        }


        public void DeleteApp(int id)
        {
            _applications.Remove(_applications.FirstOrDefault(a => a.Id == id));
        }
    }
}
