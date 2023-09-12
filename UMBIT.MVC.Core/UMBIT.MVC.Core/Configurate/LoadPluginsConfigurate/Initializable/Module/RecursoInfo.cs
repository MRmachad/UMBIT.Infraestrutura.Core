namespace UMBIT.MVC.Core.Configurate.LoadPluginsConfigurate.Initializable.Module
{
    public abstract class RecursoInfo
    {
        public int Identificador { get; private set; }

        public string Descricao { get; private set; }

        public string Controller { get; private set; }

        public string Action { get; private set; }

        public bool CompoeMenu { get; private set; }

        public bool CompoeCatalogo { get; private set; }

        protected RecursoInfo(int identificador, string descricao, string controller, string action, bool CompoeMenu, bool CompoeCatalogo)
        {
            Identificador = identificador;
            Descricao = descricao;
            Controller = controller;
            Action = action;
            this.CompoeMenu = CompoeMenu;
            this.CompoeCatalogo = CompoeCatalogo;
        }
    }
}