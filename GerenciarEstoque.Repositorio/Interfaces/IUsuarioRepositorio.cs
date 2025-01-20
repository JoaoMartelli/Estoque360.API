using GerenciarEstoque.Dominio.Entidades;

public interface IUsuarioRepositorio
{
    Task Salvar(Usuario usuario);
    Task Atualizar(Usuario usuario);
    Task Remover(Usuario usuario);
    Task<Usuario> ObterPorId(int id);
    Task<Usuario> ObterPorEmail(string email);
    Task<List<Usuario>> Listar();
}