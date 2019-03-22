using Movies.Models;
using Movies.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class FilmController : Controller
    {
        //static public List<Film> Films = new List<Film>();



        private readonly FilmRepository _repository;



        public FilmController()
        {

            _repository = new FilmRepository();
        }




        // GET: Film
        public ActionResult Index(int page=1)
        {
            bool flPrevPages = false;
            bool flNextPages=true;
            int pageSize = 10;
            int pageTotalOnView = 10;


            var films = _repository.GetFilms();
            IEnumerable<Film> filmsOnPage = films.Skip((page - 1) * pageSize).Take(pageSize);

            int pageCount = (int)Math.Ceiling((decimal)films.Count() / pageSize);
            int beginPageNumber = ((page-1) / pageTotalOnView)* pageTotalOnView + 1;
            if (beginPageNumber > pageTotalOnView) flPrevPages = true;
            int endPageNumber = beginPageNumber + pageTotalOnView-1;
            if (endPageNumber > pageCount) endPageNumber = pageCount;
            if (endPageNumber == pageCount) flNextPages = false;

       


            var filmsViewModel = new FilmsViewModel
            {
                Title = "Список фильмов",
                Films = filmsOnPage,
                PageInfo = new PageInfo()
                {
                    PageActiveNumber = page,
                    BeginPageNumber = beginPageNumber,
                    EndPageNumber = endPageNumber,
                    FlPrevPages = flPrevPages,
                    FlNextPages = flNextPages
                }
            };

            return View(filmsViewModel);
        }
    }



}