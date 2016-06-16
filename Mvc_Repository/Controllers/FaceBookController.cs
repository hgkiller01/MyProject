using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Mvc_Repository.Controllers
{
    public class FaceBookController : Controller
    {
        string client_id = "595413120567640";
        string client_secret = "eefdd9aa887d50617b9107eb86fe360e";
        // GET: FaceBook
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Return(string code = "", string access_token = "")
        {
            if (!string.IsNullOrEmpty(code))
            {
                string posted = string.Format("client_id={0}&redirect_uri={1}&client_secret={2}&code={3}"
               , client_id
               , Server.UrlEncode("http://localhost:14665/FaceBook/Return")
               , client_secret
               , code);
                HttpWebRequest request2 = (HttpWebRequest)HttpWebRequest.Create("https://graph.facebook.com/oauth/access_token?" + posted);
                request2.Method = "GET";
                var abc = Sendit(request2);
                //Response.Redirect("https://graph.facebook.com/oauth/access_token?" + posted);
                //Response.Write("https://graph.facebook.com/oauth/access_token?" + posted);
                string token = abc.Replace("access_token=", "").Split('&')[0];
                HttpWebRequest Request3 = (HttpWebRequest)HttpWebRequest.Create("https://graph.facebook.com/me?access_token=" + token);
                Request3.Method = "GET";
                var ddd = Sendit(Request3);
                Response.Write(ddd);
            }
           
            return new EmptyResult();
        }
        public ActionResult Login(dynamic result)
        {
            return Json(result);
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
    }
}