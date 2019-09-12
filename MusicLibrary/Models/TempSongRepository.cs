using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class TempSongRepository : ISongRepository
    {
        public IQueryable<Song> Songs => new List<Song>
        {
            new Song { SongID = 1, Title = "The House of the Rising Sun", Artist = "The Animals", Album = "Most of the Animals"},
            new Song { SongID = 2, Title = "Soul Makossa", Artist = "Manu Dibango", Album = "Anthology"},
            new Song { SongID = 3, Title = "Summer In The City", Artist = "The Lovin' Spoonful", Album = "Woodstock Generation"}
        }.AsQueryable<Song>();
    }
}
