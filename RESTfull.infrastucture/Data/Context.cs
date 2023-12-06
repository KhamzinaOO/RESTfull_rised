using Microsoft.EntityFrameworkCore;
using RESRTfull.Domain;
using System.Runtime.InteropServices;

namespace RESTfull.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Individual> Individuals { get; set; } = null!;
        public DbSet<Info> Infos { get; set; } = null!;
        public DbSet<Document> Documents { get; set; } = null!;
        public DbSet<DocRussianPassport> RussianPassports { get; set; } = null!;
        public DbSet<DocForeignPassport> ForeignPassports { get; set; } = null!;
        public DbSet <DocInternationalPassport> InternationalPassports { get; set; } = null!;
        public DbSet<Education> Educations { get; set; } = null!;
        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public Context(DbContextOptions<Context> options) : base(options) {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            
        }

        
    }
}