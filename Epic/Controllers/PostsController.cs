using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Epic.Models;
using Microsoft.AspNet.Identity;
using Epic.DAL.DAL_Models;
using System.IO;

namespace Epic.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            //     return View(db.Posts.ToList());
            return View(DAL_Post.ListPost());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = DAL.DAL_Models.DAL_Post.Read(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostVM model)
        {
            Post post = new Post();
            
            if (ModelState.IsValid)
            {
              
                if (model.Attachment != null)
                {
                    var inputFileName = Path.GetFileName(model.Attachment.FileName);
                    string dateTime = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString();
                    var ServerSavePath = Path.Combine(Server.MapPath("~/Images/") + dateTime + inputFileName);
                    model.Attachment.SaveAs(ServerSavePath);
                    model.PicPath = dateTime + inputFileName;
                    model.Date = DateTime.Now;
                }
                
                post.UserID = model.UserID;
                post.PicPath = model.PicPath;
                post.Attachment = model.Attachment;
                post.Date = model.Date;
                post.isDeleted = model.isDeleted;
                post.MyTags = model.MyTags;
                post.Description = model.Description;
                post.isFavorite = model.isFavorite;
           
                post.UserID = User.Identity.GetUserId();
                DAL.DAL_Models.DAL_Post.Create(post);
                return RedirectToAction("Index");
            }


            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = null;
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                DAL_Post.Update(post);
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = DAL.DAL_Models.DAL_Post.Read(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DAL.DAL_Models.DAL_Post.Delete(id);
            return RedirectToAction("Index");
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
