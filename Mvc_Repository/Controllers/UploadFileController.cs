using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using Mvc_Repository.Models;
using Mvc_Repository.Models.ViewModel;

namespace Mvc_Repository.Controllers
{
    public class UploadFileController : MemberController
    {
        TestEntities db = new TestEntities();
        public ActionResult Index()
        {
            return View();
        }
        // GET: UploadFile
        public ActionResult Upload_Multiple()
        {
            return View();
        }
        public ActionResult Uploaded(HttpPostedFileBase[] files)
        {
            if (files.Count() > 0)
            {
                foreach (var uploadFile in files)
                {
                    if (uploadFile.ContentLength > 0)
                    {
                        string savePath = Server.MapPath("~/Files/");
                        uploadFile.SaveAs(savePath + uploadFile.FileName);
                    }
                }
            }

            return RedirectToAction("Upload_Multiple");
        }
        public ActionResult GetJSON()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<CateResult> result = db.Categories.Select(x => new CateResult()
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult postedJson(ArgObject arg)
        {
            JsonSerializerSettings jsSettings = new JsonSerializerSettings();
            jsSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            return new JsonResult()
            {
                Data = arg
            };
        }
        public ActionResult TestScript()
        {
            string[] abc = { "a", "b", "c", "d", "e", "f" };
            string kkdd = "'" + string.Join("','", abc) + "'";
            return View("/Views/UploadFile/TestScript.cshtml", null, kkdd);
        }
        public ActionResult TestScript2()
        {
           
            return View();
        }
        public ActionResult TestScript3()
        {
            return View();
        }
        public ActionResult TestOpen()
        {
            return View();
        }
        public ActionResult TestOpen2()
        {
            return View();
        }
        public ActionResult W3CScript()
        {
            return View();
        }
        public ActionResult W3CScript2()
        {
            return View();
        }
        public ActionResult GetPart()
        {
            return PartialView("TestPartialView");
        }
        public ActionResult GetSession()
        {
            Session["member"] = new MemberViewModel()
            {
                MemberID = 1,
                MemberName = "Peter",
                MemberSex = "M"
            };
            return RedirectToAction("Index");
        }
        public ActionResult LoadSession()
        {
            ViewData["MemberID"] = CurrentMember.MemberID;
            ViewData["MemberName"] = CurrentMember.MemberName;
            ViewData["MemberSex"] = CurrentMember.MemberSex;
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
        public class CateResult
        {
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public string Description { get; set; }
        }
        public class ArgObject
        {
            public string Name { get; set; }
            public SubArgObject SubArg { get; set; }
        }



        public class SubArgObject
        {
            public string PropA { get; set; }
            [JsonProperty("PropX")]
            public string PropB { get; set; }
            [ScriptIgnore]
            public string PropC { get; set; }
        }


    }
}