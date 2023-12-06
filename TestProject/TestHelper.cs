using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RESRTfull.Domain;
using RESTfull.Infrastructure;
using RESTfull.Infrastructure.Interfaces;
using RESTfull.Infrastructure.Repository;

namespace TestProject
{
    public class TestHelper
    {
        private readonly Context _context;
        public TestHelper()
        {
            //Используем базу обычную базу данных, не в памяти
            //Имя тестовой базы данных должно отличатсья от базы данных проекта
            var contextOptions = new DbContextOptionsBuilder<Context>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test")
                .Options;

            _context = new Context(contextOptions);


            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            //Значение идентификатора явно не задаем. Используем для идентификации уникальное в рамках теста имя
            var info1 = new Info
            {
                Name = "Nic",
            };

            _context.Infos.Add(info1);
            _context.SaveChanges();
            //Запрещаем отслеживание (разрываем связи с БД)
            _context.ChangeTracker.Clear();
        }

        public InfoRepository InfoRepository
        {
            get
            {
                return new InfoRepository(_context);
            }
        }
    }
}
