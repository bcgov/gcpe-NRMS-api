using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using FluentAssertions;
using Newtonsoft.Json;
using Moq;
using Gcpe.Hub.NRMS;
using Gcpe.Hub.NRMS.Data;
using Gcpe.Hub.NRMS.Models;

namespace Gcpe.Hub.NRMS.IntegrationTests
{
    public class NewsReleasesPageShould : BaseWebApiTest
    {
        private int expectedEntitiesPerPage = 5;
        private NewsRelease expectedNewsRelease = TestData.CreateNewsRelease();

        public NewsReleasesPageShould(WebApplicationFactory<Startup> factory) : base(factory)
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var dataStore = CreateDataStore();

            // override default HttpClient, injecting mock services
            Client = _factory.WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(services =>
                    {
                        services.AddSingleton<IRepository>(dataStore.Object);
                    });
                })
                .CreateClient();
        }

        private Mock<IRepository> CreateDataStore()
        {
            var dataStore = new Mock<IRepository>();
            dataStore.Setup(r => r.GetAllReleases()).Returns(TestData.CreateNewsReleaseCollection(expectedEntitiesPerPage));
            dataStore.Setup(r => r.GetReleaseByKey(It.IsIn("0"))).Returns(expectedNewsRelease);
            dataStore.Setup(r => r.GetReleaseByKey(It.IsNotIn("0"))).Returns(() => null);
            return dataStore;
        }

        [Fact]
        public async Task ReturnAListOfNewsReleases()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var response = await Client.GetAsync("/api/newsreleases");
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var deserializedBody = JsonConvert.DeserializeObject<ViewModels.NewsReleaseViewModel[]>(body);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            deserializedBody.Should().HaveCount(expectedEntitiesPerPage);
        }

        [Fact]
        public async Task ReturnNewsReleaseGivenValueOf0()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var response = await Client.GetAsync("/api/newsreleases/0");
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var deserializedBody = JsonConvert.DeserializeObject<ViewModels.NewsReleaseViewModel>(body);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            deserializedBody.Key.Should().NotBeNullOrEmpty();  // `key` property is REQUIRED
        }

        [Fact]
        public async Task RespondWith404GivenValueOf1()
        {
            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var response = await Client.GetAsync("/api/newsreleases/1");

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);  // 404 not found
        }
    }
}
