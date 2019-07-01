using BackendApi.Model;
using BackendApi.Repositories;

namespace BackendApi.Business.Implementations
{
    public class UserBusinessImpl : IUserBusiness
    {
        private readonly IUserRepository _repository;

        public UserBusinessImpl(IUserRepository repository)
        {
            _repository = repository;
        }

        public User Create(User user)
        {
            return _repository.Create(user);
        }

        public User FindByLogin(string login)
        {
            return _repository.FindByLogin(login);
        }
    }
}
