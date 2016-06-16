using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Repository.Controllers2
{
    public class MyHomeController : Controller
    {
        // GET: MyHome
        public ActionResult Index()
        {
            return View();
        }

        // GET: MyHome/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MyHome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyHome/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyHome/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MyHome/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MyHome/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MyHome/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
