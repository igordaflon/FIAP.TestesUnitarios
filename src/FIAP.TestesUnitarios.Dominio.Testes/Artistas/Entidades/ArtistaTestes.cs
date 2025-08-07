using FIAP.Core.Dominio.Exceptions;
using FIAP.TestesUnitarios.Dominio.Artistas.Entidades;
using FIAP.TestesUnitarios.Dominio.Artistas.Enumeradores;
using FizzWare.NBuilder;
using FluentAssertions;

namespace FIAP.TestesUnitarios.Dominio.Testes.Artistas.Entidades;

public class ArtistaTestes
{
    private readonly Artista _sut; // System Under Test -> A coisa que vai ser testada

    public ArtistaTestes()
    {
        _sut = Builder<Artista>.CreateNew().Build(); 
    }

    public class Construtor
    {
        [Fact]
        public void Dado_ParametrosValidos_EsperoObjetoIntegro()
        {
            // Arrange
            var nomeArtista = "Pink Floyd";
            var generoMusical = GeneroMusicalEnum.Rock;

            // Act
            var artista = new Artista(nomeArtista, generoMusical);

            //Assert
            artista.Nome.Should().Be(nomeArtista);
            artista.GeneroMusical.Should().Be(generoMusical);
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
            // Arrange

            //Act
            Action action = () => _sut.SetNome(nome);

            //Assert
            action.Should().Throw<AtributoObrigatorioExcecao>();
        }
    }
}
