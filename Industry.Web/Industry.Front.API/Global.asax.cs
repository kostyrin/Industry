using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Industry.Data.DataModel;
using Industry.Front.API.Models;

namespace Industry.Front.API
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //System.Data.Entity.Database.SetInitializer(new ERPModelInitializer());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Bootstrapper.Run();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            System.Data.Entity.Database.SetInitializer(new ApplicationDbInitializer());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
        }
    }
}
