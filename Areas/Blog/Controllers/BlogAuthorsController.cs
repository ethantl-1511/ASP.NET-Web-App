using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TheatreCMS3.Areas.Blog.Models;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Blog.Controllers
{
    public class BlogAuthorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Blog/BlogAuthors
        public ActionResult Index()
        {
            return View(db.BlogAuthors.ToList());
        }

        // GET: Blog/BlogAuthors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            if (blogAuthor == null)
            {
                return HttpNotFound();
            }
            return View(blogAuthor);
        }

        // GET: Blog/BlogAuthors/Create
        [HeadAuthorAuthorize(Roles ="HeadAuthor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/BlogAuthors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HeadAuthorAuthorize(Roles = "HeadAuthor")]
        public ActionResult Create([Bind(Include = "BlogAuthorId,Name,Bio,Joined,Left")] BlogAuthor blogAuthor)
        {
            if (ModelState.IsValid)
            {
                db.BlogAuthors.Add(blogAuthor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogAuthor);
        }

        // GET: Blog/BlogAuthors/Edit/5
        [HeadAuthorAuthorize(Roles = "HeadAuthor")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            if (blogAuthor == null)
            {
                return HttpNotFound();
            }
            return View(blogAuthor);
        }

        // POST: Blog/BlogAuthors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HeadAuthorAuthorize(Roles = "HeadAuthor")]
        public ActionResult Edit([Bind(Include = "BlogAuthorId,Name,Bio,Joined,Left")] BlogAuthor blogAuthor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogAuthor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogAuthor);
        }

        // GET: Blog/BlogAuthors/Delete/5
        [HeadAuthorAuthorize(Roles = "HeadAuthor")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            if (blogAuthor == null)
            {
                return HttpNotFound();
            }
            return View(blogAuthor);
        }

        // POST: Blog/BlogAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [HeadAuthorAuthorize(Roles = "HeadAuthor")]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            db.BlogAuthors.Remove(blogAuthor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Method for Asyncronous Delete function
        [HttpPost]
        [HeadAuthorAuthorize(Roles = "HeadAuthor")]
        public JsonResult AsyncDelete(int id)
        {

            BlogAuthor blogAuthor = db.BlogAuthors.Find(id);
            var result = new JsonResult();

            db.BlogAuthors.Remove(blogAuthor);
            db.SaveChanges();

            return Json(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        // Method for the AccessDenied view
        public ActionResult AccessDenied()
        {
            return View();
        }

        // Method for Head Author
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class HeadAuthorAuthorize : AuthorizeAttribute
        {
            public string RedirectURL = "~/Blog/BlogAuthors/AccessDenied";

            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                base.HandleUnauthorizedRequest(filterContext);

                if (!filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    filterContext.Result = new RedirectResult(RedirectURL);
                }
            }
        }
    }
}
