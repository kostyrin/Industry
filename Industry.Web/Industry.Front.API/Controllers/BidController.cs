using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Industry.Domain.Entities;
using Industry.Front.Core.ViewModels;
using Industry.Services.Services;
using Repository.Pattern.UnitOfWork;

namespace Industry.Front.API.Controllers
{
    public class BidController : ApiController
    {
        private readonly IBidService _bidService;
        private readonly IShopperService _shopperService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        public BidController(IBidService bidService,IShopperService shopperService, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _bidService = bidService;
            _shopperService = shopperService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }
        // GET: api/Bid
        public IEnumerable<BidListVM> Get()
        {
            var bids = _bidService.GetBids();
            var bidsDetails = Mapper.Map<IEnumerable<SerialBid>, IEnumerable<BidListVM>>(bids);
            foreach (var bid in bidsDetails)
            {
                var shopper = _shopperService.GetShopperById(bid.ShopperId);
                bid.Shopper = shopper.Name;
            }
            return bidsDetails;
        }

        // GET: api/Bid/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Bid
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Bid/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bid/5
        public void Delete(int id)
        {
        }
    }
}
