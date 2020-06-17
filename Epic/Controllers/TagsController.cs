using Epic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Epic.DAL.DAL_Models;

namespace Epic.Controllers
{
    public class TagsController : Controller
    {

        // GET: Posts
        public ActionResult Index()
        {
            //     return View(db.Posts.ToList());
            return View(DAL_Tag.ListTags());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tagu = DAL.DAL_Models.DAL_Tag.Read(id);
            if (tagu == null)
            {
                return HttpNotFound();
            }
            return View(tagu);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tag tagu)
        {
            if (ModelState.IsValid)
            {
                DAL_Tag.Create(tagu);
                return RedirectToAction("Index");
            }
            return View(tagu);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tagu = DAL.DAL_Models.DAL_Tag.Read(id);
            if (tagu == null)
            {
                return HttpNotFound();
            }
            return View(tagu);
        }

        // POST: Posts/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tag tagu)
        {
            if (ModelState.IsValid)
            {
                DAL_Tag.Update(tagu);
                return RedirectToAction("Index");
            }
            return View(tagu);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tagu = DAL.DAL_Models.DAL_Tag.Read(id);
            if (tagu == null)
            {
                return HttpNotFound();
            }
            return View(tagu);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DAL.DAL_Models.DAL_Tag.Delete(id);
            return RedirectToAction("Index");
        }
    }
}