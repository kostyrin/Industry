using System;

namespace Industry.Services.DTOs
{
    public class BidListDTO
    {
        public long BidId { get; set; }
        public int ShopperId { get; set; }
        public string Shopper { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<System.DateTime> BidDate { get; set; }
        public Nullable<System.DateTime> RequiredDate { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public Nullable<int> ShipVia { get; set; }
        public Nullable<decimal> Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
    }
}