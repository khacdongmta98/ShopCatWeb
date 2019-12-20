using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CatShop.Models;
using System.Linq;

namespace CatShop.Function
{
    public class functionHanding
    {
        public static List<CatCustomModel> GetCatCarouselStart()
        {
            List<CatCustomModel> listcats = new List<CatCustomModel>();

            CatDbContext data = new CatDbContext();
            
            var cattable = data.Meos;
            var typecat = data.LoaiMeos;
            //full best cat if check = 1
            var item = (from  b in cattable
                        join c in typecat on b.Ma_Loai equals c.Ma_Loai
                        orderby b.luot_like descending 
                        select new
                        {
                            id = b.Id,
                            img = b.img,
                            tenloai = c.TenLoai,
                            gia = b.GiaBan
                        }).ToList();

            //
            int k = 0;
            foreach (var i in item)
            {
                
                {
                    listcats.Add(new CatCustomModel
                    {
                        Id = i.id,
                        img = i.img,
                        TenLoaiMeo = i.tenloai,
                        GiaBan = i.gia
                    });
                    k++;
                    if (k == 3) break;
                }
            }
            return listcats;
        }

        public static List<CatCustomModel> GetCatTrending()
        {
            List<CatCustomModel> listcats = new List<CatCustomModel>();
            CatDbContext data = new CatDbContext();
            var cattable = data.Meos;
            var typecat = data.LoaiMeos;
            var item = (from  b in cattable 
                        join c in typecat on b.Ma_Loai equals c.Ma_Loai
                        orderby b.luot_like descending
                        select new
                        {
                            id = b.Id,
                            img = b.img,
                            ngaytuoi = b.Ngaytuoi,
                            tenloaimeo = c.TenLoai,
                            gia = b.GiaBan
                        }).ToList();
            int k = 0;
            foreach (var i in item)
            {
                listcats.Add(new CatCustomModel
                {
                    Id = i.id,
                    img = i.img,
                    Ngaytuoi = i.ngaytuoi,
                    TenLoaiMeo = i.tenloaimeo,
                    GiaBan = i.gia
                });
                k++;
                if (k == 8) break;
            }
            return listcats;
        }


        public static List<CatCustomModel> GetCatBestSeller()
        {
            List<CatCustomModel> listcats = new List<CatCustomModel>();
            CatDbContext data = new CatDbContext();
            var catseller = data.SellerCats;
            var cattable = data.Meos;
            var typecat = data.LoaiMeos;
            var item = (from a in catseller
                        join b in cattable on a.Id equals b.Id
                        join c in typecat on b.Ma_Loai equals c.Ma_Loai
                        where a.Check_cat == 1
                        select new
                        {
                            id = b.Id,
                            img = b.img,
                            gia = b.GiaBan,
                            giam = a.TiLeGiam

                        }).ToList();

            foreach (var i in item)
            {
                listcats.Add(new CatCustomModel
                {
                    Id = i.id,
                    img = i.img,
                    GiaBan = i.gia,
                    giamoi = Convert.ToString(Convert.ToInt32(i.gia) - Convert.ToInt32(i.gia) * Convert.ToInt32(i.giam) * 0.01)
                });
            }
            return listcats;
        }

        //public static List<CatCustomModel> GetSellCatBlogSection()
        //{
        //    List<CatCustomModel> listcats = new List<CatCustomModel>();
        //    CatDbContext data = new CatDbContext();
        //    var cattable = data.LastNews;
        //    var cattable1 = data.Meos;
        //    var item = (from a in cattable
        //                join b in cattable1 on a.Id equals b.Id
        //                where a.Check_cat == 1
        //                select new
        //                {
        //                    id = b.Id,
        //                    img = b.img
        //                }).ToList();

        //    foreach (var i in item)
        //    {
        //        listcats.Add(new CatCustomModel
        //        {
        //            Id = i.id,
        //            img = i.img
        //        });
        //    }
        //    return listcats;
        //}

