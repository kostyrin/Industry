#region

using System.Collections.Generic;
using Industry.Data.Models;
using Industry.Data.Repositories;
using Industry.Domain.Entities;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Service.Pattern;

#endregion

namespace Industry.Services.Services
{
    /// <summary>
    ///     Add any custom business logic (methods) here
    /// </summary>
    public interface IShopperService : IService<Shopper>
    {
        Shopper GetShopperById(int shopperId);
        IEnumerable<Shopper> GetShoppers();
        decimal ShopperOrderTotalByYear(int customerId, int year);
        IEnumerable<Shopper> ShoppersByName(string companyName);
        IEnumerable<SerialShopperBid> GetShopperBids(string country);
    }

    /// <summary>
    ///     All methods that are exposed from Repository in Service are overridable to add business logic,
    ///     business logic should be in the Service layer and not in repository for separation of concerns.
    /// </summary>
    public class ShopperService : Service<Shopper>, IShopperService
    {
        private readonly IRepositoryAsync<Shopper> _repository;
        

        public ShopperService(IRepositoryAsync<Shopper> repository)
            : base(repository)
        {
            _repository = repository;
            
        }
        public Shopper GetShopperById(int shopperId)
        {
            return _repository.GetShopperById(shopperId);
        }

        public IEnumerable<Shopper> GetShoppers()
        {
            return _repository.GetShoppers();
        }

        public decimal ShopperOrderTotalByYear(int customerId, int year)
        {
            // add business logic here
            return _repository.GetShopperBindTotalByYear(customerId, year);
        }

        public IEnumerable<Shopper> ShoppersByName(string companyName)
        {
            // add business logic here
            return _repository.ShoppersByName(companyName);
        }

        public IEnumerable<SerialShopperBid> GetShopperBids(string country)
        {
            // add business logic here
            return _repository.GetShopperBids(country);
        }

        public override void Insert(Shopper entity)
        {
            // e.g. add business logic here before inserting
            base.Insert(entity);
        }

        public override void Update(Shopper entity)
        {
            entity.ObjectState = ObjectState.Modified;
            base.Update(entity);
            
        }

        public override void Delete(object id)
        {
            // e.g. add business logic here before deleting
            base.Delete(id);
        }

        
    }
}