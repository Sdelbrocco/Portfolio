using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.DataRepositories;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Data.MockRepositories;

namespace DVDLibrary.Data.RepoFactory
{
    public class RepositoryFactory
    {
        public static IActorRepository GetActorRepository()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new MockActorRepository(); ;
            }
            return new ActorInMemory();
        }

        public static IBorrowRepository GetBorrowRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new MockBorrowRepository();
            }
            return new BorrowInMemory();
        }

        public static IDirectorRepository GetDirectorRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new MockDirectorRepository();
            }
            return new DirectorInMemory();
        }

        public static IDVDRepository GetDVDRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new MockDVDRepository();
            }
            return new DVDInMemory();
        }

        public static IGenreRepository GetGenreRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new MockGenreRepository();
            }
            return new GenreInMemory();
        }

        public static IMovieRepository GetMovieRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new MockMovieRepository();
            }
            return new MovieInMemory();
        }

        public static IMPAARatingInterface GetMPAARepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new MockMPAARatingRepository();
            }
            return new MPAARatingInMemory();
        }

        public static IRatingRepository GetRatingRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new MockRatingRepository();
            }
            return new RatingInMemory();
        }

        public static IUserRepository GetUserRepo()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];
            if (mode.ToUpper() == "TEST")
            {
                return new MockUserRepository();
            }
            return new UserInMemory();
        }
    }
}

