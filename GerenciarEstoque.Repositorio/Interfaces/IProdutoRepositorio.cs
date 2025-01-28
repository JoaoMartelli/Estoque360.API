using GerenciarEstoque.Dominio.Entidades;

public interface IProdutoRepositorio
{
    Task Salvar(Produto produto);
    Task Atualizar(Produto produto);
    Task Remover(Produto produto);
    Task<Produto> ObterPorId(int id);
    Task<List<Produto>> Listar(int id);
    Task<Produto> ObterPorNome(string nome);
    Task<List<Produto>> ObterProdutosPorUsuarioId(int usuarioId);
}