using ObajuShopping.Admin.Models;
using ObajuShopping.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ObajuShopping.Admin.Controllers
{
    public class BlogController : Controller
    {
        private ObajuShoppingAdmin db = new ObajuShoppingAdmin();
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPosts()
        {
            var posts = db.Blog.ToList();
            return Json(posts, JsonRequestBehavior.AllowGet);
        }

        public string dateformat = "yyy-MM-dd";
        public ActionResult Get(int id)
        {
            var result = db.Blog.ToList().Find(p => p.id == id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)] // or add [AllowHtml] attr.
        public ActionResult Create(BlogViewModel post)
        {
            if (ModelState.IsValid)
            {
                var newpost = new Blog();
                newpost.baslik = post.BlogTitle;
                newpost.baslikresim = post.BlogImage;
                newpost.icerik = post.BlogContent;
                newpost.tarih = post.BlogDate;
                newpost.yazar = post.BlogAuthor;

                db.Blog.Add(newpost);
                db.SaveChanges();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var post = db.Blog.ToList().Find(x => x.id == id);

            if (post != null)
            {
                db.Blog.Remove(post);
                db.SaveChanges();
            }
            return Json(post, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog post = db.Blog.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Update",post);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Blog post)
        {
            if (ModelState.IsValid)
            {
                //var newpost = new Blog();
                //newpost.baslik = post.BlogTitle;
                //newpost.baslikresim = post.BlogImage;
                //newpost.icerik = post.BlogContent;
                //newpost.tarih = post.BlogDate;
                //newpost.yazar = post.BlogAuthor;

                //db.Blog.Attach(post);
                db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult Index(string k)
        {
            var result = db.Blog.Where(b => b.baslik.Contains(k)).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public PartialViewResult _SearchPosts(string keyword)
        {
            var data = db.Blog.Where(b => b.baslik.Contains(keyword)).ToList();
            return PartialView(data);
        }

        [HttpPost]
        public ActionResult Index(BlogViewModel p)
        {
            List<Blog> posts = db.Blog.ToList();

            Blog post = new Blog();
            post.baslik = p.BlogTitle;
            post.baslikresim = p.BlogImage;
            post.icerik = p.BlogContent;
            post.tarih = p.BlogDate;
            post.yazar = p.BlogAuthor;

            db.Blog.Add(post);
            db.SaveChanges();

            return View(p);
        }
    }
}