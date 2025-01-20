namespace GerenciarEstoque.Api.Models.Categorias.Request;

public class AdicionarCategoriaRequest
{
    public string Nome { get; set; }
    public int UsuarioId { get; set; }
}