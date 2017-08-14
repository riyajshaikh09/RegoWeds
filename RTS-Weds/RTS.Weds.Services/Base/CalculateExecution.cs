using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RTS.Weds.Services.Base
{
    public class CalculateExecution : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

           base.OnActionExecuting(actionContext);
            actionContext.Request.Properties[actionContext.ActionDescriptor.ActionName] = Stopwatch.StartNew();
        }
    }
}