using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class CustomersViewModel
    {
        public List<Customer> Customers = new List<Customer>
        {
                new Customer { Id= 0, Name = "John Smith" },
                new Customer { Id= 1, Name = "Mary Williams"}
        };

    }
}