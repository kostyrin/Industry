using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Infrastructure;

namespace Industry.Front.Core.ViewModels
{
    public class ContactVM
    {
        public int ContactId { get; set; }

        [StringLength(100), Required]
        public string Name { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }
        public DateTime? BirthDate { get; set; }

        [MaxLength(100)]
        public string Position { get; set; }

        public byte[] Image { get; set; }

        [MaxLength(150)]
        public string Descr { get; set; }

        public bool IsActive { get; set; }
        public ObjectState ObjectState { get; set; }

        public int CustomerId { get; set; }

        public string FullName
        {
            get { return String.Format("{0} {1} {2}", Name, LastName, MiddleName); }
        }
    }
}
