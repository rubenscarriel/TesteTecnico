using BackendApi.Model;

namespace BackendApi.Business
{
    public interface IUserBusiness
    {
        User Create(User user);
        User FindByLogin(string login);
    }
}
