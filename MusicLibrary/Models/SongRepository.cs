using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class SongRepository : ISongRepository
    {
        private ApplicationDbContext context;
        public SongRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Song> Songs => context.Songs;
    }
}
