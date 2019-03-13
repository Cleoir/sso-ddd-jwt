using SSO.Domain.Entity;
using System.Collections.Generic;

namespace SSO.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        bool ExistUser(string username, string password);
        IList<User> GetAll();
        void Dispose(bool disposing);
    }
}
