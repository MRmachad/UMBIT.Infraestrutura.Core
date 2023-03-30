using Microsoft.Extensions.DependencyInjection;

namespace UMBIT.MVC.Core.Configurate.Initializable
{

    public interface IModuleInitializer
    {
        void Init(IServiceCollection serviceCollection);
    }

}