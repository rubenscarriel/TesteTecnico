using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApi.Model;
using BackendApi.Model.Context;

namespace BackendApi.Repositories.Implementations
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly BdContext _context;

        public UserRepositoryImpl(BdContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }
    }
}
