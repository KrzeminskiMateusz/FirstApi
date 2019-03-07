using FirstApi.Core.Domain;
using FirstApi.Core.Repositories;
using FirstApi.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDTO Get(string email)
        {
            var user = _userRepository.Get(email);

            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName,
                UserName = user.UserName
            };


        }



        public void Register(string email, string username, string password)
        {
            var user = _userRepository.Get(email);

            if (user != null)
            {
                throw new Exception($"User with email: {email} alredy exist");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, password, salt, username);
            _userRepository.Add(user);
        }
    }
}