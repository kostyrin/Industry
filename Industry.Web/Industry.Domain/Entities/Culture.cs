using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry.Domain.Entities
{
    public class Culture: EntityBase
    {
        public Culture()
        {
            IsActive = true;
        }

        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<LocaleString> LocaleStrings { get; set; }
    }
}
