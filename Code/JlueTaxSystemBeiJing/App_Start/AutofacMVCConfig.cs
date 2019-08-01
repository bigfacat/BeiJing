using Autofac;
using Autofac.Integration.Mvc;
using JlueTaxSystemBeiJing.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJing
{
    public class AutofacMVCConfig
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(YsbqcSetting)).As(typeof(YsbqcSetting));
            builder.RegisterType(typeof(Service)).As(typeof(Service));
            builder.RegisterType(typeof(Repository)).As(typeof(Repository));

            builder.RegisterControllers(typeof(MvcApplication).Assembly);//注册所有的Controller
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}