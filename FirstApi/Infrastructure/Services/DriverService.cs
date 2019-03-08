using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApi.Core.Repositories;
using FirstApi.Infrastructure.DTO;

namespace FirstApi.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public DriverDTO Get(Guid userId)
        {
            var driver = _driverRepository.Get(userId);

            return new DriverDTO
            {

            };
        }
    }
}
