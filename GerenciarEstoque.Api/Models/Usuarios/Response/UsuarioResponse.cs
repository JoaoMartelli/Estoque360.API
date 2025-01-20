namespace GerenciarEstoque.Api.Models.Usuarios.Response;

class UsuarioResponse
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public DateOnly DataNascimento { get; set; }
}