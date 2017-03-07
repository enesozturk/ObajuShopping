using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObajuShopping.Models;
using ObajuShopping.ViewModels;

namespace Obaju.Controllers
{
    [Authorize(Roles = "admin")]
    public class BlogController : Controller
    {
        AaadbEntities db = new AaadbEntities();

        // GET: Blog
        public ActionResult Index()
        {

            var posts = db.Blogs.ToList();

            return View(posts);
        }


        public ActionResult Post(int id)
        {
            BlogViewModel bvm = new BlogViewModel();

            var post = db.Blogs.FirstOrDefault(f => f.id == id);
            if (post == null)
            {
                throw new HttpException(404, "Couldn't Found");
            }
            bvm.post = post;
            if (post != null)
            {
                bvm.LatestPosts = db.Blogs.OrderByDescending(p => p.yazar == post.yazar && p.id != post.id).ToList();
            }


            return View(bvm);
        }
    }
}
