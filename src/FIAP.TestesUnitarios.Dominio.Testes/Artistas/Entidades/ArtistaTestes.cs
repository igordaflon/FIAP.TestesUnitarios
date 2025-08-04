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
        public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
        {
            //Arrange
            string nomeArtista = "Pink Floyd";
            GeneroEnum genero = GeneroEnum.Rock;

            //Act
            var artista = new Artista(nomeArtista, genero);

            //Assert
            artista.Nome.Should().Be(nomeArtista);
            artista.Genero.Should().Be(genero);
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
            //_sut.Invoking(x => x.SetNome(nome)).Should().Throw<AtributoObrigatorioExcecao>();

            //Act
            Action acao = () => _sut.SetNome(nome);

            // Assert
            acao.Should().Throw<AtributoObrigatorioExcecao>();
        }

        [Fact]
        public void Dado_NomeComMaisDeCinquentaCaracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
        {
            //sut.Invoking(x => x.SetNome(new string('*', 51))).Should().Throw<TamanhoDeAtributoInvalidoExcecao>();

            // Arrange
            var nomeInvalido = new string('*', 51);

            // Act
            Action acao = () => _sut.SetNome(nomeInvalido);

            // Assert
            acao.Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
        }

        [Fact]
        public void Dado_NomeValido_Espero_PropriedadesPreenchidas()
        {
            // Arrange
            var nomeValido = "Metallica";

            // Act
            _sut.SetNome(nomeValido);

            // Assert
            _sut.Nome.Should().Be(nomeValido);
        }
    }

    public class SetGeneroMetodo : ArtistaTestes
    {
        [Fact]
        public void Quando_GeneroComValorInvalido_Espero_AtributoInvalidoExcecao()
        {
            // Arrange
            GeneroEnum generoEnum = (GeneroEnum)99;

            // Act & Assert
            _sut.Invoking(x => x.SetGenero(generoEnum)).Should().Throw<AtributoInvalidoExcecao>();
        }

        [Fact]
        public void Quando_GeneroValido_Espero_PropriedadePreenchida()
        {
            // Arrange
            GeneroEnum genero = GeneroEnum.Rock;

            // Act
            _sut.SetGenero(genero);

            // Assert
            _sut.Genero.Should().Be(genero);
        }
    }
}
