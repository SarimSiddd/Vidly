using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {

            var viewModel = new CustomersViewModel();

            return View(viewModel);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var viewModel = new CustomersViewModel();
            var Customer = viewModel.Customers[id];
            return View(Customer);
        }
    }
}