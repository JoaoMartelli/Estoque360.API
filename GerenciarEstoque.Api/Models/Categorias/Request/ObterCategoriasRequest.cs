namespace GerenciarEstoque.Api.Models.Categorias.Request;

public class ObterCategoriasRequest
{
    public int UsuarioId { get; set; }
    public bool Ativo { get; set; }
}