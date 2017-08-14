using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace RTS.Weds.Services.Base
{
    public class AuthorizeAction : AuthorizationFilterAttribute
    {
        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (actionContext.RequestContext.Principal.Identity.IsAuthenticated) { 


                }
            return base.OnAuthorizationAsync(actionContext, cancellationToken); 
        }
    }
}