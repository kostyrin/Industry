using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Infrastructure;

namespace Industry.Front.Core.ViewModels
{
    public class CustomerPointVM
    {
        public int CustomerPointId { get; set; }
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

        public bool IsActive { get; set; }
        public ObjectState ObjectState { get; set; }
        public int CustomerId { get; set; }

    }
}
