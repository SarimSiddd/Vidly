using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModel
{
    public class MoviesViewModel
    {
        public List<Movie> Movies = new List<Movie>
        {
                new Movie { Id= 0, Name = "Casablanca" },
                new Movie { Id= 1, Name = "An Ode to the Wind"}
        };
    }
}