using GerenciarEstoque.Dominio.Entidades;

namespace GerenciarEstoque.Aplicacao;

public interface IProdutoAplicacao
{
    Task Criar(Produto produto);
    Task Atualizar(int produtoId, string nome, decimal preco, int quantidade);
    Task Remover(int id);
    Task<List<Produto>> Listar(int id, bool ativo);
}