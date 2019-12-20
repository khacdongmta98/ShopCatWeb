using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace CatShop.Function
{
    public class AdminFunction
    {
        //ham tai hinh anh tu mot duong link nao do
        public static void DownloadFiles(Uri uri, string src)
        {
            using (var client = new WebClient())
            {
                try
                {
                    //string t = GetFileSizes(uri);
                     client.DownloadFileTaskAsync(uri, src);
                }
                catch (Exception)
                {

                    return;
                }



            }

        }



    }
}