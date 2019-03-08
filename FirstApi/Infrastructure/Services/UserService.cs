using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper; 
        }

        public async Task<UserDTO> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

            return _mapper.Map<User, UserDTO>(user);
            
        }



        public async Task RegisterAsync(string email, string username, string password)
        {
            var user = await _userRepository.GetAsync(email);

            if (user != null)
            {
                throw new Exception($"User with email: {email} alredy exist");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, password, salt, username);
            await _userRepository.AddAsync(user);
        }
    }
}