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
using Repository.Pattern.UnitOfWork;

namespace Industry.Front.API.Controllers
{
    public class ContractorController : ApiController
    {
        private readonly IActionLogService _actionLogService;
        private readonly IContractorService _contractorService;
        private readonly IContactInfoService _contactInfoService;
        private readonly IUserService _userService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public ContractorController(IActionLogService actionLogService
                                , IContractorService contractorService
                                , IContactInfoService contactInfoService
                                , IUserService userService
                                , IUnitOfWorkAsync unitOfWorkAsync)
        {

            _actionLogService = actionLogService;
            _contractorService = contractorService;
            _contactInfoService = contactInfoService;
            _userService = userService;
            _unitOfWorkAsync = unitOfWorkAsync;
            
        }
        // GET: api/Contractor
        public IHttpActionResult Get()
        {
            var contractors = Mapper.Map<IEnumerable<Contractor>, IEnumerable<ContractorVM>>(_contractorService.GetContractors());
            return Ok(contractors);
        }

        // GET: api/Contractor/5
        public IHttpActionResult Get(int id)
        {
            var contractor = _contractorService.GetContractorGraphById(id);
            var contractorForm = Mapper.Map<Contractor, ContractorVM>(contractor);
            return Ok(contractorForm);
        }

        // POST: api/Contractor
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Contractor/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contractor/5
        public void Delete(int id)
        {
        }
    }
}
