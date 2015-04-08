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

        public ActionLog Save(User user, Guid globalId, ActionType actionType, string comment, Type entityType)
        {
            this.User = user;
            this.EntityGlobalId = globalId;
            this.ActionType = actionType;
            this.Comment = comment;
            this.Mnemocode = entityType.Name;
            this.Date = DateTime.Now;
            this.ObjectState = ObjectState.Added;

            return this;
        }

        public ActionLog SaveTypeId(User user, Guid globalId, int typeId, string comment, Type entityType)
        {
            this.User = user;
            this.EntityGlobalId = globalId;
            this.ActionTypeId = typeId;
            this.Comment = comment;
            this.Mnemocode = entityType.Name;
            this.Date = DateTime.Now;
            this.ObjectState = ObjectState.Added;

            return this;
        }

        public ActionLog SaveByIds(int userId, Guid globalId, int actionTypeId, string comment, Type entityType)
        {
            this.UserId = userId;
            this.EntityGlobalId = globalId;
            this.ActionTypeId = actionTypeId;
            this.Comment = comment;
            this.Mnemocode = entityType.Name;
            this.Date = DateTime.Now;
            this.ObjectState = ObjectState.Added;

            return this;
        }
        
    }
}
