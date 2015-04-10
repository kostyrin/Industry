using System;
using System.Collections.Generic;

namespace Industry.Domain.Entities
{
    public partial class SerialBid : EntityDocument
    {
        public SerialBid()
        {
            this.BidDetails = new List<SerialBidDetail>();
            IsActive = true;
        }

        public int ShopperId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? BidDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public virtual Shopper Shopper { get; set; }
        public virtual ICollection<SerialBidDetail> BidDetails { get; set; }
    }
}
