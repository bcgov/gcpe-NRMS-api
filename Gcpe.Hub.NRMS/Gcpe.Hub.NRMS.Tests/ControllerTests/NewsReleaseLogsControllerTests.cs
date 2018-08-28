using AutoMapper;
using Gcpe.Hub.NRMS.Controllers;
using Gcpe.Hub.NRMS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gcpe.Hub.NRMS.Tests.ControllerTests
{
    [TestClass]
    public class NewsReleaseLogsControllerTests
    {
        [TestMethod]
        public void GetNewsReleaseLogsByKey_ReturnsOkObjectResult()
        {
            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(c => c.Get("2018PREM1234-123456")).Returns(TestData.TestNewsRelease);

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetReleaseByKey("2018PREM1234-123456")).Returns(TestData.TestNewsRelease);

            var mockLogger = new Mock<ILogger<NewsReleaseLogsController>>();
            var mockMapper = new Mock<IMapper>();

            var controller = new NewsReleaseLogsController(mockRepository.Object, mockLogger.Object, mockMapper.Object);

            var result = controller.Get("2018DOESNOTEXIST-000000");
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

            var httpResult = controller.Get("2018PREM1234-123456");
            Assert.IsInstanceOfType(httpResult, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAllLogsByNewsRelease_ReturnsOkObjectResult()
        {
            var mockContext = new Mock<IDataContext>();
            mockContext.Setup(c => c.Get("2018PREM1234-123456")).Returns(TestData.TestNewsRelease);

            var mockRepository = new Mock<IRepository>();
            mockRepository.Setup(r => r.GetReleaseByKey("2018PREM1234-123456")).Returns(TestData.TestNewsRelease);

            var mockLogger = new Mock<ILogger<NewsReleaseLogsController>>();
            var mockMapper = new Mock<IMapper>();

            var controller = new NewsReleaseLogsController(mockRepository.Object, mockLogger.Object, mockMapper.Object);

            var result = controller.Get("2018DOESNOTEXIST-000000", 1);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));

            var httpResult = controller.Get("2018PREM1234-123456", 1);
            Assert.IsInstanceOfType(httpResult, typeof(OkObjectResult));
        }
    }
}
