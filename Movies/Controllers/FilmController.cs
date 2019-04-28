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
        private readonly FilmRepository _repository;
        private readonly int _pageSize = 10;
        private readonly int _pageTotalOnView = 10;
        //static public List<Film> Films = new List<Film>();






        public FilmController()
        {

            _repository = new FilmRepository();
        }




        // GET: Film
        public ActionResult FilmIndex(int page=1)
        {
            var films = _repository.GetFilms();
            IEnumerable<Film> filmsOnPage = films.Skip((page - 1) * _pageSize).Take(_pageSize);

            bool flPrevPages = false;
            bool flNextPages = true;
            int pageCount = (int)Math.Ceiling((decimal)films.Count() / _pageSize);
            int beginPageNumber = ((page-1) / _pageTotalOnView)* _pageTotalOnView + 1;
            int endPageNumber = beginPageNumber + _pageTotalOnView - 1;

            if (beginPageNumber > _pageTotalOnView) flPrevPages = true;
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

            return View("FilmIndex",filmsViewModel);
        }


        public ActionResult FilmTable(int page = 1, int type=1)
        {
            var films = _repository.GetFilms();
            IEnumerable<Film> filmsOnPage = films.Skip((page - 1) * _pageSize).Take(_pageSize);

            bool flPrevPages = false;
            bool flNextPages = true;
            int pageCount = (int)Math.Ceiling((decimal)films.Count() / _pageSize);
            int beginPageNumber = ((page - 1) / _pageTotalOnView) * _pageTotalOnView + 1;
            int endPageNumber = beginPageNumber + _pageTotalOnView - 1;

            if (beginPageNumber > _pageTotalOnView) flPrevPages = true;
            if (endPageNumber > pageCount) endPageNumber = pageCount;
            if (endPageNumber == pageCount) flNextPages = false;

            //var fFilmsName = filmsOnPage.Select(f => f.Name);

            var filmsViewModel = new FilmsViewModel
                {
                Title = "Список фильмов",
                Films = filmsOnPage,
                FilmsName = filmsOnPage.Select(f => f.Name),
                PageInfo = new PageInfo()
                {
                    PageActiveNumber = page,
                    BeginPageNumber = beginPageNumber,
                    EndPageNumber = endPageNumber,
                    FlPrevPages = flPrevPages,
                    FlNextPages = flNextPages
                }
            };

            var filmsViewModelMin = new 
            {
                Title = "Список фильмов",
                Films = filmsOnPage.Select(f => f.Name),
                PageInfo = new PageInfo()
                {
                    PageActiveNumber = page,
                    BeginPageNumber = beginPageNumber,
                    EndPageNumber = endPageNumber,
                    FlPrevPages = flPrevPages,
                    FlNextPages = flNextPages
                }
            };

            if (type == 1) return View("FilmIndex", filmsViewModel);
            if (type == 2) return PartialView(filmsViewModel);
            if (type == 3) return Json(filmsViewModelMin, JsonRequestBehavior.AllowGet);
            //if (type == 3) return Json(filmsOnPage.Select(f => f.Name), JsonRequestBehavior.AllowGet);

            return RedirectToAction("Index", "Home");

        }

        public ActionResult Test()
        {
            return PartialView();
        }


    }



}