using FirstApi.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApi.Infrastructure.Services
{
    public interface IDriverService
    {
        DriverDTO Get(Guid useId);
    }
}
