using FIAP.Core.Dominio;
using FIAP.Core.Dominio.Exceptions;

namespace FIAP.TestesUnitarios.Dominio.Artistas.Entidades;

public class Artista : EntidadeBase
{
    public virtual string Nome { get; protected set; } = string.Empty;

    protected Artista() { }

    public Artista(string nome)
    {
        SetNome(nome);
    }

    public virtual void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))        
            throw new AtributoObrigatorioExcecao(nameof(Nome));        

        if (nome.Length > 50)        
            throw new TamanhoDeAtributoInvalidoExcecao(nameof(Nome), 0, 50);        

        Nome = nome;
    }
}
