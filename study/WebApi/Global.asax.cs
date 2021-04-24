using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public WebApiApplication()
        {
            Debugger.Launch();
        }

        protected void Application_Start()
        {
            Debugger.Launch();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
