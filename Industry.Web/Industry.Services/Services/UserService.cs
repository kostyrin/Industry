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
    public interface IUserService : IService<User>
    {
        User GetUserById(int userId);
        User GetUserByGlobalId(string globalUserId);
        IEnumerable<User> GetUsers();

        void CreateUser(string globalId, string email);
    }

    public class UserService : Service<User>, IUserService
    {
        private readonly IRepositoryAsync<User> _repository;
        
        public UserService(IRepositoryAsync<User> repository) : base(repository)
        {
            _repository = repository;
        }

        public User GetUserById(int userId)
        {
            return _repository.GetUserById(userId);
        }

        public User GetUserByGlobalId(string globalUserId)
        {
            return _repository.GetUserByGlobalId(globalUserId);
        }

        public void CreateUser(string globalId, string email)
        {
            User newUser = new User();
            newUser.GlobalUserId = globalId;
            newUser.Email = email;
            _repository.Insert(newUser);
        }

        public IEnumerable<User> GetUsers()
        {
            return _repository.GetUsers();
        }
    }
}
