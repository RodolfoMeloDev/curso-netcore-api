using Api.Domain.Entities;
using System.Threading.Tasks;

namespace Api.Domain.Interfaces.Services.Login
{
    public interface ILoginService
    {
        Task<object> FindByLogin(UserEntity user);
    }
}
