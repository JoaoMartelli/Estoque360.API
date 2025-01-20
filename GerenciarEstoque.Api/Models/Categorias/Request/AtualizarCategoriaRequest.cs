namespace GerenciarEstoque.Api.Models.Categorias.Request;

public class AtualizarCategoriaRequest
{
    public int CategoriaId { get; set; }
    public string NomeNovo { get; set; }
}