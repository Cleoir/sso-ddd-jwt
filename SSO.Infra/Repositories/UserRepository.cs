using SSO.Domain.Entity;
using SSO.Domain.Interfaces.Repositories;
using SSO.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SSO.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected SsoDataContext db = new SsoDataContext();

        public bool ExistUser(string username, string password)
        {
            return db.Users.Any(u => u.Name == username && u.Password == password);
        }

        public IList<User> GetAll()
        {            
            return db.Users.ToList();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                GC.SuppressFinalize(this);
            }
        }
    }
}
