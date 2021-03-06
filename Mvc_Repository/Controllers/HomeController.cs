﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Repository.Models;

namespace Mvc_Repository.Controllers
{
    public class HomeController : Controller
    {
        FLBKEntities db = new FLBKEntities();

        public ActionResult Index()
        {
            string SQL = @"select *, ROUND(ACOS(SIN(RADIANS('25.0632256')) * 
                                SIN(RADIANS(CAST ( LandMark_Gps_X AS float ))) +
                                 COS(RADIANS('25.0632256')) * 
                                 COS(RADIANS(CAST ( LandMark_Gps_X AS float ))) * 
                                 COS(RADIANS('121.5655313' - 
                                 CAST ( LandMark_Gps_Y AS float )))) * 6372.8, 1) AS distance ,
                                 (select top 1 IM.Image_Path Image_Path from Image_R IR 
                                 join Image_M IM on IR.Image_ID = IM.Image_ID 
                                 where IR.Obj_ID = LM.LandMark_ID and IR.Target_Type = 'L' and IM.IsEnable = 1
                                 and IM.IsExternalLink = 0) as Image_Path
                                from LandMark_M LM join LandMark_D LD on LM.LandMark_ID = LD.LandMark_ID
                                where  LD.Lang = 'zh-TW' and LM.IsEnable = 1 and LM.LandMark_Type = 1 
								order by distance
                                offset 10 * 0 rows fetch next 10 rows only";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            Session["Login"] = "123";
           
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult UpladForm()
        {
            int[] a = { 2, 4, 5 };
            int[] b = new int[3];
            int i = 0;
            foreach(int d in a){

            }

            return View();
        }
        public ActionResult DOMTest()
        {
            
            List<object> abc = new List<object>(){
                new {kill = 1 ,OP = 2},
                new {kill = 2 , OP = 3},
                new {kill = 3 , OP = 4}
            };
            int myIndex = 0;
            foreach (var item in abc)
            {
                myIndex = abc.IndexOf(item);
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpLoadImage(Result result)
        {
            return Json(new string[]{"1","2","3"});
  
        }
        public ActionResult ImageList(int page = 1)
        {
            var result = db.HotelRoom.Select(x => new
            {
                pcount = (string.IsNullOrEmpty(x.Room_Image_Default) ? 0 : 1) +
                (string.IsNullOrEmpty(x.Room_Image_2) ? 0 : 1) +
                (string.IsNullOrEmpty(x.Room_Image_3) ? 0 : 1) +
                (string.IsNullOrEmpty(x.Room_Image_4) ? 0 : 1) +
                (string.IsNullOrEmpty(x.Room_Image_5) ? 0 : 1),
                x.Room_Name_CN,
                x.Room_Sort,
                x.Room_Name_TW

            });
            ViewBag.page = page;
            ViewBag.pidata = result.FirstOrDefault().pcount;
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
    public class Result
    {
        public string StudentName { get; set; }
        public int StudnetID { get; set; }
        public HttpPostedFileBase StudentImg { get; set; }
    }
}