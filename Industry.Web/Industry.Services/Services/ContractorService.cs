using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Industry.Data.Repositories;
using Industry.Domain.Entities;
using Repository.Pattern.Repositories;
using Service.Pattern;

namespace Industry.Services.Services
{
    public interface IContractorService : IService<Contractor>
    {
        Contractor GetContractorById(int contractorId);
        Contractor GetContractorGraphById(int contractorId);
        IEnumerable<Contractor> GetContractors();
        IEnumerable<Contractor> GetContractorsWithParams(int count, int page, string sortField, string sortOrder, ref int totalCount);
        Contractor AddOrUpdateContractor(Contractor customer);
    }
    public class ContractorService : Service<Contractor>, IContractorService
    {
        private readonly IRepositoryAsync<Contractor> _repository;

        public ContractorService(IRepositoryAsync<Contractor> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Contractor GetContractorById(int shopperId)
        {
            return _repository.GetContractorById(shopperId);
        }

        public Contractor GetContractorGraphById(int shopperId)
        {
            return _repository.GetContractorGraphById(shopperId);
        }

        public IEnumerable<Contractor> GetContractors()
        {
            return _repository.GetContractors();
        }

        public IEnumerable<Contractor> GetContractorsWithParams(int count, int page, string sortField, string sortOrder, ref int totalCount)
        {
            return _repository.GetContractorsWithParams(count, page, sortField, sortOrder, ref totalCount);
        }

        public Contractor AddOrUpdateContractor(Contractor contractor)
        {
            _repository.InsertOrUpdateGraph(contractor);
            return contractor;
        }
    }
}
