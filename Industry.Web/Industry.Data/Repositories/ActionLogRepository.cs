using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Industry.Domain.Entities;
using Repository.Pattern.Repositories;

namespace Industry.Data.Repositories
{
    public static class ActionLogRepository
    {
        public static IEnumerable<ActionLog> GetActionLogsByGlobalId(this IRepository<ActionLog> repository, Guid entityGlobalId)
        {
            return repository.Queryable().Where(s => s.EntityGlobalId == entityGlobalId);
        }

        public static IEnumerable<ActionLog> GetActionLogsByGlobalIdAndMnemocode(this IRepository<ActionLog> repository, Guid entityGlobalId, string mnemocode)
        {
            return repository.Queryable().Where(s => s.EntityGlobalId == entityGlobalId && s.Mnemocode == mnemocode);
        }
    }
}
