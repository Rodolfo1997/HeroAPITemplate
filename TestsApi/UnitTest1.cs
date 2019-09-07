using Api;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace TestsApi
{
    public class UnitTest1
    {


        [Fact]
        public async Task Test1()
        {
            var httpClient = new HttpClient();
            var a = await httpClient.GetAsync("http://idpmon-api.azurewebsites.net/api/health"); //Not a real url..
        }
    }

    public class TestContext
    {
        public HttpClient Client { get; set; }
        private TestServer _server;

        public TestContext()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            Client = _server.CreateClient();

        }


    }
}
