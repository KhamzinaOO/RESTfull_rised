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
    public class AddressRepository : IAddressRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public AddressRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }

        public async Task<Address> Create(Address entity)
        {
            _context.Addresses.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Guid id)
        {
            Address address = await _context.Addresses.FindAsync(id);
            _context.Remove(address);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Address>> GetAll()
        {
            return await _context.Addresses
                .Include(p => p.Individual)
                .OrderBy(p => p.ID).ToListAsync();
        }

        public async Task<Address> GetByID(Guid id)
        {
            return await _context.Addresses.Where(p => p.ID == id)
                .OrderBy(p => p.Individual)
                .FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Address value)
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
