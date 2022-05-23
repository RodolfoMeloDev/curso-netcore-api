using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.Login;
using Api.Domain.Repository;
using System.Threading.Tasks;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repository;

        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            if (user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                return await _repository.FindByLoginAsync(user.Email);                
            }

            return null;            
        }
    }
}
