namespace CatalogoFilme.Domain.Repository;

using CatalogoFilme.Domain.Entity;


public interface IFilmeRepository
{
    Task Adicionar(Filmes filmes);
    Task<List<Filmes>> Listar();
    Task<Filmes> ListarPorId(long id);
    Task Atualizar(Filmes filmes);
    Task Deletar(long id);
    Task<List<Filmes>> ListarFilmesPeloGenero (long generoid);
}