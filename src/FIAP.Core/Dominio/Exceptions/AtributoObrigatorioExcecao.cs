namespace FIAP.Core.Dominio.Exceptions;

public class AtributoObrigatorioExcecao(string nomeAtributo) : Exception($"O atributo {nomeAtributo} é obrigatório.")
{
}
