using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MusicLibrary.Models
{
    public class InitialData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Songs.Any())
            {
                context.Songs.AddRange(
                    new Song
                    {
                        Title = "House of the Rising Sun",
                        Artist = "The Animals",
                        Album = "Most of the Animals",
                        Genre = "Rock"
                    },
                    new Song
                    {
                        Title = "Summer in the City",
                        Artist = "The Lovin' Spoonful",
                        Album = "Woodstock Generation",
                        Genre = "Rock"
                    },
                    new Song
                    {
                        Title = "Gravel Pit",
                        Artist = "Wu-Tang Clan",
                        Album = "Legend of the Wu-Tang",
                        Genre = "Hip hop"
                    },
                    new Song
                    {
                        Title = "The Big Payback",
                        Artist = "EPMD",
                        Album = "Unfinished Business",
                        Genre = "Hip Hop"
                    },
                    new Song
                    {
                        Title = "The Bottle",
                        Artist = "Gil Scott-Heron",
                        Album = "Johannesburg",
                        Genre = "Funk"
                    });
                context.SaveChanges();
            }
            if (!context.Login.Any())
            {
                context.Login.AddRange(
                    new Login
                    {
                        Username = "jazz",
                        Password = "jazz123"
                    },
                      new Login
                      {
                          Username = "admin",
                          Password = "admin123"
                      });
                context.SaveChanges();
            }

        }
    }
}
