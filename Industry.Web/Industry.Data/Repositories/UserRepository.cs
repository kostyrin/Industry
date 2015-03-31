using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Industry.Domain.Entities;
using Repository.Pattern.Repositories;

namespace Industry.Data.Repositories
{
    public static class UserRepository
    {
        public static User GetUserById(this IRepository<User> repository, int userId)
        {
            return repository.Queryable().FirstOrDefault(s => s.Id == userId);
        }

        public static User GetUserByGlobalId(this IRepository<User> repository, string globalUserId)
        {
            return repository.Queryable().FirstOrDefault(s => s.GlobalUserId == globalUserId);
        }

        public static IEnumerable<User> GetUsers(this IRepository<User> repository)
        {
            return repository.Queryable();
        }
    }
}
