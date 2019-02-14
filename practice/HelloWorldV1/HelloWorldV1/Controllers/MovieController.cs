using HelloWorldV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloWorldV1.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            Movies movies = new Movies();

            movies.SeedMovies();
            List<Movie> moviesList = movies.GetMoviesList();

            return View(moviesList);
        }
        public ActionResult MovieOfTheMonth()
        {
            return View();
        }
    }
}