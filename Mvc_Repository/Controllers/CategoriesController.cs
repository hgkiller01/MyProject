using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mvc_Repository.Models;
using Mvc_Repository.Models.Interface;
using Mvc_Repository.Models.Repositiry;
using System.IO;
using Mvc_Repository.Models.ViewModel;
using System.Linq.Dynamic;

namespace Mvc_Repository.Controllers
{
    public class CategoriesController : Controller
    {
        private TestEntities db = new TestEntities();
        private IRepository<Categories> categoryRepository;

        public CategoriesController()
        {
            this.categoryRepository = new GenericRepository<Categories>();
        }
        // GET: Categories
        public ActionResult Index()
        {
            return View(categoryRepository.GetAll().ToList());
        }
        public ActionResult GridViews()
        {
            return View();
        }
        public ActionResult GetGridResut()
        {
            var categories = db.Categories.OrderBy(x => x.CategoryID).Select(x => new CategoriesViewModel()
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description
            });
            var Result = new GridViewModel<CategoriesViewModel>()
            {
                total = categories.Count(),
                rows = categories.ToList()
            };
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TestLinq()
        {
            var query = db.Categories.Where("CategoryName.Contains(@0)", "品").OrderBy("CategoryID desc");
            int x = query.Count();
            return View(query);
        }
        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
           
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var categories = categoryRepository.Get(x=> x.CategoryID == id.Value);
                ViewBag.Entiy = new TestEntities();
                return View(categories);
            }
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Categories categories = db.Categories.Find(id);
            //if (categories == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(categories);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName,Description,Picture")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Create(categories);
                return RedirectToAction("Index");
            }

            return View(categories);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var categories = categoryRepository.Get(x => x.CategoryID == id.Value);
                return View(categories);
            }
        }

        // POST: Categories/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName,Description,Picture")] Categories categories)
        {
            if (ModelState.IsValid)
            {
                categoryRepository.Update(categories);
                return RedirectToAction("Index");
            }
            return View(categories);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var categories = categoryRepository.Get(x => x.CategoryID == id.Value);
                return View(categories);
            }
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var category = categoryRepository.Get(x => x.CategoryID == id);
                this.categoryRepository.Delete(category);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id });
            }
            return RedirectToAction("index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}
