using Oglasnik.WebAPI.App_Start;
using System.Web.Http;

namespace Oglasnik.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {            
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.Initialize();
        }
    }
}
