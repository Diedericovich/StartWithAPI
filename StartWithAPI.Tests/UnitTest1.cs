using AutoMapper;
using Moq;
using NUnit.Framework;
using StartWithAPI.Helpers;
using StartWithAPI.Repositories;
using StartWithAPI.Services;
using System.Threading.Tasks;

namespace StartWithAPI.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task WhenGetMemberAsyncCalled_UserISMAppedToMEmberDTO()
        {
            // ARRANGE

            // Mock a dependency so we can pass it into the constructor
            var mockRepo = new Mock<IAppUserRepo>();


            AppUser fakeUser = new AppUser
            {
                City = "FakeTown",
                CountryOfOrigin = "FakeCountry",
                Gender = "Fake",
                Interests = "Fake it",
                Name = "Faker McGee",
                DateOfBirth = new System.DateTime(1990, 4, 20)
            };

            // Fake the return value of a Mock dependency
            mockRepo.Setup(x => x.GetUserAsync(It.IsAny<int>())).ReturnsAsync(fakeUser);

            //initialize AutoMapper for Unit Tests
            var config = new MapperConfiguration(x => x.AddProfile<AutoMapperProfile>());

            // Inject fake dependencies and AutoMapper
            var service = new AppUserService(mockRepo.Object, config.CreateMapper());

            // ACT

            var result = await service.GetMemberAsync(1);

            // ASSERT 

            Assert.NotNull(result);
            Assert.AreEqual("FakeTown", result.City);
        }

    }
}