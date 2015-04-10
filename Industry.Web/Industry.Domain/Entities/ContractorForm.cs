using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry.Domain.Entities
{
    public class ContractorForm : EntityCatalog
    {
        public ContractorForm()
        {
            IsActive = true;
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string FullName { get; set; }

        public virtual ICollection<Contractor> Contractors { get; set; }
    }
}
