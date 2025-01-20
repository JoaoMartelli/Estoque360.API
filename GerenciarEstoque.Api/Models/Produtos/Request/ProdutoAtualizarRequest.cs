namespace GerenciarEstoque.Api.Models.Produtos.Request;

public class ProdutoAtualizarRequest
{
    public int ProdutoId { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}