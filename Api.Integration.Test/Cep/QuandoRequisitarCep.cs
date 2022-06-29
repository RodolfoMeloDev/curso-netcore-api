using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Cep
{
    public class QuandoRequisitarCep : BaseIntegration
    {
        [Fact]
        public async Task Eh_Possivel_Realizar_Crud_Cep()
        {
            await AdicionarToken();

            var municipioDto = new MunicipioDtoCreate
            {
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 1000000),
                UfId = new Guid("32951f32-4525-4792-a56e-8c33c58d3c29")
            };

            var response = await PostJsonAsync(municipioDto, $"{hostApi}municipios", client);
            var municipioResult = await response.Content.ReadAsStringAsync();
            var municipioPost = JsonConvert.DeserializeObject<MunicipioDtoCreateResult>(municipioResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var cepDto = new CepDtoCreate
            {
                Cep = Faker.Address.ZipCode(),
                Logradouro = Faker.Address.StreetName(),
                Numero = "S/N",
                MunicipioId = municipioPost.Id
            };

            // Post
            response = await PostJsonAsync(cepDto, $"{hostApi}ceps", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<CepDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(cepDto.Logradouro, registroPost.Logradouro);
            Assert.Equal(cepDto.Numero, registroPost.Numero);
            Assert.Equal(cepDto.MunicipioId, registroPost.MunicipioId);
            Assert.True(registroPost.Id != default(Guid));

            // Get 
            response = await client.GetAsync($"{hostApi}ceps/{registroPost.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<CepDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Cep, registroPost.Cep);
            Assert.Equal(registroSelecionado.Logradouro, registroPost.Logradouro);
            Assert.Equal(registroSelecionado.Numero, registroPost.Numero);
            Assert.Null(registroSelecionado.Municipio);

            // Get byCep/cep
            response = await client.GetAsync($"{hostApi}ceps/byCep/{registroPost.Cep}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoCep = JsonConvert.DeserializeObject<CepDto>(jsonResult);
            Assert.NotNull(registroSelecionadoCep);
            Assert.Equal(registroSelecionadoCep.Cep, registroPost.Cep);
            Assert.Equal(registroSelecionadoCep.Logradouro, registroPost.Logradouro);
            Assert.Equal(registroSelecionadoCep.Numero, registroPost.Numero);
            Assert.NotNull(registroSelecionadoCep.Municipio);

            // Put
            var cepDtoUpdate = new CepDtoUpdate
            {
                Id = registroPost.Id,
                Cep = registroPost.Cep,
                Logradouro = registroPost.Logradouro,
                Numero = $"0 ate {Faker.RandomNumber.Next(1, 1000).ToString()}",
                MunicipioId = registroPost.MunicipioId
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(cepDtoUpdate), Encoding.UTF8, "application/json");

            response = await client.PutAsync($"{hostApi}Ceps", stringContent);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<CepDtoUpdateResult>(jsonResult);
            Assert.NotNull(registroAtualizado);
            Assert.Equal(registroAtualizado.Cep, registroPost.Cep);
            Assert.Equal(registroAtualizado.Logradouro, registroPost.Logradouro);
            Assert.NotEqual(registroAtualizado.Numero, registroPost.Numero);
            Assert.NotEqual(registroAtualizado.Numero, cepDto.Numero);
            Assert.NotNull(registroSelecionadoCep.Municipio);

            // Delete
            response = await client.DeleteAsync($"{hostApi}Ceps/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get apos Delete para validar se não esta na base
            response = await client.GetAsync($"{hostApi}ceps/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
          
        }
    }
}
