using DTJD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DTJD.Controllers
{
    public class HomeController : Controller
    {
        private DTJD_Db db = new DTJD_Db();

        public ActionResult Index()
        {
            List<Drink> drinks = db.drinks.ToList();
            List<Drink> preferedDrinks = new List<Drink>();

            foreach(Drink d in drinks)
            {
                if (d.IsPreferreDrink)
                    preferedDrinks.Add(d);
            }

            return View(preferedDrinks);
        }

        public ActionResult About()
        {
            
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult ShowAllDrinks(string str)
        {
            CategoryDrinkModel model = new CategoryDrinkModel();

            if (string.IsNullOrEmpty(str))
            {
                model.drinks = db.drinks.ToList();
                model.currentCategory = "All Drinks";
                return View(model);
            }
            if (str.Equals("All Drinks"))
            {
                model.drinks = db.drinks.ToList();
                model.currentCategory = str;
                return View(model);
            }
            else if (str.Equals("Alcoholic"))
            {
                model.drinks = db.drinks.Where(p => p.Category.CategoryName.Equals("Alcoholic")).ToList();
                model.currentCategory = str;
                return View(model);
            }
            else if(str.Equals("Non-Alcoholic"))
            {
                model.drinks = db.drinks.Where(p => p.Category.CategoryName.Equals("Non-Alcoholic")).ToList();
                model.currentCategory = str;
                return View(model);
            }

            return View(model);
            
        }
        public ActionResult SearchOn(string str)
        {
            CategoryDrinkModel modelList = new CategoryDrinkModel();
            modelList.drinks = db.drinks.Where(d => str == null || d.Name.StartsWith(str)).ToList();
            modelList.currentCategory = "Mixed";
            return View("ShowAllDrinks",modelList);
        }
        public ActionResult DrinkDetails(int id)
        {
            Drink model = db.drinks.Find(id);

            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}