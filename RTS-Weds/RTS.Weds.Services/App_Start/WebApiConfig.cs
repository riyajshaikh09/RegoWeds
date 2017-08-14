using Microsoft.Practices.Unity;
using RTS.Weds.Business.Contracts;
using RTS.Weds.Business.Interface;
using RTS.Weds.DataAcess.Dapper.Interface;
using RTS.Weds.DataAcess.Dapper.Repositories;
using RTS.Weds.Services.Base;
using RTS.Weds.Services.Controllers;
using RTS.Weds.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RTS.Weds.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            
           
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
              config.MessageHandlers.Add(new BaseHandler());

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
           
            var container = new UnityContainer();

            container.RegisterType<IInfoHandle, InfoHandleController>(new HierarchicalLifetimeManager());
            container.RegisterType<IInfoHandleManager, InfoHandleManager>(new HierarchicalLifetimeManager());
            container.RegisterType<ICandidateRepository, CandidateRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IAddressDetailsRepository, AddressDetailRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IBirthDetailsRepository, BirthRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IFamilyDetailsRepository, FamilyDetailRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEducationDetailsRepository, EducationDetailRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IExpectationsDetailsRepository, ExpectationDetailRepository>(new HierarchicalLifetimeManager());

            config.DependencyResolver =  new UnityResolver(container);
            
        }
    }
}
