using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industry.Services.DTOs
{
    public class CustomerListDTO
    {
        public int CustomerId { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        [Required(ErrorMessage = @"Поле обязательно для заполения")]
        [MaxLength(100, ErrorMessage = @"Поле ограничено 100 символами")] //поле обязательное и ограничено по длине 100
        [StringLength(100, ErrorMessage = @"Не более 100 символов")]
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
        public string Descr { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        [MaxLength(50)]
        [Display(ShortName = "Телефон", AutoGenerateFilter = false)]
        public string Phone { get; set; }

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        [MaxLength(50)]
        [Display(ShortName = "E-mail", AutoGenerateFilter = false)]
        public string Email { get; set; }

        /// <summary>
        /// Вебсайт
        /// </summary>
        [MaxLength(50)]
        [Display(ShortName = "Вебсайт", AutoGenerateFilter = false)]
        public string Website { get; set; }

        //Реквизиты бизнес-логики



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


        #region Province

        /// <summary>
        /// Регион
        /// </summary>
        [MaxLength(150)]
        [Display(ShortName = "Регион")]
        public string Province { get; set; }

        #endregion


        #region ResponsibleUser
        /// <summary>
        /// Ответственное лицо
        /// </summary>
        //TODO сделать!!

        public int? ResponsibleUserId { get; set; }
        public string ResponsibleUserName { get; set; }

        #endregion

        public bool IsActive { get; set; }
        
    }
}
