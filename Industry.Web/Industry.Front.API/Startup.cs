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

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //TODO почему не работает
            config.Filters.Add(new AuthorizeAttribute());

            MediaTypeFormatterCollection formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            JsonSerializerSettings jsonSettings = formatters.JsonFormatter.SerializerSettings;

#if DEBUG
            jsonSettings.Formatting = Formatting.Indented;
#endif


            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            var builder = new ContainerBuilder();

            AutofacConfig.ConfigureWebApiContainer(builder);

            // Register Web API controller in executing assembly.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            // Create and assign a dependency resolver for Web API to use.
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // This should be the first middleware added to the IAppBuilder.
            app.UseAutofacMiddleware(container);

            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);

            app.UseWebApi(config);

            // Make sure the Autofac lifetime scope is passed to Web API.
            app.UseAutofacWebApi(config);

            AutoMapperConfiguration.Configure();
        }
    }
}
