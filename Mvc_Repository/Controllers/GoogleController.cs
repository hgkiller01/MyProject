using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using MvcLibrary.Utility;


namespace Mvc_Repository.Controllers
{
    public class GoogleController : Controller
    {
        string client_id = "906630340301-4vjdet6na06ljgu8gmu12br7mfr0q20p.apps.googleusercontent.com";
        string client_secret = "2_RkQ1BZit4jywwzdHh6r_B0";
        // GET: Google
        public ActionResult Index()
        {
            return View();
        }
        [ValidateInput(false)]
        public ActionResult Return(string code)
        {
            if (!string.IsNullOrEmpty(code))
            {
                string Url = string.Format("https://accounts.google.com/o/oauth2/token");
                string PostBody = string.Format("code={0}&client_id={1}&client_secret={2}&redirect_uri={3}&grant_type=authorization_code",
                    code,
                    client_id,
                    client_secret,
                    "http://localhost:14665/Google/Return");
                HttpWebRequest Request2 = (HttpWebRequest)WebRequest.Create(Url);
                Request2.ContentType = "application/x-www-form-urlencoded";
                Request2.Method = "POST";
                var test = Sendit(Request2, PostBody);
                string token = JsonConvert.DeserializeObject<GoogleToken>(test).access_token;
                string Url2 = string.Format("https://www.googleapis.com/oauth2/v1/userinfo?access_token={0}",token);
                HttpWebRequest Request3 = (HttpWebRequest)WebRequest.Create(Url2);
                Request3.Method = "GET";
                return Content(Sendit(Request3));
                //test
            }
            return new EmptyResult();
        }
        [NonAction]
        public string Sendit(HttpWebRequest Req, string PostBody = "")
        {
            if (!string.IsNullOrEmpty(PostBody))
            {
                using (var sw = new StreamWriter(Req.GetRequestStream()))
                {
                    sw.Write(PostBody);
                }
            }
            using (WebResponse wR = Req.GetResponse())
            {
                using (var sR = new StreamReader(wR.GetResponseStream()))
                {
                    return sR.ReadToEnd();
                }
                //在這裡對接收到的頁面內容進行處理
            }

        }

        public class GoogleToken
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int expires_in { get; set; }
            public string id_token { get; set; }
        }

    }
}