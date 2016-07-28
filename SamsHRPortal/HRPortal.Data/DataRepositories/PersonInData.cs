using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Models;

namespace HRPortal.Data.DataRepositories
{
    public class PersonInData : IPersonRepository
    {
        public Person GetPerson(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetPersonsByLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAllPeople()
        {
            throw new NotImplementedException();
        }

        public void AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public void EditPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(int id)
        {
            throw new NotImplementedException();
        }
    }
}
