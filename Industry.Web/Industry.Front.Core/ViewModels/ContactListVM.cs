using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry.Front.Core.ViewModels
{
    public class ContactListVM
    {

        public int ContactId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Position { get; set; }
        public string PhoneBasic { get; set; }
        public string EmailBasic { get; set; }
        public bool IsActive { get; set; }
        public string Descr { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string FullName
        {
            get { return String.Format("{0} {1} {2}", Name, LastName, MiddleName); }
        }

        
    }
}
