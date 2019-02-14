using lab3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using lab3.Models;

namespace lab3.Controllers
{
    public class FriendController : Controller
    {
        FriendsAndChocholatesDB db = new FriendsAndChocholatesDB();
        protected override void Dispose(bool disposing)
        {
            if(db != null)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult nov()
        {
            var model = db.Chocolates.ToList();
            return View(model);
        }

        static List<FriendModel> friendsList = new List<FriendModel>()
        {
            new FriendModel()
            {
                Friend_id = 0, name = "Viktorija", place = "Konce", imgURL = @"https://lh3.googleusercontent.com/-JeFfEzMN6u4/AAAAAAAAAAI/AAAAAAAAAGs/0XNGNXGm8Ao/s640/photo.jpg"
            },
            new FriendModel()
            {
                Friend_id = 1, name = "Aleksandar", place = "Injevo", imgURL = @"https://vignette.wikia.nocookie.net/p__/images/c/ce/Shrek%27s_smile.jpeg/revision/latest?cb=20130711011930&path-prefix=protagonist"
            }
        };

        // GET: Friend
        public ActionResult ShowAllFriends()
        {
            return View(friendsList);
        }
       
        public ActionResult Edit(int id)
        {
            
            var friend = friendsList.ElementAt(id);
            friend.id = id;
            return View(friend);
        }

        [HttpPost]
        public ActionResult Edit(FriendModel friend)
        {
           
           if (!ModelState.IsValid)
            {
                return View("Edit", friend);
            }
            friendsList.RemoveAt(friend.id);
            friendsList.Insert(friend.id, friend);
            return RedirectToAction("ShowAllFriends", "Friend");
        }

        public ActionResult AddNewFriend()
        {
            FriendModel friend = new FriendModel();
            return View(friend);
        }

        [HttpPost]
        public ActionResult AddNewFriend(FriendModel friend)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNewFriend", friend);
            }
            friendsList.Add(friend);
            return View("ShowAllFriends", friendsList);
        }

        public ActionResult Delete(int id)
        {

            friendsList.RemoveAt(id);
            return View("ShowAllFriends", friendsList);
        }
    }
}