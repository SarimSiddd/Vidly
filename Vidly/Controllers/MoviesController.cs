using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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

        public ActionResult Edit (int Id)
        {
            return Content(string.Format("The Id is {0}", Id));
        }

        //Id here is nullable
        public ActionResult Index ()
        {
            MoviesViewModel viewModel = new MoviesViewModel();
            return View(viewModel);
        }

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month){

            return Content(string.Format("{0}, {1}", year, month));
        }
    }
}