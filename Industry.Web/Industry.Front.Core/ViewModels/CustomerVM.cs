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

        public virtual IEnumerable<ContactInfoListVM> ContactInfos  { get; set; }
        public virtual IEnumerable<ContactListVM> Contacts { get; set; }
        public virtual IEnumerable<CustomerTypeVM> CustomerTypes { get; set; }
        public virtual IEnumerable<CustomerPointListVM> CustomerPoints { get; set; }
    }

    public class CustomerTypeVM
    {
        public int CustomerTypeId { get; set; }
        public string Name { get; set; }
    }

}
