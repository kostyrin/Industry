using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Industry.Domain.Entities;
using Repository.Pattern.Repositories;

namespace Industry.Data.Repositories
{
    public static class ContractorRepository
    {
        public static Contractor GetContractorById(this IRepository<Contractor> repository, int contractorId)
        {
            return repository.Queryable().FirstOrDefault(s => s.Id == contractorId);
        }

        public static Contractor GetContractorGraphById(this IRepository<Contractor> repository, int contractorId)
        {
            return repository.Queryable()
                             .Include(c => c.ContractorForm)
                             .FirstOrDefault(s => s.Id == contractorId);
        }
        public static IEnumerable<Contractor> GetContractors(this IRepository<Contractor> repository)
        {
            return repository.Queryable().Include(c => c.ContractorForm);
        }

        public static IEnumerable<Contractor> GetContractorsWithParams(this IRepository<Contractor> repository, int count, int page, string sortField, string sortOrder, ref int totalCount)
        {
            var query = repository.Queryable();
            switch (sortField)
            {
                case "Code":
                    {
                        query = sortOrder.ToLower() == "asc" ? query.OrderBy(res => res.Code) : query.OrderByDescending(res => res.Code);
                        break;
                    }

                default:
                    {
                        query = sortOrder.ToLower() == "asc" ? query.OrderBy(res => res.Name) : query.OrderByDescending(res => res.Name);
                        break;
                    }
            }

            totalCount = query.Count();
            var contractors = query.Skip((page - 1) * count).Take(count);
            return contractors;
        }
    }
}
