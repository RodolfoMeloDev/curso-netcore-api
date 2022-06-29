using Api.Domain.Dtos.Municipio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.Municipio
{
    public class QuandoRequisitarMunicipio : BaseIntegration
    {
        [Fact]
        public async Task Eh_Possivel_Realizar_Crud_Municipio()
        {
            await AdicionarToken();

            var municipioDto = new MunicipioDtoCreate
            {
                Nome = "Florianópolis",
                CodIBGE = 11111,
                UfId = new Guid("32951f32-4525-4792-a56e-8c33c58d3c29")
            };

            // Post
            var response = await PostJsonAsync(municipioDto, $"{hostApi}municipios", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<MunicipioDtoCreateResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("Florianópolis", registroPost.Nome);
            Assert.Equal(11111, registroPost.CodIBGE);
            Assert.True(registroPost.Id != default(Guid));

            // Get All
            response = await client.GetAsync($"{hostApi}municipios");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<MunicipioDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() > 0);
            Assert.True(listaFromJson.Where(t => t.Id == registroPost.Id).Count() == 1);

            var updateMunicipioDto = new MunicipioDtoUpdate
            {
                Id = registroPost.Id,
                Nome = "São José",
                CodIBGE = 11112,
                UfId = new Guid("32951f32-4525-4792-a56e-8c33c58d3c29")
            };

            // Put
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateMunicipioDto), Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}Municipios", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<MunicipioDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(registroPost.Nome, registroAtualizado.Nome);
            Assert.NotEqual(registroPost.CodIBGE, registroAtualizado.CodIBGE);

            // Get Id
            response = await client.GetAsync($"{hostApi}municipios/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<MunicipioDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionado.CodIBGE, registroAtualizado.CodIBGE);

            // Get Complete/Id
            response = await client.GetAsync($"{hostApi}municipios/Complete/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoCompleto = JsonConvert.DeserializeObject<MunicipioDtoCompleto>(jsonResult);
            Assert.NotNull(registroSelecionadoCompleto);
            Assert.Equal(registroSelecionadoCompleto.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionadoCompleto.CodIBGE, registroAtualizado.CodIBGE);
            Assert.NotNull(registroSelecionadoCompleto.Uf);

            // Get byIBGE/Id
            response = await client.GetAsync($"{hostApi}municipios/byIBGE/{registroAtualizado.CodIBGE}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoCompleto2 = JsonConvert.DeserializeObject<MunicipioDtoCompleto>(jsonResult);
            Assert.NotNull(registroSelecionadoCompleto2);
            Assert.Equal(registroSelecionadoCompleto2.Nome, registroAtualizado.Nome);
            Assert.Equal(registroSelecionadoCompleto2.CodIBGE, registroAtualizado.CodIBGE);
            Assert.NotNull(registroSelecionadoCompleto2.Uf);

            // Delete
            response = await client.DeleteAsync($"{hostApi}municipios/{registroSelecionadoCompleto2.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get apos Delete para validar se não esta na base
            response = await client.GetAsync($"{hostApi}ceps/{registroSelecionadoCompleto2.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }
    }
}
