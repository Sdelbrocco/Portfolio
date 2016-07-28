using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.MockRepositories
{
    public class MockDVDRepository : IDVDRepository
    {
        private static List<DVD> _dvds;


        public MockDVDRepository()
        {
            _dvds = new List<DVD>
            {
                new DVD
                {
                    DVDID = 1,
                    MovieID = 1
                },
                new DVD
                {
                    DVDID = 2,
                    MovieID = 1
                },
                new DVD
                {
                    DVDID = 3,
                    MovieID = 1
                }
            };   
        }


        public DVD GetDvd(int dvdId)
        {
            return _dvds.FirstOrDefault(d => d.DVDID == dvdId);
        }


        public IEnumerable<DVD> GetAllDvds()
        {
            return _dvds;
        }


        public void AddDvd(DVD dvd)
        {
            dvd.DVDID = GetNextID();
            _dvds.Add(dvd);
        }


        public void EditDvd(DVD dvd)
        {
            var selectedDVD = _dvds.FirstOrDefault(d => d.DVDID == dvd.DVDID);

            selectedDVD.MovieID = dvd.MovieID;
        }


        public void DeleteDvd(int dvdId)
        {
            _dvds.RemoveAll(d => d.DVDID == dvdId);
        }


        private int GetNextID()
        {
            if (_dvds.Count == 0)
            {
                return 1;
            }
            int id = _dvds.First(x => x.DVDID == _dvds.Max(n => n.DVDID)).DVDID;
            return ++id;
        }
    }
}
