using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.MockRepositories
{
    public class MockDirectorRepository : IDirectorRepository
    {
        private static List<Director> _directors;


        public MockDirectorRepository()
        {
            _directors = new List<Director>
            {
                new Director
                {
                    DirectorID = 1,
                    FirstName = "Steven",
                    LastName = "Spielberg"
                },
                new Director
                {
                    DirectorID = 2,
                    FirstName = "Quentin",
                    LastName = "Tarantino"
                },
                new Director
                {
                    DirectorID = 3,
                    FirstName = "Wes",
                    LastName = "Anderson"
                }
            };
        }


        public Director GetDirector(int directorId)
        {
            return _directors.FirstOrDefault(d => d.DirectorID == directorId);
        }


        public IEnumerable<Director> GetAllDirectors()
        {
            return _directors;
        }


        public void AddDirector(Director director)
        {
            director.DirectorID = GetNextID();
            _directors.Add(director);
        }


        public void EditDirector(Director director)
        {
            var selectedDirector = _directors.FirstOrDefault(d => d.DirectorID == director.DirectorID);

            selectedDirector.FirstName = director.FirstName;
            selectedDirector.LastName = director.LastName;
        }


        public void DeleteDirector(int directorId)
        {
            _directors.RemoveAll(d => d.DirectorID == directorId);
        }

        private int GetNextID()
        {
            if (_directors.Count == 0)
            {
                return 1;
            }
            int id = _directors.First(x => x.DirectorID == _directors.Max(n => n.DirectorID)).DirectorID;
            return ++id;
        }
    }
}
