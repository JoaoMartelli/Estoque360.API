using GerenciarEstoque.Api.Models.Produtos.Request;
using GerenciarEstoque.Api.Models.Produtos.Response;
using GerenciarEstoque.Aplicacao;
using GerenciarEstoque.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace GerenciarEstoque.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoAplicacao _produtoAplicacao;

    public ProdutoController(IProdutoAplicacao produtoAplicacao)
    {
        _produtoAplicacao = produtoAplicacao;
    }

    [HttpPost]
    [Route("Adicionar")]
    public async Task<IActionResult> Adicionar([FromBody] ProdutoRequest produtoRequest)
    {
        try
        {
            Produto produto = new Produto(produtoRequest.Nome, produtoRequest.Preco, produtoRequest.Quantidade, produtoRequest.CategoriaId);

            await _produtoAplicacao.Criar(produto);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("Atualizar")]
    public async Task<IActionResult> Atualizar([FromBody] ProdutoAtualizarRequest produtoRequest)
    {
        try
        {
            await _produtoAplicacao.Atualizar(produtoRequest.ProdutoId, produtoRequest.Nome, produtoRequest.Preco, produtoRequest.Quantidade);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("Remover/{id}")]
    public async Task<IActionResult> Remover([FromRoute] int id)
    {
        try
        {
            await _produtoAplicacao.Remover(id);

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("Listar/{id}")]
    public async Task<IActionResult> Listar([FromRoute] int id, [FromQuery] bool ativo)
    {
        try
        {
            var listaProdutos = await _produtoAplicacao.Listar(id, ativo);

            List<ListarProdutosResponse> listaFinal = listaProdutos.Select(x => new ListarProdutosResponse()
            {
                Id = x.Id,
                Nome = x.Nome,
                Quantidade = x.Quantidade,
                Preco = x.Preco
            }).ToList();

            return Ok(listaFinal);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("ObterPorUsuarioId/{usuarioId}")]
    public async Task<IActionResult> Listar([FromRoute] int usuarioId)
    {
        try
        {
            var listaProdutos = await _produtoAplicacao.ObterProdutosPorUsuarioId(usuarioId);

            List<ListarProdutosResponse> listaFinal = listaProdutos.Select(x => new ListarProdutosResponse()
            {
                Id = x.Id,
                Nome = x.Nome,
                Quantidade = x.Quantidade,
                Preco = x.Preco
            }).ToList();

            return Ok(listaFinal);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}