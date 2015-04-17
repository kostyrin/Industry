using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Industry.Front.Core.Mapping;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

[assembly: OwinStartup(typeof(Industry.Front.API.Startup))]

namespace Industry.Front.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            var config = new HttpConfiguration();
            
            AutofacConfig.Initialize(config);

            RouteConfig.MapRoutes(config);

            //TODO нужно разобраться!
            // This should be the first middleware added to the IAppBuilder.
            //app.UseAutofacMiddleware(container);
            //app.UseCors(CorsOptions.AllowAll);

            ConfigureAuth(app);

            app.UseWebApi(config);

            // Make sure the Autofac lifetime scope is passed to Web API.
            app.UseAutofacWebApi(config);

            AutoMapperConfiguration.Configure();
        }
    }
}
