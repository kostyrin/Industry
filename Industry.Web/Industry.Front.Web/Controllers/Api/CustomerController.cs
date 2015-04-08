using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Industry.Domain.Entities;
using Industry.Front.Core.ViewModels;
using Industry.Services.Services;
using Microsoft.AspNet.Identity;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace Industry.Front.Web.Controllers.Api
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
        public IHttpActionResult Get()
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
            return Ok(customers);
        }

        // GET: api/Customer&count=0&page0&softField='name'&sortOrder='asc'
        public IHttpActionResult Get(int count, int page, string sortField, string sortOrder)
        {
            int totalCount = 0;
            var customers = _customerService.GetCustomersWithParams(count, page, sortField, sortOrder, ref totalCount).ToList();
            IEnumerable<CustomerListVM> customerViewModels = new List<CustomerListVM>();
            Mapper.Map(customers, customerViewModels);
            PagedCollectionVM<CustomerListVM> viewModel = new PagedCollectionVM<CustomerListVM> { Data = customerViewModels, TotalCount = totalCount };

            return Ok(viewModel);

        }

        // GET: api/Customer/5
        public IHttpActionResult Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            var customerForm = Mapper.Map<Customer, CustomerVM>(customer);
            customerForm.ContactInfos = Mapper.Map<IEnumerable<ContactInfo>, IEnumerable<ContactInfoVM>>(_contactInfoService.GetContactInfosByCustomerId(customer.Id));
            return Ok(customerForm);
        }

        // POST: api/Customer
        public async Task<IHttpActionResult> Post(CustomerVM customerVM)
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            var user = _userService.GetUserByGlobalId(userId);

            Customer customer = new Customer();
            Mapper.Map(customerVM, customer);
            _customerService.AddOrUpdateCustomer(customer);
            try
            {
                await _unitOfWorkAsync.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }
            customerVM.CustomerId = customer.Id;

            return Created(Url.Link("DefaultApi", new { contoller = "Customer", CustomerId = customerVM.CustomerId}), customerVM);
        }

        // PUT: api/Customer/5
        public async Task<IHttpActionResult> Put(int id, CustomerVM customerVM)
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            var user = _userService.GetUserByGlobalId(userId);

            var customer = _customerService.GetCustomerById(id);
            Mapper.Map(customerVM, customer);
            //customer.CustomerId = id;
            customer.ObjectState = ObjectState.Modified; //TODO временно
            _customerService.AddOrUpdateCustomer(customer);
            try
            {
                await _unitOfWorkAsync.SaveChangesAsync();
            }
            catch
            {
                return BadRequest();
            }
            return Ok(customerVM);
        }

        // DELETE: api/Customer/5
        public IHttpActionResult Delete(int id)
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            var user = _userService.GetUserByGlobalId(userId);

            
            var customer = _customerService.GetCustomerById(id);
            customer.IsActive = false;

            _customerService.Update(customer);
            _unitOfWorkAsync.SaveChangesAsync();
            return Ok();
        }
    }
}
