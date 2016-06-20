using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Mvc_Repository.Helper
{
    public class RequestHelper
{
        public HttpWebRequest myRequest { get; set; }
        public string PostedBody { get; set; }
        public string Url { get; set; }
        public enum Method
        {
            Post,
            Get
        };
        public RequestHelper(string Url, string PostedBody = "", Method RequestMethod = Method.Get)
        {
            this.Url = Url;
            this.PostedBody = PostedBody;
            this.myRequest = (HttpWebRequest)WebRequest.Create(Url);
            if (RequestMethod == Method.Get)
            {
                myRequest.Method = "GET";
            }
            {
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
            }
        }
        public string Sendit()
        {
            if (!string.IsNullOrEmpty(PostedBody))
            {
                using (var sw = new StreamWriter(myRequest.GetRequestStream()))
                {
                    sw.Write(PostedBody);
                }
            }
            using (WebResponse wR = myRequest.GetResponse())
            {
                using (var sR = new StreamReader(wR.GetResponseStream()))
                {
                    return sR.ReadToEnd();
                }
                //在這裡對接收到的頁面內容進行處理
            }

        }
    }
}