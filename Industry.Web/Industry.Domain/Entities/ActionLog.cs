using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Infrastructure;

namespace Industry.Domain.Entities
{
    public class ActionLog : EntityBase
    {

        //public int UserId { get; set; }
        //public Guid EntityGlobalId { get; set; }
        //public DateTime Date { get; set; }
        //public string Comment { get; set; }
        //public int ActionTypeId { get; set; }
        //public string Mnemocode { get; set; }

        public int UserId { get; private set; }
        public Guid EntityGlobalId { get; private set; }
        public DateTime Date { get; private set; }
        public string Comment { get; private set; }
        public int ActionTypeId { get; private set; }
        public string Mnemocode { get; private set; }
        
        public virtual User User { get; set; }
        public virtual ActionType ActionType { get; set; }

        public static ActionLog Save(User user, Guid globalId, ActionType actionType, string comment, Type entityType)
        {
            var actionLog = new ActionLog();
            actionLog.User = user;
            actionLog.EntityGlobalId = globalId;
            actionLog.ActionType = actionType;
            actionLog.Comment = comment;
            actionLog.Mnemocode = entityType.Name;
            actionLog.Date = DateTime.Now;
            actionLog.ObjectState = ObjectState.Added;

            return actionLog;
        }

        public static ActionLog SaveTypeId(User user, Guid globalId, int typeId, string comment, Type entityType)
        {
            var actionLog = new ActionLog();
            actionLog.User = user;
            actionLog.EntityGlobalId = globalId;
            actionLog.ActionTypeId = typeId;
            actionLog.Comment = comment;
            actionLog.Mnemocode = entityType.Name;
            actionLog.Date = DateTime.Now;
            actionLog.ObjectState = ObjectState.Added;

            return actionLog;
        }

        public static ActionLog SaveByIds(int userId, Guid globalId, int actionTypeId, string comment, Type entityType)
        {
            var actionLog = new ActionLog();
            actionLog.UserId = userId;
            actionLog.EntityGlobalId = globalId;
            actionLog.ActionTypeId = actionTypeId;
            actionLog.Comment = comment;
            actionLog.Mnemocode = entityType.Name;
            actionLog.Date = DateTime.Now;
            actionLog.ObjectState = ObjectState.Added;

            return actionLog;
        }
        
    }
}
