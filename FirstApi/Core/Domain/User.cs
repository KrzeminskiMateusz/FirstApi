using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string UserName { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime CreatedAT { get; protected set; }

        protected User()
        {

        }
        public User(string email, string password, string salt, string username)
        {
            Id = Guid.NewGuid();
            Email = email.ToLower();
            Password = password;
            Salt = salt;
            UserName = username;
            CreatedAT = DateTime.UtcNow;
        }
    }
}
