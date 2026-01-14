namespace CatalogoFilme.Service;

using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using CatalogoFilme.Domain.Entity;

//métodos que será EXIGIDO na service de filme
public interface IFilmeService
{
    Task AdicionarFilme(Filmes filmes);
    Task<List<Filmes>> ListarFilmes();
    Task<Filmes> ListarFilmePorId(long id);
    Task AtualizarFilme(Filmes filmes);
    Task DeletarFilme(long id);
    Task <List<Filmes>> ListarFilmesPorGenero(long generoid);
    
}