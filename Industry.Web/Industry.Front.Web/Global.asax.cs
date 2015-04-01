using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Industry.Data.DataModel;
using Industry.Front.Web.Models;

namespace Industry.Front.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //System.Data.Entity.Database.SetInitializer(new ERPModelInitializer());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            System.Data.Entity.Database.SetInitializer(new ApplicationDbInitializer());
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrapper.Run();
        }
    }
}
