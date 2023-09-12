using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMBIT.Infraestrutura.Core.Basicos.Excecoes
{
    public class ExcecaoBasicaUMBIT : Exception
    {
        public string Mensagem { get; private set; }
        public Exception ExcecaoInterna { get; private set; }
        public ExcecaoBasicaUMBIT(string mensagem) : base(mensagem)
        {
            this.Mensagem = mensagem;
        }
        public ExcecaoBasicaUMBIT(string mensagem, Exception ex) : base(mensagem, ex)
        {
            this.Mensagem = ex.GetType() == typeof(ExcecaoBasicaUMBIT) ? ((ExcecaoBasicaUMBIT)ex).Mensagem : mensagem;
            this.ExcecaoInterna = ex;
        }

        public override string ToString()
        {
            return this.Mensagem;
        }
    }
}
