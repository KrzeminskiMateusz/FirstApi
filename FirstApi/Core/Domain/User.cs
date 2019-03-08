using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstApi.Core.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string UserName { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime CreatedAT { get; protected set; }
        public DateTime UpdatedAT { get; protected set; }

        protected User()
        {

        }

        public User(string email, string password, string salt, string username)
        {
            Id = Guid.NewGuid();
            SetPassword(password);
            SetEmail(email);
            SetUserName(username);
            Salt = salt;           
            CreatedAT = DateTime.UtcNow;
        }

        public void SetUserName(string username)
        {
            if (!NameRegex.IsMatch(username))
            {
                throw new Exception("Username is invalid.");
            }

            UserName = username.ToLowerInvariant();
            UpdatedAT = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new Exception("Email can not be empty");
            }
            if (Email == email)
            {
                return;
            }

            Email = email;
            UpdatedAT = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Password can not be empty");
            }
            if (Password == password)
            {
                return;
            }
            if (password.Length < 4)
            {
                throw new Exception("Password must contain at least 4 characters");
            }
            if (password.Length > 100)
            {
                throw new Exception("Password can not be longer than 100 characters");
            }

            Password = password;
            UpdatedAT = DateTime.UtcNow;
        }
    }
}
