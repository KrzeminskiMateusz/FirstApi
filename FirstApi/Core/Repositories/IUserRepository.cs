using FirstApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Core.Repositories
{
    public interface IUserRepository
    {
        User Get(string email);
        User Get(Guid id);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Remove(Guid id);
        void Update(User user);
    }
}
