using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Industry.Domain.Entities
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Customer : EntityCatalog
    {
        public Customer()
        {
            IsActive = true;
        }

        [StringLength(150), Required]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Code { get; set; } 
        [MaxLength(250)]
        public string Descr { get; set; }
        public int? ManagerUserId { get; set; }


        public virtual User ManagerUser { get; set; }
        public virtual ICollection<CustomerType> CustomerTypes { get; set; }
        public virtual ICollection<CustomerPoint> CustomerPoints { get; set; }
        public virtual ICollection<ContactInfo> ContactInfos { get; set; }
        public virtual ICollection<Contractor> Contractors { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0}", Name);
        }




        
    }
}