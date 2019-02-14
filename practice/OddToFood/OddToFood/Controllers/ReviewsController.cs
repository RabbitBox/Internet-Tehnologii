//using OddToFood.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace OddToFood.Controllers
//{
//    public class ReviewsController : Controller
//    {

//        static List<RestorantReview> _reviews = new List<RestorantReview>
//        {
//            new RestorantReview
//            {
//                Id = 0,
//                Name = "Cinnamon Club",
//                City = "London",
//                Country = "UK",
//                Rating = 10,
//            },
//            new RestorantReview
//            {
//                Id = 1,
//                Name = "Marrakesh",
//                City = "D.C",
//                Country = "USA",
//                Rating = 10,
//            },
//            new RestorantReview
//            {
//                Id = 2,
//                Name = "The House of Eliot",
//                City = "Ghent",
//                Country = "Belgium",
//                Rating = 10,
//            },
//        };

//        public ActionResult BestReview()
//        {
//            var bestReview = from r in _reviews
//                             orderby r.Rating descending
//                             select r;

//            return PartialView("_Rewiev", _reviews.First());
//        }
//        //
//        // GET: /Reviews/

//        public ActionResult Index()
//        {
//            var model = _reviews;

//            return View(model);
//        }

//        //
//        // GET: /Reviews/Details/5

//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        //
//        // GET: /Reviews/Create

//        public ActionResult Create()
//        {
//            return View();
//        }

//        //
//        // POST: /Reviews/Create

//        [HttpPost]
//        public ActionResult Create(FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add insert logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        //
//        // GET: /Reviews/Edit/5

//        public ActionResult Edit(int id)
//        {
//            var review = _reviews.ElementAt(id);
//            return View(review);
//        }

//        //
//        // POST: /Reviews/Edit/5
        
//        [HttpPost]
//        public ActionResult Edit(RestorantReview model  /*int id,FormCollection collection*/)
//        {
//            _reviews.RemoveAt(model.Id);
//            _reviews.Insert(model.Id, model);     // zakomentiranoto e drug nacin istata funkcija

//            return View("Index", _reviews);

//           /* var review = _reviews.ElementAt(id);
//            if (TryUpdateModel(review))
//            {
//                return View("Index", _reviews);
//            }

//            return View("", review); */
//        }

//        //
//        // GET: /Reviews/Delete/5

//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        //
//        // POST: /Reviews/Delete/5

//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
