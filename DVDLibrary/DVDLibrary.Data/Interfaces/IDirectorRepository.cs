﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Models.Data;

namespace DVDLibrary.Data.Interfaces
{
    public interface IDirectorRepository
    {
        Director GetDirector(int directorId);
        IEnumerable<Director> GetAllDirectors();
        void AddDirector(Director director);
        void EditDirector(Director director);
        void DeleteDirector(int directorId);
    }
}
