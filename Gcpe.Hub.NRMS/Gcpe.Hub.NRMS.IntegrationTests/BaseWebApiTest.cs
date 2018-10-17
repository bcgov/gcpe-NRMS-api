using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Gcpe.Hub.NRMS;


namespace Gcpe.Hub.NRMS.IntegrationTests
{
    public abstract class BaseWebApiTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly WebApplicationFactory<Startup> _factory;

        public HttpClient Client { get; protected set; }

        public BaseWebApiTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            Client = _factory.CreateClient();
        }
    }
}
