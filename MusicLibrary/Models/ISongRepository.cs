﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public interface ISongRepository
    {
        IQueryable<Song> Songs { get; }
    }
}
