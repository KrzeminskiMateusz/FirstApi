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

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(string email)
        {
           return await Task.FromResult(_users.SingleOrDefault(x => x.Email == email.ToLower()));
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _users.Remove(user);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
        }
    }
}
