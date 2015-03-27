#region

using Industry.Domain.Entities;
using Repository.Pattern.Repositories;
using Service.Pattern;

#endregion

namespace Industry.Services.Services
{
    public interface IProductService : IService<SerialProduct>
    {
    }

    public class SerialProductService : Service<SerialProduct>, IProductService
    {
        public SerialProductService(IRepositoryAsync<SerialProduct> repository)
            : base(repository)
        {
        }
    }
}