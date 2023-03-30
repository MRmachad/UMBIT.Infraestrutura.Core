using System.Reflection;

namespace UMBIT.MVC.Core.Configurate.Initializable
{
    public class ModuleInfo
    {
        public string Name { get;  set; }
        public Assembly Assembly { get;  set; }
        public string Path { get;  set; }
    }
}