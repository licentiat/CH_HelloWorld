using Moq;
using Nh.Data;
using Entities = Nh.Data.Entities;
using Nh.Services.Messages;
using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nh.Services.MapperConfig;

namespace Services.Tests
{
    public class MessagesProviderTests
    {
        public MessagesProviderTests()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(new[] { typeof(MessagesMapProfile) }));
        }

        [Fact]
        public void WhenParameterIsNull_Update_ShouldThrowError()
        {
            //Arrange
            var mockMessageRepository = GetMessageProvider();
            //Act
            var sut = new MessagesProvider(mockMessageRepository.Object);
            //Assert
            Assert.Throws<ArgumentNullException>(() => sut.Update(null));

        }

        [Fact]
        public void GetAll_ShouldReturnData()
        {
            //Arrange
            var mockMessageRepository = new Mock<IRepository<Entities.Message>>();
            var msg = new Entities.Message { Id = 1, Text = "Hello world!" };
            mockMessageRepository.Setup(m => m.GetAll()).Returns(new List<Entities.Message>{ msg });
            //Act
            var sut = new MessagesProvider(mockMessageRepository.Object);
            var result = sut.GetAll();
            //Assert
            Assert.True(result.Any());

        }
        
        private static Mock<IRepository<Entities.Message>> GetMessageProvider()
        {
            var mockMessageRepository = new Mock<IRepository<Entities.Message>>();
            var msg = new Entities.Message { Id = 1, Text = "Hello world!" };
            mockMessageRepository.Setup(m => m.GetAll()).Returns(new List<Entities.Message> { msg });
            return mockMessageRepository;
        }
    }
}
