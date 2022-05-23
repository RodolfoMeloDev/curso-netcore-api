using Api.Domain.Dtos;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.Login
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto user);
    }
}
