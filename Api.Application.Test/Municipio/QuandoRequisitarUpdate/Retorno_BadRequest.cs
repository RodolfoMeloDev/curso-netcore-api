using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
namespace Api.Application.Test.Municipio.QuandoRequisitarUpdate
{
    public class Retorno_BadRequest
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É Possível Realizar o Update.")]
        public async Task Eh_Possivel_Invocar_a_Controller_Update()
        {
            var serviceMock = new Mock<IMunicipioService>();
            serviceMock.Setup(m => m.Put(It.IsAny<MunicipioDtoUpdate>())).ReturnsAsync(
                new MunicipioDtoUpdateResult
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid(),
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new MunicipiosController(serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Formato Inválido");

            var municipioDtoUpdate = new MunicipioDtoUpdate
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 10000),
                UfId = Guid.NewGuid()
            };

            var result = await _controller.UpdateCity(municipioDtoUpdate);
            Assert.True(result is BadRequestResult);

            _controller.ModelState.Remove("Id");
            serviceMock.Setup(m => m.Put(It.IsAny<MunicipioDtoUpdate>())).Returns(Task.FromResult((MunicipioDtoUpdateResult) null));

            result = await _controller.UpdateCity(municipioDtoUpdate);
            Assert.True(result is BadRequestResult);
        }
    }
}
