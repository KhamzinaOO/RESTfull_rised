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
    internal class ForeignPassportRepository : IForeignPassportRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public ForeignPassportRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }

        public async Task<DocForeignPassport> Create(DocForeignPassport entity)
        {
            _context.ForeignPassports.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Guid id)
        {
            DocForeignPassport passport = await _context.ForeignPassports.FindAsync(id);
            _context.Remove(passport);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DocForeignPassport>> GetAll()
        {
            return await _context.ForeignPassports.Include(p => p.Individual)
                .OrderBy(p => p.DocumentCountry).ToListAsync();
        }

        public async Task<DocForeignPassport> GetByID(Guid id)
        {
            return await _context.ForeignPassports.Where(p => p.ID == id)
            .OrderBy(p => p.DocumentCountry)
            .Include(p => p.Individual)
            .FirstOrDefaultAsync();
        }

        public async Task<DocForeignPassport> GetByNumber(string number)
        {
            return await _context.ForeignPassports
              .Where(p => p.DocumentSeries == number)
              .Include(p => p.Individual)
               .FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(DocForeignPassport value)
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
