namespace CatalogoFilme.Domain.Entity;

public class Filmes
{
    // private set porque não pode ser alterado
    public long Id { get; private set; }
    public string Titulo { get; set; }
    public long GeneroId { get; set; }
    public string Descricao { get; set; }
    public int Duracao { get; set; }
    public string Autor { get; set; }

    //pra deixar opcional as notas, usar o ?
    public string? Notas { get; set; }

    public Filmes()
    {
        
    }

    public Filmes (string titulo, long generoid, string descricao, int duracao, string autor, string? notas)
    {
        Titulo = titulo;
        GeneroId = generoid;
        Descricao = descricao;
        Duracao = duracao;
        Autor = autor;
        Notas = notas;
    }

    internal void CriarId(long id)
    {
        //setando (criando) o Id da minha entity com o _id do FilmeRepository
        this.Id = id;
    }

}

