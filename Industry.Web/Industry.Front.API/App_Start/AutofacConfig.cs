using Autofac;
using Autofac.Integration.WebApi;
using Industry.Data.DataModel;
using Industry.Domain.Entities;
using Industry.Front.API.Models;
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
        public static void ConfigureWebApiContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ERPContext>().As<IDataContextAsync>().AsImplementedInterfaces().InstancePerLifetimeScope();
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>().AsImplementedInterfaces().InstancePerLifetimeScope();
            containerBuilder.Register(d => new RepositoryProvider(new RepositoryFactories())).As<IRepositoryProvider>().InstancePerLifetimeScope();

            containerBuilder.RegisterType<Repository<ActionLog>>().As<IRepositoryAsync<ActionLog>>().InstancePerRequest();
            containerBuilder.RegisterType<Repository<Customer>>().As<IRepositoryAsync<Customer>>().InstancePerRequest();
            containerBuilder.RegisterType<Repository<ContactInfo>>().As<IRepositoryAsync<ContactInfo>>().InstancePerRequest();
            containerBuilder.RegisterType<Repository<ContactInfoType>>().As<IRepositoryAsync<ContactInfoType>>().InstancePerRequest();
            containerBuilder.RegisterType<Repository<User>>().As<IRepositoryAsync<User>>().InstancePerRequest();
            containerBuilder.RegisterType<ActionLogService>().As<IActionLogService>().InstancePerRequest();
            containerBuilder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            containerBuilder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerRequest();
            containerBuilder.RegisterType<ContactInfoService>().As<IContactInfoService>().InstancePerRequest();

            containerBuilder.Register(c => new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext())
            {
                /*Avoids UserStore invoking SaveChanges on every actions.*/
                //AutoSaveChanges = false
            })).As<UserManager<ApplicationUser>>().InstancePerRequest();

            containerBuilder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}