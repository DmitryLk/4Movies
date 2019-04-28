using Movies.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Movies.Repository
{
    public class FilmRepository
    {
        public FilmRepository() { }

        public IEnumerable<Film> GetFilms()
        {
            var result = new List<Film>();
            using (var context = new FilmContext())
            {
                //result = await context.Films.ToListAsync();
                //result = context.Films.Include(f => f.Actors).Include(f => f.Genres).Include(f => f.Producers).ToList();
                result = context.Films.ToList();
            }
            return result;
        }

        public void AddFilmRange(List<Film> films)
        {
            using (var context = new FilmContext())
            {
                context.Films.AddRange(films);
                context.SaveChanges();
            }
        }

        public void ReInitialize()
        { 
            Database.SetInitializer(new DropCreateDatabaseAlways<FilmContext>());
            using (var context = new FilmContext())
            {
                context.Database.Initialize(true);
            }
        }





    }
}