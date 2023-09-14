using System.Collections.Generic;

namespace UMBIT.Infraestrutura.Core.Entidade
{
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

    }
}