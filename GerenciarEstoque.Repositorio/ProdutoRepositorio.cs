using GerenciarEstoque.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GerenciarEstoque.Repositorio;

public class ProdutoRepositorio : BaseRepositorio, IProdutoRepositorio
{
    public ProdutoRepositorio(GerenciarEstoqueContexto contexto) : base(contexto)
    {
    }

    public async Task Atualizar(Produto produto)
    {
        _contexto.Produtos.Update(produto);
        await _contexto.SaveChangesAsync();
    }

    public async Task<List<Produto>> Listar(int id)
    {
        return await _contexto.Produtos.Where(x => x.CategoriaId == id).ToListAsync();
    }

    public async Task<Produto> ObterPorId(int id)
    {
        return await _contexto.Produtos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Produto> ObterPorNome(string nome)
    {
        return await _contexto.Produtos.FirstOrDefaultAsync(x => x.Nome == nome);
    }

    public async Task Remover(Produto produto)
    {
        _contexto.Produtos.Remove(produto);
        await _contexto.SaveChangesAsync();
    }

    public async Task Salvar(Produto produto)
    {
        _contexto.Produtos.Add(produto);
        await _contexto.SaveChangesAsync();
    }

    public async Task<List<Produto>> ObterProdutosPorUsuarioId(int usuarioId)
    {
        var produtosAtivos = await _contexto.Categorias
            .Where(c => c.UsuarioId == usuarioId)
            .SelectMany(c => c.Produtos.Where(p => p.Ativo == true))
            .ToListAsync();

        return produtosAtivos;
    }

}
