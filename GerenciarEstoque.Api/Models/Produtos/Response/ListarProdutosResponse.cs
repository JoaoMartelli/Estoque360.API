namespace GerenciarEstoque.Api.Models.Produtos.Response;

public class ListarProdutosResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Quantidade { get; set; }
}