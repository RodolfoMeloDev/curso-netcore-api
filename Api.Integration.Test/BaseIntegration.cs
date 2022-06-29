using Api.Application;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using Api.Domain.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
            hostApi = "http://localhost:5000/api/";

            var builder = new WebHostBuilder().
                UseEnvironment("Testing").
                UseStartup<Startup>();

            var server = new TestServer(builder);

            myContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();

            mapper = new AutoMapperFixture().GetMapper();

            client = server.CreateClient();
        }

        public async Task AdicionarToken()
        {
            var loginDto = new LoginDto()
            {
                Email = "admin@mail.com"
            };

            var resultLogin = await PostJsonAsync(loginDto, $"{hostApi}Login", client);
            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObjetct = JsonConvert.DeserializeObject<LoginResponseDto>(jsonLogin);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginObjetct.accessToken);
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataClass, string url, HttpClient client)
        {
            return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(dataClass), Encoding.UTF8, "application/json"));
        }

        public void Dispose()
        {
            myContext.Database.EnsureDeleted();
            myContext.Dispose();
            client.Dispose();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new ModelToEntityProfile());
                cfg.AddProfile(new EntityToDtoProfile());
            });

            return config.CreateMapper();
        }

        public void Dispose() { }
    }
}   
