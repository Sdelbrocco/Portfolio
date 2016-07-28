using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPortal.Data.Interfaces;
using HRPortal.Models;

namespace HRPortal.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private static List<Person> _persons;

        static PersonRepository()
        {
            _persons = new List<Person>
            {
                new Person { Id = 1, FirstName = "Samantha", LastName = "DelBrocco", Address = "123 S. Main St.", PhoneNumber = "440-821-7260", Email = "delbrocco.sam@gmail.com"},
                new Person { Id = 2, FirstName = "Chris", LastName = "Mason", Address = "22 E 4th St.", PhoneNumber = "440-234-5689", Email = "Mason.Chris@gmail.com"},
                new Person { Id = 3, FirstName = "Audrey", LastName = "Cooper", Address = "112 Wabash Ave.", PhoneNumber = "440-563-6894", Email = "Cooper.Audrey@gmail.com"},
                new Person { Id = 4, FirstName = "Danielle", LastName = "DelBrocco", Address = "124 N. LakeShore Dr.", PhoneNumber = "440-234-5788", Email = "delbrocco.Danielle@gmail.com"},
            };
        }


        public List<Person> GetPersonsByLastName(string lastName)
        {
            return _persons.FindAll(p => p.LastName == lastName);
        }


        public Person GetPerson(int id)
        {
            return _persons.FirstOrDefault(p => p.Id == id);
        }


        public IEnumerable<Person> GetAllPeople()
        {
            return _persons;
        }


        public void AddPerson(Person person)
        {
            person.Id = GetNextID();
            _persons.Add(person);
        }

        private void ReadFromFile()
        {
            var fileName = "";
            using (StreamReader sr = new StreamReader(fileName))
            {
                string input = "";
                while ((input = sr.ReadLine()) != null)
                {
                    Application application = new Application();
                    application.FromCSV(input);
                }
            }
        }
        private void Writing()
        {
            var fileName = "";
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                string input = "";
                foreach (var person in _persons)
                {
                    sw.WriteLine(person.ToString());
                }
               
            }
        }

        public void EditPerson(Person person)
        {
            var selectedPerson = _persons.FirstOrDefault(p => p.Id == person.Id);

            selectedPerson.FirstName = person.FirstName;
            selectedPerson.LastName = person.LastName;
            selectedPerson.Address = person.Address;
            selectedPerson.PhoneNumber = person.PhoneNumber;
        }


        public void DeletePerson(int id)
        {
            _persons.RemoveAll(p => p.Id == id);
        }


        private int GetNextID()
        {
            if (_persons.Count == 0)
            {
                return 1;
            }
            int id = _persons.First(x => x.Id == _persons.Max(n => n.Id)).Id;
            return ++id;
        }
    }
}
