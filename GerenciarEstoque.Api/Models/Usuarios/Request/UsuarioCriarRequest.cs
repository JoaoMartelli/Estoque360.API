namespace GerenciarEstoque.Api.Models.Usuarios.Request;

public class UsuarioCriarRequest
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Senha { get; set; }
}