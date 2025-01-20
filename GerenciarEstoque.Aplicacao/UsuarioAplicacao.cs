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

        if (string.IsNullOrEmpty(senhaNova))
        {
            throw new Exception("Senha do usuário não pode ser vazia.");
        }

        if(usuarioAtualizar.VerificarSenha(senhaAntiga)){
            throw new Exception("Senha antiga inválida.");
        }

        usuarioAtualizar.AlterarSenha(senhaNova);

        await _usuarioRepositorio.Atualizar(usuarioAtualizar);
    }

    public async Task Criar(Usuario usuario)
    {
        if (usuario == null)
        {
            throw new Exception("Usuario não pode ser vazio.");
        }

        if (string.IsNullOrEmpty(usuario.Nome))
        {
            throw new Exception("Nome do usuário não pode ser vazio.");
        }

        if (string.IsNullOrEmpty(usuario.Senha))
        {
            throw new Exception("Senha do usuário não pode ser vazia.");
        }

        if (await _usuarioRepositorio.ObterPorEmail(usuario.Email) != null)
        {
            throw new Exception("Usuário já existe.");
        }

        if (DateOnly.FromDateTime(DateTime.Now).AddYears(-18) < usuario.DataNascimento)
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
            throw new Exception("Usuario não encontrado");
        }

        if (!usuario.VerificarSenha(senha))
        {
            throw new Exception("Senha incorreta");
        }

        return usuario.Id;
    }
}