using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Industry.Domain.Entities;
using Repository.Pattern.Repositories;

namespace Industry.Data.Repositories
{
    public static class BidRepository
    {
        public static SerialBid GetBidById(this IRepository<SerialBid> repository, int bidId)
        {
            return repository.Queryable().FirstOrDefault(s => s.Id == bidId);
        }

        public static SerialBid GetBidGraphById(this IRepository<SerialBid> repository, int bidId)
        {
            return repository.Queryable().Include(b =>b.BidDetails.Select(bd => bd.Product)).FirstOrDefault(b => b.Id == bidId);
        }
        public static IEnumerable<SerialBid> GetBids(this IRepository<SerialBid> repository)
        {
            return repository.Queryable();
        }
    }
}
