using OddToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OddToFood.Controllers
{
    public class HomeController : Controller
    {
       // OddToFoodDb _db = new OddToFoodDb();

        public ActionResult Index()
        {

           // var model = _db.Restourants.ToList();

            return View();
        }

        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Aleksandar";
            model.Location = "Radovis, Macedonia";

            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (_db != null)
        //    {
        //        _db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
