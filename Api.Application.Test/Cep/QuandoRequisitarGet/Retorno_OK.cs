using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Api.Application.Test.Cep.QuandoRequisitarGet
{
    public class Retorno_OK
    {
        private CepsController _controller;

        [Fact(DisplayName = "É Possível Realizar o Get By Id.")]
        public async Task Eh_Possivel_Invocar_a_Controller_Get_By_Id()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new CepDto
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.Address.ZipCode(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "S/N",
                    MunicipioId = Guid.NewGuid()                    
                }
            );

            _controller = new CepsController(serviceMock.Object);

            var result = await _controller.GetById(Guid.NewGuid());
            Assert.True(result is OkObjectResult);
        }

        [Fact(DisplayName = "É Possível Realizar o Get By Cep.")]
        public async Task Eh_Possivel_Invocar_a_Controller_Get_By_Cep()
        {
            var serviceMock = new Mock<ICepService>();
            serviceMock.Setup(m => m.Get(It.IsAny<string>())).ReturnsAsync(
                new CepDto
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.Address.ZipCode(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "S/N",
                    MunicipioId = Guid.NewGuid()
                }
            );

            _controller = new CepsController(serviceMock.Object);

            var result = await _controller.GetByCep(Faker.Address.ZipCode()); ;
            Assert.True(result is OkObjectResult);
        }
    }
}
