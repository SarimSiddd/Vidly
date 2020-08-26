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

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month){

            return Content(string.Format("{0}, {1}", year, month));
        }
    }
}