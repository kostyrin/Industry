using System;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Industry.Data.DataModel;
using Industry.Domain.Entities;
using Industry.Front.API.Models;
using Industry.Front.Core.Logging;
using Industry.Services.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;

namespace Industry.Front.API
{
    public static class AutofacConfig
    {

        public static IContainer Container = null;

        public static void Initialize(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            RegisterTypes(builder);

            Container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);

            ILogger logger = Container.Resolve<ILogger>();
            logger.Info("log4net OK"); 
        }

        public static void RegisterTypes(ContainerBuilder builder)
        {
            // Register Web API controller in executing assembly.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<ERPContext>().As<IDataContextAsync>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<AuthDbContext>().As<DbContext>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>().AsImplementedInterfaces().InstancePerLifetimeScope();
            //TODO RegisterGeneric???
            builder.Register(d => new RepositoryProvider(new RepositoryFactories())).As<IRepositoryProvider>().InstancePerLifetimeScope();

            builder.Register(l => LoggingModule.GetLogger(typeof(Object))).As<ILogger>().InstancePerLifetimeScope();
            //builder.RegisterModule(new LoggingModule());
            builder.RegisterType<Repository<ActionLog>>().As<IRepositoryAsync<ActionLog>>().InstancePerRequest();
            builder.RegisterType<Repository<Customer>>().As<IRepositoryAsync<Customer>>().InstancePerRequest();
            builder.RegisterType<Repository<Contractor>>().As<IRepositoryAsync<Contractor>>().InstancePerRequest();
            builder.RegisterType<Repository<ContactInfo>>().As<IRepositoryAsync<ContactInfo>>().InstancePerRequest();
            builder.RegisterType<Repository<ContactInfoType>>().As<IRepositoryAsync<ContactInfoType>>().InstancePerRequest();
            builder.RegisterType<Repository<User>>().As<IRepositoryAsync<User>>().InstancePerRequest();
            builder.RegisterType<ActionLogService>().As<IActionLogService>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerRequest();
            builder.RegisterType<ContractorService>().As<IContractorService>().InstancePerRequest();
            builder.RegisterType<ContactInfoService>().As<IContactInfoService>().InstancePerRequest();

            builder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new AuthDbContext())
            {
                /*Avoids UserStore invoking SaveChanges on every actions.*/
                //AutoSaveChanges = false
            })).As<UserManager<ApplicationUser>>().InstancePerRequest();

            builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}