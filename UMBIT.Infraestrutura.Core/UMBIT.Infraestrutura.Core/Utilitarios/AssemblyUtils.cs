using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace UMBIT.Infraestrutura.Core.Utilitarios
{
	public class AssemblyUtils
	{
		public static Assembly LoadAssembly(string pathAssembly)
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
