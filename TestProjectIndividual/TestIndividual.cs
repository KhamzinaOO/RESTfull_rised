using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RESRTfull.Domain;
using RESTfull.Infrastructure;
using RESTfull.Infrastructure.Repository;

namespace TestProjectIndividual
{
    public class TestIndividual
    {
        [Fact]
        //Тест, проверяющий, что база данных создалась
        public void VoidTest()
        {
            var testHelper = new TestHelper();
            var individualRepository = testHelper.IndividualRepository;

            Assert.Equal(1, 1);
        }

        [Fact]
        public async void TestCreate()
        {
            var testHelper = new TestHelper();
            var individualRepository = testHelper.IndividualRepository;
            var person = new Individual { ID = Guid.NewGuid() };
            Guid testId = person.ID;
            var perons = await individualRepository.Create(person);
            //Запрещаем отслеживание сущностей (разрываем связи с БД)
            individualRepository.ChangeTrackerClear();

            Assert.True(individualRepository.GetAll().Result.Count == 2);
            Assert.Equal(testId, individualRepository.GetByID(person.ID).Result.ID);
            Assert.Equal(Guid.NewGuid(), individualRepository.GetByID(person.ID).Result.ID);
        }
    }
}
