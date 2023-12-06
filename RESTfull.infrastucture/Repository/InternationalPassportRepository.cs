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
    internal class InternationalPassportRepository : IInternationalPassportRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public InternationalPassportRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }

        public async Task<DocInternationalPassport> Create(DocInternationalPassport entity)
        {
            _context.InternationalPassports.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Guid id)
        {
            DocInternationalPassport passport = await _context.InternationalPassports.FindAsync(id);
            _context.Remove(passport);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DocInternationalPassport>> GetAll()
        {
            return await _context.InternationalPassports.Include(p => p.Individual)
                .OrderBy(p => p.DocumentSeries).ToListAsync();
        }

        public async Task<DocInternationalPassport> GetByID(Guid id)
        {
            return await _context.InternationalPassports.Where(p => p.ID == id)
            .OrderBy(p => p.DocumentSeries)
            .Include(p => p.Individual)
            .FirstOrDefaultAsync();
        }

        public async Task<DocInternationalPassport> GetByNumber(string number)
        {
            return await _context.InternationalPassports
              .Where(p => p.DocumentSeries == number)
              .Include(p => p.Individual)
               .FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(DocInternationalPassport value)
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
    }
}
