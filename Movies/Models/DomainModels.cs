using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Country { get; set; }
        public int? RatingIMDB { get; set; }
        public int? RatingKinopoisk { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Producer> Producers { get; set; }

        public Film()
        {
            Genres = new List<Genre>();
            Actors = new List<Actor>();
            Producers = new List<Producer>();
        }
    }

    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Weight { get; set; }

        public virtual ICollection<Film> Films { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }

        public Actor()
        {
            Films = new List<Film>();
            Genres = new List<Genre>();
        }
    }

    public class Producer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Weight { get; set; }

        public virtual ICollection<Film> Films { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }

        public Producer()
        {
            Films = new List<Film>();
            Genres = new List<Genre>();
        }
    }


    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public virtual ICollection<Film> Films { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Producer> Producers { get; set; }

        public Genre()
        {
            Films = new List<Film>();
            Actors = new List<Actor>();
            Producers = new List<Producer>();
        }


    }




}