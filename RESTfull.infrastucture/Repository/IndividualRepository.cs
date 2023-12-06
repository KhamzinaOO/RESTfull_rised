using Microsoft.EntityFrameworkCore;
using RESRTfull.Domain;
using RESTfull.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RESTfull.Infrastructure.Repository
{
    public class IndividualRepository : IBaseRepository<Individual>
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public IndividualRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void ChangeTrackerClear()
        {
            _context.ChangeTracker.Clear();
        }

        public async Task<Individual> Create(Individual entity)
        {
            _context.Individuals.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(Guid id)
        {
            Individual person = await _context.Individuals.FindAsync(id);
            _context.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Individual>> GetAll()
        {
            return await _context.Individuals
                .Include(p => p.Information)
                .Include(p => p.PersonAddress)
                .Include(p => p.Jobs)
                .Include(p => p.Educations)
                .Include(p => p.Documents)
                .Include(p => p.RussianPassport)
                .Include(p => p.InternationalPassport)
                .Include(p => p.ForeignPassport)
                .OrderBy(p => p.ID).ToListAsync();
        }

        public async Task<Individual> GetByID(Guid id)
        {
            return await _context.Individuals.Where(p => p.ID == id)
                .OrderBy(p => p.ID)
                .Include(p => p.Information)
                .Include(p => p.PersonAddress)
                .Include(p => p.Jobs)
                .Include(p => p.Educations)
                .Include(p => p.Documents)
                .Include(p => p.RussianPassport)
                .Include(p => p.InternationalPassport)
                .Include(p => p.ForeignPassport)
                .FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task Update(Individual individual)
        {
            var existPerson = GetByID(individual.ID).Result;
            if (existPerson != null)
            {
                _context.Entry(existPerson).CurrentValues.SetValues(individual);

                foreach (var job in individual.Jobs)
                {
                    var existJob = existPerson.Jobs.FirstOrDefault(pn => pn.ID == job.ID);
                    if (existJob == null)
                    {
                        existPerson.Jobs.Add(job);
                    }
                    else
                    {
                        _context.Entry(existJob).CurrentValues.SetValues(job);
                    }
                }
                foreach (var existJob in existPerson.Jobs)
                {
                    if (!individual.Jobs.Any(pn => pn.ID == existJob.ID))
                    {
                        _context.Remove(existJob);
                    }
                }


                foreach (var education in individual.Educations)
                {
                    var existEducation = existPerson.Educations.FirstOrDefault(pn => pn.ID == education.ID);
                    if (existEducation == null)
                    {
                        existPerson.Educations.Add(education);
                    }
                    else
                    {
                        _context.Entry(existEducation).CurrentValues.SetValues(education);
                    }
                }
                foreach (var existEducation in existPerson.Educations)
                {
                    if (!individual.Educations.Any(pn => pn.ID == existEducation.ID))
                    {
                        _context.Remove(existEducation);
                    }
                }


                foreach (var document in individual.Documents)
                {
                    var existDocument = existPerson.Documents.FirstOrDefault(pn => pn.ID == document.ID);
                    if (existDocument == null)
                    {
                        existPerson.Documents.Add(document);
                    }
                    else
                    {
                        _context.Entry(existDocument).CurrentValues.SetValues(document);
                    }
                }
                foreach (var existDocument in existPerson.Documents)
                {
                    if (!individual.Documents.Any(pn => pn.ID == existDocument.ID))
                    {
                        _context.Remove(existDocument);
                    }
                }


                if (existPerson.Information.ID != individual.Information.ID)
                {
                    existPerson.Information =individual.Information;
                }
                else
                {
                    _context.Entry(existPerson.Information).CurrentValues.SetValues(individual.Information);
                }

                if (individual.Information.ID != existPerson.Information.ID)
                {
                    _context.Remove(existPerson.Information);
                }


                if (existPerson.PersonAddress.ID != individual.PersonAddress.ID)
                {
                    existPerson.PersonAddress = individual.PersonAddress;
                }
                else
                {
                    _context.Entry(existPerson.PersonAddress).CurrentValues.SetValues(individual.PersonAddress);
                }

                if (individual.PersonAddress.ID != existPerson.PersonAddress.ID)
                {
                    _context.Remove(existPerson.PersonAddress);
                }


                if (existPerson.ForeignPassport.ID != individual.ForeignPassport.ID)
                {
                    existPerson.ForeignPassport = individual.ForeignPassport;
                }
                else
                {
                    _context.Entry(existPerson.ForeignPassport).CurrentValues.SetValues(individual.ForeignPassport);
                }

                if (individual.ForeignPassport.ID != existPerson.ForeignPassport.ID)
                {
                    _context.Remove(existPerson.ForeignPassport);
                }


                if (existPerson.RussianPassport.ID != individual.RussianPassport.ID)
                {
                    existPerson.RussianPassport = individual.RussianPassport;
                }
                else
                {
                    _context.Entry(existPerson.RussianPassport).CurrentValues.SetValues(individual.RussianPassport);
                }

                if (individual.RussianPassport.ID != existPerson.RussianPassport.ID)
                {
                    _context.Remove(existPerson.RussianPassport);
                }


                if (existPerson.InternationalPassport.ID != individual.InternationalPassport.ID)
                {
                    existPerson.InternationalPassport = individual.InternationalPassport;
                }
                else
                {
                    _context.Entry(existPerson.InternationalPassport).CurrentValues.SetValues(individual.InternationalPassport);
                }

                if (individual.InternationalPassport.ID != existPerson.InternationalPassport.ID)
                {
                    _context.Remove(existPerson.InternationalPassport);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
