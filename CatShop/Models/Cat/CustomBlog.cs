using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatShop.Models
{
    public class CustomBlog
    {
        
        public string Ma_blog { get; set; }
        public string Title { get; set; }
        public string NoiDung { get; set; }
        public string img { get; set; }
        public DateTime? ThoiGian { get; set; }
        public int? slview { get; set; }
        public int Sumcomment { get; set; }
        public string Hoten { get; set; }
        public string NoiDungCM { get; set; }
        public DateTime? ThoiGianCM { get; set; }
        public virtual ICollection<CommentBlog> CommentBlogs { get; set; }
    }
}