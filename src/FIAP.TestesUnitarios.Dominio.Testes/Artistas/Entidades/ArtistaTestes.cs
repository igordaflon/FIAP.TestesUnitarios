using FIAP.Core.Dominio.Exceptions;
using FIAP.TestesUnitarios.Dominio.Artistas.Entidades;
using FizzWare.NBuilder;
using FluentAssertions;

namespace FIAP.TestesUnitarios.Dominio.Testes.Artistas.Entidades;

public class ArtistaTestes
{
    private readonly Artista sut;

    public ArtistaTestes()
    {
        sut = Builder<Artista>.CreateNew().Build();
    }

    public class Construtor
    {
        [Fact]
        public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
        {
            string nomeArtista = "Linkin Park";

            var artista = new Artista(nomeArtista);
            artista.Nome.Should().Be(nomeArtista);
        }
    }

    public class SetNomeMetodo : ArtistaTestes
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Dado_NomeNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string nome)
        {
            sut.Invoking(x => x.SetNome(nome)).Should().Throw<AtributoObrigatorioExcecao>();
        }

        [Fact]
        public void Dado_NomeComMaisDeCinquentaCaracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
        {
            sut.Invoking(x => x.SetNome(new string('*', 51))).Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
        }

        [Fact]
        public void Dado_NomeValido_Espero_PropriedadesPreenchidas()
        {
            sut.SetNome("Mamonas Assassinas");
            sut.Nome.Should().Be("Mamonas Assassinas");
        }
    }
}
