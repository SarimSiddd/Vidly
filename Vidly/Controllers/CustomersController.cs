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
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {

            var Customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(Customers);
        }

        [Route("Customers/Details/{id}")]
        public ActionResult Details(int id)
        {
            var Customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (Customer == null)
                return HttpNotFound();

            var viewModel = new CustomersViewModel();
           // var Customer = viewModel.Customers[id];
            return View(Customer);
        }
    }
}