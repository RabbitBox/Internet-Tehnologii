using FirstDrink.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstDrink.Controllers
{
    public class DrinksController : Controller
    {
        static List<Drink> drinkList = new List<Drink>()
        {
            new Drink()
            {
                name = "Sex on the beach", img = @"https://ae01.alicdn.com/kf/HTB1tIWWRpXXXXXZXFXXq6xXFXXXp/48pcs-Hawaiian-Hula-Beach-Party-Coloured-Cocktail-Umbrella-Parasol-Drinking-Straws-For-Kids-Birthday-Wedding-Decoration.jpg_640x640.jpg",
                rating = 4.2f, ingredients = "orange, vodka, peach, cranberry", isAlcoholic = true
            },
            new Drink()
            {
                name = "Alabama Slammer", img = @"https://cdn.liquor.com/wp-content/uploads/2018/07/27061649/alabama-slammer-720x720-recipe.jpg",
                rating = 2.8f, ingredients = "lemon, jin, peach, mint", isAlcoholic = true
            }
        };

        static List<Countries> countries = new List<Countries>()
        {
            new Countries()
            {
                name = "United States of America", population = 250000000, religion = "Christian"
            },
            new Countries()
            {
                name = "Brazil", population = 110000000, religion = "Christian"
            },
        };


        // GET: Drinks
        public ActionResult GetAllDrinks()
        {
            return View(drinkList);
        }
        public ActionResult ShowDrink(int id)
        {
            Drink drink = drinkList.ElementAt(id);
            DrinksAndConutries model = new DrinksAndConutries();
            model.drink = drink;
            model.countriesDrinks = countries;
            return View(model);
        }
        public ActionResult ShowCountry(int id)
        {
            Countries country = countries.ElementAt(id);
            return View(country);
        }
        public ActionResult AddNewDrink()
        {
            Drink drink = new Drink();
            return View(drink);
        }
        [HttpPost]
        public ActionResult AddNewDrinkPost(Drink model)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNewDrink", model);
            }

            drinkList.Add(model);
            return View("GetAllDrinks",drinkList);
        }
        public ActionResult AddNewCountry()
        {
            Countries country = new Countries();
            return View(country);
        }
        [HttpPost]
        public ActionResult AddNewCountryPost(Countries model)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNewCountry", model);
            }

            countries.Add(model);
            return View("GetAllDrinks", drinkList);
        }
        public ActionResult EditDrink(int id)
        {
            Drink model = drinkList.ElementAt(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditDrinkPost(Drink model)
        {
            if (!ModelState.IsValid)
            {
                return View("EditDrink", model);
            }

            drinkList.RemoveAt(model.id);
            drinkList.Insert(model.id, model);

            return View("GetAllDrinks", drinkList);
        }
        public ActionResult DeleteDrink(int id)
        {
            drinkList.RemoveAt(id);
            return View("GetAllDrinks", drinkList);
        }

    }
}