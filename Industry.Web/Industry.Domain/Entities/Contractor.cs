using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry.Domain.Entities
{
    public class Contractor: EntityCatalog
    {
        [Required] [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string FullName { get; set; }
        [MaxLength(50)]
        public string Code { get; set; }
        [MaxLength(150)]
        public string Descr { get; set; }

        public bool IsRussainAdress { get; set; }
        [MaxLength(250)]
        public string RegistrationAddress { get; set; }
        [MaxLength(250)]
        public string PostAddress { get; set; }
        [MaxLength(250)]
        public string Passport { get; set; }
        [MaxLength(50)]
        public string INN { get; set; }
        [MaxLength(50)]
        public string KPP { get; set; }
        [MaxLength(50)]
        public string OGRN { get; set; }
        [MaxLength(50)]
        public string OKPO { get; set; }
        [MaxLength(150)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }

        //Данные для печати
        [MaxLength(150)]
        public string PrintInface { get; set; }
        [MaxLength(150)]
        public string PrintOn { get; set; }
        [MaxLength(150)]
        public string PrintPosition { get; set; }
        [MaxLength(150)]
        public string PrintFullFIO { get; set; }

        public int ContractorTypeId { get; set; }
        public int ContractorFormId { get; set; }
        public int? CustomerId { get; set; }

        public virtual ContractorType ContractorType { get; set; }
        public virtual ContractorForm ContractorForm { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<CustomerType> CustomerTypes { get; set; }
    }
}
