namespace GerenciarEstoque.Dominio.Entidades;

public class Categoria
{
    #region Atributos

    private int _id;
    private string _nome;
    private int _usuarioId;
    private bool _ativo;
    private Usuario _usuario;
    private List<Produto> _produtos;

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

    public bool Ativo
    {
        get { return _ativo; }
        set { _ativo = value; }
    }

    public List<Produto> Produtos
    {
        get { return _produtos; }
        set { _produtos = value; }
    }

    public int UsuarioId
    {
        get { return _usuarioId; }
        set { _usuarioId = value; }
    }

    public Usuario Usuario
    {
        get { return _usuario; }
        set { _usuario = value; }
    }

    #endregion

    #region Construtores

    public Categoria()
    {
        _produtos = new List<Produto>();
    }

    public Categoria(string nome, int usuarioId)
    {
        _produtos = new List<Produto>();
        _nome = nome;
        _usuarioId = usuarioId;
        _ativo = true;
    }

    #endregion
}