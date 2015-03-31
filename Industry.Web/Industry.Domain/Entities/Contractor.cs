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
        [Required] [MaxLength(100)]
        public string ContractorName { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public string Descr { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string OGRN { get; set; }
        public string OKPO { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PostAddress { get; set; }
        public string RegistrationAddress { get; set; }
        public string Account { get; set; }
        public string Bank { get; set; }
        public string BIK { get; set; }
        public string CorrAccount { get; set; }
        public string PrintInface { get; set; }
        public string PrintOn { get; set; }
        public string PrintPosition { get; set; }
        public string PrintFullFIO { get; set; }
        public int ContractorTypeId { get; set; }
        public int ContractorFormId { get; set; }
        public int? CustomerId { get; set; }

        //public virtual ContractorType ContractorType { get; set; }
        //public virtual ContractorForm ContractorForm { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
