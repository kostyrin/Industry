using System.Web;
using System.Web.Http;

namespace Industry.Front.API
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //System.Data.Entity.Database.SetInitializer(new ERPModelInitializer());
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Bootstrapper.Run();
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }
    }
}
