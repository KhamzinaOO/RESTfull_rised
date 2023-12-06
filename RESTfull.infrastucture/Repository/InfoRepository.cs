using Microsoft.EntityFrameworkCore;
using RESRTfull.Domain;
using RESTfull.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfull.Infrastructure.Repository
{
    public class InfoRepository : IinfosRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public InfoRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Info> Create(Info entity)
        {
            _context.Infos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Info>> GetAll()
        {
            return await _context.Infos.Include(p => p.Individual).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Info> GetByName(string name)
        {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return await _context.Infos
                .Where(p => p.Name == name)
                .Include(p => p.Individual)
                .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public async Task<Info> GetByID(Guid id)
        {
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
            return await _context.Infos.Where(p => p.ID == id)
                .OrderBy(p => p.Name)
                .Include(p => p.Individual)
                .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
        }

        public async Task Delete(Guid id)
        {
            Info info = await _context.Infos.FindAsync(id);
            _context.Remove(info);
            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
        public async Task Update(Info value)
        {
            var existInfo = GetByID(value.ID).Result;
            if (existInfo != null)
            {
                _context.Entry(existInfo).CurrentValues.SetValues(value);


                if (existInfo.Individual.ID != value.Individual.ID)
                {
                    existInfo.Individual = value.Individual;
                }
                else
                {
                    _context.Entry(existInfo.Individual).CurrentValues.SetValues(value.Individual);
                }

                if (value.Individual.ID != existInfo.Individual.ID)
                {
                    _context.Remove(existInfo.Individual);
                }
            }

            await _context.SaveChangesAsync();
        }

        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }

    }
}
