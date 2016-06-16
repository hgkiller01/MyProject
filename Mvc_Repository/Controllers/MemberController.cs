using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc_Repository.Models.ViewModel;

namespace Mvc_Repository.Controllers
{
    public class MemberController : Controller
    {
        public MemberViewModel CurrentMember;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["member"] != null)
            {
                CurrentMember = filterContext.HttpContext.Session["member"] as MemberViewModel;
            }
            
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
        }
    }
}