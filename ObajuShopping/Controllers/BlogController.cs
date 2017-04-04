using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObajuShopping.Models;
using ObajuShopping.ViewModels;

namespace ObajuShopping.Controllers
{
    public class BlogController : Controller
    {
        ObajuEntities db = new ObajuEntities();

        public ActionResult Index()
        {
            var posts = db.Blog.ToList();

            return View(posts);
        }

        public ActionResult Post(int id)
        {
            BlogViewModel bvm = new BlogViewModel();

            var post = db.Blog.FirstOrDefault(f => f.id == id);
            if (post == null)
            {
                throw new HttpException(404, "Couldn't Found");
            }
            bvm.post = post;
            if (post != null)
            {
                bvm.LatestPosts = db.Blog.OrderByDescending(p => p.yazar == post.yazar && p.id != post.id).ToList();
            }

            return View(bvm);
        }
    }
}
