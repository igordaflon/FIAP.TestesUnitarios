using FIAP.TestesUnitarios.Dominio.Artistas.Entidades;

namespace FIAP.TestesUnitarios.Dominio.Artistas.Repositorios;

public interface IArtistaRepositorio
{
    Task<Artista> RecuperarAsync(int id);
}
