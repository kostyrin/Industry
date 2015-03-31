using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Infrastructure;

namespace Industry.Services.DTOs
{
    public class ContactInfoDTO
    {
        public int ContactInfoId { get; set; }
        public string ContactInfoName { get; set; }
        public string ContactInfoDescr { get; set; }
        public bool IsBasic { get; set; }
        public int? CustomerId { get; set; }
        public int? ContactId { get; set; }
        public int ContactInfoTypeId { get; set; }
        public ObjectState ObjectState { get; set; }
    }
}
