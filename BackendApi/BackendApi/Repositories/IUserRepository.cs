using BackendApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApi.Repositories
{
    public interface IUserRepository
    {
        User FindByLogin(string login);

        User Create(User user);
    }
}
