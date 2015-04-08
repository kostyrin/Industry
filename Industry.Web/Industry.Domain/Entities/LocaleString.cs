using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry.Domain.Entities
{
    public class LocaleString : EntityBase
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int CultureId { get; set; }

        public virtual Culture Culture { get; set; }
    }
}
