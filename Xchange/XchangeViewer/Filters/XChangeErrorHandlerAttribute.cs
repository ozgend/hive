using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Denolk.XchangeViewer.Filters
{
    public class XChangeErrorHandlerAttribute : HandleErrorAttribute
    {

        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.Result = new JsonResult {
                Data = new { ok = false, message = ex.Message }
            };
        }

    }
}