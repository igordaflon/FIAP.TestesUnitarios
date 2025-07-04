namespace FIAP.TestesUnitarios.Dominio.Artistas.Entidades;

public class Artista
{
    public virtual string Nome { get; protected set; }

    public Artista(string nome)
    {
        SetNome(nome);
    }

    public virtual void SetNome(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))        
            throw new AtributoObrigatorioExcecao("Nome");        

        if (nome.Length > 50)        
            throw new TamanhoDeAtributoInvalidoExcecao("Nome", 0, 50);        

        Nome = nome;
    }
}
