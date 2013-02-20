using Denolk.XchangeViewer.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denolk.XchangeViewer.Filters
{
    public class AuthenticationRequiredAttribute : ActionFilterAttribute
    {
        UserBusiness _bus = new UserBusiness();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool isAuth = _bus.IsAuthenticated();
            if (isAuth)
            {
                base.OnActionExecuting(filterContext);
            }
            else {
                filterContext.Result = new RedirectToRouteResult("Default",null);
            }

        }


    }
}