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
    public static class CustomerRepository
    {
        public static Customer GetCustomerById(this IRepository<Customer> repository, int customerId)
        {
            return repository.Queryable()
                             .Include(c => c.CustomerTypes)
                             .Include(c => c.ManagerUser)
                             .FirstOrDefault(s => s.Id == customerId);
        }
        public static IEnumerable<Customer> GetCustomers(this IRepository<Customer> repository)
        {
            return repository.Queryable().Include(c => c.CustomerTypes);
        }

        public static IEnumerable<Customer> GetCustomersWithParams(this IRepository<Customer> repository, int count, int page, string sortField, string sortOrder, ref int totalCount)
        {
            var query = repository.Queryable();
            switch (sortField)
            {
                case "CustomerCode":
                {
                    query = sortOrder.ToLower() == "asc" ? query.OrderBy(res => res.CustomerCode) : query.OrderByDescending(res => res.CustomerCode);
                    break;
                }

                default:
                {
                    query = sortOrder.ToLower() == "asc" ? query.OrderBy(res => res.CustomerName) : query.OrderByDescending(res => res.CustomerName);
                    break;
                }
            }

            totalCount = query.Count();
            var customers = query.Skip((page - 1)*count).Take(count);
            return customers;
        }
    }
}
