using Microsoft.Extensions.DependencyInjection;

namespace UMBIT.MVC.Core.Configurate.LoadPluginsConfigurate.Initializable.Module
{

    public interface IPluginInitializer
    {
        void Init(IServiceCollection serviceCollection);
    }

}