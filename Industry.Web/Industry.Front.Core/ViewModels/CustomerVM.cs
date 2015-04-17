using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Repository.Pattern.Infrastructure;

namespace Industry.Front.Core.ViewModels
{
    public class CustomerVM
    {
        public int CustomerId { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        [Required(ErrorMessage = @"Поле обязательно для заполения")]
        [MaxLength(150, ErrorMessage = @"Поле ограничено 100 символами")] //поле обязательное и ограничено по длине 100
        public string Name { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        [MaxLength(50)]
        public string Code { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [MaxLength(250, ErrorMessage = @"Поле ограничено 250 символами")]
        public string Descr { get; set; }
        
        public int? ManagerUserId { get; set; }
        public string ManagerUserName { get; set; }

        public bool IsActive { get; set; }

        public ObjectState ObjectState { get; set; }

        public virtual IEnumerable<ContactInfoVM> ContactInfos { get; set; }
        public virtual IEnumerable<ContractorVM> Contractors { get; set; }
        public virtual IEnumerable<ContactVM> Contacts { get; set; }
        public virtual IEnumerable<CompanyTypeVM> CompanyTypes { get; set; }
        public virtual IEnumerable<CustomerPointVM> CustomerPoints { get; set; }
    }

    public class CompanyTypeVM
    {
        public int CompanyTypeId { get; set; }
        public string Name { get; set; }
    }

}
