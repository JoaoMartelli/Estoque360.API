using GerenciarEstoque.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GerenciarEstoque.Repositorio;

public class CategoriaRepositorio : BaseRepositorio, ICategoriaRepositorio
{
    public CategoriaRepositorio(GerenciarEstoqueContexto contexto) : base(contexto)
    {
    }

    public async Task Atualizar(Categoria categoria)
    {
        _contexto.Categorias.Update(categoria);
        await _contexto.SaveChangesAsync();
    }

    public async Task<List<Categoria>> Listar(int id)
    {
        return await _contexto.Categorias.Where(x => x.UsuarioId == id).ToListAsync();
    }

    public async Task<Categoria> ObterPorId(int id)
    {
        return await _contexto.Categorias.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Categoria> ObterPorNome(string nome)
    {
        return await _contexto.Categorias.FirstOrDefaultAsync(x => x.Nome == nome);
    }

    public async Task Remover(Categoria categoria)
    {
        _contexto.Categorias.Remove(categoria);
        await _contexto.SaveChangesAsync();
    }

    public async Task Salvar(Categoria categoria)
    {
        _contexto.Categorias.Add(categoria);
        await _contexto.SaveChangesAsync();
    }
}