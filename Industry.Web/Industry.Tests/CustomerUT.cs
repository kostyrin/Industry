using System;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Industry.Domain.Entities;
using Industry.Data.Repositories;
using Industry.Front.Core.ViewModels;
using Industry.Front.Web.Api;
using Industry.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Repository.Pattern.UnitOfWork;

namespace Industry.Tests
{
    [TestClass]
    public class CustomerUT
    {
        [TestMethod]
        public void GetCustomer()
        {
            var cs = new Mock<ICustomerService>();
            var ci = new Mock<IContactInfoService>();
            var uow = new Mock<IUnitOfWorkAsync>();
            var us = new Mock<IUserService>();
            cs.Setup(s => s.GetCustomerById(It.IsAny<int>())).Returns(new Customer());

            //var mapper = new Mock<AutoMapper.IObjectMapper>();
            //mapper.Setup(m => m.Map<Customer, CustomerVM>(It.IsAny<CustomerVM>())).Returns(new CustomerVM());

            var controller = new CustomerController(cs.Object, ci.Object, us.Object, uow.Object);

            // Act
            var response = controller.Get();

            // Assert
            Assert.IsNotNull(response);
            
        }
    }
}
