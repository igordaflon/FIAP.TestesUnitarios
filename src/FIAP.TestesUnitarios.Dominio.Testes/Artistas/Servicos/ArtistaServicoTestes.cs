using FIAP.Core.Dominio.Exceptions;
using FIAP.TestesUnitarios.Dominio.Artistas.Entidades;
using FIAP.TestesUnitarios.Dominio.Artistas.Repositorios;
using FIAP.TestesUnitarios.Dominio.Artistas.Servicos;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace FIAP.TestesUnitarios.Dominio.Testes.Artistas.Servicos;

public class ArtistaServicoTestes
{
    private readonly ArtistaServico _sut; // A coisa que vai ser testada
    private readonly IArtistaRepositorio _artistaRepositorio;

    public ArtistaServicoTestes()
    {
        _artistaRepositorio = Substitute.For<IArtistaRepositorio>();
        _sut = new ArtistaServico(_artistaRepositorio);
    }

    public class ValidarAsyncMetodo : ArtistaServicoTestes
    {
        [Fact]
        public async Task Dado_IdValido_Espero_ArtistaValido()
        {
            //Arrange
            Artista artista = Builder<Artista>.CreateNew().Build();
            _artistaRepositorio.RecuperarAsync(Arg.Any<int>()).Returns(artista);

            //Act
            Artista resultado = await _sut.ValidarAsync(artista.Id);

            //Assert
            resultado.Should().Be(artista);
        }

        [Fact]
        public async Task Dado_IdInvalido_Espero_RegraDeNegocioExcecao()
        {
            //Arrange
            _artistaRepositorio.RecuperarAsync(Arg.Any<int>()).ReturnsNull();

            //Act & Assert
            await _sut.Invoking(s => s.ValidarAsync(1)).Should().ThrowAsync<RegraDeNegocioExcecao>();
        }
    }
}
