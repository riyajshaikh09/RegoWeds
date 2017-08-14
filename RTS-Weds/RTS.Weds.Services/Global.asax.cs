using Microsoft.Practices.Unity;
using RTS.Weds.Business.Contracts;
using RTS.Weds.Business.Interface;
using RTS.Weds.Services.Controllers;
using RTS.Weds.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Routing;

namespace RTS.Weds.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            GlobalConfiguration.Configure(WebApiConfig.Register);

            
            var config = GlobalConfiguration.Configuration;
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            //  config.Filters.Add();

        } 
    }
}
