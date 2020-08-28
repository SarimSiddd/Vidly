using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {

            var myCustomers = new List<Customer>
            {
                new Customer {Name = "Customer1" },
                new Customer {Name = "Customer2" }
            };

            Movie myMovie = new Movie { Name = "Shrek!" };
            RandomMovieViewModel viewModel = new RandomMovieViewModel
            {
                Movie = myMovie,
                Customer = myCustomers
            };

            //return HttpNotFound();
            return View(viewModel);
        }

        //Id here is nullable
        public ActionResult Index ()
        {
            //MoviesViewModel viewModel = new MoviesViewModel();
            var Movies = _context.Movies.Include(c => c.Genre).ToList();
            if (!Movies.Any())
                return HttpNotFound();
            return View(Movies);
        }

        public ActionResult Details (int Id)
        {
            var Movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == Id);
            return View(Movie);
        }

        public ActionResult New()
        {
            var Genres = _context.Genres.ToList();
            var viewModel = new MoviesFormViewModel
            {
                Genres = Genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var Movie = _context.Movies.SingleOrDefault(c => c.Id == Id);
            if (Movie == null)
                return HttpNotFound();

            var viewModel = new MoviesFormViewModel(Movie)
            {
                Genres = _context.Genres.ToList()
            };
         
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MoviesFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            movie.DateAdded = DateTime.Now;
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else {
                var movieInDB = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDB.Name = movie.Name;
                movieInDB.ReleaseDate = movie.ReleaseDate;
                movieInDB.GenreId = movie.GenreId;
                movieInDB.NumberInStock = movie.NumberInStock;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}