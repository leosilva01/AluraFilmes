using System.Net.Http;
using Api.Data.Context;
using Application;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Api.Integration.Test
{
    public class BaseIntegration : IDisposable
    {
        public MyContext myContext { get; private set; }
        public HttpClient client { get; private set; }
        public IMapper mapper { get; set; }
        public string hostApi { get; set; }
        public HttpResponseMessage response { get; set; }

        public BaseIntegration()
        {
            hostApi = "http://localhost:5000";

            var builder = new WebHostBuilder()
                .UseEnvironment("Testing")
                .UseStartup<Startup>();

            builder.ConfigureServices(service => service.AddAutoMapper(typeof(Startup)));

            var server = new TestServer(builder);

            myContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();

            client = server.CreateClient();


        }

        public void Dispose()
        {
            myContext.Dispose();
            client.Dispose();
        }
    public static async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string url, HttpClient client){
            var result = await client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(dataclass),
                System.Text.Encoding.UTF8, "application/json"));
            return result;
        }
    }

}