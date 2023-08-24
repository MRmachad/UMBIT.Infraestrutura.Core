using System.IO;
using System;
using System.Reflection;
using System.Runtime.Loader;
using System.Linq;
using System.Collections.Generic;

namespace UMBIT.Infraestrutura.Core.Entidade
{
    public class PluginsInfo
    {
        public List<Plugin> Plugins { get; set; }

      
    }
    public class Plugin
    {
        public string Titulo { get; set; }

        public string Area { get; set; }

        public string ProjetoUIWeb { get; set; }
        public string ProjetoUIWebPath { get; set; }

        public string ProjetoDominio { get; set; }
        public string ProjetoDominioPath { get; set; }

        public string ProjetoInfraData { get; set; }
        public string ProjetoInfraDataPath { get; set; }

        public Assembly LoadAssembly(string pathAssembly)
        {

            var binFolder = new FileInfo(pathAssembly);
            if (!binFolder.Exists)
            {
                return null;
            }

            Assembly assembly = null;
            try
            {
                assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(pathAssembly);
            }
            catch (FileLoadException ex)
            {
                if (!(ex.Message == "Assembly with same name is already loaded"))
                {
                    throw;
                }
            }

            return assembly;
        }

    }
}