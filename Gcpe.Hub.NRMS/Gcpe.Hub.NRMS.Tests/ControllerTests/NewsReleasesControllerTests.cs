using AutoMapper;
using Gcpe.Hub.NRMS.Controllers;
using Gcpe.Hub.NRMS.Data;
using Gcpe.Hub.NRMS.Helpers;
using Gcpe.Hub.NRMS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace Gcpe.Hub.NRMS.Tests.ControllerTests
{
    [TestClass]
    public class NewsReleasesControllerTests
    {
        [TestMethod]
        public void GetNewsReleaseByKey_ReturnsOkObjectResult()
        {
            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(c => c.Get("2018PREM1234-123456")).Returns(TestData.TestNewsRelease);

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetReleaseByKey("2018PREM1234-123456")).Returns(TestData.TestNewsRelease);

            var mockLogger = new Mock<ILogger<NewsReleasesController>>();
            var mockMapper = new Mock<IMapper>();

            var controller = new NewsReleasesController(mockRepository.Object, mockLogger.Object, mockMapper.Object);

            var result = controller.GetById("2018DOESNOTEXIST-000000");
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));


            var httpResult = controller.GetById("2018PREM1234-123456");
            Assert.IsInstanceOfType(httpResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAllNewsReleases_ReturnsOkObjectResult()
        {
            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(c => c.GetAll()).Returns(TestData.TestNewsReleases);

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetAllReleases()).Returns(TestData.TestNewsReleases);

            var mockLogger = new Mock<ILogger<NewsReleasesController>>();
            var mockMapper = new Mock<IMapper>();

            var controller = new NewsReleasesController(mockRepository.Object, mockLogger.Object, mockMapper.Object);

            var paginationParams = new NewsReleaseParams();
            var results = controller.GetResultsPage(paginationParams);

            Assert.AreEqual(paginationParams.PageSize, results.Count());
        }

        [TestMethod]
        public void CreateNewsRelease_ReturnsOkObjectResult()
        {
            var mockContext = new Mock<IDataContext>();
            var mockRepository = new Mock<IRepository>();
            var mockLogger = new Mock<ILogger<NewsReleasesController>>();
            var mockMapper = new Mock<IMapper>();

            var controller = new NewsReleasesController(mockRepository.Object, mockLogger.Object, mockMapper.Object);

            var releaseToCreate = new NewsReleaseViewModel
            {
                Key = TestData.TestNewsRelease.Key,
                PublishDateTime = DateTime.Now
            };

            var httpResult = controller.Post(releaseToCreate);
            Assert.IsInstanceOfType(httpResult, typeof(StatusCodeResult));
        }

        [TestMethod]
        public void UpdateNewsRelease_ReturnsOkObjectResult()
        {
            var release = TestData.TestNewsRelease;

            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(c => c.Get(release.Key)).Returns(release);

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetReleaseByKey(release.Key)).Returns(release);

            var mockLogger = new Mock<ILogger<NewsReleasesController>>();
            var mockMapper = new Mock<IMapper>();

            var controller = new NewsReleasesController(mockRepository.Object, mockLogger.Object, mockMapper.Object);

            var result = controller.GetById("2018DOESNOTEXIST-000000");
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

            var httpResult = controller.Put(release.Key, release);
            Assert.IsInstanceOfType(httpResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Delete_ReturnsOkObjectResult()
        {
            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(c => c.Get("2018PREM1234-123456")).Returns(TestData.TestNewsRelease);

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetReleaseByKey("2018PREM1234-123456")).Returns(TestData.TestNewsRelease);

            var mockLogger = new Mock<ILogger<NewsReleasesController>>();
            var mockMapper = new Mock<IMapper>();

            var controller = new NewsReleasesController(mockRepository.Object, mockLogger.Object, mockMapper.Object);

            var result = controller.Delete("2018DOESNOTEXIST-000000");
            Assert.IsInstanceOfType(result, typeof(NotFoundObjectResult));


            var httpResult = controller.GetById("2018PREM1234-123456");
            Assert.IsInstanceOfType(httpResult, typeof(OkObjectResult));
        }
    }
}
