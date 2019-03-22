using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class FilmContext : DbContext
    {
        static FilmContext()
        {
            //Database.SetInitializer<FilmContext>(new MyContextInitializer());
        }

        public FilmContext()
        {
        }

        public DbSet<Film> Films { get; set; }

    }



    class MyContextInitializer : DropCreateDatabaseAlways<FilmContext>
    {
        protected override void Seed(FilmContext db)
        {
            db.SaveChanges();
        }
    }
}