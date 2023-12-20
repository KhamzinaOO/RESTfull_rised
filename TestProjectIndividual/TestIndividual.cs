using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RESTful.Domain;
using RESTful.Infrastructure;
using RESTful.Infrastructure.Repository;

namespace TestProjectIndividual
{
    public class TestIndividual
    {
        [Fact]

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

            individualRepository.ChangeTrackerClear();

            Assert.True(individualRepository.GetAll().Result.Count == 2);
            Assert.Equal(testId, individualRepository.GetByID(person.ID).Result.ID);
            Assert.Equal("Vlad", individualRepository.GetByName("Vlad").Result.First().Information.Name);
        }

        [Fact]
        public void TestUpdateAdd()
        {
            var testHelper = new TestHelper();
            var individualRepository = testHelper.IndividualRepository;
            var person = individualRepository.GetByName("Vlad").Result.First();

            individualRepository.ChangeTrackerClear();

            person.Information.Name = "Ivanov Ivan";

            individualRepository.Update(person).Wait();

            Assert.Equal("Ivanov Ivan", individualRepository.GetByName("Ivanov Ivan").Result.First().Information.Name);
        }

        [Fact]
        public void TestUpdateDelete()
        {
            var testHelper = new TestHelper();
            var personRepository = testHelper.IndividualRepository;
            var person = personRepository.GetByName("Vlad").Result.First();

            personRepository.ChangeTrackerClear();

            personRepository.Delete(person.ID).Wait();

            personRepository.Update(person).Wait();

            Assert.Null(personRepository.GetByID(person.ID).Result);
        }
    }
}
