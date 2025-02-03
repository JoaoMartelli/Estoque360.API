using GerenciarEstoque.Dominio.Entidades;

namespace GerenciarEstoque.Aplicacao;

public class CategoriaAplicacao : ICategoriaAplicacao
{
    private readonly ICategoriaRepositorio _categoriaRepositorio;

    public CategoriaAplicacao(ICategoriaRepositorio categoriaRepositorio)
    {
        _categoriaRepositorio = categoriaRepositorio;
    }

    public async Task Atualizar(int categoriaId, string nomeNovo)
    {
        Categoria categoria = await _categoriaRepositorio.ObterPorId(categoriaId);

        if (categoria == null)
        {
            throw new Exception("Categoria não encontrada.");
        }

        categoria.Nome = nomeNovo;

        VerificandoInformacao(categoria);

        await _categoriaRepositorio.Atualizar(categoria);
    }

    private static void VerificandoInformacao(Categoria categoria)
    {
        if (categoria == null)
        {
            throw new Exception("Categoria não pode ser nulo.");
        }

        if (string.IsNullOrWhiteSpace(categoria.Nome))
        {
            throw new Exception("O nome da categoria não pode ser vazio.");
        }

        if (categoria.UsuarioId <= 0)
        {
            throw new Exception("O usuário do produto não pode ser vazio.");
        }
    }

    public async Task Criar(Categoria categoria)
    {
        VerificandoInformacao(categoria);

        await _categoriaRepositorio.Salvar(categoria);
    }

    public async Task<List<Categoria>> Listar(int id, bool ativo)
    {
        var lista = await _categoriaRepositorio.Listar(id);

        var novaLista = lista.Where(x => x.Ativo == ativo).ToList();

        return novaLista;
    }

    public async Task Remover(int id)
    {
        var categoria = await _categoriaRepositorio.ObterPorId(id);
        
        if (categoria == null)
        {
            throw new Exception("A categoria não existe.");
        }

        categoria.Ativo = false;

        await _categoriaRepositorio.Atualizar(categoria);
    }
}