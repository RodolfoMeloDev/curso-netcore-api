using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
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

        [Fact(DisplayName = "CRUD de Usuário")]
        [Trait("CRUD", "UserEntity")]
        public async Task CRUD_Usuario()
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

                _entity.Name = Faker.Name.First();

                var _resultUpdate = await _repository.UpdateAsync(_entity);
                Assert.NotNull(_resultUpdate);
                Assert.Equal(_entity.Email, _resultUpdate.Email);
                Assert.Equal(_entity.Name, _resultUpdate.Name);

                var _resultExist = await _repository.ExistAsync(_resultUpdate.Id);
                Assert.True(_resultExist);

                var _resultSelected = await _repository.SelectAsync(_resultUpdate.Id);
                Assert.NotNull(_resultUpdate);
                Assert.Equal(_resultUpdate.Email, _resultSelected.Email);
                Assert.Equal(_resultUpdate.Name, _resultSelected.Name);

                var _resultSelectAll = await _repository.SelectAllAsync();
                Assert.NotNull(_resultSelectAll);
                Assert.True(_resultSelectAll.Count() > 1); // Pq na criação do banco já insere 1 registro

                var _resultDeleted = await _repository.DeleteAsync(_resultSelected.Id);
                Assert.True(_resultDeleted);

                var _resultLogin = await _repository.FindByLoginAsync("admin@mail.com");
                Assert.NotNull(_resultUpdate);
                Assert.Equal("admin@mail.com", _resultLogin.Email);
                Assert.Equal("Administrador", _resultLogin.Name);
            }
        }
    }
}
