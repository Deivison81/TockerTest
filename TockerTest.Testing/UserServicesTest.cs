using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TockerTest.API.Contract.Persitence;
using TockerTest.API.Contract.Services;
using TockerTest.API.Models;
using TockerTest.API.Models.Vmodel;
using TockerTest.API.Services;
using Xunit;

namespace TockerTest.Testing
{
    public class UserServicesTest
    {

        private readonly Mock<IGenericRepository<User>> _mockRepo; 
        private readonly UserServices _userServices;

        public UserServicesTest()
        {
            _mockRepo = new Mock<IGenericRepository<User>>();
            _userServices = new UserServices(_mockRepo.Object);
        }

        [Fact]
        public async void CreateServiceAsyncTest()
        {
            //Arrange
            var user = new VMUser
            {
                UserName = "Deivison Jimenez",
                Phone= "+5804141104299"
            };

            var expectedUser = new User 
            { 
                Id = Guid.NewGuid(), 
                Phone = user.Phone, 
                UserName = user.UserName };
            
            
            _mockRepo.Setup(repo => repo.CreateAsync(It.IsAny<User>())).ReturnsAsync(expectedUser);
            
            // Act

            var result = await _userServices.CreateServiceAsync(user);



            // Assert

            Assert.NotNull(result); 
            Assert.Equal(expectedUser.Phone, result.Phone); 
            Assert.Equal(expectedUser.UserName, result.UserName);

        }
    }
}
