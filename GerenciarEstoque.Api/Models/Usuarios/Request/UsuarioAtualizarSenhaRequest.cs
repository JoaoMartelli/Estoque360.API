namespace GerenciarEstoque.Api.Models.Usuarios.Request;

public class UsuarioAtualizarSenhaRequest
{
    public int Id { get; set; }
    public string SenhaAntiga { get; set; }
    public string SenhaNova { get; set; }
}