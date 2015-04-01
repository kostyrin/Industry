using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Industry.Domain.Entities;
using Industry.Front.Core.ViewModels;
using Industry.Services.Services;
using Industry.Front.Web.Models;
using Microsoft.AspNet.Identity;
using Repository.Pattern.UnitOfWork;

namespace Industry.Front.Web.Api
{
    [RoutePrefix("api/customers")]
    [Authorize]
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IContactInfoService _contactInfoService;
        private readonly IUserService _userService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public CustomerController(ICustomerService customerService
                                , IContactInfoService contactInfoService
                                , IUserService userService
                                , IUnitOfWorkAsync unitOfWorkAsync)
        {
            _customerService = customerService;
            _contactInfoService = contactInfoService;
            _userService = userService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        
        // GET: api/Customer
        public IEnumerable<CustomerListVM> Get()
        {
            var id = RequestContext.Principal.Identity.GetUserId();
            var customers = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerListVM>>(_customerService.GetCustomers());
            foreach (var item in customers)
            {
                if (item.ManagerUserId.HasValue)
                {
                    var user = _userService.GetUserById((int)item.ManagerUserId);
                    item.ManagerUserName = user.FirstName;
                }

                var contactInfos = _contactInfoService.GetContactInfosByCustomerId(item.CustomerId);
                if (contactInfos != null)
                {
                    var phone = contactInfos.FirstOrDefault(ci => ci.ContactInfoTypeId == (int) ContactInfoType.PredefinedTypeIds.Phone && ci.IsBasic);
                    if (phone != null) item.Phone = phone.ContactInfoName;

                    var email = contactInfos.FirstOrDefault(ci => ci.ContactInfoTypeId == (int) ContactInfoType.PredefinedTypeIds.Email && ci.IsBasic);
                    if (email != null) item.Email = email.ContactInfoName;
                }
            }
            return customers;
        }

        // GET: api/Customer/5
        public CustomerVM Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            var customerForm = Mapper.Map<Customer, CustomerVM>(customer);
            customerForm.ContactInfos = Mapper.Map<IEnumerable<ContactInfo>, IEnumerable<ContactInfoVM>>(_contactInfoService.GetContactInfosByCustomerId(customer.Id));
            return customerForm;
        }

        // POST: api/Customer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
