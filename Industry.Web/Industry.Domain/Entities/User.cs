using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry.Domain.Entities
{
    public class User : EntityCatalog
    {
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public byte[] Image { get; set; }

        public int? DealerId { get; set; }
        public int? DepartmentId { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public bool? Gender { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public double? ZipCode { get; set; }

        public double? ContactNo { get; set; }

        public string GlobalUserId { get; set; }


        //public virtual Dealer Dealer
        //public virtual Department Department
        public virtual ICollection<Customer> Customers { get; set; }
        //public virtual ICollection<Contact> Contacts { get; set; }
    }
}
