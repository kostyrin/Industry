using System.Collections.Generic;
using Industry.Data.Repositories;
using Industry.Domain.Entities;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace Industry.Services.Services
{
    public interface IBidService : IService<SerialBid>
    {
        IEnumerable<SerialBid> GetBids();
        SerialBid GetBidById(int bidId);
        SerialBid GetBidGraphById(int bidId);
    }

    public class BidService : Service<SerialBid>, IBidService
    {
        private readonly IRepositoryAsync<SerialBid> _repository;
        

        public BidService(IRepositoryAsync<SerialBid> repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<SerialBid> GetBids()
        {
            return _repository.GetBids();
        }

        public SerialBid GetBidById(int bidId)
        {
            return _repository.GetBidById(bidId);
        }

        public SerialBid GetBidGraphById(int bidId)
        {
            return _repository.GetBidGraphById(bidId);
        }
    }
}
