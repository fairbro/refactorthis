using refactor_me;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace refactor_this
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutomapperConfig.Initialize();
            IocConfig.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
