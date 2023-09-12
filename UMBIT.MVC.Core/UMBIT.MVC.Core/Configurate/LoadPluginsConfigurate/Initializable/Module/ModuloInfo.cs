using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UMBIT.MVC.Core.Configurate.LoadPluginsConfigurate.Initializable.Module
{
    public abstract class ModuloInfo
    {
        public int Identificador { get; private set; }

        public string Descricao { get; private set; }

        public string Icone { get; private set; }

        public RecursoInfo[] RecursosDoModulo { get; private set; }

        protected ModuloInfo(int identificador, string descricao, string icone, params RecursoInfo[] recursos)
        {
            Identificador = identificador;
            Descricao = descricao;
            Icone = icone;
            RecursosDoModulo = recursos;
        }

        public static IEnumerable<Type> ObtenhaFonteDeModulos(string assembly)
        {
            if (string.IsNullOrEmpty(assembly))
            {
                return new List<Type>();
            }

            return from type in Assembly.LoadFrom(assembly).GetTypes()
                   where type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(ModuloInfo))
                   select type;
        }
    }
}
