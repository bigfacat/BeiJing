using Autofac;
using Autofac.Integration.WebApi;
using JlueTaxSystemBeiJingBS.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace JlueTaxSystemBeiJingBS
{
    public class AutofacWebApiConfig
    {
        public static void Run()
        {
            ContainerBuilder builder = new ContainerBuilder();
            HttpConfiguration config = GlobalConfiguration.Configuration;

            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<YsbqcSetting>().As<IYsbqcSetting>().InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

    }
}