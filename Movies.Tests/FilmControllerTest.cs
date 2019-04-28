using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Movies.Controllers;
using Movies.Models;
using NUnit.Framework;



namespace Movies.Tests
{
    [TestFixture]
    class FilmControllerTest
    {
        [Test]
        public void FilmIndex_ActionResult_NotNull()
        {
            //Arrange
            FilmController controller = new FilmController();

            //Act
            var result = controller.FilmIndex();

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void FilmIndex_ActionResult_ActionResultType()
        {
            //Arrange
            FilmController controller = new FilmController();

            //Act
            var result = controller.FilmIndex();

            //Assert
            Assert.IsInstanceOf(typeof(ViewResult), result);
        }


        [Test]
        public void FilmIndex_ActionResult_ViewResultName()
        {
            //Arrange
            FilmController controller = new FilmController();

            //Act
            var result = controller.FilmIndex();

            //Assert
            Assert.AreEqual("FilmIndex", (result as ViewResult).ViewName);
        }

        [Test]
        public void FilmIndex_ActionResult_Model()
        {
            //Arrange
            FilmController controller = new FilmController();

            //Act
            var result = controller.FilmIndex();

            //Assert
            Assert.IsInstanceOf(typeof(FilmsViewModel), (result as ViewResult).Model);
            Assert.IsInstanceOf(typeof(FilmsViewModel), (result as ViewResult).ViewData.Model);
            Assert.AreEqual("Список фильмов", ((result as ViewResult).ViewData.Model as FilmsViewModel).Title);
        }

        [Test]
        public void FilmTable_ActionResult_NotNull()
        {
            //Arrange
            FilmController controller = new FilmController();

            //Act
            var result = controller.FilmTable();

            //Assert
            Assert.IsNotNull(result);
        }


        [TestCase(1, 4)]
        [TestCase(1, 5)]
        [TestCase(1, 6)]
        [TestCase(1, 7)]
        public void FilmTable_ActionResult_ActionResultType(int page, int type)
        {
            //Arrange
            FilmController controller = new FilmController();

            //Act
            var result = controller.FilmTable(page, type);

            //Assert
            Assert.IsInstanceOf<RedirectToRouteResult>(result);
        }



    }
}
