using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatShop.Function;
using CatShop.Models;
namespace CatShop.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        //[HttpGet]
        public ActionResult Login()
        {
            //Account acc = new Account();
            return View();
        }

        //[HttpGet]
        //public ActionResult CheckAccountAdmin()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            bool login = false;
            List<Account> ListAdmin = new List<Account>();
            CatDbContext data = new CatDbContext();
            var account = data.C_Login;



            foreach (var item in account)
            {
                if (username == item.TaiKhoan && password == item.MatKhau)
                    login = true;

            }

            if (login)
                return RedirectToAction("AdminHome");

            return RedirectToAction("Login");
        }

        public ActionResult AdminHome()
        {
            return View(functionHanding.GetAllCat());

        }
        /// <summary>
        /// get cat type
        /// </summary>
        /// <returns>partial cat type on modal</returns>
        [HttpGet]
        public ActionResult ModalData()
        {

            return PartialView();
        }

        [HttpPost]
        public String ModalData(CatCustomModel meo)
        {

            var file = meo.fileImage;

            CatDbContext data = new CatDbContext();
            String dlink = "";
            //meo.TenLoaiMeo = data.LoaiMeos.Single(x => x.Ma_Loai == meo.Ma_Loai).TenLoai;
            if (meo.Ma_Loai == "ML01")
            {
                dlink = "Meo_anh_long_dai";
            }

            if (file != null)
            {

                var fileName = System.IO.Path.GetFileName(file.FileName);
                //var extention = System.IO.Path.GetExtension(file.FileName);
                //var filenamewithoutextension = System.IO.Path.GetFileNameWithoutExtension(file.FileName);
                String ImagePath = "/Anh meo/" + dlink + "/" + file.FileName;
                file.SaveAs(Server.MapPath(ImagePath));


                Meo cat = new Meo
                {
                    Id = functionHanding.CountCat(),
                    img = ImagePath,
                    Ma_Loai = meo.Ma_Loai,
                    MauSac = meo.MauSac,
                    CanNang = meo.CanNang
                };


                try
                {
                    data.Meos.Add(cat);
                    data.SaveChanges();
                }
                catch (Exception)
                {
                    return "upload khong thanh cong";
                    throw;
                }


                return "upload thanh cong";
            }
            else if (meo.img != null)
            {
                Uri uri = new Uri(meo.img);
                string src = "/Anh meo/" + meo.TenLoaiMeo + "/" + meo.Id + ".jpg";
                AdminFunction.DownloadFiles(uri, src);

                Meo cat = new Meo
                {
                    Id = functionHanding.CountCat(),
                    img = src,
                    Ma_Loai = meo.Ma_Loai,
                    MauSac = meo.MauSac,
                    CanNang = meo.CanNang
                };

                try
                {
                    data.Meos.Add(cat);
                    data.SaveChanges();
                }
                catch (Exception)
                {
                    return "upload khong thanh cong";
                    throw;
                }
                return "upload thanh cong thong qua link anh";


            }





            else return "upload khong thanh cong";

        }

        public ActionResult ModalEdit()
        {


            return View();
        }
        [HttpPost]
        public String ModalEdit(CatCustomModel meo)
        {


            return "Sua doi thanh cong nhe ban hien";
        }

        public void DeleteCat(string id)
        {
            using (CatDbContext context = new CatDbContext())
            {



                var item = context.Meos.SingleOrDefault(x => x.Id == id);
                if (item != null)
                {
                    context.Meos.Remove(item);
                    context.SaveChanges();
                }
            }
        }
    }
}
