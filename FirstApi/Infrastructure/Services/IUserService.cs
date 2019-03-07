using FirstApi.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Infrastructure.Services
{
    public interface IUserService
    {
        UserDTO Get(string email);
        void Register(string email, string username, string password);
    }
}
