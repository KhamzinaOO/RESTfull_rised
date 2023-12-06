using RESRTfull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfull.Infrastructure.Interfaces
{
    internal interface IEducationRepository: IBaseRepository<Education>
    {
        Task<Education> GetByType(string type);
    }
}
