using System.Threading.Tasks;
using FIAP.TestesUnitarios.Dominio.Artistas.Entidades;
using FIAP.TestesUnitarios.Dominio.Artistas.Repositorios;
using FIAP.TestesUnitarios.Dominio.Artistas.Servicos;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;

namespace FIAP.TestesUnitarios.Dominio.Testes.Artistas.Servicos;

public class ArtistaServicoTestes
{
    private readonly ArtistaServico _sut; // System Under Test
    private readonly IArtistaRepositorio _artistasRepositorio;

    public ArtistaServicoTestes()
    {
        _artistasRepositorio = Substitute.For<IArtistaRepositorio>();
        _sut = new ArtistaServico(_artistasRepositorio);
    }

    public class ValidarAsyncMetodo : ArtistaServicoTestes
    {
        [Fact]
        public async Task Dado_IdValido_Espero_ArtistaValido()
        {
            //Arrange
            Artista artista = Builder<Artista>.CreateNew().Build();

            _artistasRepositorio.RecuperarAsync(Arg.Any<int>()).Returns(artista);

            //Act

            var resultado = await _sut.ValidarAsync(artista.Id);

            //Assert
            resultado.Should().Be(artista);
        }
    }
}
