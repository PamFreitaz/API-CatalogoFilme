namespace CatalogoFilme.Domain.Entity;

public class Genero
{
    public long Id {get; private set; }
    public string Nome {get; set; }
    public string Descricao {get; set; }

    public List<Filmes> listarFilmes {get; set; }

    public Genero()
    {
        
    }

    public Genero(string nome, string descricao)
    {
        this.Nome = nome;
        this.Descricao = descricao;
        //não recebo lista de filmes, mas cria uma nova, por isso não tem no construtor
        this.listarFilmes = new List<Filmes>();
    }
}