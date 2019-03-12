﻿using Autofac;
using Autofac.Integration.Mvc;
using JlueTaxSystemBeiJingBS.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JlueTaxSystemBeiJingBS
{
    public class AutofacMVCConfig
    {
        public static void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(typeof(YsbqcSetting)).As(typeof(IYsbqcSetting));
            builder.RegisterControllers(typeof(Global).Assembly);//注册所有的Controller
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}