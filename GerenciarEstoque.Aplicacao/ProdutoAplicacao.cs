using GerenciarEstoque.Dominio.Entidades;

namespace GerenciarEstoque.Aplicacao;

public class ProdutoAplicacao : IProdutoAplicacao
{
    private readonly IProdutoRepositorio _produtoRepositorio;

    public ProdutoAplicacao(IProdutoRepositorio produtoRepositorio)
    {
        _produtoRepositorio = produtoRepositorio;
    }

    public async Task Atualizar(int produtoId, string nome, decimal preco, int quantidade)
    {
        Produto produto = await _produtoRepositorio.ObterPorId(produtoId);

        if (produto == null)
        {
            throw new Exception("O produto não foi encontrado.");
        }

        produto.Nome = nome;
        produto.Preco = preco;
        produto.Quantidade = quantidade;

        VerificarProduto(produto);

        await _produtoRepositorio.Atualizar(produto);
    }

    public async Task Criar(Produto produto)
    {
        VerificarProduto(produto);

        await _produtoRepositorio.Salvar(produto);
    }

    public async Task<List<Produto>> Listar(int id, bool ativo)
    {
        var lista = await _produtoRepositorio.Listar(id);

        var listaProdutos = lista.Where(x => x.Ativo == ativo).ToList();

        return listaProdutos;
    }

    public async Task<List<Produto>> ObterProdutosPorUsuarioId(int usuarioId)
    {
        return await _produtoRepositorio.ObterProdutosPorUsuarioId(usuarioId);
    }

    public async Task Remover(int id)
    {
        var produto = await _produtoRepositorio.ObterPorId(id);

        if (produto == null)
        {
            throw new Exception("O produto não foi encontrado.");
        }

        produto.Ativo = false;

        await _produtoRepositorio.Atualizar(produto);
    }

    public void VerificarProduto(Produto produto)
    {
        if (produto == null)
        {
            throw new Exception("O produto não pode ser vazio.");
        }

        if (string.IsNullOrWhiteSpace(produto.Nome))
        {
            throw new Exception("O nome do produto não pode ser vazio.");
        }

        if (produto.Preco <= 0 )
        {
            throw new Exception("O preço do produto não pode ser zero ou negativo.");
        }

        if (produto.Quantidade < 0)
        {
            throw new Exception("A quantidade do produto não pode ser negativa.");
        }

        if (produto.CategoriaId <= 0)
        {
            throw new Exception("O usuário do produto não pode ser vazio.");
        }
    }
}