using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Repository.Models;

namespace Mvc_Repository.Controllers
{
    public class selectListsController : Controller
    {
        TestEntities db = new TestEntities();
        // GET: selectLists
        public ActionResult Index(int Kind = 0)
        {
            var cate = db.Categories.OrderBy(x => x.CategoryID).ToList();
            ViewBag.Categoryer = new SelectList(
                items: cate,
                dataTextField: "CategoryName",
                dataValueField: "CategoryID",
                selectedValue: (Kind == 0) ? "" : Kind.ToString()
                );
            return View();
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