using Movies.Models;
using Movies.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly FileManager _fileManager;
        private readonly FilmRepository _repository;



        public HomeController()
        {

            _fileManager = new FileManager();
            _repository = new FilmRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Import()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Import(HttpPostedFileBase fileExcel)
        {
            
            if (ModelState.IsValid)
            {
                var responseDto = await _fileManager.InitialImportFromFile( new FileRequestDTO { FileExcel=fileExcel } );
                //FilmController.Films = responseDto.Films;

                _repository.ReInitialize();
                _repository.AddFilmRange(responseDto.Films);

                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Export()
        {
            return View();
        }
    }
}