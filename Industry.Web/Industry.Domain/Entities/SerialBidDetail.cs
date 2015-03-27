namespace Industry.Domain.Entities
{
    public partial class SerialBidDetail : EntityDocument
    {
        public long BidId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public virtual SerialBid Bid { get; set; }
        public virtual SerialProduct Product { get; set; }
    }
}
