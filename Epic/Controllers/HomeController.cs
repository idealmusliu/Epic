using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Epic.DAL.DAL_Models;
using Epic.Models;
using Microsoft.AspNet.Identity;
namespace Epic.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var posts = DAL_Post.ListPost();
            var favouriteposts = DAL_Favorites.GetFavoritePostsByCurrentUser(User.Identity.GetUserId());
            if (favouriteposts!=null)
            {
                foreach (int item in favouriteposts)
                {
                    Post post = posts.Where(x=>x.PostID==item).FirstOrDefault();
                    if (post!=null)
                    {
                        post.isFavorite = true;
                    }
                }
            }
            return View(posts);
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
    }
}