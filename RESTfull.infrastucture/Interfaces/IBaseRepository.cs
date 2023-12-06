using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfull.Infrastructure.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> Create (T entity);

        Task<T> GetByID (Guid id);

        Task<List<T>> GetAll();

        Task Update (T entity);

        Task Delete (Guid id);

        Task Save();

        public void ChangeTrackerClear();

    }
}
