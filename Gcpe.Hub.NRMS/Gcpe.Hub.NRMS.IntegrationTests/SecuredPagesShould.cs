using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Gcpe.Hub.NRMS;

namespace Gcpe.Hub.NRMS.IntegrationTests
{
    public class SecuredPagesShould : BaseWebApiTest
    {
        public SecuredPagesShould(WebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory(Skip = "Not available yet...")]
        [InlineData("/SecurePage")]
        public async Task RequireAnAuthenticatedUser(string url)
        {
            //-----------------------------------------------------------------------------------------------------------
            // Arrange
            //-----------------------------------------------------------------------------------------------------------
            var client = _factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });

            //-----------------------------------------------------------------------------------------------------------
            // Act
            //-----------------------------------------------------------------------------------------------------------
            var response = await client.GetAsync(url);

            //-----------------------------------------------------------------------------------------------------------
            // Assert
            //-----------------------------------------------------------------------------------------------------------
            response.StatusCode.Should().Be(HttpStatusCode.Redirect);
            response.Headers.Location.OriginalString.Should().StartWith("http://localhost/Identity/Account/Login");
        }
    }
}
