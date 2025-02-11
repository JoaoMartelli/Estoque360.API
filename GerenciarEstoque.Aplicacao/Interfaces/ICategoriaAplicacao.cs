using GerenciarEstoque.Dominio.Entidades;

namespace GerenciarEstoque.Aplicacao;

public interface ICategoriaAplicacao
{
    Task Criar(Categoria categoria);
    Task Atualizar(int categoriaId, string nomeNovo);
    Task Remover(int id);
    Task<List<Categoria>> Listar(int id, bool ativo);
    Task<IEnumerable<ProdutosPorCategoriaDoUsuario>> ProdutosPorCategoriaDoUsuario(int usuarioId);
}