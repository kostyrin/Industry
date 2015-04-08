using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Industry.Domain.Entities
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Customer : EntityCatalog
    {
        [Required] [MaxLength(100)]
        public string CustomerName { get; set; }
        [MaxLength(50)]
        public string CustomerCode { get; set; } 
        [MaxLength(250)]
        public string CustomerDescr { get; set; }
        public int? ManagerUserId { get; set; }


        public virtual ICollection<CustomerType> CustomerTypes { get; set; }
        public virtual User ManagerUser { get; set; }
        public virtual ICollection<ContactInfo> ContactInfo { get; set; }

        
        public override string ToString()
        {
            return string.Format("{0}", CustomerName);
        }




        
    }
}