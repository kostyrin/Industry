using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry.Domain.Entities
{
    public class CustomerPoint: EntityCatalog
    {
        public CustomerPoint()
        {
            IsActive = true;
        }

        [StringLength(150), Required]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        [MaxLength(150)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        public bool IsDelivery { get; set; }
        [MaxLength(250)]
        public string Descr { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
