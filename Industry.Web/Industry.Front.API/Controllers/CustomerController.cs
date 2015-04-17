using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Industry.Common.Enums;
using Industry.Domain.Entities;
using Industry.Front.Core.ViewModels;
using Industry.Services.Services;
using log4net;
using Microsoft.AspNet.Identity;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;

namespace Industry.Front.API.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly IActionLogService _actionLogService;
        private readonly ICustomerService _customerService;
        private readonly IContactInfoService _contactInfoService;
        private readonly IUserService _userService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly ILog _log;

        public CustomerController( IActionLogService actionLogService
                                , ICustomerService customerService
                                , IContactInfoService contactInfoService
                                , IUserService userService
                                , IUnitOfWorkAsync unitOfWorkAsync
                                , ILog logger)
        {
            _actionLogService = actionLogService;
            _customerService = customerService;
            _contactInfoService = contactInfoService;
            _userService = userService;
            _unitOfWorkAsync = unitOfWorkAsync;
            _log = logger;
        }

        
        // GET: api/Customer
        public IHttpActionResult Get()
        {
            _log.Info("GET: api/Customer");
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
                    if (phone != null) item.Phone = phone.Name;

                    var email = contactInfos.FirstOrDefault(ci => ci.ContactInfoTypeId == (int) ContactInfoType.PredefinedTypeIds.Email && ci.IsBasic);
                    if (email != null) item.Email = email.Name;
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
            var customer = _customerService.GetCustomerGraphById(id);
            var customerForm = Mapper.Map<Customer, CustomerVM>(customer);
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
            _actionLogService.AddActionLog(user.Id, customer.GlobalId, (int)ActionTypeNames.Common.Modified, "",customer.GetType());
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
            _actionLogService.AddActionLog(user.Id, customer.GlobalId, (int)ActionTypeNames.Common.Modified, "", customer.GetType());
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
