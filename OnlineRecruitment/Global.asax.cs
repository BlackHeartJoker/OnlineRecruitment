using AutoMapper;
using OnlineRecruitment.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OnlineRecruitment
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //AutoMapperConfiguration.Configure();
        }
       
    }

    //public static class AutoMapperConfiguration
    //{
    //    public static void Configure()
    //    {
    //        var configuration = new MapperConfiguration(config =>
    //        {
    //            config.CreateMap()
    //            config.CreateMap<Person, PersonDTO>();
    //        });
    //    }
    //}
}
