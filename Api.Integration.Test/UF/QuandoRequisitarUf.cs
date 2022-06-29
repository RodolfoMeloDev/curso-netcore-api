using Api.Domain.Dtos.Uf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Integration.Test.UF
{
    public class QuandoRequisitarUf : BaseIntegration
    {
        [Fact]
        public async Task Eh_Possivel_Realizar_Consultas_de_Uf()
        {
            await AdicionarToken();

            //Get all
            response = await client.GetAsync($"{hostApi}ufs");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listaFromJson = JsonConvert.DeserializeObject<IEnumerable<UfDto>>(jsonResult);
            Assert.NotNull(listaFromJson);
            Assert.True(listaFromJson.Count() == 27);
            Assert.True(listaFromJson.Where(s => s.Sigla == "SC").Count() == 1);

            var id = listaFromJson.Where(s => s.Sigla == "SC").FirstOrDefault().Id;
            response = await client.GetAsync($"{hostApi}ufs/{id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<UfDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal("SC", registroSelecionado.Sigla);
        }
    }
}
