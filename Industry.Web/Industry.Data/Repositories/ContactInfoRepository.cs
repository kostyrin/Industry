using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Industry.Domain.Entities;
using Repository.Pattern.Repositories;

namespace Industry.Data.Repositories
{
    public static class ContactInfoRepository
    {
        public static ContactInfo GetContactInfoById(this IRepository<ContactInfo> repository, int contactInfoId)
        {
            return repository.Queryable().FirstOrDefault(s => s.Id == contactInfoId);
        }

        public static IEnumerable<ContactInfo> GetContactInfosByCustomerId(this IRepository<ContactInfo> repository, int customerId)
        {
            return repository.Queryable().Where(c => c.CustomerId == customerId);
        }
    }
}
