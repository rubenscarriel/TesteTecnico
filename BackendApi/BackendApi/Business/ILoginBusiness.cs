using BackendApi.Model;

namespace BackendApi.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(User user);
    }
}
