using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace RTS.Weds.Services.Base
{
    public class BaseHandler : DelegatingHandler

    {
        protected override async Task<HttpResponseMessage> SendAsync(
   HttpRequestMessage request, CancellationToken cancellationToken)
        {

            // Authorize still has a Task<bool> return type
            // but await allows this nicer inline syntax
            var authorized = true; //await Authorize(request);

                if (!authorized)
                {
                    return new HttpResponseMessage(HttpStatusCode.Unauthorized)
                    {
                        Content = new StringContent("Unauthorized.")
                    };
                }

                return await base.SendAsync(request, cancellationToken);
            

        }

    }
}