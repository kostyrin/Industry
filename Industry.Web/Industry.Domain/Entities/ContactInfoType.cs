using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry.Domain.Entities
{
    public class ContactInfoType: EntityBase
    {
        [Required][MaxLength(50)]
        public string ContactInfoTypeName { get; set; }

        public virtual ICollection<ContactInfo> ContactInfos { get; set; }

        public enum PredefinedTypeIds
        {
            /// <summary>
            /// Телефон
            /// </summary>
            Phone = 1,
            /// <summary>
            /// Адрес
            /// </summary>
            Address = 2,
            /// <summary>
            /// Почта
            /// </summary>
            Email = 3,
            /// <summary>
            /// Сайт
            /// </summary>
            Site = 4
        }
    }
}
