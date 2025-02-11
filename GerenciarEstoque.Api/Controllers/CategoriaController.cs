using GerenciarEstoque.Api.Models.Categorias.Request;
using GerenciarEstoque.Api.Models.Categorias.Response;
using GerenciarEstoque.Aplicacao;
using GerenciarEstoque.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace GerenciarEstoque.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaController : ControllerBase
{
    private readonly ICategoriaAplicacao _categoriaAplicacao;

    public CategoriaController(ICategoriaAplicacao categoriaAplicacao)
    {
        _categoriaAplicacao = categoriaAplicacao;
    }

    [HttpPost]
    [Route("Adicionar")]
    public async Task<IActionResult> Adicionar([FromBody] AdicionarCategoriaRequest categoriaRequest)
    {
        try
        {
            Categoria categoria = new Categoria(categoriaRequest.Nome, categoriaRequest.UsuarioId);

            await _categoriaAplicacao.Criar(categoria);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("ObterCategorias/{usuarioId}")]
    public async Task<IActionResult> Listar([FromRoute] int usuarioId, [FromQuery] bool ativo)
    {
        try
        {
            var lista = await _categoriaAplicacao.Listar(usuarioId, ativo); 

            List<ListarCategoriasResponse> listaCategorias = lista.Select(x => new ListarCategoriasResponse()
            {
                Id = x.Id,
                Nome = x.Nome
            }).ToList();

            return Ok(listaCategorias);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("Deletar/{categoriaId}")]
    public async Task<IActionResult> Remover([FromRoute] int categoriaId)
    {
        try
        {
            await _categoriaAplicacao.Remover(categoriaId);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("Atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] AtualizarCategoriaRequest categoriaRequest)
    {
        try
        {
            await _categoriaAplicacao.Atualizar(categoriaRequest.CategoriaId, categoriaRequest.NomeNovo);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);  
        }
    }

    [HttpGet]
    [Route("ObterProdutosPorCategoriaDoUsuario/{usuarioId}")]
    public async Task<IActionResult> Atualizar([FromRoute] int usuarioId)
    {
        try
        {
            var lista = await _categoriaAplicacao.ProdutosPorCategoriaDoUsuario(usuarioId);

            return Ok(lista);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);  
        }
    }
}