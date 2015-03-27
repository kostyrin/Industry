using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Industry.Domain.Entities;
using Industry.Services.DTOs;
using Industry.Services.Services;
using Repository.Pattern.UnitOfWork;

namespace Industry.Web.Api
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService _customerService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public CustomerController(ICustomerService customerService, IUnitOfWorkAsync unitOfWorkAsync)
        {
            _customerService = customerService;
            _unitOfWorkAsync = unitOfWorkAsync;
        }

        // GET: api/Customer
        public IEnumerable<CustomerListDTO> Get()
        {
            var customers = _customerService.GetCustomers();
            var customerList = Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerListDTO>>(customers);
            return customerList;
        }

        // GET: api/Customer/5
        public CustomerDTO Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            var customerForm = Mapper.Map<Customer, CustomerDTO>(customer);
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
