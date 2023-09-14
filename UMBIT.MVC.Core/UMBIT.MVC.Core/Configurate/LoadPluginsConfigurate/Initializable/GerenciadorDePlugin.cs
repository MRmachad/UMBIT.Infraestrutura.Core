using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UMBIT.Infraestrutura.Core.Entidade;
using UMBIT.Infraestrutura.Core.Utilitarios;
using UMBIT.MVC.Core.Configurate.LoadPluginsConfigurate.Initializable.Module;

namespace UMBIT.MVC.Core.Configurate.LoadPluginsConfigurate.Initializable
{
	public class GerenciadorDePlugin
	{
		public static (List<Plugin> plugins, List<KeyValuePair<string, List<ModuloInfo>>> moduloInfos) InformePlugins(List<Plugin> PluginsSelecionados)
		{
			var pluginsPath = new List<Plugin>();
			var ModuloDeplugins = new List<KeyValuePair<string, List<ModuloInfo>>>();

			var binFolder = new DirectoryInfo(DiretorioDeConfiguracao.ObtenhaDiretorioPadrao() + "/Plugins");
			if (!binFolder.Exists) { return (null, null); }

			foreach (var plugin in PluginsSelecionados)
			{
				var pathUI = binFolder.FullName + "\\" + plugin.ProjetoUIWeb + "\\Binarios\\" + plugin.ProjetoUIWeb + ".dll";
				if (new FileInfo(pathUI).Exists)
				{
					plugin.ProjetoUIWebPath = pathUI;

					var modulesType = ModuloInfo.ObtenhaFonteDeModulos(pathUI);

					var listaDeModulos = new List<ModuloInfo>();

					foreach (var moduloInfo in modulesType)
					{
						var modulesInfo = moduloInfo.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public)
													.Where(t => t.IsStatic && t.FieldType.BaseType == typeof(ModuloInfo))
													.Select(t => t.GetValue(null))
													.Cast<ModuloInfo>()
													.ToList();
						
						listaDeModulos.AddRange(modulesInfo);

					}

					ModuloDeplugins.Add(new KeyValuePair<string, List<ModuloInfo>>(plugin.Area, listaDeModulos));
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

				pluginsPath.Add(plugin);
			}

			return (pluginsPath, ModuloDeplugins);
		}


	}
}
