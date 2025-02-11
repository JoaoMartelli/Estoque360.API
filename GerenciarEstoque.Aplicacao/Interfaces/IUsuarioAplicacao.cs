using System.Net.Mail;
using GerenciarEstoque.Dominio.Entidades;

namespace GerenciarEstoque.Aplicacao;

public interface IUsuarioAplicacao
{
    Task Criar(Usuario usuario);
    Task<int> CriarGoogle(string nome, string email);
    Task AtualizarSenha(int id, string senhaAntiga, string senhaNova);
    Task Remover(int id);
    Task<int> ValidarLogin(string email, string senha);
    Task<Usuario> ObterUsuario(int id);
    Task<Usuario> ObterUsuarioPorEmail(string email);
    Task AtualizarInformacoes(int id, string nome, DateTime? dataNascimento);
    Task AtualizarFoto(int usuarioId, byte[] novaFoto);
    Task RemoverFoto(int usuarioId);
}