namespace GerenciarEstoque.Api.Models.Usuarios.Request;

public class UsuarioAtualizarRequest
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; }
    public DateTime? DataNascimento { get; set; }
}