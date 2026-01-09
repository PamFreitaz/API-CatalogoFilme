namespace CatalogoFilme.Service;

using CatalogoFilme.Domain.Entity;

//métodos que será EXIGIDO na service de filme
public interface IFilmeService
{
    Task AdicionarFilme(Filmes filmes);
    Task<List<Filmes>> ListarFilmes();
    Task<Filmes> ListarFilmePorId(long id);
    Task AtualizarFilme(long id, Filmes filmes);
    Task DeletarFilme(long id);
    
}