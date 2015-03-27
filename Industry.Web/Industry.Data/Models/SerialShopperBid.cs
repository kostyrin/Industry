using System;

namespace Industry.Data.Models
{
    public class SerialShopperBid
    {
        public int ShopperId { get; set; }
        public string ContactName { get; set; }
        public long BidId { get; set; }
        public DateTime? BidDate { get; set; }
    }
}