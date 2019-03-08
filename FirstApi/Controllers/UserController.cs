using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApi.Infrastructure.Commands;
using FirstApi.Infrastructure.DTO;
using FirstApi.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/values/5
        [HttpGet("{email}")]
        public async Task<UserDTO> Get(string email)
        {
            return await _userService.GetAsync(email);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]CreateUser request)
              =>  await _userService.RegisterAsync(request.Email, request.Password, request.UserName);
        
    }
}