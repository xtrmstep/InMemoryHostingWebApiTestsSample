using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace WebApiTestsSample
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Configure();
        }

        public static void Configure(HttpConfiguration config = null)
        {
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