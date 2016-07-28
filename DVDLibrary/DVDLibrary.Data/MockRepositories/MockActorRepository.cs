using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.MockRepositories
{
    public class MockActorRepository : IActorRepository
    {
        private static List<Actor> _actors;

        public MockActorRepository()
        {
            _actors = new List<Actor>
            {
                new Actor
                {
                    ActorID = 1,
                    FirstName = "Sam",
                    LastName = "DelBrocco",
                    HometownCity = "Aurora",
                    HometownState = "Ohio",
                    Description = "Born an Ohio native, this actress moved to Los Angeles at 2 years old to persue acting.",
                    DateOfBirth = "07/30/1990",
                },
                new Actor
                {
                    ActorID = 1,
                    FirstName = "Tom",
                    LastName = "Bohn",
                    HometownCity = "WestLake",
                    HometownState = "Ohio",
                    Description = "Born an Ohio native, this actor moved to Los Angeles at 12 years old to persue acting.",
                    DateOfBirth = "12/30/1990",
                },
                new Actor
                {
                    ActorID = 1,
                    FirstName = "Chris",
                    LastName = "Mason",
                    HometownCity = "Stevensville",
                    HometownState = "Michigan",
                    Description = "Born an Ohio native, this actree moved to Los Angeles at 2 years old to persue acting.",
                    DateOfBirth = "10/06/1990",
                }
            };
        }


        public Actor GetActor(int actorId)
        {
            return _actors.FirstOrDefault(a => a.ActorID == actorId);
        }

        public IEnumerable<Actor> GetAllActors()
        {
            return _actors;
        }

        public void AddActor(Actor actor)
        {
            actor.ActorID = GetNextID();
            _actors.Add(actor);
        }

        private int GetNextID()
        {
            if (_actors.Count == 0)
            {
                return 1;
            }
            int id = _actors.First(x => x.ActorID == _actors.Max(n => n.ActorID)).ActorID;
            return ++id;
        }

        public void EditActor(Actor actor)
        {
            var selectedActor = _actors.FirstOrDefault(a => a.ActorID == actor.ActorID);

            selectedActor.FirstName = actor.FirstName;
            selectedActor.LastName = actor.LastName;
            selectedActor.Description = actor.Description;
            selectedActor.DateOfBirth = actor.DateOfBirth;
            selectedActor.HometownCity = actor.HometownCity;
            selectedActor.HometownState = actor.HometownState;
        }

        public void DeleteActor(int id)
        {
            _actors.RemoveAll(a => a.ActorID == id);
        }
    }
}
