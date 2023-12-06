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
    public class JobRepository : IjobRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public JobRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }

        public async Task<Job> Create(Job entity)
        {
            _context.Jobs.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Guid id)
        {
            Job job = await _context.Jobs.FindAsync(id);
            _context.Remove(job);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Job>> GetAll()
        {
            return await _context.Jobs.Include(p => p.Individual)
                .OrderBy(p => p.Organization).ToListAsync();
        }

        public async Task<Job> GetByID(Guid id)
        {
            return await _context.Jobs.Where(p => p.ID == id)
            .OrderBy(p => p.Organization)
            .Include(p => p.Individual)
            .FirstOrDefaultAsync();
        }

        public async Task<Job> GetByOrganizationName(string name)
        {
            return await _context.Jobs
            .Where(p => p.Organization == name)
            .Include(p => p.Individual)
            .FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Job value)
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
