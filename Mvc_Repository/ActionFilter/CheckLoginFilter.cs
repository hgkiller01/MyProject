using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc_Repository.ActionFilter
{
    public class CheckLoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Login"] != null)
            {
                string s = filterContext.HttpContext.Session["Login"].ToString();
            }
            filterContext.Controller.TempData["Alert"] = "請先登入!";
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary 
                { 
                    { "controller", "Home" }, 
                    { "action", "Index" } 
                });
            
            //filterContext.HttpContext.Response.Redirect("/Home/Index");
        }
      
    }
}