using GerenciarEstoque.Dominio.Entidades;

namespace GerenciarEstoque.Aplicacao;

public class UsuarioAplicacao : IUsuarioAplicacao
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public async Task AtualizarSenha(int id, string senhaAntiga, string senhaNova)
    {
        var usuarioAtualizar = await _usuarioRepositorio.ObterPorId(id);

        if (string.IsNullOrWhiteSpace(senhaNova))
        {
            throw new Exception("Senha do usuário não pode ser vazia.");
        }

        if (!usuarioAtualizar.VerificarSenha(senhaAntiga))
        {
            throw new Exception("Senha antiga inválida.");
        }

        usuarioAtualizar.AlterarSenha(senhaNova);

        await _usuarioRepositorio.Atualizar(usuarioAtualizar);
    }

    public async Task AtualizarInformacoes(int id, string nome, DateTime? dataNascimento)
    {
        var usuario = await _usuarioRepositorio.ObterPorId(id);

        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        if (string.IsNullOrWhiteSpace(nome))
        {
            throw new Exception("Nome não pode ser vazio.");
        }

        if (DateTime.Now.AddYears(-18) < dataNascimento)
        {
            throw new Exception("Usuário deve ter pelo menos 18 anos.");
        }

        usuario.Nome = nome;
        usuario.DataNascimento = dataNascimento;

        await _usuarioRepositorio.Atualizar(usuario);
    }

    public async Task RemoverFoto(int usuarioId)
    {
        var usuario = await _usuarioRepositorio.ObterPorId(usuarioId);

        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        usuario.FotoPerfil = null;

        await _usuarioRepositorio.Atualizar(usuario);
    }

    public async Task AtualizarFoto(int usuarioId, byte[] novaFoto)
    {
        var usuario = await _usuarioRepositorio.ObterPorId(usuarioId);

        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        usuario.FotoPerfil = novaFoto;

        await _usuarioRepositorio.Atualizar(usuario);
    }

    public async Task Criar(Usuario usuario)
    {
        if (usuario == null)
        {
            throw new Exception("Usuario não pode ser vazio.");
        }

        if (string.IsNullOrWhiteSpace(usuario.Nome))
        {
            throw new Exception("Nome do usuário não pode ser vazio.");
        }

        if (string.IsNullOrWhiteSpace(usuario.Senha))
        {
            throw new Exception("Senha do usuário não pode ser vazia.");
        }

        if (await _usuarioRepositorio.ObterPorEmail(usuario.Email) != null)
        {
            throw new Exception("Usuário já existe.");
        }

        if (DateTime.Now.AddYears(-18) < usuario.DataNascimento)
        {
            throw new Exception("Usuário deve ter pelo menos 18 anos.");
        }

        await _usuarioRepositorio.Salvar(usuario);
    }

    public async Task<Usuario> ObterUsuario(int id)
    {
        return await _usuarioRepositorio.ObterPorId(id);
    }

    public async Task Remover(int id)
    {
        var usuario = await _usuarioRepositorio.ObterPorId(id);

        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        usuario.Ativo = false;

        await _usuarioRepositorio.Atualizar(usuario);
    }

    public async Task<int> ValidarLogin(string email, string senha)
    {
        var usuario = await _usuarioRepositorio.ObterPorEmail(email);

        if (usuario == null)
        {
            throw new Exception("Email ou senha inválido!");
        }

        if (!usuario.VerificarSenha(senha))
        {
            throw new Exception("Email ou senha inválido!");
        }

        return usuario.Id;
    }

    public async Task<Usuario> ObterUsuarioPorEmail(string email)
    {
        return await _usuarioRepositorio.ObterPorEmail(email);
    }

    public async Task<int> CriarGoogle(string nome, string email)
    {
        var usuario = new Usuario()
        {
            Nome = nome,
            Email = email,
            Ativo = true
        };

        await _usuarioRepositorio.Salvar(usuario);

        var obterUsuario = await _usuarioRepositorio.ObterPorEmail(email);

        return obterUsuario.Id;
    }
}