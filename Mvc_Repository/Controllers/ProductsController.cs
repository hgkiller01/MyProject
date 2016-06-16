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
using Mvc_Repository.ActionFilter;

namespace Mvc_Repository.Controllers
{
    public class ProductsController : Controller
    {
        private IRepository<Products> productRepository;
        private IRepository<Categories> categoryRepository;
        public IEnumerable<Categories> Categories
        {
            get
            {
                return categoryRepository.GetAll();
            }
        }
        
        public ProductsController()
        {
            productRepository = new GenericRepository<Products>();
            categoryRepository = new GenericRepository<Categories>();
        }
        // GET: Products
        [CheckLoginFilter]
        public ActionResult Index()
        {
            var products = productRepository.GetAll().Include(p => p.Categories);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id.HasValue)
            {
                var products = productRepository.Get(x => x.CategoryID == id.Value);
                return View(products);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Products/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Products products)
        {
            if (ModelState.IsValid)
            {
                productRepository.Create(products);
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(Categories, "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var products = productRepository.Get(x => x.CategoryID == id.Value);
                ViewBag.CategoryID = new SelectList(Categories, "CategoryID", "CategoryName", products.CategoryID);
                return View(products);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        // POST: Products/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,SupplierID,CategoryID,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Products products)
        {
            if (ModelState.IsValid)
            {
                productRepository.Update(products);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(Categories, "CategoryID", "CategoryName", products.CategoryID);
            return View(products);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var products = productRepository.Get(x => x.CategoryID == id.Value);
                return View(products);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = productRepository.Get(x => x.CategoryID == id);
            productRepository.Delete(products);
            return new EmptyResult();
        }
    }
}
