using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Core.Dominio.Exceptions
{
    public class AtributoInvalidoExcecao(string atributo) : Exception($"O valor do atributo '{atributo}' é inválido ou não definido.")
    {
    }
}
