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
        [MaxLength(100, ErrorMessage = @"Поле ограничено 100 символами")] //поле обязательное и ограничено по длине 100
        [Display(ShortName = "Наименование")]
        public string CustomerName { get; set; }

        /// <summary>
        /// Код
        /// </summary>
        [MaxLength(50)]
        [Display(ShortName = "Код", AutoGenerateFilter = false)]
        public string CustomerCode { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        [MaxLength(250, ErrorMessage = @"Поле ограничено 250 символами")]
        [Display(ShortName = "Описание", AutoGenerateFilter = false)]
        public string CustomerDescr { get; set; }

        
        #region CustomerType

        /// <summary>
        /// Тип клиента
        /// </summary>
        public string CustomerTypeName { get; set; }

        /// <summary>
        /// Идентификатор типа клиента
        /// </summary>
        public int CustomerTypeId { get; set; }

        #endregion

        public int? ManagerUserId { get; set; }
        public string ManagerUserName { get; set; }

        public bool IsActive { get; set; }

        public ObjectState ObjectState { get; set; }

        public virtual IEnumerable<ContactInfoVM> ContactInfos  { get; set; }
    }
}
