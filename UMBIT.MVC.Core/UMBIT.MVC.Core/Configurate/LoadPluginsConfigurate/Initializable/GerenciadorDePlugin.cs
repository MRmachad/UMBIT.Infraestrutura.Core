using System.Collections.Generic;
using System.IO;
using UMBIT.Infraestrutura.Core.Entidade;
using UMBIT.Infraestrutura.Core.Utilitarios;

namespace UMBIT.MVC.Core.Configurate.LoadPluginsConfigurate.Initializable
{
    public class GerenciadorDePlugin
    {
        public static PluginsInfo InformePlugins( PluginsInfo PluginsSelecionados)
        {
            var pluginsPath = new PluginsInfo()
            {
                Plugins = new List<Plugin>()
            };

            var binFolder = new DirectoryInfo(DiretorioDeConfiguracao.ObtenhaDiretorioPadrao() + "/Plugins");
            if (!binFolder.Exists)
            {
                return null;
            }

           var bins = binFolder.GetFileSystemInfos("*.dll", SearchOption.AllDirectories);

            foreach (var plugin in PluginsSelecionados.Plugins)
            {
                var pathUI = binFolder.FullName + "\\" + plugin.ProjetoUIWeb + "\\Binarios\\" + plugin.ProjetoUIWeb + ".dll";
                if(new FileInfo(pathUI).Exists)
                {
                    plugin.ProjetoUIWebPath = pathUI;
                }
                    
                
                var pathDominio = binFolder.FullName + "\\" + plugin.ProjetoDominio + "\\Binarios\\" + plugin.ProjetoDominio + ".dll";
                if (new FileInfo(pathDominio).Exists)
                {
                    plugin.ProjetoDominioPath = pathDominio;
                }

                var pathInfra = binFolder.FullName + "\\" + plugin.ProjetoInfraData + "\\Binarios\\" + plugin.ProjetoInfraData + ".dll";
                if (new FileInfo(pathInfra).Exists)
                {
                    plugin.ProjetoInfraDataPath = pathInfra;
                }

                pluginsPath.Plugins.Add(plugin);
            }

            return pluginsPath;
        }

       
    }
}
