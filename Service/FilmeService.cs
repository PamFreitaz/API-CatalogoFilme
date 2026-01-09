namespace CatalogoFilme.Service;

using CatalogoFilme.Domain.Repository;
using CatalogoFilme.Domain.Entity;

public class FilmeService : IFilmeService
{
    //readonly no lugar do final do java
    private readonly IFilmeRepository repository;


    //isso aqui é o @Autowired
    public FilmeService (IFilmeRepository filmeRepository)
    {
        repository = filmeRepository;
    }

    public Task AdicionarFilme(Filmes filmes)
    {
        //chamando o método da linha 12 de FilmeRepository
        return repository.Adicionar(filmes);
    }

    public Task<List<Filmes>> ListarFilmes()
    {
        return repository.Listar();
    }
    
    public Task<Filmes> ListarFilmePorId(long Id)
    {
        return repository.ListarPorId(Id);
    }

    //Controller que sempre chama o método da service
    public Task AtualizarFilme(long Id, Filmes filmes)
    {
        return repository.Atualizar(Id, filmes);
    }
    
    public Task DeletarFilme(long Id)
    {
        return repository.Deletar(Id);
    }
    
}