using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Repository.Pattern.Infrastructure;

namespace Industry.Front.Core.ViewModels
{
    public class CustomerListVM
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerDescr { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? ManagerUserId { get; set; }
        public string ManagerUserName { get; set; }
        public bool IsActive { get; set; }
        public ObjectState ObjectState { get; set; }

        public virtual IEnumerable<CustomerTypeVM> CustomerTypes { get; set; }
        
    }
}
