namespace GerenciarEstoque.Api.Models.Produtos.Request;

public class ProdutoRequest
{
    public int CategoriaId { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}