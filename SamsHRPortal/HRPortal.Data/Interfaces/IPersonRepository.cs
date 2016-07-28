using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Models;

namespace HRPortal.Data.Interfaces
{
    public interface IPersonRepository
    {
        Person GetPerson(int id);
        List<Person> GetPersonsByLastName(string lastName);
        IEnumerable<Person> GetAllPeople();
        void AddPerson(Person person);
        void EditPerson(Person person);
        void DeletePerson(int id);
    }
}
