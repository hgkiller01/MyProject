using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Repository.Models;
using Mvc_Repository.Models.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mvc_Repository.Controllers
{
    public class AngularController : Controller
    {
        TestEntities db = new TestEntities();
        // GET: Angular
        public ActionResult Index(string test = "")
        {
            string show = test;
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult Index3()
        {
            return View();
        }
        public ActionResult Module()
        {
            return View();
        }
        public ActionResult EasyUI()
        {

            return View();
        }
        public ActionResult EasyUI2()
        {
            return View();
        }
        public ActionResult EasyUI3(TestFormModel Form)
        {
            if (TryUpdateModel(Form, new string[] { "Content", "UserId" }))
            {
                ViewData["Content"] = Form.Content;
                ViewData["UserId"] = Form.UserId;
                ViewData["Time"] = Form.Time;
            }
            return View();

        }
        public ActionResult ReturnJS()
        {
            string js = "alert('這是JavaScriptResult')";
            return JavaScript(js);
        }
        [NonAction]
        public void EmptyReturn()
        {
            Response.Write(Request.Cookies["names3"].Value);
        }
        public ActionResult SaveCookie()
        {
            if (Request.Cookies["names3"] != null)
            {
                //Response.Write(Server.UrlDecode(Request.Cookies["names2"].Value));
                //Response.Write(Request.Cookies["myCookie"].Value);
                //int[] abc = JsonConvert.DeserializeObject<int[]>(Request.Cookies["names3"].Value);
                //foreach (var item in abc)
                //{
                //    Response.Write(item);
                //}
            }
            return View();
        }
        public ActionResult GetJson()
        {
            var result = db.Categories.Select(x => new CategoriesViewModel()
              {
                  CategoryID = x.CategoryID,
                  CategoryName = x.CategoryName,
                  Description = x.Description
              });
            return Json(result);
        }
        public ActionResult TestOne()
        {
            foreach (var item in Request.Form)
            {
                string a = item.ToString();
            }
            Response.Write(JsonConvert.SerializeObject(new { success = true }));
            //return Json(new { sucess = true } , JsonRequestBehavior.AllowGet);
            return new EmptyResult();
        }
        public ActionResult GetOne(int id)
        {
            var result = db.Categories.Where(x => x.CategoryID == id)
                .Select(p => new CategoriesViewModel()
                {
                    CategoryID = p.CategoryID,
                    CategoryName = p.CategoryName,
                    Description = p.Description
                }).FirstOrDefault();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }

    }
}