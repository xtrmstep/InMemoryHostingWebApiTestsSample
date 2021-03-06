﻿using System;
using System.Data.Entity;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using log4net.Config;
using WebApiTestsSample.Migrations;
using WebApiTestsSample.Models;

namespace WebApiTestsSample
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Configure();
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApiDataContext, Configuration>());
        }

        public static void Configure(HttpConfiguration config = null)
        {
            XmlConfigurator.Configure();
            //log4net.LogicalThreadContext.Properties["GroupId"] = Guid.NewGuid().ToString();

            #region Initialize the Web API
            if (config == null)
            {
                GlobalConfiguration.Configure(WebApiConfig.Register);
                config = GlobalConfiguration.Configuration;
            }
            else
            {
                // used in the integration tests
                WebApiConfig.Register(config);
            }
            
            #endregion
        }
    }
}