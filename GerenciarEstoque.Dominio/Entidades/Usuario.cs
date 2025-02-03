namespace GerenciarEstoque.Dominio.Entidades;

public class Usuario
{
    #region Atributos

    private int _id;
    private string _nome;
    private string _email;
    private DateTime? _dataNascimento;
    private string _senha;
    private bool _ativo;
    private List<Categoria> _categorias;
    private byte[] _fotoPerfil;

    #endregion

    #region Propriedades

    public int Id
    {
        get { return _id; }
    }

    public string Nome
    {
        get { return _nome; }
        set { _nome = value; }
    }

    public string Email
    {
        get { return _email; }
        set { _email = value; }
    }

    public DateTime? DataNascimento
    {
        get { return _dataNascimento; }
        set { _dataNascimento = value; }
    }

    public string Senha
    {
        get { return _senha; }
    }

    public bool Ativo
    {
        get { return _ativo; }
        set { _ativo = value; }
    }

    public List<Categoria> Categorias
    {
        get { return _categorias; }
        set { _categorias = value; }
    }

    public byte[] FotoPerfil
    {
        get { return _fotoPerfil; }
        set { _fotoPerfil = value; }
    }

    #endregion

    #region Construtores

    public Usuario()
    {
        _categorias = new List<Categoria>();
    }

    public Usuario(string nome, string email, DateTime data, string senha)
    {
        _nome = nome;
        _email = email;
        AlterarSenha(senha);
        _dataNascimento = data;
        _categorias = new List<Categoria>();
        _ativo = true;
    }

    #endregion

    #region Métodos

    public void AlterarSenha(string senha)
    {
        string senhaHash = BCrypt.Net.BCrypt.HashPassword(senha);
        _senha = senhaHash;
    }

    public bool VerificarSenha(string senha)
    {
        return BCrypt.Net.BCrypt.Verify(senha, _senha);
    }

    #endregion
}