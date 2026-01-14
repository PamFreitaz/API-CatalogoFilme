namespace CatalogoFilme.Domain.Repository;

using CatalogoFilme.Domain.Repository;
using CatalogoFilme.Domain.Entity;
using Dapper;
using CatalogoFilme.Infrastructure;
using System.Runtime.InteropServices;

public class FilmeRepository : IFilmeRepository
{
    //é para criar uma lista vazia de filmes, não sei pra que kkkkkk
    private static readonly List<Filmes>_filmes = new ();

    private readonly DbConnection _dbConnection;

    private static long _id = 1;
    //construtor
    public FilmeRepository(DbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    //adiciona um filme na lista de filmes (linha 6)
    public async Task Adicionar(Filmes filmes)
    {
        filmes.CriarId(_id++);
        //vai sempre ser assim pra criar uma conexao com o banco de dados
        using ( var dbConnection = _dbConnection.CreateConnection() )
        {
            //Sql de insert
            var SqlQuery = "INSERT INTO Filmes (Id, Titulo, GeneroId, Descricao, Duracao, Autor, Notas) VALUES (@Id, @Titulo, @GeneroId, @Descricao, @Duracao, @Autor, @Notas)";
            //executa enviando o Sql e filmes
            await dbConnection.ExecuteAsync(SqlQuery,filmes); 
        }
    }


    public async Task<List<Filmes>> Listar()
    {
        using (var dbConnection = _dbConnection.CreateConnection() )
        {
            var SqlQuery = "SELECT * FROM Filmes";
            //tem que ter retorno pq é pesquisa, ToList para listar todos
            return (await dbConnection.QueryAsync<Filmes> (SqlQuery)).ToList();
        }
    }

    public async Task<Filmes> ListarPorId(long id)
    {
        using (var dbConnection = _dbConnection.CreateConnection() )
        {
            var SqlQuery = "SELECT * FROM Filmes WHERE Id = @Id";
            //new{Id = id} para conectar os dois Id
            return await dbConnection.QueryFirstOrDefaultAsync<Filmes>(SqlQuery, new{Id = id});
        }
    }

    public async Task Atualizar(Filmes filmes)
    {
        using(var dbConnection = _dbConnection.CreateConnection())
        {
           var SqlQuery = "UPDATE Filmes SET Titulo = @Titulo, GeneroId = @GeneroId, Descricao = @Descricao, Duracao = @Duracao, Autor = @Autor, Notas = @Notas WHERE Id = @Id";
            //executa enviando o Sql e filmes
            await dbConnection.ExecuteAsync(SqlQuery,filmes);
        }
    }

    public async Task Deletar(long id)
    {
        using(var dbConnection = _dbConnection.CreateConnection())
        {
            var SqlQuery = "DELETE FROM Filmes WHERE Id = @Id";
            await dbConnection.ExecuteAsync(SqlQuery, new {Id = id});
        }

    }

    public async Task<List<Filmes>> ListarFilmesPeloGenero (long generoid)
    {
        using (var dbConnection = _dbConnection.CreateConnection())
        {
            var SqlQuery = "SELECT * FROM Filmes WHERE GeneroId = @GeneroId";
            //tem que ter retorono pq é pesquisa, queryasync pq tá pesquisando todos (que se encquadram na pesquisa do genero)
            //retorna uma lista de filmes, por isso o ToList no final
            return (await dbConnection.QueryAsync<Filmes>(SqlQuery, new {GeneroId = generoid})).ToList();
        }
    }


}