using Api.Domain.Interfaces.Services.Login;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            // Transient = Sempre cria uma instancia do service
            // Scooped = Cria uma nova instancia após 10 execuções daquele serviço
            // Singleton = Cria uma unica vez a instancia do service e sempre usará o mesmo na aplicação
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}
