using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry.Domain.Entities
{
    public class ContactInfo : EntityCatalog
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Descr { get; set; }
        public bool IsBasic { get; set; }
        public int? CustomerId { get; set; }
        public int? ContactId { get; set; }
        public int ContactInfoTypeId { get; set; }

        public virtual ContactInfoType ContactInfoType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Contact Contact { get; set; }

    }
}
