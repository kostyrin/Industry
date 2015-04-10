using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Infrastructure;

namespace Industry.Front.Core.ViewModels
{
    public class ContractorVM
    {
        public int ContractorId { get; set; }
        [StringLength(150), Required]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(250)]
        public string Descr { get; set; }
        public bool IsActive { get; set; }
        public ObjectState ObjectState { get; set; }
        public int CustomerId { get; set; }
    }
}
