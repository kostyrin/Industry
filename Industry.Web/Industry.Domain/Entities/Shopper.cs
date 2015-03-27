using System.Collections.Generic;

namespace Industry.Domain.Entities
{
    public partial class Shopper : EntityBase
    {
        public Shopper()
        {
            this.Bids = new List<SerialBid>();
        }

        public string Name { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public virtual ICollection<SerialBid> Bids { get; set; }
    }
}
