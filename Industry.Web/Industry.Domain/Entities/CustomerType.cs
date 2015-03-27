using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Industry.Domain.Entities
{
    /// <summary>
    /// Тип клиента
    /// </summary>
    public class CustomerType : EntityBase 
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [Required] [MaxLength(50)]
        public string Name { get; set; }
        
        /// <summary>
        /// Клиенты с таким типом
        /// </summary>
        public virtual ICollection<Customer> Customers { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }

        public enum PredefinedTypeIds
        {
            //Клиент
            Customer = 1,
            //Транспортная компания
            TransportCompany
        }
    }
}
