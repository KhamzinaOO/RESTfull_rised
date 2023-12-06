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
    public class DocumentRepository : IDocumentRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public DocumentRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }

        public async Task<Document> GetByName(string name)
        {
            return await _context.Documents
                .Where(p => p.DocumentName == name)
                .Include(p => p.Individual)
                .FirstOrDefaultAsync();
        }

        public async Task<Document> Create(Document entity)
        {
            _context.Documents.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Document> GetByID(Guid id)
        {
            return await _context.Documents.Where(p => p.ID == id)
                .OrderBy(p => p.DocumentName)
                .Include(p => p.Individual)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Document>> GetAll()
        {
            return await _context.Documents.Include(p => p.Individual)
                .OrderBy(p => p.DocumentName).ToListAsync();
        }

        public async Task Update(Document value)
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
            Document document = await _context.Documents.FindAsync(id);
            _context.Remove(document);
            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }

}
