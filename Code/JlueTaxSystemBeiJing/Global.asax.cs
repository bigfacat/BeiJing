﻿using JlueTaxSystemBeiJing.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace JlueTaxSystemBeiJing
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutofacMVCConfig.Run();

            GlobalFilters.Filters.Add(new AuthenticationFilter());
            GlobalFilters.Filters.Add(new AuthorizationFilter());
            GlobalFilters.Filters.Add(new ActionFilter());
            GlobalFilters.Filters.Add(new ResultFilter());
            GlobalFilters.Filters.Add(new ExceptionFilter());

        }

        public override void Init()
        {
            this.PostMapRequestHandler += (sender, e) => myMapRequestHandler();
            this.BeginRequest += (sender, e) => myBeginRequest();
            this.PostAuthenticateRequest += (sender, e) => HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            base.Init();
        }

        private void myBeginRequest()
        {
            string path = Request.Path;
            if (Regex.IsMatch(path, "biz") || Regex.IsMatch(path, "xxmh/html/index_login.html"))
            {
                RouteTable.Routes.RouteExistingFiles = true;
                //Context.Handler = new CustomHandler();
                //Context.RemapHandler(new CustomHandler());
            }
            else
            {
                RouteTable.Routes.RouteExistingFiles = false;
            }

        }

        private void myMapRequestHandler()
        {
        }

    }
}
