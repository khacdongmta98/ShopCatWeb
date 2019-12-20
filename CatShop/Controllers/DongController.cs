using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatShop.Models;

namespace CatShop.Controllers
{
    public class DongController : Controller
    {
        //
        // GET: /Dong/
        //List<CatCustomModel> listcats = new List<CatCustomModel>();
        //private CatDbContext context;
        //string check = " ";
        public ActionResult Index()
        {

            if (Session["check"] == null) 
           {
                return Redirect("~/Dong/Login_1");
           }
            else
            {
                List<Blog> danhsach = new List<Blog>();
                using (CatDbContext data = new CatDbContext())
                {

                    danhsach.AddRange(data.Blogs.Where(x => x.Ma_blog != " "));
                }

                return View(danhsach);
            }
           
            ///return Redirect("~/dong/Login_1");
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
            return Redirect("~/Dong");
        }


        public ActionResult huy()
        {
            return View();
        }

        public ActionResult update()
        {
            return View();
        }
        
        public ActionResult update(string id) 
        {
            CatDbContext data = new CatDbContext();
            Blog blog = new Blog();
            data.Blogs.Single(x => x.Ma_blog == id);
            return View();
        }
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Them(string id, HttpPostedFileBase filename, string title, string noidung)
        {
            CatDbContext data = new CatDbContext();
            string dlink = "Meo_anh_long_dai";
            Blog item = null;

            item = data.Blogs.SingleOrDefault(x => x.Ma_blog == id);
            Blog blog = new Blog();
            if (item == null)
            {
                var link = System.IO.Path.GetFileName(filename.FileName);
                String ImagePath = "~/Anh meo/" + dlink + "/" + filename.FileName;
                filename.SaveAs(Server.MapPath(ImagePath));

                blog = new Blog
                {
                    Ma_blog = id,
                    Title = title,
                    NoiDung = noidung,
                    img = ImagePath.Substring(2, ImagePath.Length - 2),
                    slview = 0
                };
            }
            data.Blogs.Add(blog);
            data.SaveChanges();
            return Redirect("~/Dong/Index");
        }
        [HttpGet]
        public ActionResult Login_1()
        {
            Account acc = new Account();
            return View(acc);
        }
       [HttpPost]
        public ActionResult Login_1(Account acc)
        {
            
            string Name = acc.TaiKhoan;
            string PassWord = acc.MatKhau;
            Session["check"] = null;
            List<Account> List = new List<Account>();
            CatDbContext data = new CatDbContext();
            var account = data.C_Login;
            foreach (var item in account)
            {
                if (Name == item.TaiKhoan && PassWord == item.MatKhau && item.PhanQuyen ==0 )
                {
                    //check = "admin";
                    Session["check"] = "admin";
                    break;
                }
                 else if(Name == item.TaiKhoan && PassWord == item.MatKhau && item.PhanQuyen == 1)
                {
                    // check = "nguoi dung";
                    Session["check"] = "nguoidung";
                    break;
                }
               
            }
            
            if (Session["check"]==null)
                return RedirectToAction("Login_1");

            return RedirectToAction("Index");
         
        }
        public ActionResult LogOut()
        {
            Session["check"] = null;
            return RedirectToAction("Login_1");
        }
        public ActionResult DangKi()
        {
            return View();
        }
        public void Delete(string IDBlog)
        {
            CatDbContext db = new CatDbContext();
            Blog bl = db.Blogs.SingleOrDefault(x => x.Ma_blog == IDBlog);
            db.Blogs.Remove(bl);
            db.SaveChanges();
           
        }
    }
}
