using System.ComponentModel.DataAnnotations;

namespace Industry.Domain.Entities
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Customer : EntityCatalog
    {
        /// <summary>
        /// Наименование
        /// </summary>
        [Required(ErrorMessage = @"Поле обязательно для заполения")]
        [MaxLength(100,ErrorMessage = @"Поле ограничено 100 символами")] //поле обязательное и ограничено по длине 100
        [StringLength(100, ErrorMessage = @"Не более 100 символов")]
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

        /// <summary>
        /// Телефон
        /// </summary>
        [MaxLength(50)]
        public string Phone { get; set; } 

        /// <summary>
        /// Адрес электронной почты
        /// </summary>
        [MaxLength(50)]
        public string Email { get; set; }  
    
        /// <summary>
        /// Вебсайт
        /// </summary>
        [MaxLength(50)]
        public string Website { get; set; } 


        #region CustomerType

        /// <summary>
        /// Тип клиента
        /// </summary>
        public virtual CustomerType CustomerType { get; set; } 

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
        public string Province { get; set; }
        
        #endregion


        #region ResponsibleUser
        /// <summary>
        /// Ответственное лицо
        /// </summary>
        //TODO сделать!!
        //[Display(AutoGenerateFilter = false)]
        //public virtual  ResponsibleUser { get; set; }

        /// <summary>
        /// Идентификатор ответственного лица
        /// </summary>
        public int? ResponsibleUserId { get; set; }
        #endregion

        
        public override string ToString()
        {
            return string.Format("{0}", Name);
        }


        
    }
}