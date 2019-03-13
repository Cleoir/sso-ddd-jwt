using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSO.Domain.Interfaces.Services
{
    public interface IUserService
    {
        bool CheckUser(string username, string password);
    }
}
