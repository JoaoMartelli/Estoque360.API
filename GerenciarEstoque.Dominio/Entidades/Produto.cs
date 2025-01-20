namespace GerenciarEstoque.Dominio.Entidades;

public class Produto
{
    #region Atributos

    private int _id;
    private string _nome;
    private decimal _preco;
    private int _quantidade;
    private int _categoriaId;
    private bool _ativo;
    private Categoria _categoria;

    #endregion

    #region Propriedades

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public decimal Preco
    {
        get { return _preco; }
        set { _preco = value; }
    }

    public int Quantidade
    {
        get { return _quantidade; }
        set { _quantidade = value; }
    }

    public int CategoriaId
    {
        get { return _categoriaId; }
        set { _categoriaId = value; }
    }

    public Categoria Categoria
    {
        get { return _categoria; }
        set { _categoria = value; }
    }
    
    public bool Ativo
    {
        get { return _ativo; }
        set { _ativo = value; }
    }

    #endregion

    #region Construtores

    public Produto()
    {

    }

    public Produto(string nome, decimal preco, int quantidade, int categoriaId)
    {
        _nome = nome;
        _preco = preco;
        _quantidade = quantidade;
        _categoriaId = categoriaId;
        _ativo = true;
    }

    #endregion

    #region Métodos

    public void AdicionarQuantidade(int quantidade)
    {
        _quantidade += quantidade;
    }

    public void RemoverQuantidade(int quantidade)
    {
        _quantidade -= quantidade;
    }

    public void AlterarNome(string nome)
    {
        _nome = nome;
    }

    public void AlterarPreco(decimal preco)
    {
        _preco = preco;
    }

    #endregion
}