using GerenciarEstoque.Dominio.Entidades;

public interface ICategoriaRepositorio
{
    Task Salvar(Categoria categoria);
    Task Atualizar(Categoria categoria);
    Task Remover(Categoria categoria);
    Task<Categoria> ObterPorId(int id);
    Task<List<Categoria>> Listar(int id);
    Task<Categoria> ObterPorNome(string nome);
}