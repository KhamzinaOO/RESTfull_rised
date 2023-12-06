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
    internal class EducationRepository : IEducationRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public EducationRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }

        public async Task<Education> GetByType(string type)
        {
            return await _context.Educations
                .Where(p => p.Type == type)
                .Include(p => p.Individual)
                .FirstOrDefaultAsync();
        }

        public async Task<Education> Create(Education entity)
        {
            _context.Educations.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Education> GetByID(Guid id)
        {
            return await _context.Educations.Where(p => p.ID == id)
                .OrderBy(p => p.Type)
                .Include(p => p.Individual)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Education>> GetAll()
        {
            return await _context.Educations.Include(p => p.Individual)
                .OrderBy(p => p.Type).ToListAsync();
        }

        public async Task Update(Education value)
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

        public async Task Delete(Guid id)
        {
            Education education = await _context.Educations.FindAsync(id);
            _context.Remove(education);
            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
