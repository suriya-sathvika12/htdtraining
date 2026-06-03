using System.Linq;
using System.Web.Mvc;
using MoviesMVC.Models;
using MoviesMVC.Repository;

namespace MoviesMVC.Controllers
{
    public class MovieController : Controller
    {
        MovieRepository repo = new MovieRepository();

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            repo.Insert(movie);
            repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            repo.Save();
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int year)
        {
            MovieContext db = new MovieContext();

            var result = db.Movies
                .Where(m => m.DateOfRelease.Year == year)
                .ToList();

            return View(result);
        }

        public ActionResult MoviesByDirector(string directorName)
        {
            MovieContext db = new MovieContext();

            var result = db.Movies
                .Where(m => m.DirectorName == directorName)
                .ToList();

            return View(result);
        }
    }
}