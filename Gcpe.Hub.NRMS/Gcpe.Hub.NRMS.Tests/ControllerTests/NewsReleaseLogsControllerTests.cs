using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Gcpe.Hub.NRMS.Controllers;
using Gcpe.Hub.NRMS.Data;
using Gcpe.Hub.NRMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using Moq;
using FluentAssertions;

namespace Gcpe.Hub.NRMS.Tests.ControllerTests
{
    public class NewsReleaseLogsControllerTests
    {
        private readonly Models.NewsRelease _expectedModelReturn;
        private Mock<ILogger<NewsReleaseLogsController>> _logger;
        private Mock<IMapper> _mapper;

        public NewsReleaseLogsControllerTests()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            _expectedModelReturn = TestData.TestNewsRelease;
            _logger = new Mock<ILogger<NewsReleaseLogsController>>();
            _mapper = CreateMapper();
        }

        private Mock<IRepository> CreateDataStore()
        {
            var dataStore = new Mock<IRepository>();
            dataStore.Setup(r => r.GetReleaseByKey("0")).Returns(() => _expectedModelReturn);
            dataStore.Setup(r => r.GetReleaseByKey(It.IsNotIn("0"))).Returns(() => null);
            return dataStore;
        }

        // For unit testing, we are only interested in the following properties:
        // - Id
        // - ReleaseId
        // - Description
        // - DateTime
        private Mock<IMapper> CreateMapper()
        {
            Func<Models.NewsReleaseLog, NewsReleaseLogViewModel> toViewModel = (Models.NewsReleaseLog entity) => new NewsReleaseLogViewModel
            {
                Id = entity.Id,
                Description = entity.Description,
                DateTime = entity.DateTime,
                ReleaseId = entity.ReleaseId
            };

            Func<NewsReleaseLogViewModel, Models.NewsReleaseLog> fromViewModel = (NewsReleaseLogViewModel data) => new Models.NewsReleaseLog
            {
                Id = data.Id,
                Description = data.Description,
                DateTime = data.DateTime,
                ReleaseId = data.ReleaseId
            };

            var mapper = new Mock<IMapper>();
            mapper.Setup(m => m.Map<Models.NewsReleaseLog, NewsReleaseLogViewModel>(It.IsAny<Models.NewsReleaseLog>())).Returns(toViewModel);
            mapper.Setup(m => m.Map<NewsReleaseLogViewModel, Models.NewsReleaseLog>(It.IsAny<NewsReleaseLogViewModel>())).Returns(fromViewModel);
            // map collections as well...
            mapper.Setup(m => m.Map<IEnumerable<Models.NewsReleaseLog>, IEnumerable<NewsReleaseLogViewModel>>(It.IsAny<IEnumerable<Models.NewsReleaseLog>>()))
                .Returns((IEnumerable<Models.NewsReleaseLog> entities) => entities.Select(toViewModel));
            mapper.Setup(m => m.Map<IEnumerable<NewsReleaseLogViewModel>, IEnumerable<Models.NewsReleaseLog>>(It.IsAny<IEnumerable<NewsReleaseLogViewModel>>()))
                .Returns((IEnumerable<NewsReleaseLogViewModel> data) => data.Select(fromViewModel));

            return mapper;
        }

        [Fact]
        public void GetAll_ShouldReturnSuccess()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var expectedCount = _expectedModelReturn.Logs.Count;
            var expectedLogEntry = _expectedModelReturn.Logs.FirstOrDefault();
            var mockRepository = CreateDataStore();
            var controller = new NewsReleaseLogsController(mockRepository.Object, _logger.Object, _mapper.Object);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = controller.GetAll("0");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should().BeOfType(typeof(OkObjectResult), "because the read operation should go smoothly");
            var actual = ((result as OkObjectResult).Value as IEnumerable<NewsReleaseLogViewModel>);
            var actualLogEntry = actual.FirstOrDefault();

            actual.Count().Should().Be(expectedCount);
            actualLogEntry.Id.Should().Be(expectedLogEntry.Id);
            actualLogEntry.ReleaseId.Should().Be(expectedLogEntry.ReleaseId);
            actualLogEntry.Description.Should().Be(expectedLogEntry.Description);
        }

        [Fact]
        public void GetAll_ShouldReturnNotFound_WhenGivenInvalidReleaseId()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var mockRepository = CreateDataStore();
            var controller = new NewsReleaseLogsController(mockRepository.Object, _logger.Object, _mapper.Object);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = controller.GetAll("-1");  // does not exist...

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should().BeOfType(typeof(NotFoundResult), "because an invalid Id should not yield a result");
        }

        [Fact]
        public void Get_ShouldReturnSuccess()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var mockRepository = CreateDataStore();
            var controller = new NewsReleaseLogsController(mockRepository.Object, _logger.Object, _mapper.Object);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = controller.Get("0", 1);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should().BeOfType(typeof(OkObjectResult), "because the read operation should go smoothly");
        }

        [Theory]
        [InlineData("0", -1, "because an invalid LogId should not yield a result")]
        [InlineData("-1", 1, "because an invalid ReleaseId should not yield a result")]
        public void Get_ShouldReturnNotFound_WhenGivenInvalidParameters(string releaseId, int logId, string because = null)
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var mockRepository = CreateDataStore();
            var controller = new NewsReleaseLogsController(mockRepository.Object, _logger.Object, _mapper.Object);

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var result = controller.Get(releaseId, logId);  // does not exist...

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            result.Should().BeOfType(typeof(NotFoundResult), because);
        }
    }
}
