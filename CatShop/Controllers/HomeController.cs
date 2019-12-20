using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatShop.Models;
using System.Linq;
using CatShop.Function;

namespace CatShop.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {

            MultiCustomModel multicus = new MultiCustomModel();
            multicus.blogcat.AddRange(functionHanding.GetBlogCat());
            multicus.ModelCAT_CarouselStart.AddRange(functionHanding.GetCatCarouselStart());
            multicus.ModelCAT_Trending.AddRange(functionHanding.GetCatTrending());
            multicus.ModelCAT_BestSeller.AddRange(functionHanding.GetCatBestSeller());
            multicus.lastblog.AddRange(functionHanding.GetCatBlogSection());
            return View(multicus);
        }


        public ActionResult Shop()
        {
            MultiCustomModel multicus = new MultiCustomModel();
            multicus.Shop_SectionStart.AddRange(functionAjax.GetCatOfType("ML01"));
            multicus.Product.AddRange(functionHanding.GetCatCarouselStart());
            return View(multicus);
        }

        public ActionResult Blog()
        {

            //kiem tra id page co phai la dang so hay khong ?
            CatDbContext db = new CatDbContext();
            int PageNum = Convert.ToInt32(db.Blogs.Count() / 5 + 0.5);
            ViewBag.PageNumber = PageNum;

            //1 -->1-10  ... 
            //nhan no voi 5 thi minh hien thi ra cac blog tu n-9-->n
            MultiCustomModel multicus = new MultiCustomModel();
            multicus.lastblog.AddRange(functionHanding.GetCatBlogSection());
            multicus.blogcat.AddRange(functionHanding.GetBlogCat());

            return View(multicus);
        }




        public ActionResult ViewBlog(String idBlog)
        {
            //xac dinh blog co id la idBlog
            MultiCustomModel multicus = new MultiCustomModel();
            multicus.lastblog.AddRange(functionHanding.UpgradeGetBlogCat(idBlog));



            return View(multicus);
        }




        public JsonResult GetCatType(string type)
        {

            //CatCustomModel cat = new CatCustomModel();


            return Json(functionAjax.GetCatOfType(type), JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetOnlyCat(string IDCat)
        {


            List<CatCustomModel> listcats = new List<CatCustomModel>();

            CatDbContext data = new CatDbContext();

            var cattable = data.Meos;
            //full best cat if check = 1
            var item = (from a in cattable
                        where a.Id == IDCat
                        select new
                        {
                            id = a.Id,
                            img = a.img,
                            mau = a.MauSac,
                            gia = a.GiaBan,
                            maloai = a.Ma_Loai
                        }).ToList();

            //
            foreach (var i in item)
            {
                listcats.Add(new CatCustomModel
                {
                    Id = i.id,
                    img = i.img,
                    MauSac = i.mau,
                    GiaBan = i.gia,
                    Ma_Loai = i.maloai
                });
            }
            return Json(listcats, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        //public ActionResult PostComment()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult PostComment(string HoTen, string id , string NoiDung)
        //{
        //    CatDbContext data = new CatDbContext();
        //    Blog blog = null;
        //    blog = data.Blogs.SingleOrDefault(x => x.Ma_blog == id);
        //    if(blog==null)
        //    {
        //        return Redirect("~/Home/ViewBlog?idBlog=" + id);

        //    }

        //        CommentBlog comment = new CommentBlog()
        //        {
        //            Ma_Comment = "CMT"+DateTime.UtcNow.Day+ DateTime.UtcNow.Hour+DateTime.UtcNow.Minute+ DateTime.UtcNow.Second,
        //            ThoiGian = DateTime.UtcNow,
        //            NoiDung = NoiDung,
        //            HoTen = HoTen,
        //            Ma_blog = id
        //        };
        //        data.CommentBlogs.Add(comment);
        //        data.SaveChanges();

            
        //    return Redirect("~/Home/ViewBlog?idBlog=" + id);
        //}

    }
    // them comment vao co so du lieu va dua len 
    //public ActionResult PostComment(string idBlog)
    //{

    //    return View();
    //}
}

