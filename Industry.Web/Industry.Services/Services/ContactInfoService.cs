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
    public interface IContactInfoService : IService<ContactInfo>
    {
        ContactInfo GetContactInfoById(int id);
        IEnumerable<ContactInfo> GetContactInfosByCustomerId(int customerId);
    }

    public class ContactInfoService : Service<ContactInfo>, IContactInfoService
    {
        private readonly IRepositoryAsync<ContactInfo> _repository;

        public ContactInfoService(IRepositoryAsync<ContactInfo> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public ContactInfo GetContactInfoById(int id)
        {
            return _repository.GetContactInfoById(id);
        }

        public IEnumerable<ContactInfo> GetContactInfosByCustomerId(int customerId)
        {
            return _repository.GetContactInfosByCustomerId(customerId);
        }
    }
}
