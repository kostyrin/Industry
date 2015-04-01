using System;
using System.Data.Entity;
using Industry.Data.DataModel;
using Industry.Domain.Entities;
using Industry.Services.Services;
using Industry.Front.Web.Controllers;
using Industry.Front.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Ef6.Factories;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;

namespace Industry.Front.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            container
                .RegisterType<IDataContextAsync, ERPContext>(new PerRequestLifetimeManager())
                .RegisterType<IRepositoryProvider, RepositoryProvider>(
                    new PerRequestLifetimeManager(),
                    new InjectionConstructor(new object[] {new RepositoryFactories()})
                )
                .RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
                .RegisterType<IRepositoryAsync<Shopper>, Repository<Shopper>>()
                .RegisterType<IRepositoryAsync<SerialBid>, Repository<SerialBid>>()
                .RegisterType<IRepositoryAsync<Customer>, Repository<Customer>>()
                .RegisterType<IRepositoryAsync<ContactInfo>, Repository<ContactInfo>>()
                .RegisterType<IRepositoryAsync<ContactInfoType>, Repository<ContactInfoType>>()
                .RegisterType<IRepositoryAsync<User>, Repository<User>>()
                //.RegisterType<IRepositoryAsync<Product>, Repository<Product>>()
                .RegisterType<IUserService, UserService>()
                .RegisterType<ICustomerService, CustomerService>()
                .RegisterType<IShopperService, ShopperService>()
                .RegisterType<IBidService, BidService>()
                .RegisterType<IContactInfoService, ContactInfoService>()
                .RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>()
                .RegisterType<UserManager<ApplicationUser>>()
                .RegisterType<DbContext, ApplicationDbContext>()
                .RegisterType<ApplicationUserManager>()
                .RegisterType<AccountController>(new InjectionConstructor());
        }
    }
}
