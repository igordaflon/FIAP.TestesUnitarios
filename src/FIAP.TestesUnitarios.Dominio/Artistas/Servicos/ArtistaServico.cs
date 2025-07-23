using FIAP.Core.Dominio.Exceptions;
using FIAP.TestesUnitarios.Dominio.Artistas.Entidades;
using FIAP.TestesUnitarios.Dominio.Artistas.Repositorios;
using FIAP.TestesUnitarios.Dominio.Artistas.Servicos.Interfaces;

namespace FIAP.TestesUnitarios.Dominio.Artistas.Servicos;

public class ArtistaServico : IArtistaServico
{
    private readonly IArtistaRepositorio _artistasRepositorio;

    public ArtistaServico(IArtistaRepositorio artistasRepositorio)
    {
        _artistasRepositorio = artistasRepositorio;
    }

    public async Task<Artista> ValidarAsync(int id)
    {
        Artista artista = await _artistasRepositorio.RecuperarAsync(id);

        if (artista == null)        
            throw new RegraDeNegocioExcecao("Artista informado não encontrado.");        

        return artista;
    }
}
