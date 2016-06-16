using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Repository.Models;
using Mvc_Repository.Models.ViewModel;
using System.Linq.Dynamic;

namespace Mvc_Repository.Controllers
{
    public class CustomersController : Controller
    {
        TestEntities db = new TestEntities();
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCustomers(int page = 1, int rows = 10, string sort = "CustomerID", string order = "asc")
        {
            var customers = db.Customers.AsQueryable().OrderBy(x => x.CustomerID);
            string[] sorts = sort.Split(',');
            string[] orders = order.Split(',');
            for (int i = 0; i < sorts.Length; i++)
            {
                if (i == 0)
                {
                    switch (sorts[i])
                    {
                        case "CustomerID":
                            if (orders[i] == "asc")
                                customers = customers.OrderBy(x => x.CustomerID);
                            else if (orders[i] == "desc")
                                customers = customers.OrderByDescending(x => x.CustomerID);
                            break;
                        case "CompanyName":
                            if (orders[i] == "asc")
                                customers = customers.OrderBy(x => x.CompanyName);
                            else if (orders[i] == "desc")
                                customers = customers.OrderByDescending(x => x.CompanyName);
                            break;
                        case "ContactName":
                            if (orders[i] == "asc")
                                customers = customers.OrderBy(x => x.ContactName);
                            else if (orders[i] == "desc")
                                customers = customers.OrderByDescending(x => x.ContactName);
                            break;
                        case "City":
                            if (orders[i] == "asc")
                                customers = customers.OrderBy(x => x.City);
                            else if (orders[i] == "desc")
                                customers = customers.OrderByDescending(x => x.City);
                            break;
                    }
                }
                else
                {
                    switch (sorts[i])
                    {
                        case "CustomerID":
                            if (orders[i] == "asc")
                                customers = customers.ThenBy(x => x.CustomerID);
                            else if (orders[i] == "desc")
                                customers = customers.ThenByDescending(x => x.CustomerID);
                            break;
                        case "CompanyName":
                            if (orders[i] == "asc")
                                customers = customers.ThenBy(x => x.CompanyName);
                            else if (orders[i] == "desc")
                                customers = customers.ThenByDescending(x => x.CompanyName);
                            break;
                        case "ContactName":
                            if (orders[i] == "asc")
                                customers = customers.ThenBy(x => x.ContactName);
                            else if (orders[i] == "desc")
                                customers = customers.ThenByDescending(x => x.ContactName);
                            break;
                        case "City":
                            if (orders[i] == "asc")
                                customers = customers.ThenBy(x => x.City);
                            else if (orders[i] == "desc")
                                customers = customers.ThenByDescending(x => x.City);
                            break;
                    } 
                }
                
            }
            var customers2 = customers.Skip((page - 1) * rows).Take(rows);
            var Result = new GridViewModel<Customers>()
            {
                total = db.Customers.Count(),
                rows = customers2.ToList()
            };
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
    }
}