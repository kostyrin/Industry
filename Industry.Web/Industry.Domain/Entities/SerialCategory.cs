using System.Collections.Generic;

namespace Industry.Domain.Entities
{
    public partial class SerialCategory : EntityBase
    {
        public SerialCategory()
        {
            this.Products = new List<SerialProduct>();
        }

        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public virtual ICollection<SerialProduct> Products { get; set; }
    }
}
