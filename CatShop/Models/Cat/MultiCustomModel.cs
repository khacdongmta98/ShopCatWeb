using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CatShop.Models
{
    public class MultiCustomModel
    {
        public List<CatCustomModel> ModelCAT_Trending = new List<CatCustomModel>();
        public List<CatCustomModel> ModelCAT_Banner = new List<CatCustomModel>();
        public List<CatCustomModel> ModelCAT_BestSeller = new List<CatCustomModel>();
        public List<CatCustomModel> ModelCAT_BlogSection = new List<CatCustomModel>();
        public List<CatCustomModel> ModelCAT_CarouselStart = new List<CatCustomModel>();
        public List<CatCustomModel> ModelCAT_Footer = new List<CatCustomModel>();
        public List<CatCustomModel> ModelCAT_Lastnews = new List<CatCustomModel>();
        public List<CatCustomModel> ModelCAT_Subcribe = new List<CatCustomModel>();
        public List<CatCustomModel> ModelCAT_Header = new List<CatCustomModel>();

        public List<CatCustomModel> Shop_SectionStart = new List<CatCustomModel>();
        public List<CatCustomModel> Product = new List<CatCustomModel>();
        public List<Blog> blogcat = new List<Blog>();
        public List<CustomBlog> lastblog = new List<CustomBlog>();
        public List<Blog> ViewBlog = new List<Blog>();
        public List<CommentBlog> CMBlog = new List<CommentBlog>();
    }
}