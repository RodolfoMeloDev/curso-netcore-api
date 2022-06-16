using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class CepCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvider;

        public CepCrudCompleto(DbTeste dbteste)
        {
            _serviceProvider = dbteste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Cep")]
        [Trait("CRUD", "CepEntity")]
        public async Task Eh_Possivel_Realizar_CRUD_Cep()
        {
            using (var context = _serviceProvider.GetService<MyContext>())
            {
                MunicipioImplementation _repositorioMunicipio = new MunicipioImplementation(context);
                MunicipioEntity _entityMunicipio = new MunicipioEntity
                {
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                    UfId = new Guid("3288e581-e757-4eb8-9733-cbb70d55a0eb")
                };

                var _municipioCriado = await _repositorioMunicipio.InsertAsync(_entityMunicipio);

                CepImplementation _repositorioCep = new CepImplementation(context);
                CepEntity _entityCep = new CepEntity
                {
                    Cep = "88054-300",
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "0 até 2000",
                    MunicipioId = _municipioCriado.Id
                };

                var _cepCriado = await _repositorioCep.InsertAsync(_entityCep);
                Assert.NotNull(_cepCriado);
                Assert.Equal(_entityCep.Cep, _cepCriado.Cep);
                Assert.Equal(_entityCep.Logradouro, _cepCriado.Logradouro);
                Assert.Equal(_entityCep.Numero, _cepCriado.Numero);
                Assert.Equal(_entityCep.MunicipioId, _cepCriado.MunicipioId);
                Assert.False(_entityCep.Id == Guid.Empty);

                _cepCriado.Logradouro = Faker.Address.StreetName();

                var _cepAtualizado = await _repositorioCep.UpdateAsync(_entityCep);
                Assert.NotNull(_cepAtualizado);
                Assert.Equal(_entityCep.Cep, _cepAtualizado.Cep);
                Assert.Equal(_entityCep.Logradouro, _cepAtualizado.Logradouro);
                Assert.Equal(_entityCep.Numero, _cepAtualizado.Numero);
                Assert.True(_entityCep.Id == _cepAtualizado.Id);

                var _registroExiste = await _repositorioCep.ExistAsync(_cepAtualizado.Id);
                Assert.True(_registroExiste);

                var _registroSelecionado = await _repositorioCep.SelectAsync(_cepAtualizado.Id);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_cepAtualizado.Cep, _registroSelecionado.Cep);
                Assert.Equal(_cepAtualizado.Logradouro, _registroSelecionado.Logradouro);
                Assert.Equal(_cepAtualizado.Numero, _registroSelecionado.Numero);
                Assert.True(_cepAtualizado.Id == _registroSelecionado.Id);

                _registroSelecionado = await _repositorioCep.SelectAsync(_cepAtualizado.Cep);
                Assert.NotNull(_registroSelecionado);
                Assert.Equal(_cepAtualizado.Cep, _registroSelecionado.Cep);
                Assert.Equal(_cepAtualizado.Logradouro, _registroSelecionado.Logradouro);
                Assert.Equal(_cepAtualizado.Numero, _registroSelecionado.Numero);
                Assert.True(_cepAtualizado.Id == _registroSelecionado.Id);
                Assert.NotNull(_registroSelecionado.Municipio);
                Assert.Equal(_entityMunicipio.Nome, _registroSelecionado.Municipio.Nome);
                Assert.NotNull(_registroSelecionado.Municipio.Uf);

                var _todosRegistros = await _repositorioCep.SelectAllAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 0);

                var _removeu = await _repositorioCep.DeleteAsync(_registroSelecionado.Id);
                Assert.True(_removeu);

                _todosRegistros = await _repositorioCep.SelectAllAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() == 0);
            }
        }
    }
}
