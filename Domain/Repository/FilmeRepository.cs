namespace CatalogoFilme.Domain.Repository;

using CatalogoFilme.Domain.Repository;
using CatalogoFilme.Domain.Entity;

public class FilmeRepository : IFilmeRepository
{
    //é para criar uma lista vazia de filmes, não sei pra que kkkkkk
    private static readonly List<Filmes>_filmes = new ();

    //quando for chamar o id vai começar com 1
    private static long _id = 1;

    //adiciona um filme na lista de filmes (linha 6)
    public Task Adicionar(Filmes filmes)
    {
        //linha 18 serve para incrementar o ID da linha 12
        filmes.CriarId(_id++);
        _filmes.Add(filmes);
        //retornou a tarefa completa
        return Task.CompletedTask;
    }


    public Task<List<Filmes>> Listar()
    {
        //FromResult faz uma pesquisa na lista de filmes (_filmes, linha 14)
        return Task.FromResult(_filmes);
    }

    public Task<Filmes> ListarPorId(long id)
    {
        //ele pesquisa na lista de filmes (_filmes, linha 14), e quando ele achar um ID igual ao da linha 26, ele retorna
        return Task.FromResult(_filmes.FirstOrDefault(filmes => filmes.Id == id));
    }

    public Task Atualizar(long id, Filmes filmes)
    {
        //pesquisa o Id na lista de filmes e se for diferente de erro (-1) ele atualiza o filme
        var atualizar = _filmes.FindIndex (filmes => filmes.Id == id );
        if (atualizar != -1)
        {
            _filmes[atualizar] = filmes;
        }
        return Task.CompletedTask;
    }

    public Task Deletar(long id)
    {
        //pesquisa o Id na lista de filmes e se for diferente de null, ele deleta o filme
        var filme = _filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme != null)
        {
            _filmes.Remove(filme);
        }
        return Task.CompletedTask;
    }

}