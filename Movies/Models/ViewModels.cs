using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class FilmsViewModel
    {
        public IEnumerable<Film> Films { get; set; }
        public IEnumerable<string> FilmsName { get; set; }
        public string Title { get; set; }
        public PageInfo PageInfo { get; set; }
        public FilmsViewModel()
        {
            Films = new List<Film>();
        }
    }

    public class PageInfo
    {
        public int PageActiveNumber { get; set; }
        public int BeginPageNumber { get; set; }
        public int EndPageNumber { get; set; }
        public bool FlPrevPages { get; set; }
        public bool FlNextPages { get; set; }
    }



    public class ResultViewModel
    {
        public string title;
        public string message;

    }


    //public class FilmViewModel
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Year { get; set; }
    //    public string Country { get; set; }
    //}


}