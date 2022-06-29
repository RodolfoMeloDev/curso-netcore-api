using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarUpdate
{
    public class RetornoNotFound
    {
        private CepsController _controller;

        [Fact(DisplayName = "É Possível Realizar o Update.")]
        public async Task Eh_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).Returns(Task.FromResult((CepDtoUpdateResult) null));

            _controller = new CepsController(serviceMock.Object);

            var cepDtoUpdate = new CepDtoUpdate
            {
                Cep = Faker.Address.ZipCode(),
                Logradouro = Faker.Address.StreetName(),
                Numero = "S/N",
                MunicipioId = Guid.NewGuid(),
                Id = Guid.NewGuid()
            };

            var result = await _controller.UpdateCep(cepDtoUpdate);
            Assert.True(result is NotFoundResult);
        }
    }
}
