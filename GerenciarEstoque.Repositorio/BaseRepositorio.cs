public abstract class BaseRepositorio
{
    protected readonly GerenciarEstoqueContexto _contexto;

    protected BaseRepositorio(GerenciarEstoqueContexto contexto)
    {
        _contexto = contexto;
    }
}