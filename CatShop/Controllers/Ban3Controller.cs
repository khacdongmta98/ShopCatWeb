using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CatShop.Models;
using System.Web.Mvc;

namespace CatShop.Controllers
{
    public class Ban3Controller : Controller
    {
        //
        // GET: /Ban3/

        public ActionResult Index()
        {
            List<Blog> danhsach = new List<Blog>();
            using (CatDbContext data = new CatDbContext())
            {

                danhsach.AddRange(data.Blogs.Where(x => x.Ma_blog != " "));
            }

            return View(danhsach);
        }
        public ActionResult Getdetail(string id)
        {
            //CatCustomModel Data = new CatCustomModel();
            CatDbContext data = new CatDbContext();
            Blog meo = data.Blogs.Single(x => x.Ma_blog == id);

            return View(meo);
        }
        public ActionResult Xoa(string id)
        {
            CatDbContext data = new CatDbContext();
            IEnumerable<CommentBlog> item1 = null;
            item1 = data.CommentBlogs.Where(x => x.Ma_blog == id);
            if (item1 != null)
            {
                data.CommentBlogs.RemoveRange(item1);
                data.SaveChanges();
            }
            Blog item = null;
            item = data.Blogs.SingleOrDefault(x => x.Ma_blog == id);
            if (item != null)
            {
                data.Blogs.Remove(item);
                data.SaveChanges();
            }
            return Redirect("~/ban3");
        }
        public ActionResult insert(string id)
        {
            CatDbContext data = new CatDbContext();
            List<Blog> danhsach = new List<Blog>();          
            {

                danhsach.AddRange(data.Blogs.Where(x => x.Ma_blog == "b01"));
            }
           // return Redirect("~/ban3/Index");
            return View(danhsach);
        }
    }
}
