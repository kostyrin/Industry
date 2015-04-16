using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Industry.Front.API.Startup))]

namespace Industry.Front.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            //var config = new HttpConfiguration();

            //config.Routes.MapHttpRoute(
            //    "DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            //var builder = new ContainerBuilder();

            //Bootstrapper.ConfigureWebApiContainer(builder);
            //// Register Web API controller in executing assembly.
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //var container = builder.Build();

            //// Create and assign a dependency resolver for Web API to use.
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            //// This should be the first middleware added to the IAppBuilder.
            //app.UseAutofacMiddleware(container);

            //// Make sure the Autofac lifetime scope is passed to Web API.
            //app.UseAutofacWebApi(config);

            //app.UseWebApi(config);

            ConfigureAuth(app);
        }
    }
}