        public static List<CustomBlog> GetCatBlogSection()
        {
            List<CustomBlog> list = new List<CustomBlog>();
            CatDbContext data = new CatDbContext();
            var blog = data.Blogs;
            var comment = data.CommentBlogs;
            

            var item = (from a in blog 
                        
                        select new 
                        {
                            mablog=a.Ma_blog,
                            img=a.img,
                            tieude=a.Title,
                            noidung=a.NoiDung
                        });
            int k = 0;
            foreach (var i in item)
            {
                list.Add(new CustomBlog
                    {
                        Ma_blog = i.mablog,
                        img = i.img,
                        Title = i.tieude,
                        NoiDung = i.noidung
                    });
                k++;
                if (k == 3) break;
            }
            return list;
        }

        public static List<Blog> GetBlogCat()
        {
            List<Blog> listcats = new List<Blog>();
            CatDbContext data = new CatDbContext();
            var blog = data.Blogs;
           
            var item = ( from a in blog orderby a.slview descending  // sap xep theo so luong view
                            
                         
                        select new
                        {
                            id=a.Ma_blog,
                            slview = a.slview,
                            title = a.Title,
                            noidung=a.NoiDung,
                            thoigian=a.ThoiGian, 
                            img=a.img
                        }).ToList();
            //int index = 0;
            foreach (var i in item)
            {
                //index++;
                //if (Convert.ToInt32(index/5+ 0.5) == IdPage)
                {
                    listcats.Add(new Blog
                    {
                        Ma_blog = i.id,
                        img = i.img,
                        Title = i.title,
                        ThoiGian = i.thoigian,
                        slview = i.slview,
                        NoiDung = i.noidung
                    });
                }
                
                
            }
            return listcats;
        }

        public static List<CustomBlog> UpgradeGetBlogCat(string id)
        {
            List<CustomBlog> listcats = new List<CustomBlog>();
            CatDbContext data = new CatDbContext();
            var blog = data.Blogs;
            var cmblog = data.CommentBlogs; 
            var item = ( from a in blog join b in cmblog on a.Ma_blog equals b.Ma_blog 
                         where a.Ma_blog==id
                        select new
                        {
                            id=a.Ma_blog,
                            slview = a.slview,
                            title = a.Title,
                            noidung=a.NoiDung,
                            thoigian=a.ThoiGian, 
                            img=a.img,
                            noidungcm=b.NoiDung,
                            thoigiancm=b.ThoiGian,
                            HotenCM=b.HoTen
                        }).ToList();
            
            foreach (var i in item)
            {
                
                {
                    listcats.Add(new CustomBlog
                    {
                        Ma_blog = i.id,
                        img = i.img,
                        Title = i.title,
                        ThoiGian = i.thoigian,
                        slview = i.slview,
                        NoiDung = i.noidung,
                        Hoten=i.HotenCM,
                        NoiDungCM=i.noidungcm,
                        ThoiGianCM=i.thoigiancm,
                        Sumcomment=item.Count()
                    });
                }
                
                
            }
            return listcats;
        }

        
        public static List<CatCustomModel> GetAllCat()
        {
            List<CatCustomModel> listcats = new List<CatCustomModel>();

            CatDbContext data = new CatDbContext();

            var cattable = data.Meos;
            var typecat = data.LoaiMeos;
            //full best cat if check = 1
            var item = (from a in cattable
                        join b in typecat on a.Ma_Loai equals b.Ma_Loai
                        select new
                        {
                            id = a.Id,
                            img = a.img,
                            tenloai = b.TenLoai,
                            gia = a.GiaBan,
                            luotlike = a.luot_like,
                            mausac = a.MauSac,
                            ngaytuoi = a.Ngaytuoi

                        }).ToList();

            //
            foreach (var i in item)
            {
                listcats.Add(new CatCustomModel
                {
                    Id = i.id,
                    img = i.img,
                    TenLoaiMeo = i.tenloai,
                    GiaBan = i.gia,
                    MauSac = i.mausac,
                    Ngaytuoi = i.ngaytuoi,
                    luot_like = Convert.ToInt32(i.luotlike)
                });
            }
            return listcats;
        }

        public static string CountCat()
        {
            CatDbContext data= new CatDbContext();
            var cattable = data.Meos;
            string s="M";
            string s1 = Convert.ToString(cattable.Count()+1);
            s = s+s1;
            return s;
        }

        //public static PhanTrang
        
    }
}