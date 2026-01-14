// tem que ter em todas as controllers essa linha
using Microsoft.AspNetCore.Mvc;
using CatalogoFilme.Service;
using CatalogoFilme.Domain.Entity;
using System.ComponentModel;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;


//using System.Runtime.Versioning;

namespace CatalogoFilme.Controllers;
[ApiController]
[Route ("/filmes")]

public class FilmesController : ControllerBase
{
    private readonly IFilmeService service;
    public FilmesController (IFilmeService filmeService)
    {
        service = filmeService;
    }

    //No java era o @PostMapping
    [HttpPost]

    //No java o FromBady era o RequestBody
    //Tarefa assincrona que espera um resultado de ação onde executamos o método adicionar filmes da service
    public async Task<IActionResult> Adicionar([FromBody] Filmes filmes)
    {
        await service.AdicionarFilme(filmes);
        return Ok ("Filme " + filmes.Titulo + " criado com sucesso");
    }

    [HttpGet]
    //buscando na service o ListarFilmes
    public async Task<IActionResult> ListarTodosFilmes()
    {
        var filmes = await service.ListarFilmes();
        return Ok (filmes);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> ListarPorId(long Id)
    {
        var filmes = await service.ListarFilmePorId(Id);
        if (filmes == null)
        {
            return NotFound();
        }
        return Ok (filmes);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Atualizar(long Id, [FromBody] Filmes filmeAtualizado)
    {
        var filmeExistente = await service.ListarFilmePorId(Id);
        if (filmeExistente == null)
        {
            return NotFound();
        }
        //titulo 1 sendo atualizado para titulo 2
        filmeExistente.Titulo = filmeAtualizado.Titulo;
        filmeExistente.GeneroId = filmeAtualizado.GeneroId;
        filmeExistente.Descricao = filmeAtualizado.Descricao;
        filmeExistente.Duracao = filmeAtualizado.Duracao;
        filmeExistente.Autor = filmeAtualizado.Autor;
        filmeExistente.Notas = filmeAtualizado.Notas;

        //agora o filme existente é titulo 2
        await service.AtualizarFilme(filmeExistente);
        return NoContent();
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Deletar(long Id)
    {
        await service.DeletarFilme(Id);
        return Ok("Filme deletado com sucesso");
    }


    //endpoint para chamar por gênero
    [HttpGet("porgenero/{generoid}")]

    public async Task<IActionResult> ListarPorGenero (long generoid)
    {
        var filmes = await service.ListarFilmesPorGenero(generoid);
        return Ok(filmes);
    }


}