using FIAP.Core.Dominio.Exceptions;
using FIAP.TestesUnitarios.Dominio.Artistas.Entidades;
using FIAP.TestesUnitarios.Dominio.Artistas.Repositorios;
using FIAP.TestesUnitarios.Dominio.Artistas.Servicos;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace FIAP.TestesUnitarios.Dominio.Testes.Artistas.Servicos
{
    public class ArtistaServicoTestes
    {
        private readonly ArtistaServico _sut;
        private readonly IArtistaRepositorio _artistasRepositorio;

        public ArtistaServicoTestes()
        {
            _artistasRepositorio = Substitute.For<IArtistaRepositorio>();
            _sut = new ArtistaServico(_artistasRepositorio);
        }

        public class ValidarMetodo : ArtistaServicoTestes
        {
            [Fact]
            public async Task Quando_IdValido_Espero_ArtistaValido()
            {
                Artista artista = Builder<Artista>.CreateNew().Build();

                _artistasRepositorio.RecuperarAsync(Arg.Any<int>())
                    .Returns(artista);

                Artista resultado = await _sut.ValidarAsync(artista.Id);

                resultado.Should().Be(artista);
            }

            [Fact]
            public async Task Quando_IdInvalido_Espero_RegistroNaoFoiEncontradoExcecao()
            {
                _artistasRepositorio.RecuperarAsync(Arg.Any<int>())
                    .ReturnsNull();

                await _sut.Invoking(s => s.ValidarAsync(1)).Should().ThrowAsync<RegraDeNegocioExcecao>();
            }
        }
    }
}
