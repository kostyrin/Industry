using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Industry.Data.Repositories;
using Industry.Domain.Entities;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace Industry.Services.Services
{
    public interface IActionLogService : IService<ActionLog>
    {
        IEnumerable<ActionLog> GetActionLogsByGlobalId(Guid entityGlobalId);
        IEnumerable<ActionLog> GetActionLogsByGlobalIdAndMnemocode(Guid entityGlobalId, string mnemocode);
        bool AddActionLog(int userId, Guid globalId, int actionTypeId, string comments, Type type);
    }

    public class ActionLogService : Service<ActionLog>, IActionLogService
    {
        private readonly IRepositoryAsync<ActionLog> _repository;


        public ActionLogService(IRepositoryAsync<ActionLog> repository) : base(repository)
        {
            _repository = repository;
        }


        public IEnumerable<ActionLog> GetActionLogsByGlobalId(Guid entityGlobalId)
        {
            return _repository.GetActionLogsByGlobalId(entityGlobalId);
        }

        public IEnumerable<ActionLog> GetActionLogsByGlobalIdAndMnemocode(Guid entityGlobalId, string mnemocode)
        {
            return _repository.GetActionLogsByGlobalIdAndMnemocode(entityGlobalId, mnemocode);
        }

        public bool AddActionLog(int userId, Guid globalId, int actionTypeId, string comments, Type type)
        {
            var actionLog = new ActionLog();
            actionLog.SaveByIds(userId, globalId, actionTypeId, comments, type);
            _repository.Insert(actionLog);
            return true;
        }
    }
}
