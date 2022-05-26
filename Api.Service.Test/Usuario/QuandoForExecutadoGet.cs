using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Service.Test.Usuario
{
    public class QuandoForExecutadoGet : UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "É possível Executar o Método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(o => o.GetUser(IdUsuario)).ReturnsAsync(userDto);
            _service = _serviceMock.Object;

            var result = await _service.GetUser(IdUsuario);

            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(o => o.GetUser(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto) null));
            _service = _serviceMock.Object;

            var _record = await _service.GetUser(IdUsuario);
            Assert.Null(_record);
        }
    }
}
