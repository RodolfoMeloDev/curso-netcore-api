using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto: BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvider = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuário - Inserir")]
        [Trait("CRUD", "UserEntity")]
        public async Task Inserir_Usuario()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                UserImplementation _repository = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var _result = await _repository.InsertAsync(_entity);

                Assert.NotNull(_result);
                Assert.Equal(_entity.Email, _result.Email);
                Assert.Equal(_entity.Name, _result.Name);
                Assert.False(_result.Id == Guid.Empty);
            }
        }
    }
}
