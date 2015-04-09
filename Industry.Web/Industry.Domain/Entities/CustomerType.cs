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
        public virtual ICollection<Contractor> Contractors { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }

        public enum PredefinedTypeIds
        {
            //Покупатель
            Customer = 1,
            //Поставщик
            Supplier,
            //Виртуальный
            Virtual
        }
    }
}
