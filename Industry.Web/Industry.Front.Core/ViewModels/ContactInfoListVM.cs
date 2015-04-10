using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry.Front.Core.ViewModels
{
    public class ContactInfoListVM
    {
        public int ContactInfoId { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public bool IsBasic { get; set; }
        public int? CustomerId { get; set; }
        public int? ContactId { get; set; }
        public bool IsActive { get; set; }

        public virtual IEnumerable<ContactInfoTypeVM> ContactInfoTypes { get; set; }
    }
}
