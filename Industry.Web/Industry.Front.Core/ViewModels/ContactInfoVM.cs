using Repository.Pattern.Infrastructure;

namespace Industry.Front.Core.ViewModels
{
    public class ContactInfoVM
    {
        public int ContactInfoId { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }
        public bool IsBasic { get; set; }
        public int? CustomerId { get; set; }
        public int? ContactId { get; set; }
        public int ContactInfoTypeId { get; set; }
        public ObjectState ObjectState { get; set; }

        public virtual ContactInfoTypeVM ContactInfoType { get; set; }
    }

    public class ContactInfoTypeVM
    {
        public int ContactInfoTypeId { get; set; }
        public string ContactInfoTypeName { get; set; }
    }
}
