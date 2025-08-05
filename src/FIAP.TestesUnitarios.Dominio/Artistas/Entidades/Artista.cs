using FIAP.Core.Dominio;
using FIAP.Core.Dominio.Exceptions;
using FIAP.TestesUnitarios.Dominio.Artistas.Enumeradores;

namespace FIAP.TestesUnitarios.Dominio.Artistas.Entidades;

public class Artista : EntidadeBase
{
    public virtual string Nome { get; protected set; } = string.Empty;
    public virtual GeneroMusicalEnum GeneroMusical { get; protected set; }

    protected Artista() { }

    public Artista(string nome, GeneroMusicalEnum genero)
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

    public virtual void SetGenero(GeneroMusicalEnum generoMusical)
    {
        if (!Enum.IsDefined(typeof(GeneroMusicalEnum), generoMusical))
            throw new AtributoInvalidoExcecao(nameof(GeneroMusical));

        GeneroMusical = generoMusical;
    }
}
