using DrinkAndGo1.Data;
using DrinkAndGo1.Models;
using DrinkAndGo1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DrinkAndGo1.Controllers
{
    public class HomeController : Controller
    {
        private DrinkAndGoContext db = new DrinkAndGoContext();

        public ActionResult ShowAllDrinks()
        {
            DrinkListViewModel dm = new DrinkListViewModel();
            dm.Drinks = db.Drinks.ToList();
            dm.CurrentCategory = "drink category";
            return View(dm);
        }

        public ActionResult Index()
        {
            List<Drink> drinks = db.Drinks.ToList();
            List<Drink> prefered = new List<Drink>();

            foreach(var drink in drinks)
            {
                if (drink.IsPreferredDrink)
                {
                    prefered.Add(drink);
                }
            }
            return View(prefered);
        }

        public ActionResult ShowAlcoholicDrinks()
        {
            List<Drink> drinks = db.Drinks.ToList();
            List<Drink> prefered = new List<Drink>();

            foreach (var drink in drinks)
            {
                if (drink.CategoryId == 1)
                {
                    prefered.Add(drink);
                }
            }

            return View(prefered);
        }

        public ActionResult ShowNonAlcoholicDrinks()
        {
            List<Drink> drinks = db.Drinks.ToList();
            List<Drink> prefered = new List<Drink>();

            foreach (var drink in drinks)
            {
                if (drink.CategoryId == 2)
                {
                    prefered.Add(drink);
                }
            }

            return View(prefered);
        }

        public ActionResult SearchOn(string str)
        {
            DrinkListViewModel modelList = new DrinkListViewModel();
            modelList.Drinks = db.Drinks.Where(d => str == null || d.Name.StartsWith(str)).ToList();
            return View(modelList);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drink drink = db.Drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
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