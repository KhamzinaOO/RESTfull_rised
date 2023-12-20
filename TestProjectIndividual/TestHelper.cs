using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RESTful.Domain;
using RESTful.Infrastructure;
using RESTful.Infrastructure.Repository;

namespace TestProjectIndividual
{
    public class TestHelper
    {
        private readonly Context _context;
        public TestHelper()
        {
            //Используем базу обычную базу данных, не в памяти
            //Имя тестовой базы данных должно отличатсья от базы данных проекта
            var contextOptions = new DbContextOptionsBuilder<Context>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestesIndividual")
                .Options;

            _context = new Context(contextOptions);


            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            //Значение идентификатора явно не задаем. Используем для идентификации уникальное в рамках теста имя
            var individual1 = new Individual
            {
                ID = Guid.NewGuid()
            };

            individual1.AddInfo(new Info { ID = Guid.NewGuid(),
                Name = "Vlad",
                Gender = "male", 
                DateOfBirth= new DateTime(2000, 3, 11),
                Email = "vlad@gmail.com",
                Phone = "8-910-134-54-65" }
            );

            individual1.AddJob(new Job
            {
                ID = Guid.NewGuid(),
               
                Position = "web developer",
                Organization = "mail.ru",
                DateStart = new DateTime(2023, 1, 12),
                DateEnd = null
            }
            );


            

            _context.Individuals.Add(individual1);
            _context.SaveChanges();
            //Запрещаем отслеживание (разрываем связи с БД)
            _context.ChangeTracker.Clear();
        }

        public IndividualRepository IndividualRepository
        {
            get
            {
                return new IndividualRepository(_context);
            }
        }
    }
}
