using FirstApi.Core.Domain;
using FirstApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Infrastructure.Repositories
{
    public class InMemoryUserRepository : IUserRepository
    {
        private ISet<User> _users = new HashSet<User>
        {
            new User("user1@email.pl", "secred", "salt", "user1"),
            new User("user2@email.pl", "secred", "salt", "user2"),
            new User("user3@email.pl", "secred", "salt", "user3")
        };

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(string email)
        {
           return _users.Single(x => x.Email == email.ToLower());
        }

        public User Get(Guid id)
        {
            return _users.Single(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public void Remove(Guid id)
        {
            var user = Get(id);
            _users.Remove(user);
        }

        public void Update(User user)
        {           
        }
    }
}
