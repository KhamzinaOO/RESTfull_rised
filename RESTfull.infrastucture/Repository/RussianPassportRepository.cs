﻿using Microsoft.EntityFrameworkCore;
using RESRTfull.Domain;
using RESTfull.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTfull.Infrastructure.Repository
{
    public class RussianPassportRepository : IRussianPassportRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public RussianPassportRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }

        public async Task<DocRussianPassport> Create(DocRussianPassport entity)
        {
            _context.RussianPassports.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Guid id)
        {
            DocRussianPassport passport = await _context.RussianPassports.FindAsync(id);
            _context.Remove(passport);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DocRussianPassport>> GetAll()
        {
            return await _context.RussianPassports.Include(p => p.Individual)
                .OrderBy(p => p.DocumentSeries).ToListAsync();
        }

        public async Task<DocRussianPassport> GetByID(Guid id)
        {
            return await _context.RussianPassports.Where(p => p.ID == id)
            .OrderBy(p => p.DocumentSeries)
            .Include(p => p.Individual)
            .FirstOrDefaultAsync();
        }

        public async Task<DocRussianPassport> GetByNumber(string number)
        {
            return await _context.RussianPassports
               .Where(p => p.DocumentSeries == number)
                .Include(p => p.Individual)
                .FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(DocRussianPassport value)
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
