using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.DataRepositories
{
    public class ActorInMemory : IActorRepository
    {
        public Actor GetActor(int actorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetAllActors()
        {
            throw new NotImplementedException();
        }

        public void AddActor(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void EditActor(Actor actor)
        {
            throw new NotImplementedException();
        }

        public void DeleteActor(int id)
        {
            throw new NotImplementedException();
        }
    }
}
