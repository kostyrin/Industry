using System;
using System.Collections.Generic;

namespace Industry.Domain.Entities
{
    public partial class SerialProduct : EntityCatalog
    {
        public SerialProduct()
        {
            //this.BidDetails = new List<SerialBidDetail>();
            IsActive = true;
        }

        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public int QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public virtual SerialCategory Category { get; set; }
        public virtual ICollection<SerialBidDetail> BidDetails { get; set; }
    }
}
