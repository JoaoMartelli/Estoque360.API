using GerenciarEstoque.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GerenciarEstoque.Repositorio;

public class UsuarioRepositorio : BaseRepositorio, IUsuarioRepositorio
{
    public UsuarioRepositorio(GerenciarEstoqueContexto contexto) : base(contexto)
    {
    }

    public async Task Atualizar(Usuario usuario)
    {
        _contexto.Usuarios.Update(usuario);
        await _contexto.SaveChangesAsync();
    }

    public async Task<List<Usuario>> Listar()
    {
        return await _contexto.Usuarios.ToListAsync();
    }

    public async Task<Usuario> ObterPorEmail(string email)
    {
        return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<Usuario> ObterPorId(int id)
    {
        return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task Remover(Usuario usuario)
    {
        _contexto.Usuarios.Remove(usuario);
        await _contexto.SaveChangesAsync();
    }

    public async Task Salvar(Usuario usuario)
    {
        _contexto.Usuarios.Add(usuario);
        await _contexto.SaveChangesAsync();
    }
}