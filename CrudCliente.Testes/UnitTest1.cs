using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CrudCliente.Api;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class UnitTest1
    {
        private readonly HttpClient _client;
        public UnitTest1()
        {
            var appFactory = new WebApplicationFactory<Startup>(); 
            _client = appFactory.CreateClient();
        }

        [Test]
        public async Task Test1()
        {
           var response = await _client.GetAsync("http://localhost:5000/api/Cliente/v1/obtertodos");
        }
    }
}