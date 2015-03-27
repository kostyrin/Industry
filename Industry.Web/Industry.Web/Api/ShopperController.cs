using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Industry.Domain.Entities;
using Industry.Services.DTOs;
using Industry.Services.Services;
using Repository.Pattern.UnitOfWork;

namespace Industry.Web.Api
{
    public class ShopperController : ApiController
    {
        private readonly IShopperService _shopperService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public ShopperController(IShopperService shopperService, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _shopperService = shopperService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        // GET: api/Shopper
        public IEnumerable<ShopperListDTO> Get()
        {
            var shoppers = _shopperService.GetShoppers();
            var shoppersDetails = Mapper.Map<IEnumerable<Shopper>, IEnumerable<ShopperListDTO>>(shoppers);
            return shoppersDetails;
        }

        // GET: api/Shopper/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Shopper
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Shopper/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Shopper/5
        public void Delete(int id)
        {
        }
    }
}
