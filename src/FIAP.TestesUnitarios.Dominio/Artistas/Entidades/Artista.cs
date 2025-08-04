using FIAP.Core.Dominio;
using FIAP.Core.Dominio.Exceptions;
using FIAP.TestesUnitarios.Dominio.Artistas.Enumeradores;

namespace FIAP.TestesUnitarios.Dominio.Artistas.Entidades;

public class Artista : EntidadeBase
{
    public virtual string Nome { get; protected set; } = string.Empty;
    public virtual GeneroEnum Genero { get; protected set; }

    protected Artista() { }

    public Artista(string nome, GeneroEnum genero)
    {
        SetNome(nome);
        SetGenero(genero);
    }

    public virtual void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))        
            throw new AtributoObrigatorioExcecao(nameof(Nome));        

        if (nome.Length > 50)        
            throw new TamanhoDeAtributoInvalidoExcecao(nameof(Nome), 0, 50);        

        Nome = nome;
    }

    public virtual void SetGenero(GeneroEnum genero)
    {
        if (!Enum.IsDefined(typeof(GeneroEnum), genero))
            throw new AtributoInvalidoExcecao(nameof(Genero));

        Genero = genero;
    }
}
