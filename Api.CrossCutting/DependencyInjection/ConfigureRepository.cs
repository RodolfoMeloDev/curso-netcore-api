using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            // Banco de dados espera sempre um serviço de scopo
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            serviceCollection.AddScoped<IUfRepository, UfImplementation>();
            serviceCollection.AddScoped<IMunicipioRepository, MunicipioImplementation>();
            serviceCollection.AddScoped<ICepRepository, CepImplementation>();

            if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "postgre")
            {
                serviceCollection.AddDbContext<MyContext>(
                    options => options.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }
            else
            {
                serviceCollection.AddDbContext<MyContext>(
                    options => options.UseSqlServer(Environment.GetEnvironmentVariable("DB_CONNECTION"))
                );
            }
        }
    }
}
