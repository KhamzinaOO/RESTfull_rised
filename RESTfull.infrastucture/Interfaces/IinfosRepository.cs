using RESRTfull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfull.Infrastructure.Interfaces
{
    public interface IinfosRepository : IBaseRepository<Info>

    {
        Task<Info> GetByName(string name);

    }
}
