using System.ComponentModel;
using FIAP.Core.Dominio.Exceptions;
using FIAP.TestesUnitarios.Dominio.Artistas.Entidades;
using FIAP.TestesUnitarios.Dominio.Artistas.Enumeradores;
using FizzWare.NBuilder;
using FluentAssertions;
using FluentAssertions.Equivalency;

namespace FIAP.TestesUnitarios.Dominio.Testes.Artistas.Entidades;

public class ArtistaTestes
{
    //SUT -> System Under Test -> A coisa que vai ser testada
    private readonly Artista _sut;

    public ArtistaTestes()
    {
        _sut = Builder<Artista>.CreateNew().Build();
    }

    public class Construtor
    {
        [Fact]
        public void Dado_ParametrosValidos_Espero_ObjetoIntegro()
        {
            //Arrange
            string nome = "Pink Floyd";
            GeneroMusicalEnum genero = GeneroMusicalEnum.Rock;

            //Act
            var artista = new Artista(nome, genero);

            //Assert
            artista.Nome.Should().Be(nome);
            artista.GeneroMusical.Should().Be(genero);
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
            //Arrange

            //Act
            Action action = () => _sut.SetNome(nome);

            //Assert
            action.Should().Throw<AtributoObrigatorioExcecao>();
        }

        [Fact]
        public void Dado_NomeComMaisDeCinquentaCaracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
        {
            //Arrange
            string nomeComMaisCinquentaCarateres = new('A', 51);

            //Act
            Action action = () => _sut.SetNome(nomeComMaisCinquentaCarateres);

            //Assert
            action.Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
        }

        [Fact]
        public void Dado_NomeValido_Espero_PropriedadePreenchida()
        {
            //Arrange
            string nomeValido = "Led Zeppelin";

            //Act
            _sut.SetNome(nomeValido);

            //Assert
            _sut.Nome.Should().Be(nomeValido);
        }
    }

    public class SetGeneroMetodo : ArtistaTestes
    {
        [Fact]
        public void Dado_GeneroInvalido_Espero_AtributoInvalidoExcecao()
        {
            //Arrange
            GeneroMusicalEnum generoInvalido = (GeneroMusicalEnum)999;
            //Act
            Action action = () => _sut.SetGenero(generoInvalido);
            //Assert
            action.Should().Throw<AtributoInvalidoExcecao>();
        }

        [Fact]
        public void Dado_GeneroValido_Espero_PropriedadePreenchida()
        {
            //Arrange
            GeneroMusicalEnum generoValido = GeneroMusicalEnum.Blues;
            //Act
            _sut.SetGenero(generoValido);
            //Assert
            _sut.GeneroMusical.Should().Be(generoValido);
        }
    }
}
