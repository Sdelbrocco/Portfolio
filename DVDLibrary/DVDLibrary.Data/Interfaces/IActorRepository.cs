using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.Interfaces
{
    public interface IActorRepository
    {
        Actor GetActor(int actorId);
        IEnumerable<Actor> GetAllActors();
        void AddActor(Actor actor);
        void EditActor(Actor actor);
        void DeleteActor(int id);
    }
}
