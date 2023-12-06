using RESRTfull.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfull.Infrastructure.Interfaces
{
    public interface IInternationalPassportRepository : IBaseRepository<DocInternationalPassport>
    {
        Task<DocInternationalPassport> GetByNumber(string number);
    }
}
