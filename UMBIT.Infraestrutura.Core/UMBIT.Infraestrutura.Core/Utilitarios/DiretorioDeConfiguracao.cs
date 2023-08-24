using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMBIT.Infraestrutura.Core.Utilitarios
{
    public static class DiretorioDeConfiguracao
    {
        const string UMBIT_CONFIG_PATH_ENVIRONMENT_VARIABLE = "UMBIT_PLUGINS";

        public static string ObtenhaDiretorioPadrao()
        {
            var UMBIT_config_path = Environment.GetEnvironmentVariable(UMBIT_CONFIG_PATH_ENVIRONMENT_VARIABLE);

            if (String.IsNullOrEmpty(UMBIT_config_path))
            {
                Environment.SetEnvironmentVariable(UMBIT_CONFIG_PATH_ENVIRONMENT_VARIABLE, @"C:\UMBIT_PLUGINS");
            }

            return Environment.GetEnvironmentVariable(UMBIT_CONFIG_PATH_ENVIRONMENT_VARIABLE);
        }
    }
}

