using BackendApi.Model;
using BackendApiUnitTest.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BackendApiUnitTest.Controllers
{
    public class LoginControllerUnitTest
    {
        private TestContext _testContext;

        public LoginControllerUnitTest()
        {
            _testContext = new TestContext(); 
        }

        [Fact]
        public async Task LoginControllerComSucesso()
        {
            var usuario = new User() {
                Login = "rcarriel",
                Password = "admin123"
            };

            var ususarioJson = JsonConvert.SerializeObject(usuario);
            var usuarioString = new StringContent(ususarioJson, Encoding.UTF8, "application/json");

            var response = await _testContext.Client.PostAsync("/api/login", usuarioString);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
