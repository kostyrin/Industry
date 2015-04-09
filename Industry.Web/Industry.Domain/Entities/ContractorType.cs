using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry.Domain.Entities
{
    public class ContractorType : EntityBase 
    {
        public string Name { get; set; }

        public virtual ICollection<Contractor> Contractors { get; set; }
    }
}
