using RESRTfull.Domain;

namespace TestProjectIndividual
{
        public class TestInfoRepository
        {
            [Fact]
            //����, �����������, ��� ���� ������ ���������
            public void VoidTest()
            {
                var testHelper = new TestHelper();
                var infoRepository = testHelper.InfoRepository;

                Assert.Equal(1, 1);
            }

            [Fact]
            public async void TestCreate()
            {
                var testHelper = new TestHelper();
                var infoRepository = testHelper.InfoRepository;
                var person = new Info { Name = "Ivan" };
                person.ID = Guid.NewGuid();

                var perons = await infoRepository.Create(person);
                //��������� ������������ ��������� (��������� ����� � ��)
                infoRepository.ChangeTrackerClear();

                Assert.True(infoRepository.GetAll().Result.Count == 2);
                Assert.Equal("Ivan", infoRepository.GetByID(person.ID).Result.Name);
                Assert.Equal("Nic", infoRepository.GetByName("Nic").Result.Name);
                Assert.Equal("Ivan", infoRepository.GetByName("Ivan").Result.Name);
            }
        C:\Users\Olga\source\repos\RESTfull\TestProjectIndividual\TestInfoRepository.cs
            //[Fact]
            //public void TestUpdateAdd()
            //{
            //    var testHelper = new TestHelper();
            //    var infoRepository = testHelper.InfoRepository;
            //    var person = infoRepository.GetByNameAsync("Nic").Result;
            //    //��������� ������������ ��������� (��������� ����� � ��)
            //    infoRepository.ChangeTrackerClear();
            //    person.Name = "Ivanov Ivan";
            //    var phoneNumber = new Phone { PhoneType = "Mobile", PhoneNumber = "333-333" };
            //    person.AddPhone(phoneNumber);

            //    infoRepository.UpdateAsync(person).Wait();

            //    Assert.Equal("Ivanov Ivan", infoRepository.GetByNameAsync("Ivanov Ivan").Result.Name);
            //    Assert.Equal(3, infoRepository.GetByNameAsync("Ivanov Ivan").Result.PhoneCount);
            //}

            //[Fact]
            //public void TestUpdateDelete()
            //{
            //    var testHelper = new TestHelper();
            //    var infoRepository = testHelper.InfoRepository;
            //    var info = infoRepository.GetByName("Nic").Result;
            //    //��������� ������������ ��������� (��������� ����� � ��)
            //    infoRepository.ChangeTrackerClear();

            //    //infoRepository.Update(info).Wait();

            //    //Assert.Equal(1, infoRepository.GetByName("Nic").Result.Email);
            //}
        }
    }